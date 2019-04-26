namespace MCTS
{
    public class Node
    {
        public int PlayerOneWin { get; set; }

        public int Visited { get; set; }

        public Node Parent { get; set; }

        public Node[] Childs { get; set; }

        public Board CurrBoard { get; set; }

        public Node(Board board, Node parent)
        {
            CurrBoard = board;
            Parent = parent;
        }
    }
}
