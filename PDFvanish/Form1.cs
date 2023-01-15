using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PDFvanish
{
    public partial class PDFvanish : Form
    {
        public PDFvanish()
        {
            InitializeComponent();
        }

        private void fileList_DragDrop(object sender, DragEventArgs e)
        {
            // If we drop a file
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                
                string[] dropped = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filepath in dropped)
                {
                    if (Path.GetExtension(filepath).Equals(".pdf"))
                    {
                        // if textbox empty
                        if (fileList.Items.Count == 1 && fileList.Items[0].Equals("Drag & Drop Items Here"))
                        {
                            fileList.Font = new Font(fileList.Font.FontFamily, 10, FontStyle.Regular);
                            fileList.Items.Clear();
                        }
                        if (!fileList.Items.Contains(filepath)) fileList.Items.Add(filepath);
                        actionBtn.Focus();
                        this.AcceptButton = actionBtn;
                    }
                }
            }

        }

        private void actionBtn_Click(object sender, EventArgs e)
        {
            actionBtn.Enabled = false;
            List<string> inw = new List<string>();
            List<string> outw = new List<string>();
            List<string> errorw = new List<string>();

            // file by file we have to remove the metadata
            foreach (string file in fileList.Items)
            {
                string outFileName = file.Replace(".pdf", "_vanish.pdf");
                // optimized method for modifying txt large files
                // modified from https://stackoverflow.com/a/46519381
                if (File.Exists(file))
                {
                    using (var sw = new StreamWriter(outFileName))
                    using (var fs = File.OpenRead(file))
                    using (var sr = new StreamReader(fs, Encoding.GetEncoding("iso-8859-1"))) //use iso encoding because pdf weird
                    {
                        string line, newLine;

                        while ((line = sr.ReadLine()) != null)
                        {
                            // replace actual metadata with empty strings
                            // regex modified from https://stackoverflow.com/a/7899162
                            newLine = line;
                            newLine = Regex.Replace(newLine, "\\/Author[ ]?\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)", "/Author()");
                            newLine = Regex.Replace(newLine, "\\/Creator[ ]?\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)", "/Creator()");
                            newLine = Regex.Replace(newLine, "\\/Subject[ ]?\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)", "/Subject()");
                            newLine = Regex.Replace(newLine, "\\/Title[ ]?\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)", "/Title()");
                            newLine = Regex.Replace(newLine, "\\/Keywords[ ]?\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)", "/Keywords()");
                            newLine = Regex.Replace(newLine, "\\/Producer[ ]?\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)", "/Producer()");
                            newLine = Regex.Replace(newLine, "\\/CreationDate[ ]?\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)", "/CreationDate()");
                            newLine = Regex.Replace(newLine, "\\/ModDate[ ]?\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)", "/ModDate()");
                            newLine = Regex.Replace(newLine, "\\/PTEX.Fullbanner[ ]?\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)", "/PTEX.Fullbanner()");


                            // todo: modify windows system dates


                            sw.WriteLine(newLine);
                        }
                    }
                    inw.Add(file); outw.Add(outFileName);
                }
                else errorw.Add(file);
            }
            foreach (string s in errorw) fileList.Items.Remove(s);
            for (int i = 0; i < inw.Count; i++)
            {
                fileList.Items.Remove(inw[i]);
                fileList.Items.Add(outw[i]);
            }
            MessageBox.Show("Metadata Removed and output files produced!", "PDFvanish v1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            actionBtn.Enabled = true;

        }

        private void fileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void fileList_DoubleClick(object sender, EventArgs e)
        {
            //remove item if we double click
            if (fileList.SelectedItem != null)
            {
                fileList.Items.Remove(fileList.SelectedItem);
                if (fileList.Items.Count == 0)
                {
                    fileList.Font = new Font(fileList.Font.FontFamily, (float)16.2, FontStyle.Regular);
                    fileList.Items.Add("Drag & Drop Items Here");
                    actionBtn.Focus();
                    this.AcceptButton = actionBtn;
                }
            }
        }

        private void selectFileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog()) {
                file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                file.Filter = "PDF Files (*.pdf)|*.pdf";
                file.Multiselect = true;
                if (file.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filepath in file.FileNames)
                    {
                        if (Path.GetExtension(filepath).Equals(".pdf"))
                        {
                            // if textbox empty
                            if (fileList.Items.Count == 1 && fileList.Items[0].Equals("Drag & Drop Items Here"))
                            {
                                fileList.Font = new Font(fileList.Font.FontFamily, 10, FontStyle.Regular);
                                fileList.Items.Clear();
                            }
                            if (!fileList.Items.Contains(filepath)) fileList.Items.Add(filepath);
                            actionBtn.Focus();
                            this.AcceptButton = actionBtn;
                        }
                    }
                }
            }
        }

        private void clearListBtn_Click(object sender, EventArgs e)
        {
            fileList.Items.Clear();
            fileList.Font = new Font(fileList.Font.FontFamily, (float)16.2, FontStyle.Regular);
            fileList.Items.Add("Drag & Drop Items Here");
            selectFileBtn.Focus();
            this.AcceptButton = selectFileBtn;
        }
    }
}
