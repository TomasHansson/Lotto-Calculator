namespace Lotto
{
    partial class Lotto
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
            this.lottoNumber1 = new System.Windows.Forms.TextBox();
            this.yourLottoNumbersLabel = new System.Windows.Forms.Label();
            this.lottoNumber2 = new System.Windows.Forms.TextBox();
            this.lottoNumber3 = new System.Windows.Forms.TextBox();
            this.lottoNumber4 = new System.Windows.Forms.TextBox();
            this.lottoNumber5 = new System.Windows.Forms.TextBox();
            this.lottoNumber6 = new System.Windows.Forms.TextBox();
            this.lottoNumber7 = new System.Windows.Forms.TextBox();
            this.numberOfDrawsLabel = new System.Windows.Forms.Label();
            this.numberOfDraws = new System.Windows.Forms.TextBox();
            this.runLotto = new System.Windows.Forms.Button();
            this.fiveMatchesLabel = new System.Windows.Forms.Label();
            this.fiveMatches = new System.Windows.Forms.TextBox();
            this.sixMatchesLabel = new System.Windows.Forms.Label();
            this.sixMatches = new System.Windows.Forms.TextBox();
            this.sevenMatchesLabel = new System.Windows.Forms.Label();
            this.sevenMatches = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lottoNumber1
            // 
            this.lottoNumber1.Location = new System.Drawing.Point(91, 23);
            this.lottoNumber1.MaxLength = 2;
            this.lottoNumber1.Name = "lottoNumber1";
            this.lottoNumber1.Size = new System.Drawing.Size(40, 20);
            this.lottoNumber1.TabIndex = 0;
            this.lottoNumber1.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // yourLottoNumbersLabel
            // 
            this.yourLottoNumbersLabel.AutoSize = true;
            this.yourLottoNumbersLabel.Location = new System.Drawing.Point(24, 26);
            this.yourLottoNumbersLabel.Name = "yourLottoNumbersLabel";
            this.yourLottoNumbersLabel.Size = new System.Drawing.Size(64, 13);
            this.yourLottoNumbersLabel.TabIndex = 1;
            this.yourLottoNumbersLabel.Text = "Din lottorad:";
            // 
            // lottoNumber2
            // 
            this.lottoNumber2.Location = new System.Drawing.Point(137, 23);
            this.lottoNumber2.MaxLength = 2;
            this.lottoNumber2.Name = "lottoNumber2";
            this.lottoNumber2.Size = new System.Drawing.Size(40, 20);
            this.lottoNumber2.TabIndex = 2;
            this.lottoNumber2.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // lottoNumber3
            // 
            this.lottoNumber3.Location = new System.Drawing.Point(183, 23);
            this.lottoNumber3.MaxLength = 2;
            this.lottoNumber3.Name = "lottoNumber3";
            this.lottoNumber3.Size = new System.Drawing.Size(40, 20);
            this.lottoNumber3.TabIndex = 3;
            this.lottoNumber3.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // lottoNumber4
            // 
            this.lottoNumber4.Location = new System.Drawing.Point(229, 23);
            this.lottoNumber4.MaxLength = 2;
            this.lottoNumber4.Name = "lottoNumber4";
            this.lottoNumber4.Size = new System.Drawing.Size(40, 20);
            this.lottoNumber4.TabIndex = 4;
            this.lottoNumber4.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // lottoNumber5
            // 
            this.lottoNumber5.Location = new System.Drawing.Point(276, 23);
            this.lottoNumber5.MaxLength = 2;
            this.lottoNumber5.Name = "lottoNumber5";
            this.lottoNumber5.Size = new System.Drawing.Size(40, 20);
            this.lottoNumber5.TabIndex = 5;
            this.lottoNumber5.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // lottoNumber6
            // 
            this.lottoNumber6.Location = new System.Drawing.Point(322, 23);
            this.lottoNumber6.MaxLength = 2;
            this.lottoNumber6.Name = "lottoNumber6";
            this.lottoNumber6.Size = new System.Drawing.Size(40, 20);
            this.lottoNumber6.TabIndex = 6;
            this.lottoNumber6.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // lottoNumber7
            // 
            this.lottoNumber7.Location = new System.Drawing.Point(368, 23);
            this.lottoNumber7.MaxLength = 2;
            this.lottoNumber7.Name = "lottoNumber7";
            this.lottoNumber7.Size = new System.Drawing.Size(40, 20);
            this.lottoNumber7.TabIndex = 7;
            this.lottoNumber7.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // numberOfDrawsLabel
            // 
            this.numberOfDrawsLabel.AutoSize = true;
            this.numberOfDrawsLabel.Location = new System.Drawing.Point(87, 53);
            this.numberOfDrawsLabel.Name = "numberOfDrawsLabel";
            this.numberOfDrawsLabel.Size = new System.Drawing.Size(90, 13);
            this.numberOfDrawsLabel.TabIndex = 8;
            this.numberOfDrawsLabel.Text = "Antal dragningar: ";
            // 
            // numberOfDraws
            // 
            this.numberOfDraws.Location = new System.Drawing.Point(183, 50);
            this.numberOfDraws.MaxLength = 6;
            this.numberOfDraws.Name = "numberOfDraws";
            this.numberOfDraws.Size = new System.Drawing.Size(85, 20);
            this.numberOfDraws.TabIndex = 9;
            this.numberOfDraws.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // runLotto
            // 
            this.runLotto.Location = new System.Drawing.Point(274, 49);
            this.runLotto.Name = "runLotto";
            this.runLotto.Size = new System.Drawing.Size(135, 22);
            this.runLotto.TabIndex = 10;
            this.runLotto.Text = "Starta Lotto";
            this.runLotto.UseVisualStyleBackColor = true;
            this.runLotto.Click += new System.EventHandler(this.RunLotto_Click);
            // 
            // fiveMatchesLabel
            // 
            this.fiveMatchesLabel.AutoSize = true;
            this.fiveMatchesLabel.Location = new System.Drawing.Point(97, 93);
            this.fiveMatchesLabel.Name = "fiveMatchesLabel";
            this.fiveMatchesLabel.Size = new System.Drawing.Size(34, 13);
            this.fiveMatchesLabel.TabIndex = 11;
            this.fiveMatchesLabel.Text = "5 rätt:";
            // 
            // fiveMatches
            // 
            this.fiveMatches.Location = new System.Drawing.Point(137, 90);
            this.fiveMatches.Name = "fiveMatches";
            this.fiveMatches.ReadOnly = true;
            this.fiveMatches.Size = new System.Drawing.Size(40, 20);
            this.fiveMatches.TabIndex = 12;
            this.fiveMatches.TabStop = false;
            // 
            // sixMatchesLabel
            // 
            this.sixMatchesLabel.AutoSize = true;
            this.sixMatchesLabel.Location = new System.Drawing.Point(189, 93);
            this.sixMatchesLabel.Name = "sixMatchesLabel";
            this.sixMatchesLabel.Size = new System.Drawing.Size(34, 13);
            this.sixMatchesLabel.TabIndex = 13;
            this.sixMatchesLabel.Text = "6 rätt:";
            // 
            // sixMatches
            // 
            this.sixMatches.Location = new System.Drawing.Point(229, 90);
            this.sixMatches.Name = "sixMatches";
            this.sixMatches.ReadOnly = true;
            this.sixMatches.Size = new System.Drawing.Size(40, 20);
            this.sixMatches.TabIndex = 14;
            this.sixMatches.TabStop = false;
            // 
            // sevenMatchesLabel
            // 
            this.sevenMatchesLabel.AutoSize = true;
            this.sevenMatchesLabel.Location = new System.Drawing.Point(282, 93);
            this.sevenMatchesLabel.Name = "sevenMatchesLabel";
            this.sevenMatchesLabel.Size = new System.Drawing.Size(34, 13);
            this.sevenMatchesLabel.TabIndex = 15;
            this.sevenMatchesLabel.Text = "7 rätt:";
            // 
            // sevenMatches
            // 
            this.sevenMatches.Location = new System.Drawing.Point(322, 90);
            this.sevenMatches.Name = "sevenMatches";
            this.sevenMatches.ReadOnly = true;
            this.sevenMatches.Size = new System.Drawing.Size(40, 20);
            this.sevenMatches.TabIndex = 16;
            this.sevenMatches.TabStop = false;
            // 
            // Lotto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 141);
            this.Controls.Add(this.sevenMatches);
            this.Controls.Add(this.sevenMatchesLabel);
            this.Controls.Add(this.sixMatches);
            this.Controls.Add(this.sixMatchesLabel);
            this.Controls.Add(this.fiveMatches);
            this.Controls.Add(this.fiveMatchesLabel);
            this.Controls.Add(this.runLotto);
            this.Controls.Add(this.numberOfDraws);
            this.Controls.Add(this.numberOfDrawsLabel);
            this.Controls.Add(this.lottoNumber7);
            this.Controls.Add(this.lottoNumber6);
            this.Controls.Add(this.lottoNumber5);
            this.Controls.Add(this.lottoNumber4);
            this.Controls.Add(this.lottoNumber3);
            this.Controls.Add(this.lottoNumber2);
            this.Controls.Add(this.yourLottoNumbersLabel);
            this.Controls.Add(this.lottoNumber1);
            this.Name = "Lotto";
            this.Text = "Lotto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lottoNumber1;
        private System.Windows.Forms.Label yourLottoNumbersLabel;
        private System.Windows.Forms.TextBox lottoNumber2;
        private System.Windows.Forms.TextBox lottoNumber3;
        private System.Windows.Forms.TextBox lottoNumber4;
        private System.Windows.Forms.TextBox lottoNumber5;
        private System.Windows.Forms.TextBox lottoNumber6;
        private System.Windows.Forms.TextBox lottoNumber7;
        private System.Windows.Forms.Label numberOfDrawsLabel;
        private System.Windows.Forms.TextBox numberOfDraws;
        private System.Windows.Forms.Button runLotto;
        private System.Windows.Forms.Label fiveMatchesLabel;
        private System.Windows.Forms.TextBox fiveMatches;
        private System.Windows.Forms.Label sixMatchesLabel;
        private System.Windows.Forms.TextBox sixMatches;
        private System.Windows.Forms.Label sevenMatchesLabel;
        private System.Windows.Forms.TextBox sevenMatches;
    }
}

