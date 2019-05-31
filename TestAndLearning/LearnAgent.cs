using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCTS;
using MCTS.Data;

namespace TestAndLearning
{
    public static class LearnAgent
    {
        public static void LearnTheAgent(int timeInMs, double expFactor, string firstXml)
        {
            var masterMcts = new Mcts(timeInMs, expFactor);
            var weakerMcts = new Mcts(timeInMs, expFactor);
            masterMcts.LoadFromXml(firstXml);
            var tempFile = string.Empty;
            var masterWins = 0;

            for (int i = 0; i < 100; i++)
            {
                tempFile = $"temp{i}.xml";
                masterMcts.SaveToXml(tempFile);

                if (SimulateGame(masterMcts, weakerMcts) == GameState.Player1Win)
                {
                    masterWins += 1;
                }

                masterMcts.BackToRoot();
                weakerMcts.LoadFromXml(tempFile);
            }

            File.WriteAllText("LearningResult.txt", $"Master won {masterWins} times");
        }

        private static GameState SimulateGame(Mcts lefMcts, Mcts righMcts)
        {
            // wygenerowanie ruchu pierwszego gracza
            int leftPLayerMove;
            int rightPlayerMove;

            while (true)
            {
                leftPLayerMove = lefMcts.GenerateMove();

                // wykonanie ruchu pierwszego gracza dla pierwszego parametru
                lefMcts.MakeMove(leftPLayerMove);
                if (lefMcts.IsEnd)
                {
                    return lefMcts.GetBoard().State;
                }

                // wykonanie ruchu pierwszego gracza dla drugiego parametru
                righMcts.MakeMove(leftPLayerMove);
                if (righMcts.IsEnd)
                {
                    return righMcts.GetBoard().State;
                }

                // wygenerowanie ruchu drugiego gracza
                rightPlayerMove = righMcts.GenerateMove();

                // wykonanie ruchu drugiego gracza dla pierwszego parametru
                lefMcts.MakeMove(rightPlayerMove);
                if (lefMcts.IsEnd)
                {
                    return lefMcts.GetBoard().State;
                }

                // wykonanie ruchu drugiego gracza dla drugiego parametru
                righMcts.MakeMove(rightPlayerMove);
                if (righMcts.IsEnd)
                {
                    return righMcts.GetBoard().State;
                }
            }
        }
    }
}
