using System;
using System.Windows.Forms;
using System.IO;
using GridLevelLib;
using WK.Libraries.BetterFolderBrowserNS;
using System.Drawing;

namespace GridLevelEditor
{
    public partial class TilesEditor : MetroFramework.Forms.MetroForm
    {
        Menu menu;
        string currentTilesPath;
        bool copyTextures = true;
        bool changedCopyTexturesSetting = false;
        string savePath;

        Tiles tiles = new Tiles(Directory.GetCurrentDirectory());

        public TilesEditor(Menu menu)
        {
            InitializeComponent();
            this.menu = menu;

            tiles.SetName("New Tileset");
            tilesetTexturesPathText.Text = Directory.GetCurrentDirectory();
            copyTexturesCheckbox.Checked = copyTextures;

            tilesUnsavedChanges.Visible = false;
            unsavedPropertiesWarning.Visible = false;
        }

        private void TilesEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu.Show();
        }

        private void SavePropertiesButton_Click(object sender, EventArgs e)
        {
            SaveProperties();
            tilesUnsavedChanges.Visible = true;
        }

        public void SaveProperties()
        {
            tiles.copyTextures = copyTexturesCheckbox.Checked;
            tiles.SetName(tilesetNameText.Text);
            tiles.SetTexturesFolder(tilesetTexturesPathText.Text);
            copyTextures = copyTexturesCheckbox.Checked;
            unsavedPropertiesWarning.Visible = false;
        }

        private void TilesetNameText_TextChanged(object sender, EventArgs e)
        {
            unsavedPropertiesWarning.Visible = true;
        }

        private void TilesetTexturesPathText_TextChanged(object sender, EventArgs e)
        {
            unsavedPropertiesWarning.Visible = true;
        }

        private void SaveTilesButton_Click(object sender, EventArgs e)
        {
            SaveProperties();
            if (string.IsNullOrEmpty(savePath) || changedCopyTexturesSetting)
            {
                bool saveTexturesToFolder = copyTexturesCheckbox.Checked;

                if (saveTexturesToFolder)
                {
                    BetterFolderBrowser fb = new BetterFolderBrowser();
                    fb.Title = "Browse for tileset save location";
                    fb.RootFolder = "C:\\";
                    fb.Multiselect = false;

                    if (fb.ShowDialog(this) == DialogResult.OK)
                    {
                        tiles.copyTextures = true;
                        savePath = fb.SelectedPath;
                        TilesSaver.SaveTilesAndTextures(fb.SelectedPath, tiles);
                        tilesUnsavedChanges.Visible = false;
                    }
                }
                else
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "Save Tileset";
                    sfd.Filter = "Tileset Files|*.xml|All files|*.*";
                    sfd.DefaultExt = "xml";
                    DialogResult result = sfd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        tiles.copyTextures = false;
                        tiles.SaveTiles(sfd.FileName);
                        savePath = sfd.FileName;
                        tilesUnsavedChanges.Visible = false;
                    }
                }
            } else
            {
                if (!copyTexturesCheckbox.Checked)
                {
                    tiles.SaveTiles(savePath);
                    tilesUnsavedChanges.Visible = false;
                } else
                {
                    tiles.copyTextures = true;
                    TilesSaver.SaveTilesAndTextures(savePath, tiles);
                    tilesUnsavedChanges.Visible = false;
                }

            }
        }

        private void LoadTilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Tileset";
            ofd.Filter = "Tileset Files|*.xml";
            ofd.DefaultExt = "xml";
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                tiles.LoadTiles(ofd.FileName);
                RefreshValues();
                savePath = ofd.FileName;
                currentTilesPath = ofd.FileName;
            }
        }

        public void RefreshValues()
        {
            tilesetNameText.Text = tiles.name;
            tilesetTexturesPathText.Text = tiles.textureFolder;
            copyTexturesCheckbox.Checked = tiles.copyTextures;

            // TODO load tiles

            unsavedPropertiesWarning.Visible = false;
            tilesUnsavedChanges.Visible = false;
        }

        private void CopyTexturesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            unsavedPropertiesWarning.Visible = true;

            if (!changedCopyTexturesSetting)
                changedCopyTexturesSetting = true;
            else
                changedCopyTexturesSetting = false;
        }

        private void BrowseForTexturePathButton_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser fb = new BetterFolderBrowser();
            fb.Title = "Browse for tileset textures folder";
            fb.RootFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            fb.Multiselect = false;

            if (fb.ShowDialog(this) == DialogResult.OK)
            {
                tilesetTexturesPathText.Text = fb.SelectedPath;
            }
        }

        private void LoadImagesButton_Click(object sender, EventArgs e)
        {
            texturesBox.SmallImageList = tileImageList;

            if (string.IsNullOrEmpty(tiles.textureFolder))
            {
                MessageBox.Show("Cannot load images as the textures folder has not been set.", "Error loading images",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (tiles.textureFolder == "/Textures/")
            {
                LoadImagesFromPath(string.Format("{0}/Textures/", savePath));
            } else
            {
                LoadImagesFromPath(tiles.textureFolder);
            }
        }

        public void LoadImagesFromPath(string path)
        {
            string[] textureFiles = Directory.GetFiles(path, "*.png");
            texturesBox.Items.Clear();
            tileImageList.Images.Clear();
            foreach (string file in textureFiles)
            {
                tileImageList.Images.Add(Path.GetFileNameWithoutExtension(file), Image.FromFile(file));
                texturesBox.Items.Add(Path.GetFileNameWithoutExtension(file), Path.GetFileNameWithoutExtension(file));
            }
        }

        private void AddTileButton_Click(object sender, EventArgs e)
        {
            tiles.CreateTile("New Tile", null);
        }
    }
}
