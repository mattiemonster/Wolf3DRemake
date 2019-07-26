namespace GridLevelEditor
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            this.newLevelButton = new MetroFramework.Controls.MetroButton();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.openLevelButton = new MetroFramework.Controls.MetroButton();
            this.tilesEditorButton = new MetroFramework.Controls.MetroButton();
            this.quitButton = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // newLevelButton
            // 
            this.newLevelButton.Location = new System.Drawing.Point(50, 65);
            this.newLevelButton.Name = "newLevelButton";
            this.newLevelButton.Size = new System.Drawing.Size(120, 30);
            this.newLevelButton.TabIndex = 0;
            this.newLevelButton.Text = "New Level";
            this.newLevelButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = null;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(0, 256);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(222, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Uses Metro Framework by Jens Theil";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // openLevelButton
            // 
            this.openLevelButton.Location = new System.Drawing.Point(50, 101);
            this.openLevelButton.Name = "openLevelButton";
            this.openLevelButton.Size = new System.Drawing.Size(120, 30);
            this.openLevelButton.TabIndex = 2;
            this.openLevelButton.Text = "Open Level";
            this.openLevelButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tilesEditorButton
            // 
            this.tilesEditorButton.Location = new System.Drawing.Point(50, 137);
            this.tilesEditorButton.Name = "tilesEditorButton";
            this.tilesEditorButton.Size = new System.Drawing.Size(120, 30);
            this.tilesEditorButton.TabIndex = 3;
            this.tilesEditorButton.Text = "Tiles Editor";
            this.tilesEditorButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tilesEditorButton.Click += new System.EventHandler(this.TilesEditorButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(83, 230);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(61, 22);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "Quit";
            this.quitButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.quitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 281);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.tilesEditorButton);
            this.Controls.Add(this.openLevelButton);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.newLevelButton);
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.Flat;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "Grid Level Editor";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton newLevelButton;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton openLevelButton;
        private MetroFramework.Controls.MetroButton tilesEditorButton;
        private MetroFramework.Controls.MetroButton quitButton;
    }
}

