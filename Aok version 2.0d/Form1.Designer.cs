namespace Aok_version_2._0d
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
            this.btn_BrowserGame = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_BrowserGame
            // 
            this.btn_BrowserGame.Location = new System.Drawing.Point(340, 169);
            this.btn_BrowserGame.Name = "btn_BrowserGame";
            this.btn_BrowserGame.Size = new System.Drawing.Size(114, 61);
            this.btn_BrowserGame.TabIndex = 14;
            this.btn_BrowserGame.Text = "Browser Game ...";
            this.btn_BrowserGame.UseVisualStyleBackColor = true;
            this.btn_BrowserGame.Click += new System.EventHandler(this.btn_BrowserGame_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 53);
            this.button1.TabIndex = 15;
            this.button1.Text = "2.0d";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(152, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 51);
            this.button2.TabIndex = 16;
            this.button2.Text = "Back to your version";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 244);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_BrowserGame);
            this.Name = "Form1";
            this.Text = "Aok 2.0d anticheat version";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_BrowserGame;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

