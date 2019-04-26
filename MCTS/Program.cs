using System;

namespace MCTS
{
    class Program
    {
        public static void DrawBoard(Board board)
        {
            Console.WriteLine();

            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    var letter = "   ";
                    switch (board.Fields[i, j])
                    {
                        case FieldType.Empty:
                            letter = " X ";
                            break;
                        case FieldType.Yellow:
                            letter = " Y ";
                            break;
                        case FieldType.Red:
                            letter = " R ";
                            break;
                    }

                    Console.Write(letter);
                }
                Console.Write("\n");
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            

            Console.WriteLine("Koniec...");
            Console.ReadKey();
        }


    }
}
