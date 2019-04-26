namespace MCTS
{
    public class Board
    {
        public int Rows { get; } = 6;

        public int Columns { get; } = 7;

        public FieldType[,] Fields { get; private set; }

        public Board()
        {
            Fields = new FieldType[Rows,Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Fields[i, j] = FieldType.Empty;
                }
            }
        }

        
    }
}
