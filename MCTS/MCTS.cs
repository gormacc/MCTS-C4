using System;
using System.Collections.Generic;
using MCTS.Data;
using MCTS.Serialization;

namespace MCTS
{
    public class Mcts
    {
        private Node _rootNode; // korzeń całego drzewa

        private Node _currNode; // obecny stan gry

        private readonly int _miliSecondsToProcess; // czas na rozszerzanie drzewa

        private readonly double _explorationFactor; // współczynnik eksploracji

        private long _idCounter = 1; // zmienna przypisująca id węzła

        public Mcts(int miliSeconds, double explorationFactor)
        {
            _miliSecondsToProcess = miliSeconds;
            _explorationFactor = explorationFactor;
            _rootNode = new Node(new Board(), null, _idCounter++);
            _currNode = _rootNode;
        }

        public void BackToRoot()
        {
            _currNode = _rootNode;
        }

        //zapis całego drzewa do xml
        public void SaveToXml(string filePath)
        {
            var nodes = SaveRec(_rootNode);
            XmlDataStore.Save(nodes, filePath);
        }

        private List<NodeDto> SaveRec(Node node)
        {
            var list = new List<NodeDto>();
            if(node == null) return list;
            list.Add(new NodeDto(node));
            foreach (var child in node.Childs)
            {
                list.AddRange(SaveRec(child));
            }

            return list;
        }

        // wczytanie całego drzewa z xml
        public void LoadFromXml(string filePath)
        {
            var nodes = XmlDataStore.Load<List<NodeDto>>(filePath);
            if(nodes == null || nodes.Count == 0 ) return;

            _idCounter = nodes.Count + 1;

            var stack = new Stack<Tuple<Node, NodeDto>>();
            foreach (var n in nodes)
            {
                if (n.Id == 1)
                {
                    var node = n.ExtractDto(null);
                    _rootNode = node;
                    _currNode = _rootNode;
                    stack.Push(new Tuple<Node, NodeDto>(node,n));
                    break;
                }
            }

            while (stack.Count > 0)
            {
                var tuple = stack.Pop();

                for (var i = 0; i < tuple.Item2.Childs.Length; i++)
                {
                    var childrenId = tuple.Item2.Childs[i];
                    if (childrenId == 0)
                    {
                        tuple.Item1.Childs[i] = null;
                        continue;
                    }

                    foreach (var nodeDto in nodes)
                    {
                        if (nodeDto.Id == childrenId)
                        {
                            var child = nodeDto.ExtractDto(tuple.Item1);
                            tuple.Item1.Childs[i] = child;
                            stack.Push(new Tuple<Node, NodeDto>(child, nodeDto));
                            break;
                        }
                    }
                }

                nodes.Remove(tuple.Item2);
            }
        }

        // wykonywanie ruchu, przed wykonaniem następuje rozszerzenie drzewa
        public void MakeMove(int column)
        {
            Expand();

            // na wypadek wykonania nieprawidłowego ruchu
            if (_currNode.Childs[column] == null)
            {
                if (_currNode.AllChildsCreated)
                {
                    for (int i = 0; i < _currNode.Childs.Length; i++)
                    {
                        if (_currNode.Childs[i] != null)
                        {
                            column = i;
                            break;
                        }
                    }
                }
                else
                {
                    column = _currNode.CreateChild(_idCounter++);
                }
            }

            _currNode = _currNode.Childs[column];
        }

        // zwracanie najbardziej optymalnego ruchu
        public int GenerateMove()
        {
            return FindBestChildIndex(_currNode);
        }

        // zwracanie aktualnego stanu rozgrywki
        public Board GetBoard()
        {
            return _currNode.NodeBoard;
        }

        public bool IsEnd => _currNode != null && _currNode.NodeBoard.GameEnded;

        // Rozszerzanie drzewa - algorytm MCTS
        private void Expand()
        {
            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalMilliseconds < _miliSecondsToProcess)
            {
                var node = FindNodeToTest();
                var result = Simulate(node);
                UpdateStats(node, result);
            }
        }

        private Node FindNodeToTest()
        {
            var currN = _currNode;
            while (currN.AllChildsCreated && currN.NodeBoard.GameEnded == false)
            {
                var bestChildIndex = FindBestChildIndex(currN);
                currN = currN.Childs[bestChildIndex];
            }
            
            if (currN.AllChildsCreated == false && currN.NodeBoard.GameEnded == false)
            {
                var createdChildIndex = currN.CreateChild(_idCounter++);
                return currN.Childs[createdChildIndex];
            }
            else
            {
                return currN;
            }
        }

        private int FindBestChildIndex(Node node)
        {
            int bestChildIndex = 0;
            double bestChildValue = -1;

            for (int i = 0; i < node.Childs.Length; i++)
            {
                var child = node.Childs[i];
                if (child == null || node.NodeBoard.Fields[0,i] != FieldType.Empty) continue;

                var winRate = child.PlayerOneWin / child.Visited;
                if (node.NodeBoard.State == GameState.Player2Turn)
                {
                    winRate = 1 - winRate;
                }

                var ucb = winRate + _explorationFactor * Math.Sqrt(Math.Log(node.Visited, Math.E) / child.Visited);

                if (ucb >= bestChildValue)
                {
                    bestChildValue = ucb;
                    bestChildIndex = i;
                }
            }

            return bestChildIndex;
        }

        private GameState Simulate(Node node)
        {
            if (node.NodeBoard.GameEnded) return node.NodeBoard.State;

            var tmpBoard = new Board(node.NodeBoard);
            var rand = new Random(DateTime.Now.Millisecond);
            while (tmpBoard.GameEnded == false)
            {
                var availableColumns = tmpBoard.GetAvailableColumns();
                var index = rand.Next() % availableColumns.Count;
                tmpBoard = new Board(tmpBoard, availableColumns[index]);
            }

            return tmpBoard.State;
        }

        private void UpdateStats(Node currN, GameState state)
        {
            var node = currN;
            while (node != null)
            {
                if (state == GameState.Player1Win) node.PlayerOneWin += 1;
                if (state == GameState.Draw) node.PlayerOneWin += 0.5;
                node.Visited += 1;

                node = node.Parent;
            }
        }
    }
}
