namespace MCTS.Data
{
    public class Node
    {
        public long Id { get; }

        public double PlayerOneWin { get; set; } // współcznnik wygranych gracza 1

        public double Visited { get; set; } // liczba odwiedzeń wierzchołka

        public Node Parent { get; set; }

        public Node[] Childs { get; set; }

        public Board NodeBoard { get; set; } // plansza gry

        public bool AllChildsCreated { get; set; } // informacja czy należy dodać dziecko

        public Node(Board board, Node parent, long id)
        {
            NodeBoard = board;
            Parent = parent;
            Id = id;
            Childs = new Node[board.Columns];
            CheckForAllChildsCreated();
        }

        public int CreateChild(long id)
        {
            for (int i = 0; i < Childs.Length; i++)
            {
                if (Childs[i] == null && NodeBoard.Fields[0, i] == FieldType.Empty)
                {
                    var newBoard = new Board(NodeBoard, i);
                    Childs[i] = new Node(newBoard, this, id);
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
