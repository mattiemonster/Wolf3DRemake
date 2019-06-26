using System;
using System.Windows.Forms;
using System.IO;
using GridLevelLib;

namespace GridLevelEditor
{
    public partial class TilesEditor : MetroFramework.Forms.MetroForm
    {
        Menu menu;
        string texturePath;
        bool hasSetTexturePath = false;
        string savePath;

        Tiles tiles = new Tiles(Directory.GetCurrentDirectory());

        public TilesEditor(Menu menu)
        {
            InitializeComponent();
            this.menu = menu;

            tiles.SetName("New Tileset");
            tilesetTexturesPathText.Text = Directory.GetCurrentDirectory();

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
            tiles.SetName(tilesetNameText.Text);
            tiles.SetTexturesFolder(tilesetTexturesPathText.Text);
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
            if (string.IsNullOrEmpty(savePath))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Save Tileset";
                sfd.Filter = "Tileset Files|*.tiles|All files|*.*";
                sfd.DefaultExt = "tiles";
                DialogResult result = sfd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    tiles.SaveTiles(sfd.FileName);
                    savePath = sfd.FileName;
                    tilesUnsavedChanges.Visible = false;
                }
            } else
            {
                tiles.SaveTiles(savePath);
            }
        }

        private void LoadTilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Tileset";
            ofd.Filter = "Tileset Files|*.tiles";
            ofd.DefaultExt = "tiles";
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                tiles.LoadTiles(ofd.FileName);
                savePath = ofd.FileName;
            }
        }
    }
}
