using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridLevelEditor
{
    public partial class Menu : MetroFramework.Forms.MetroForm
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TilesEditorButton_Click(object sender, EventArgs e)
        {
            TilesEditor tilesEditor = new TilesEditor(this);
            tilesEditor.Show();
            Hide();
        }
    }
}
