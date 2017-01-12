namespace Neo4J_Repository
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.actorNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.movieNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.directorTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.directorActorsTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(278, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Svi Prevoznici";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // actorNameTextBox
            // 
            this.actorNameTextBox.Location = new System.Drawing.Point(12, 90);
            this.actorNameTextBox.Name = "actorNameTextBox";
            this.actorNameTextBox.Size = new System.Drawing.Size(159, 20);
            this.actorNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id Vozila";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Pronadji vozilo i isporuku";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // movieNameTextBox
            // 
            this.movieNameTextBox.Location = new System.Drawing.Point(12, 140);
            this.movieNameTextBox.Name = "movieNameTextBox";
            this.movieNameTextBox.Size = new System.Drawing.Size(159, 20);
            this.movieNameTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fabrika";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(184, 140);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Ko vrsi dostavu za Fabriku";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // directorTextBox
            // 
            this.directorTextBox.Location = new System.Drawing.Point(12, 186);
            this.directorTextBox.Name = "directorTextBox";
            this.directorTextBox.Size = new System.Drawing.Size(159, 20);
            this.directorTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ime ili deo imena reditelja";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(184, 183);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Pronađi filmove reditelja";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // directorActorsTextBox
            // 
            this.directorActorsTextBox.Location = new System.Drawing.Point(12, 229);
            this.directorActorsTextBox.Name = "directorActorsTextBox";
            this.directorActorsTextBox.Size = new System.Drawing.Size(159, 20);
            this.directorActorsTextBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ime ili deo imena reditelja";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(184, 226);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(191, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Pronađi glumce u filmovima reditelja ";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 277);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(191, 23);
            this.button6.TabIndex = 13;
            this.button6.Text = "Dodaj glumca";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 306);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(191, 23);
            this.button7.TabIndex = 14;
            this.button7.Text = "Obriši glumca";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(15, 335);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(188, 23);
            this.button8.TabIndex = 15;
            this.button8.Text = "Izmeni glumca";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(296, 12);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(278, 23);
            this.button9.TabIndex = 16;
            this.button9.Text = "Sve Isporuke";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(12, 42);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(278, 23);
            this.button10.TabIndex = 17;
            this.button10.Text = "Sve Prodavnice";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(296, 41);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(278, 23);
            this.button11.TabIndex = 18;
            this.button11.Text = "Sve Fabrike";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 411);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.directorActorsTextBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.directorTextBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.movieNameTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.actorNameTextBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox actorNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox movieNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox directorTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox directorActorsTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
    }
}

