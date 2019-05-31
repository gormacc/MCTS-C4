using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCTS;
using MCTS.Data;

namespace TestAndLearning
{
    public static class FindBetterParameter
    {
        public static string CompareParameters(int timeInMs, double firstParameter, double secondParameter)
        {
            int firstParameterWins = 0;
            int secondParameterWins = 0;

            for (int i = 0; i < 10; i++)
            {
                var resultOne = SimulateGame(timeInMs, firstParameter, secondParameter);

                if (resultOne == GameState.Player1Win)
                {
                    firstParameterWins++;
                }
                else if(resultOne == GameState.Player2Win)
                {
                    secondParameterWins++;
                }

                var resultTwo = SimulateGame(timeInMs, secondParameter, firstParameter);

                if (resultTwo == GameState.Player1Win)
                {
                    secondParameterWins++;
                }
                else if (resultTwo == GameState.Player2Win)
                {
                    firstParameterWins++;
                }

                Console.WriteLine($"{firstParameter} wins : {firstParameterWins} times , {secondParameter} wins {secondParameterWins} times\n");
            }

            return $"{firstParameter} wins : {firstParameterWins} times , {secondParameter} wins {secondParameterWins} times{Environment.NewLine}";
        }

        // zwraca informację czy wygrał lewy gracz
        private static GameState SimulateGame(int timeInMs, double firstParam, double secondParam)
        {
            var leftMcts = new Mcts(timeInMs, firstParam);
            var rightMcts = new Mcts(timeInMs, secondParam);

            // wygenerowanie ruchu pierwszego gracza
            int leftPLayerMove = new Random(DateTime.Now.Millisecond).Next() % 7;
            int rightPlayerMove;

            while (true)
            {
                // wykonanie ruchu pierwszego gracza dla pierwszego parametru
                leftMcts.MakeMove(leftPLayerMove);
                if (leftMcts.IsEnd)
                {
                    return leftMcts.GetBoard().State;
                }

                // wykonanie ruchu pierwszego gracza dla drugiego parametru
                rightMcts.MakeMove(leftPLayerMove);
                if (rightMcts.IsEnd)
                {
                    return rightMcts.GetBoard().State;
                }

                // wygenerowanie ruchu drugiego gracza
                rightPlayerMove = rightMcts.GenerateMove();

                // wykonanie ruchu drugiego gracza dla pierwszego parametru
                leftMcts.MakeMove(rightPlayerMove);
                if (leftMcts.IsEnd)
                {
                    return leftMcts.GetBoard().State;
                }

                // wykonanie ruchu drugiego gracza dla drugiego parametru
                rightMcts.MakeMove(rightPlayerMove);
                if (rightMcts.IsEnd)
                {
                    return rightMcts.GetBoard().State;
                }

                leftPLayerMove = leftMcts.GenerateMove();
            }
        }
    }
}
