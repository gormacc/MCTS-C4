namespace Connect4GUI
{
    partial class Connect4MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonColorYellow = new System.Windows.Forms.RadioButton();
            this.radioButtonColorRed = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonStartingHuman = new System.Windows.Forms.RadioButton();
            this.radioButtonStartingAI = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownExplorationFactor = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTimeProcess = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelGamePanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExplorationFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeProcess)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 451);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(198, 449);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonColorYellow);
            this.groupBox1.Controls.Add(this.radioButtonColorRed);
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Human player color";
            // 
            // radioButtonColorYellow
            // 
            this.radioButtonColorYellow.AutoSize = true;
            this.radioButtonColorYellow.Location = new System.Drawing.Point(7, 57);
            this.radioButtonColorYellow.Name = "radioButtonColorYellow";
            this.radioButtonColorYellow.Size = new System.Drawing.Size(56, 17);
            this.radioButtonColorYellow.TabIndex = 1;
            this.radioButtonColorYellow.Text = "Yellow";
            this.radioButtonColorYellow.UseVisualStyleBackColor = true;
            // 
            // radioButtonColorRed
            // 
            this.radioButtonColorRed.AutoSize = true;
            this.radioButtonColorRed.Checked = true;
            this.radioButtonColorRed.Location = new System.Drawing.Point(7, 20);
            this.radioButtonColorRed.Name = "radioButtonColorRed";
            this.radioButtonColorRed.Size = new System.Drawing.Size(45, 17);
            this.radioButtonColorRed.TabIndex = 0;
            this.radioButtonColorRed.TabStop = true;
            this.radioButtonColorRed.Text = "Red";
            this.radioButtonColorRed.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonStartingHuman);
            this.groupBox2.Controls.Add(this.radioButtonStartingAI);
            this.groupBox2.Location = new System.Drawing.Point(13, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Starting player";
            // 
            // radioButtonStartingHuman
            // 
            this.radioButtonStartingHuman.AutoSize = true;
            this.radioButtonStartingHuman.Location = new System.Drawing.Point(7, 57);
            this.radioButtonStartingHuman.Name = "radioButtonStartingHuman";
            this.radioButtonStartingHuman.Size = new System.Drawing.Size(59, 17);
            this.radioButtonStartingHuman.TabIndex = 1;
            this.radioButtonStartingHuman.Text = "Human";
            this.radioButtonStartingHuman.UseVisualStyleBackColor = true;
            // 
            // radioButtonStartingAI
            // 
            this.radioButtonStartingAI.AutoSize = true;
            this.radioButtonStartingAI.Checked = true;
            this.radioButtonStartingAI.Location = new System.Drawing.Point(7, 20);
            this.radioButtonStartingAI.Name = "radioButtonStartingAI";
            this.radioButtonStartingAI.Size = new System.Drawing.Size(35, 17);
            this.radioButtonStartingAI.TabIndex = 0;
            this.radioButtonStartingAI.TabStop = true;
            this.radioButtonStartingAI.Text = "AI";
            this.radioButtonStartingAI.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.numericUpDownExplorationFactor);
            this.groupBox3.Controls.Add(this.numericUpDownTimeProcess);
            this.groupBox3.Location = new System.Drawing.Point(13, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(167, 133);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AI parameters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Exploration factor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time in ms to process";
            // 
            // numericUpDownExplorationFactor
            // 
            this.numericUpDownExplorationFactor.DecimalPlaces = 4;
            this.numericUpDownExplorationFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDownExplorationFactor.Location = new System.Drawing.Point(3, 93);
            this.numericUpDownExplorationFactor.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownExplorationFactor.Name = "numericUpDownExplorationFactor";
            this.numericUpDownExplorationFactor.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownExplorationFactor.TabIndex = 5;
            this.numericUpDownExplorationFactor.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // numericUpDownTimeProcess
            // 
            this.numericUpDownTimeProcess.Location = new System.Drawing.Point(6, 44);
            this.numericUpDownTimeProcess.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownTimeProcess.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTimeProcess.Name = "numericUpDownTimeProcess";
            this.numericUpDownTimeProcess.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownTimeProcess.TabIndex = 3;
            this.numericUpDownTimeProcess.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start new game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tableLayoutPanelGamePanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 451);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanelGamePanel
            // 
            this.tableLayoutPanelGamePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelGamePanel.ColumnCount = 7;
            this.tableLayoutPanelGamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28592F));
            this.tableLayoutPanelGamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28592F));
            this.tableLayoutPanelGamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28592F));
            this.tableLayoutPanelGamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28592F));
            this.tableLayoutPanelGamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28592F));
            this.tableLayoutPanelGamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28592F));
            this.tableLayoutPanelGamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28449F));
            this.tableLayoutPanelGamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGamePanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelGamePanel.Name = "tableLayoutPanelGamePanel";
            this.tableLayoutPanelGamePanel.RowCount = 6;
            this.tableLayoutPanelGamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelGamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelGamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelGamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelGamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelGamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelGamePanel.Size = new System.Drawing.Size(598, 449);
            this.tableLayoutPanelGamePanel.TabIndex = 0;
            this.tableLayoutPanelGamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanelGamePanel_Paint);
            // 
            // Connect4MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(16, 490);
            this.Name = "Connect4MainWindow";
            this.Text = "Connect4";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExplorationFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeProcess)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeProcess;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonStartingHuman;
        private System.Windows.Forms.RadioButton radioButtonStartingAI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonColorYellow;
        private System.Windows.Forms.RadioButton radioButtonColorRed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownExplorationFactor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGamePanel;
    }
}

