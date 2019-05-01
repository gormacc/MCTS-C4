using System;

namespace MCTS
{
    public class Mcts
    {
        private Node _rootNode; // korzeń całego drzewa

        private Node _currNode; // obecny stan gry

        private int _secondsToProcess = 1;

        private double _explorationFactor = Math.Sqrt(2);

        public Mcts()
        {
            _rootNode = new Node(new Board(), null);
            _currNode = _rootNode;
        }

        // todo zapis i wczytanie całego drzewa

        public void MakeMove(int column)
        {
            Expand();
            var newBoard = new Board(_currNode.NodeBoard, column);
            _currNode = new Node(newBoard, _currNode);
        }

        public int GenerateMove()
        {
            return FindBestChildIndex(_currNode);
        }

        public Board GetBoard()
        {
            return _currNode.NodeBoard;
        }

        private void Expand()
        {
            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).Seconds < _secondsToProcess)
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
                var createdChildIndex = currN.CreateChild();
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
                if (child == null) continue;

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
