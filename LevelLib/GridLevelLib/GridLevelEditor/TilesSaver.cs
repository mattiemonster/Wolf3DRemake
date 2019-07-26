using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GridLevelLib;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;

namespace GridLevelEditor
{
    public class TilesSaver
    {
        public static ProgressBarWindow barWindow;
        public static Tiles currentTiles;
        public static string currentPath;
        public static string currentFileName;
        public static int currentFile;
        public static int fileAmount;

        public static BackgroundWorker worker;

        public static void Init()
        {
            worker = new BackgroundWorker();
            
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = false;

            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.ProgressChanged += worker_ProgressChanged;
        }

        public static void SaveTilesAndTextures(string path, Tiles tiles)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            // Save tileset
            currentTiles = tiles;
            currentPath = path;

            if (!Directory.Exists(path + "/Textures"))
                Directory.CreateDirectory(path + "/Textures");

            if (!worker.IsBusy)
            {
                barWindow = new ProgressBarWindow("Copying Textures");
                barWindow.Show();
                worker.RunWorkerAsync();
            }

            tiles.SetTexturesFolder("/Textures/");
            tiles.SaveTiles(path + "/Tileset.xml");
        }

        public static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; i <= 10; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    string[] textureFiles = Directory.GetFiles(currentTiles.textureFolder, "*.png");
                    fileAmount = textureFiles.Length;
                    int amountDone = 0;
                    foreach (string file in textureFiles)
                    {

                        try
                        {
                            File.Copy(file, currentPath + "/Textures/" + Path.GetFileName(file), true);
                            currentFile++;
                            currentFileName = Path.GetFileName(file);
                            worker.ReportProgress(((100 / textureFiles.Length) * amountDone));
                        }
                        catch (Exception ex)
                        {
                            StreamWriter logFile = File.CreateText(string.Format("{0}_TextureCopyError.log", DateTime.Now.ToString("dd-M-yy_HHmm")));
                            logFile.WriteLine(string.Format("Attempted to copy textures from {0} to {1} but failed.",
                                file, "/Textures/" + Path.GetFileName(file)));
                            logFile.WriteLine(string.Format("Time: {0}", DateTime.Now.ToString()));
                            logFile.WriteLine(string.Format("Exception log: {0}", ex.Message));
                            logFile.WriteLine(string.Format("Inner Exception log: {0}", ex.InnerException.Message));
                            logFile.Flush();
                            logFile.Close();
                        }
                    }
                }
            }
        }

        public static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            barWindow.Update(((100 / fileAmount) * currentFile), "Current file: " + currentFileName);
        }

        // This event handler deals with the results of the background operation.
        public static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                return;
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Failed to copy textures.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                barWindow.Close();
            }
        }

        public static Tiles LoadTilesAndTextures(string path)
        {
            Tiles tiles = new Tiles();

            if (!Directory.Exists(path))
                return null;

            tiles = XmlLoader.DeSerializeObject<Tiles>(path + "Tileset.xml");

            tiles.textureFolder = path + "/Textures/";
            if (!Directory.Exists(tiles.textureFolder))
                Directory.CreateDirectory(tiles.textureFolder);

            return tiles;
        }
    }

}
