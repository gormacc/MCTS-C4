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
                        case FieldType.PlayerOne:
                            letter = " Y ";
                            break;
                        case FieldType.PlayerTwo:
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
            var program = new Mcts();

            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine();
                Console.WriteLine();

                DrawBoard(program.GetBoard());

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Wprowadz kolumnę lub generuj");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.G)
                {
                    var move = program.GenerateMove();
                    program.MakeMove(move);
                }
                else if(key.Key == ConsoleKey.D1)
                {
                    program.MakeMove(0);
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    program.MakeMove(1);
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    program.MakeMove(2);
                }
                else if (key.Key == ConsoleKey.D4)
                {
                    program.MakeMove(3);
                }
                else if (key.Key == ConsoleKey.D5)
                {
                    program.MakeMove(4);
                }
                else if (key.Key == ConsoleKey.D6)
                {
                    program.MakeMove(5);
                }
                else if (key.Key == ConsoleKey.D7)
                {
                    program.MakeMove(6);
                }


            } while (key.Key != ConsoleKey.Escape);


            Console.WriteLine("Koniec...");
            Console.ReadKey();
        }


    }
}
