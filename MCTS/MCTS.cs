using System;

namespace MCTS
{
    public class Mcts
    {
        // konstruktor

        private Node _rootNode; // korzeń całego drzewa

        private Node _currNode; // obecny stan gry

        private int _secondsToProcess = 2;

        private double _explorationFactor = Math.Sqrt(2);

        public void MakeMove(int column)
        {
            // todo
        }

        public int GenerateMove()
        {
            return 0; //todo
        }

        public Board GetBoard()
        {
            return _currNode.NodeBoard;
        }

        private void Search()
        {
            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).Seconds < _secondsToProcess)
            {
                
            }
        }

        private Node FindNodeToTest()
        {
            var currN = _currNode;
            while (currN.AllChildsCreated == false || currN.NodeBoard.State == GameState.EndGame)
            {
                var bestChildIndex = FindBestChildIndex(currN);
                currN = currN.Childs[bestChildIndex];
            }

            

            if (currN.AllChildsCreated == false)
            {
                var createdChildIndex = currN.CreateChild();
                return currN.Childs[createdChildIndex];
                // todo tu skończyłem
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
    }
}
