using System;
using System.Collections.Generic;

namespace MCTS
{
    public class Board
    {
        public int Rows { get; } = 6;

        public int Columns { get; } = 7;

        public FieldType[,] Fields { get; private set; }

        public GameState State { get; private set; }

        public bool GameEnded => State == GameState.Draw || State == GameState.Player1Win || State == GameState.Player2Win;

        // konstruktor tworzący tablicę od zera
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

        // konstruktor kopiowania tablicy
        public Board(Board board)
        {
            Fields = new FieldType[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Fields[i, j] = board.Fields[i, j];
                }
            }

            State = board.State;
        }

        // konstruktor wykonujący ruch
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

            // przypisanie ruchu
            int rowIndex = EmptyRowIndex(column);
            if (board.State == GameState.Player1Turn)
            {
                Fields[rowIndex, column] = FieldType.PlayerOne;
            }
            else
            {
                Fields[rowIndex, column] = FieldType.PlayerTwo;
            }

            //sprawdzenie wygranej
            if (CheckWin(rowIndex, column, out GameState winState))
            {
                State = winState;
                return;
            }

            // przypadek remisu
            if (CheckEndGameState())
            {
                State = GameState.Draw;
            }
            else
            {
                State = board.State == GameState.Player1Turn ? GameState.Player2Turn : GameState.Player1Turn;
            }
        }

        public List<int> GetAvailableColumns()
        {
            var columns = new List<int>();
            for (int i = 0; i < Columns; i++)
            {
                if (Fields[0, i] == FieldType.Empty) columns.Add(i);
            }
            return columns;
        }

        private int EmptyRowIndex(int column)
        {
            for (int i = Rows-1; i >= 0; i--)
            {
                if (Fields[i, column] == FieldType.Empty) return i;
            }

            return 0;
        }

        private bool CheckEndGameState()
        {
            // sprawdzenie remisu
            for (int i = 0; i < Columns; i++)
            {
                if (Fields[0, i] == FieldType.Empty) return false;
            }

            return true;
        }

        private bool CheckWin(int row, int col, out GameState winState)
        {
            int left = 0, right = 0, up = 0, down = 0, leftUp = 0, leftDown = 0, rightUp = 0, rightDown = 0;
            FieldType checkType = Fields[row, col];
            int i, j;
            winState = GameState.Draw;

            // left
            for (i = col - 1; i >= 0; i--)
            {
                if (Fields[row, i] == checkType) { left += 1; } else { break; }
            }

            // right
            for (i = col + 1; i < Columns; i++)
            {
                if (Fields[row, i] == checkType) { right += 1; } else { break; }
            }

            // up
            for (i = row - 1; i >= 0; i--)
            {
                if (Fields[i, col] == checkType) { up += 1; } else { break; }
            }

            // down
            for (i = row + 1; i < Rows; i++)
            {
                if (Fields[i, col] == checkType) { down += 1; } else { break; }
            }

            // leftUp
            i = row - 1;
            j = col - 1;
            while (i >= 0 && j >= 0)
            {
                if (Fields[i, j] == checkType) { leftUp += 1; } else { break; }
                i-=1;
                j-=1;
            }

            // leftDown
            i = row + 1;
            j = col - 1;
            while (i < Rows && j >= 0)
            {
                if (Fields[i, j] == checkType) { leftDown += 1; } else { break; }
                i += 1;
                j -= 1;
            }

            // rightDown
            i = row + 1;
            j = col + 1;
            while (i < Rows && j < Columns)
            {
                if (Fields[i, j] == checkType) { rightDown += 1; } else { break; }
                i += 1;
                j += 1;
            }

            // rightUp
            i = row - 1;
            j = col + 1;
            while (i >= 0 && j < Columns)
            {
                if (Fields[i, j] == checkType) { rightUp += 1; } else { break; }
                i -= 1;
                j += 1;
            }

            if (up + down >= 3 || left + right >= 3 || leftDown + rightUp >= 3 || leftUp + rightDown >= 3)
            {
                winState = checkType == FieldType.PlayerOne ? GameState.Player1Win : GameState.Player2Win;
                return true;
            }

            return false;
        }



    }
}
