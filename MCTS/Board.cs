namespace MCTS
{
    public class Board
    {
        public int Rows { get; } = 6;

        public int Columns { get; } = 7;

        public FieldType[,] Fields { get; private set; }

        public GameState State { get; private set; }

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

            State = GameState.Player1Turn;
        }

        public Board(Board board, int column)
        {
            Fields = new FieldType[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Fields[i, j] = board.Fields[i,j];
                }
            }

            int rowIndex = EmptyRowIndex(column);
            if (board.State == GameState.Player1Turn)
            {
                Fields[rowIndex, column] = FieldType.PlayerOne;
            }
            else
            {
                Fields[rowIndex, column] = FieldType.PlayerTwo;
            }

            if (CheckEndGameState())
            {
                State = GameState.EndGame;
            }
            else
            {
                State = board.State == GameState.Player1Turn ? GameState.Player2Turn : GameState.Player1Turn;
            }
        }

        private int EmptyRowIndex(int column)
        {
            for (int i = Rows-1; i >= 0; i++)
            {
                if (Fields[i, column] == FieldType.Empty) return i;
            }

            return 0;
        }

        private bool CheckEndGameState()
        {
            for (int i = 0; i < Columns; i++)
            {
                if (Fields[0, i] == FieldType.Empty) return false;
            }

            return true;
        }

    }
}
