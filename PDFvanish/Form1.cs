using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

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
            ;
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
