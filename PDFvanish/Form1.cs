using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Path = System.IO.Path;

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
            // If we drop a file && form enabled
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && fileList.Enabled) {
                
                string[] dropped = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filepath in dropped)
                {
                    if (Path.GetExtension(filepath).Equals(".pdf"))
                    {
                        // if textbox empty
                        if (fileList.Items.Count == 1 && fileList.Items[0].Equals("Drag & Drop Items Here"))
                        {
                            fileList.Font = new System.Drawing.Font(fileList.Font.FontFamily, 10, FontStyle.Regular);
                            fileList.Items.Clear();
                        }
                        if (!fileList.Items.Contains(filepath)) fileList.Items.Add(filepath);
                        actionBtn.Enabled = true;
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
            DateTime mintime = new DateTime(1601, 1, 1, 0, 0, 1, DateTimeKind.Utc);

            // file by file we have to remove the metadata
            foreach (string file in fileList.Items)
            {
                string outFileName = file.Replace(".pdf", "_vanish.pdf");
                if (File.Exists(file))
                {
                    // remove info from pdf
                    PdfReader R = new PdfReader(file);
                    R.Info["Title"] = null;
                    R.Info["Author"] = null;
                    R.Info["Subject"] = null;
                    R.Info["Keywords"] = null;
                    R.Info["Creator"] = null;
                    R.Info["Producer"] = null;
                    R.Info["CreationDate"] = null;
                    R.Info["ModDate"] = null;
                    R.Info["Trapped"] = null;

                    // save the pdf
                    using (FileStream FS = new FileStream(outFileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (Document Doc = new Document())
                        {
                            //Use the PdfCopy object to copy each page
                            using (PdfCopy writer = new PdfCopy(Doc, FS))
                            {
                                Doc.Open();
                                //Loop through each page
                                for (int i = 1; i <= R.NumberOfPages; i++)
                                {
                                    //Add it to the new document
                                    writer.AddPage(writer.GetImportedPage(R, i));
                                }
                                Doc.Close();
                            }
                        }
                    }

                    // modify windows system dates
                    // Set the file's creation and modification dates to the minimum possible value
                    if (File.Exists(outFileName))
                    {
                        File.SetLastWriteTimeUtc(outFileName, mintime);
                        File.SetCreationTimeUtc(outFileName, mintime);
                        File.SetLastAccessTimeUtc(outFileName, mintime);
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
            actionBtn.Enabled = false;
            fileList.Enabled = false;
            MessageBox.Show("Metadata Removed and output files produced!", "PDFvanish v1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && fileList.Enabled)
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
            if (fileList.Enabled)
            {
                //remove item if we double click
                if (fileList.SelectedItem != null)
                {
                    fileList.Items.Remove(fileList.SelectedItem);
                    if (fileList.Items.Count == 0)
                    {
                        fileList.Font = new System.Drawing.Font(fileList.Font.FontFamily, (float)16.2, FontStyle.Regular);
                        fileList.Items.Add("Drag & Drop Items Here");
                        actionBtn.Focus();
                        this.AcceptButton = actionBtn;
                    }
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
                            // if textbox empty or if textbox disabled
                            if ((fileList.Items.Count == 1 && fileList.Items[0].Equals("Drag & Drop Items Here")) || !fileList.Enabled)
                            {
                                fileList.Font = new System.Drawing.Font(fileList.Font.FontFamily, 10, FontStyle.Regular);
                                fileList.Items.Clear();
                            }
                            if (!fileList.Items.Contains(filepath)) fileList.Items.Add(filepath);
                            actionBtn.Focus();
                            actionBtn.Enabled = true;
                            this.AcceptButton = actionBtn;
                            fileList.Enabled = true;
                        }
                    }
                }
            }
        }

        private void clearListBtn_Click(object sender, EventArgs e)
        {
            fileList.Items.Clear();
            fileList.Font = new System.Drawing.Font(fileList.Font.FontFamily, (float)16.2, FontStyle.Regular);
            fileList.Items.Add("Drag & Drop Items Here");
            fileList.Enabled = true;
            actionBtn.Enabled = false;
            selectFileBtn.Focus();
            this.AcceptButton = selectFileBtn;
        }
    }
}
