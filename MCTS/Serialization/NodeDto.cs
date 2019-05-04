using MCTS.Data;

namespace MCTS.Serialization
{
    public class NodeDto
    {
        public double PlayerOneWin { get; set; }
        public double Visited { get; set; }
        public bool AllChildsCreated { get; set; }

        public long Id { get; set; }
        public long[] Childs { get; set; }
        public long Parent { get; set; }

        public int[] Fields { get; set; }
        public int State { get; set; }

        public NodeDto()
        {
            
        }

        public NodeDto(Node node)
        {
            if(node == null) return;
            PlayerOneWin = node.PlayerOneWin;
            Visited = node.Visited;
            AllChildsCreated = node.AllChildsCreated;
            Id = node.Id;
            Parent = node.Parent?.Id ?? 0;
            State = (int)node.NodeBoard.State;

            Childs = new long[node.Childs.Length];
            for (int i = 0; i < node.Childs.Length; i++)
            {
                Childs[i] = node.Childs[i]?.Id ?? 0;
            }

            int rows = 6;
            int columns = 7;
            Fields = new int[rows * columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Fields[i * columns + j] = (int)node.NodeBoard.Fields[i, j];
                }
            }

        }

        public Node ExtractDto(Node parent)
        {
            var board = new Board();
            int rows = 6;
            int columns = 7;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    board.Fields[i, j] = (FieldType)Fields[i * columns + j];
                }
            }
            board.State = (GameState) State;

            var node = new Node(board, parent, Id)
            {
                PlayerOneWin = PlayerOneWin,
                Visited = Visited,
                AllChildsCreated = AllChildsCreated
            };

            return node;
        }
    }
}
