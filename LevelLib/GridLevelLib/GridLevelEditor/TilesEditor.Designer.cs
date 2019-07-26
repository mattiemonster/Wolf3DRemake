namespace GridLevelEditor
{
    partial class TilesEditor
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
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tilesBox = new System.Windows.Forms.ListBox();
            this.loadTilesButton = new MetroFramework.Controls.MetroButton();
            this.saveTilesButton = new MetroFramework.Controls.MetroButton();
            this.removeTileButton = new MetroFramework.Controls.MetroButton();
            this.addTileButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.tilesetNameText = new MetroFramework.Controls.MetroTextBox();
            this.tilesetTexturesPathText = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.browseForTexturePathButton = new MetroFramework.Controls.MetroButton();
            this.savePropertiesButton = new MetroFramework.Controls.MetroButton();
            this.unsavedPropertiesWarning = new MetroFramework.Controls.MetroLabel();
            this.tilesUnsavedChanges = new MetroFramework.Controls.MetroLabel();
            this.copyTexturesCheckbox = new MetroFramework.Controls.MetroCheckBox();
            this.loadTilesFolderButton = new MetroFramework.Controls.MetroButton();
            this.tileNameTextbox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.tileImageList = new System.Windows.Forms.ImageList(this.components);
            this.loadImagesButton = new MetroFramework.Controls.MetroButton();
            this.texturesBox = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = null;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tilesBox
            // 
            this.tilesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tilesBox.Enabled = false;
            this.tilesBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.tilesBox.FormattingEnabled = true;
            this.tilesBox.Location = new System.Drawing.Point(42, 144);
            this.tilesBox.Name = "tilesBox";
            this.tilesBox.Size = new System.Drawing.Size(176, 251);
            this.tilesBox.TabIndex = 0;
            // 
            // loadTilesButton
            // 
            this.loadTilesButton.Location = new System.Drawing.Point(42, 117);
            this.loadTilesButton.Name = "loadTilesButton";
            this.loadTilesButton.Size = new System.Drawing.Size(85, 23);
            this.loadTilesButton.TabIndex = 1;
            this.loadTilesButton.Text = "Load";
            this.loadTilesButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loadTilesButton.Click += new System.EventHandler(this.LoadTilesButton_Click);
            // 
            // saveTilesButton
            // 
            this.saveTilesButton.Location = new System.Drawing.Point(42, 89);
            this.saveTilesButton.Name = "saveTilesButton";
            this.saveTilesButton.Size = new System.Drawing.Size(176, 23);
            this.saveTilesButton.TabIndex = 2;
            this.saveTilesButton.Text = "Save";
            this.saveTilesButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.saveTilesButton.Click += new System.EventHandler(this.SaveTilesButton_Click);
            // 
            // removeTileButton
            // 
            this.removeTileButton.Location = new System.Drawing.Point(133, 401);
            this.removeTileButton.Name = "removeTileButton";
            this.removeTileButton.Size = new System.Drawing.Size(85, 23);
            this.removeTileButton.TabIndex = 4;
            this.removeTileButton.Text = "Remove";
            this.removeTileButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // addTileButton
            // 
            this.addTileButton.Location = new System.Drawing.Point(42, 401);
            this.addTileButton.Name = "addTileButton";
            this.addTileButton.Size = new System.Drawing.Size(85, 23);
            this.addTileButton.TabIndex = 3;
            this.addTileButton.Text = "Add";
            this.addTileButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.addTileButton.Click += new System.EventHandler(this.AddTileButton_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroLabel1.Location = new System.Drawing.Point(42, 59);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(45, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Tiles";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroLabel2.Location = new System.Drawing.Point(288, 59);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(120, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Tile Properties";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroLabel3.Location = new System.Drawing.Point(570, 59);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(141, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Tileset Properties";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseStyleColors = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(573, 94);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(85, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Tileset Name";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tilesetNameText
            // 
            this.tilesetNameText.Location = new System.Drawing.Point(585, 118);
            this.tilesetNameText.Name = "tilesetNameText";
            this.tilesetNameText.Size = new System.Drawing.Size(174, 23);
            this.tilesetNameText.TabIndex = 9;
            this.tilesetNameText.Text = "New Tileset";
            this.tilesetNameText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tilesetNameText.TextChanged += new System.EventHandler(this.TilesetNameText_TextChanged);
            // 
            // tilesetTexturesPathText
            // 
            this.tilesetTexturesPathText.Location = new System.Drawing.Point(585, 177);
            this.tilesetTexturesPathText.Name = "tilesetTexturesPathText";
            this.tilesetTexturesPathText.Size = new System.Drawing.Size(174, 23);
            this.tilesetTexturesPathText.TabIndex = 11;
            this.tilesetTexturesPathText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tilesetTexturesPathText.TextChanged += new System.EventHandler(this.TilesetTexturesPathText_TextChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(573, 153);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(124, 19);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "Tileset Textures Path";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // browseForTexturePathButton
            // 
            this.browseForTexturePathButton.Location = new System.Drawing.Point(585, 205);
            this.browseForTexturePathButton.Name = "browseForTexturePathButton";
            this.browseForTexturePathButton.Size = new System.Drawing.Size(174, 23);
            this.browseForTexturePathButton.TabIndex = 12;
            this.browseForTexturePathButton.Text = "Browse";
            this.browseForTexturePathButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.browseForTexturePathButton.Click += new System.EventHandler(this.BrowseForTexturePathButton_Click);
            // 
            // savePropertiesButton
            // 
            this.savePropertiesButton.Location = new System.Drawing.Point(585, 372);
            this.savePropertiesButton.Name = "savePropertiesButton";
            this.savePropertiesButton.Size = new System.Drawing.Size(174, 23);
            this.savePropertiesButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.savePropertiesButton.TabIndex = 13;
            this.savePropertiesButton.Text = "Save";
            this.savePropertiesButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.savePropertiesButton.Click += new System.EventHandler(this.SavePropertiesButton_Click);
            // 
            // unsavedPropertiesWarning
            // 
            this.unsavedPropertiesWarning.AutoSize = true;
            this.unsavedPropertiesWarning.Location = new System.Drawing.Point(575, 398);
            this.unsavedPropertiesWarning.Name = "unsavedPropertiesWarning";
            this.unsavedPropertiesWarning.Size = new System.Drawing.Size(194, 19);
            this.unsavedPropertiesWarning.Style = MetroFramework.MetroColorStyle.Yellow;
            this.unsavedPropertiesWarning.TabIndex = 14;
            this.unsavedPropertiesWarning.Text = "Unsaved changes to properties!";
            this.unsavedPropertiesWarning.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.unsavedPropertiesWarning.UseStyleColors = true;
            // 
            // tilesUnsavedChanges
            // 
            this.tilesUnsavedChanges.AutoSize = true;
            this.tilesUnsavedChanges.Location = new System.Drawing.Point(87, 63);
            this.tilesUnsavedChanges.Name = "tilesUnsavedChanges";
            this.tilesUnsavedChanges.Size = new System.Drawing.Size(113, 19);
            this.tilesUnsavedChanges.Style = MetroFramework.MetroColorStyle.Yellow;
            this.tilesUnsavedChanges.TabIndex = 15;
            this.tilesUnsavedChanges.Text = "Unsaved changes!";
            this.tilesUnsavedChanges.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tilesUnsavedChanges.UseStyleColors = true;
            // 
            // copyTexturesCheckbox
            // 
            this.copyTexturesCheckbox.AutoSize = true;
            this.copyTexturesCheckbox.Location = new System.Drawing.Point(577, 248);
            this.copyTexturesCheckbox.Name = "copyTexturesCheckbox";
            this.copyTexturesCheckbox.Size = new System.Drawing.Size(181, 15);
            this.copyTexturesCheckbox.TabIndex = 16;
            this.copyTexturesCheckbox.Text = "Copy textures to save location";
            this.copyTexturesCheckbox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.copyTexturesCheckbox.UseVisualStyleBackColor = true;
            this.copyTexturesCheckbox.CheckedChanged += new System.EventHandler(this.CopyTexturesCheckbox_CheckedChanged);
            // 
            // loadTilesFolderButton
            // 
            this.loadTilesFolderButton.Location = new System.Drawing.Point(133, 117);
            this.loadTilesFolderButton.Name = "loadTilesFolderButton";
            this.loadTilesFolderButton.Size = new System.Drawing.Size(85, 23);
            this.loadTilesFolderButton.TabIndex = 17;
            this.loadTilesFolderButton.Text = "Load Folder";
            this.loadTilesFolderButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tileNameTextbox
            // 
            this.tileNameTextbox.Location = new System.Drawing.Point(300, 118);
            this.tileNameTextbox.Name = "tileNameTextbox";
            this.tileNameTextbox.Size = new System.Drawing.Size(174, 23);
            this.tileNameTextbox.TabIndex = 19;
            this.tileNameTextbox.Text = "New Tile";
            this.tileNameTextbox.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(288, 94);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(69, 19);
            this.metroLabel6.TabIndex = 18;
            this.metroLabel6.Text = "Tile Name";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(288, 154);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(74, 19);
            this.metroLabel7.TabIndex = 20;
            this.metroLabel7.Text = "Tile Texture";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tileImageList
            // 
            this.tileImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.tileImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.tileImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // loadImagesButton
            // 
            this.loadImagesButton.Location = new System.Drawing.Point(368, 154);
            this.loadImagesButton.Name = "loadImagesButton";
            this.loadImagesButton.Size = new System.Drawing.Size(106, 23);
            this.loadImagesButton.TabIndex = 21;
            this.loadImagesButton.Text = "Load Images";
            this.loadImagesButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loadImagesButton.Click += new System.EventHandler(this.LoadImagesButton_Click);
            // 
            // texturesBox
            // 
            this.texturesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.texturesBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.texturesBox.Location = new System.Drawing.Point(300, 183);
            this.texturesBox.Name = "texturesBox";
            this.texturesBox.Size = new System.Drawing.Size(174, 241);
            this.texturesBox.StateImageList = this.tileImageList;
            this.texturesBox.TabIndex = 23;
            this.texturesBox.UseCompatibleStateImageBehavior = false;
            this.texturesBox.View = System.Windows.Forms.View.SmallIcon;
            // 
            // TilesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.texturesBox);
            this.Controls.Add(this.loadImagesButton);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.tileNameTextbox);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.loadTilesFolderButton);
            this.Controls.Add(this.copyTexturesCheckbox);
            this.Controls.Add(this.tilesUnsavedChanges);
            this.Controls.Add(this.unsavedPropertiesWarning);
            this.Controls.Add(this.savePropertiesButton);
            this.Controls.Add(this.browseForTexturePathButton);
            this.Controls.Add(this.tilesetTexturesPathText);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.tilesetNameText);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.removeTileButton);
            this.Controls.Add(this.addTileButton);
            this.Controls.Add(this.saveTilesButton);
            this.Controls.Add(this.loadTilesButton);
            this.Controls.Add(this.tilesBox);
            this.MaximizeBox = false;
            this.Name = "TilesEditor";
            this.Resizable = false;
            this.Text = "Tiles Editor";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TilesEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private System.Windows.Forms.ListBox tilesBox;
        private MetroFramework.Controls.MetroButton loadTilesButton;
        private MetroFramework.Controls.MetroButton saveTilesButton;
        private MetroFramework.Controls.MetroButton removeTileButton;
        private MetroFramework.Controls.MetroButton addTileButton;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox tilesetNameText;
        private MetroFramework.Controls.MetroTextBox tilesetTexturesPathText;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton browseForTexturePathButton;
        private MetroFramework.Controls.MetroButton savePropertiesButton;
        private MetroFramework.Controls.MetroLabel unsavedPropertiesWarning;
        private MetroFramework.Controls.MetroLabel tilesUnsavedChanges;
        private MetroFramework.Controls.MetroCheckBox copyTexturesCheckbox;
        private MetroFramework.Controls.MetroButton loadTilesFolderButton;
        private MetroFramework.Controls.MetroTextBox tileNameTextbox;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.ImageList tileImageList;
        private MetroFramework.Controls.MetroButton loadImagesButton;
        private System.Windows.Forms.ListView texturesBox;
    }
}