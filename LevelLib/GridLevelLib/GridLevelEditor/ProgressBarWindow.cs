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
    public partial class ProgressBarWindow : MetroFramework.Forms.MetroForm
    {
        public ProgressBarWindow(string title)
        {
            InitializeComponent();
            Text = title;
        }

        public void Update(float newProgress, string newDesc)
        {
            progressBar.Value = (int)newProgress;
            processDescLabel.Text = newDesc;
        }

    }
}
