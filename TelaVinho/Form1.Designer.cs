namespace TelaVinho
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNome = new TextBox();
            txtIdade = new TextBox();
            txtPreco = new TextBox();
            txtCod = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(528, 274);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // button1
            // 
            button1.Location = new Point(50, 311);
            button1.Name = "button1";
            button1.Size = new Size(83, 29);
            button1.TabIndex = 1;
            button1.Text = "Informações";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(139, 311);
            button2.Name = "button2";
            button2.Size = new Size(83, 29);
            button2.TabIndex = 2;
            button2.Text = "BuscarCod";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(228, 311);
            button3.Name = "button3";
            button3.Size = new Size(83, 29);
            button3.TabIndex = 3;
            button3.Text = "Novo";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(317, 311);
            button4.Name = "button4";
            button4.Size = new Size(83, 29);
            button4.TabIndex = 4;
            button4.Text = "Alterar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(406, 311);
            button5.Name = "button5";
            button5.Size = new Size(83, 29);
            button5.TabIndex = 5;
            button5.Text = "Excluir";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(560, 86);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 7;
            label2.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(560, 131);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 8;
            label3.Text = "Idade:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(560, 173);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 9;
            label4.Text = "Preço:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(609, 83);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(79, 23);
            txtNome.TabIndex = 11;
            // 
            // txtIdade
            // 
            txtIdade.Location = new Point(611, 128);
            txtIdade.Name = "txtIdade";
            txtIdade.Size = new Size(79, 23);
            txtIdade.TabIndex = 12;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(611, 170);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(79, 23);
            txtPreco.TabIndex = 13;
            // 
            // txtCod
            // 
            txtCod.Location = new Point(611, 47);
            txtCod.Name = "txtCod";
            txtCod.Size = new Size(79, 23);
            txtCod.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(560, 50);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 6;
            label1.Text = "Código:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 361);
            Controls.Add(txtPreco);
            Controls.Add(txtIdade);
            Controls.Add(txtNome);
            Controls.Add(txtCod);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNome;
        private TextBox txtIdade;
        private TextBox txtPreco;
        private TextBox txtCod;
        private Label label1;
    }
}
