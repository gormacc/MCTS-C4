using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Connect4GUI.Properties;
using MCTS;
using MCTS.Data;

namespace Connect4GUI
{
    public partial class Connect4MainWindow : Form
    {
        private bool IsPlayerRed { get; set; }

        private bool IsPlayerStarting { get; set; }

        private int TimeToProcess { get; set; }

        private double ExplorationFactor { get; set; }

        private Mcts MCTSLogic { get; set; }

        private Board currentGameBoard { get; set; }

        private bool gameEnded { get; set; }

        public Connect4MainWindow()
        {
            InitializeComponent();
            IsPlayerRed = radioButtonColorRed.Checked;
            IsPlayerStarting = radioButtonStartingHuman.Checked;
            TimeToProcess = (int)numericUpDownTimeProcess.Value;
            ExplorationFactor = (double)numericUpDownExplorationFactor.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanelGamePanel.Controls.Clear();
            MCTSLogic = new Mcts(TimeToProcess, ExplorationFactor);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "data.xml");
            MCTSLogic.LoadFromXml(filePath);
            RestartGameState();
            if (!IsPlayerStarting)
            {
                var move = MCTSLogic.GenerateMove();
                MCTSLogic.MakeMove(move);
                tableLayoutPanelGamePanel.Refresh();
            }
        }

        private void RestartGameState()
        {
            gameEnded = false;
            IsPlayerRed = radioButtonColorRed.Checked;
            IsPlayerStarting = radioButtonStartingHuman.Checked;
            TimeToProcess = (int)numericUpDownTimeProcess.Value;
            ExplorationFactor = (double)numericUpDownExplorationFactor.Value;
            tableLayoutPanelGamePanel.Controls.Clear();
            for (int i = 0; i < tableLayoutPanelGamePanel.ColumnCount; i++)
            {
                for (int j = 0; j < tableLayoutPanelGamePanel.RowCount; j++)
                {
                    var guiElement = new Panel
                    {
                        Dock = DockStyle.Fill,
                        BackgroundImageLayout = ImageLayout.Zoom,
                    };

                    int locali = i;
                    guiElement.Click += new EventHandler((x, y) =>
                    {
                        if (gameEnded)
                        {
                            MessageBox.Show("Please start new game!");
                            return;
                        }
                        if (MCTSLogic.GetBoard().Fields[0, locali] != FieldType.Empty)
                        {
                            MessageBox.Show("Column is full!");
                            return;
                        }
                        MCTSLogic.MakeMove(locali);
                        tableLayoutPanelGamePanel.Refresh();
                        if (MCTSLogic.IsEnd)
                        {
                            MessageBox.Show("Player has won!");
                            gameEnded = true;
                        }
                        if (gameEnded)
                            return;
                        var move = MCTSLogic.GenerateMove();
                        MCTSLogic.MakeMove(move);
                        tableLayoutPanelGamePanel.Refresh();
                        if (MCTSLogic.IsEnd)
                        {
                            MessageBox.Show("AI has won!");
                            gameEnded = true;
                        }
                    }
                    );

                    tableLayoutPanelGamePanel.Controls.Add(
                        guiElement,
                        i, j);
                }
            }
        }

        private void tableLayoutPanelGamePanel_Paint(object sender, PaintEventArgs e)
        {

            if (MCTSLogic != null)
            {
                currentGameBoard = MCTSLogic.GetBoard();

                for (int i = 0; i < currentGameBoard.Rows; i++)
                {
                    for (int j = 0; j < currentGameBoard.Columns; j++)
                    {
                        var boardElement = tableLayoutPanelGamePanel.GetControlFromPosition(j, i);
                        if (boardElement.BackgroundImage == null)
                        {
                            switch (currentGameBoard.Fields[i, j])
                            {
                                case FieldType.Empty:
                                    break;
                                case FieldType.PlayerOne:
                                    boardElement.BackgroundImage =
                                        (IsPlayerStarting && IsPlayerRed)
                                        || (!IsPlayerStarting && !IsPlayerRed)
                                        ? Resources.RedPlayer : Resources.YellowPlayer;
                                    break;
                                case FieldType.PlayerTwo:
                                    boardElement.BackgroundImage =
                                        (!IsPlayerStarting && IsPlayerRed)
                                        || (IsPlayerStarting && !IsPlayerRed)
                                        ? Resources.RedPlayer : Resources.YellowPlayer;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        Point? GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return null;

            int w = tlp.Width;
            int h = tlp.Height;
            int[] widths = tlp.GetColumnWidths();

            int i;
            for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
                w -= widths[i];
            int col = i + 1;

            int[] heights = tlp.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];

            int row = i + 1;

            return new Point(col, row);
        }
    }
}
