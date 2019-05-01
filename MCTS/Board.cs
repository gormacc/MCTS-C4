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

            // przypisanie stanu gry
            if (CheckEndGameState(out GameState endState))
            {
                State = endState;
            }
            else
            {
                State = board.State == GameState.Player1Turn ? GameState.Player2Turn : GameState.Player1Turn;
            }
        }

        private int EmptyRowIndex(int column)
        {
            for (int i = Rows-1; i >= 0; i--)
            {
                if (Fields[i, column] == FieldType.Empty) return i;
            }

            return 0;
        }

        private bool CheckEndGameState(out GameState endStates)
        {
            // sprawdzenie wygranej jednego z graczy
            if (CheckWin(out GameState winState))
            {
                endStates = winState;
                return true;
            }

            // sprawdzenie remisu
            endStates = GameState.Draw;
            for (int i = 0; i < Columns; i++)
            {
                if (Fields[0, i] == FieldType.Empty) return false;
            }

            return true;
        }

        private bool CheckWin(out GameState winState)
        {
            winState = GameState.Draw;
            return false;
            //todo
        }

        public List<int> GetAvailableColumns()
        {
            var columns = new List<int>();
            for (int i = 0; i < Columns; i++)
            {
                if(Fields[0,i] == FieldType.Empty) columns.Add(i);
            }
            return columns;
        }

    }
}
