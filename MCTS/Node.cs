namespace MCTS
{
    public class Node
    {
        public double PlayerOneWin { get; set; }

        public double Visited { get; set; }

        public Node Parent { get; set; }

        public Node[] Childs { get; set; }

        public Board NodeBoard { get; set; }

        public bool AllChildsCreated { get; private set; }

        public Node(Board board, Node parent)
        {
            NodeBoard = board;
            Parent = parent;
            Childs = new Node[board.Columns];
        }

        public int CreateChild()
        {
            for (int i = 0; i < Childs.Length; i++)
            {
                if (Childs[i] == null && NodeBoard.Fields[0, i] == FieldType.Empty)
                {
                    var newBoard = new Board(NodeBoard, i);
                    Childs[i] = new Node(newBoard, this);
                    CheckForAllChildsCreated();
                    return i;
                }
            }

            return -1;
        }

        private void CheckForAllChildsCreated()
        {
            for (int i = 0; i < Childs.Length; i++)
            {
                if (Childs[i] == null && NodeBoard.Fields[0, i] == FieldType.Empty)
                {
                    AllChildsCreated = false;
                    return;
                }
            }

            AllChildsCreated = true;
        }
    }
}
