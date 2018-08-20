namespace StdVersCodeGui
{
	partial class Form1
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(470, 207);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(40, 20);
			this.button1.TabIndex = 0;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(67, 207);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(396, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(193, 168);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(167, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Repertoire ou sera situé le resultat";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(161, 410);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(161, 40);
			this.button2.TabIndex = 3;
			this.button2.Text = "Générer";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(67, 311);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(395, 20);
			this.textBox2.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(193, 266);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Entrez le nom du projet";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(72, 120);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(391, 20);
			this.textBox3.TabIndex = 6;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(470, 120);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(45, 20);
			this.button3.TabIndex = 7;
			this.button3.Text = "...";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(193, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Selectionner un fichier à convertir ";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(522, 497);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label3;
	}
}

