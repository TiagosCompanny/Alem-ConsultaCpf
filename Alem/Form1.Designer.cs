namespace Alem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Importar = new Button();
            button2 = new Button();
            label1 = new Label();
            inputFile = new TextBox();
            label2 = new Label();
            progressBar1 = new ProgressBar();
            trackBar1 = new TrackBar();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            labelTimer = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Importar
            // 
            Importar.Cursor = Cursors.Hand;
            Importar.Location = new Point(418, 81);
            Importar.Margin = new Padding(3, 2, 3, 2);
            Importar.Name = "Importar";
            Importar.Size = new Size(82, 25);
            Importar.TabIndex = 0;
            Importar.Text = "Importar";
            Importar.UseVisualStyleBackColor = true;
            Importar.Click += button_SelecionarArquivo;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(153, 255, 102);
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Sylfaen", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(588, 126);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(132, 48);
            button2.TabIndex = 1;
            button2.Text = "Iniciar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button_IniciarAsync;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 63);
            label1.Name = "label1";
            label1.Size = new Size(75, 19);
            label1.TabIndex = 2;
            label1.Text = "Planilha: ";
            // 
            // inputFile
            // 
            inputFile.Location = new Point(12, 84);
            inputFile.Margin = new Padding(3, 2, 3, 2);
            inputFile.Name = "inputFile";
            inputFile.Size = new Size(392, 23);
            inputFile.TabIndex = 3;
            inputFile.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(160, 29);
            label2.TabIndex = 5;
            label2.Text = "Consulta CPF";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(11, 126);
            progressBar1.Margin = new Padding(3, 2, 3, 2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(392, 22);
            progressBar1.TabIndex = 6;
            progressBar1.Click += progressBar1_Click;
            // 
            // trackBar1
            // 
            trackBar1.Cursor = Cursors.NoMoveHoriz;
            trackBar1.Location = new Point(451, 145);
            trackBar1.Maximum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(76, 45);
            trackBar1.TabIndex = 7;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(408, 145);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 8;
            label3.Text = "Ocultar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(426, 129);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 9;
            label4.Text = "Mostrar";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(408, 124);
            label5.Name = "label5";
            label5.Size = new Size(174, 20);
            label5.TabIndex = 10;
            label5.Text = "Processamento Selenium";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(567, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(171, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(523, 145);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 12;
            label6.Text = "Mostrar";
            // 
            // labelTimer
            // 
            labelTimer.AutoSize = true;
            labelTimer.Font = new Font("Segoe UI Symbol", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTimer.Location = new Point(390, 6);
            labelTimer.Name = "labelTimer";
            labelTimer.Size = new Size(13, 17);
            labelTimer.TabIndex = 14;
            labelTimer.Text = " ";
            labelTimer.Click += label8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(731, 183);
            Controls.Add(labelTimer);
            Controls.Add(label6);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(trackBar1);
            Controls.Add(progressBar1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(inputFile);
            Controls.Add(label1);
            Controls.Add(Importar);
            ForeColor = SystemColors.InactiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Robô Alem";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Importar;
        private Button button2;
        private Label label1;
        private TextBox inputFile;
        private Label label2;
        private ProgressBar progressBar1;
        private TrackBar trackBar1;
        private Label label3;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox1;
        private Label label6;
        private Label labelTimer;
    }
}
