namespace PDFvanish
{
    partial class PDFvanish
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFvanish));
            this.fileList = new System.Windows.Forms.ListBox();
            this.actionBtn = new System.Windows.Forms.Button();
            this.selectFileBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clearListBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileList
            // 
            this.fileList.AllowDrop = true;
            this.fileList.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileList.FormattingEnabled = true;
            this.fileList.ItemHeight = 31;
            this.fileList.Items.AddRange(new object[] {
            "Drag & Drop Items Here"});
            this.fileList.Location = new System.Drawing.Point(17, 85);
            this.fileList.Name = "fileList";
            this.fileList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fileList.Size = new System.Drawing.Size(800, 252);
            this.fileList.TabIndex = 0;
            this.fileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileList_DragDrop);
            this.fileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileList_DragEnter);
            this.fileList.DoubleClick += new System.EventHandler(this.fileList_DoubleClick);
            // 
            // actionBtn
            // 
            this.actionBtn.Enabled = false;
            this.actionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionBtn.Location = new System.Drawing.Point(301, 371);
            this.actionBtn.Name = "actionBtn";
            this.actionBtn.Size = new System.Drawing.Size(253, 50);
            this.actionBtn.TabIndex = 1;
            this.actionBtn.Text = "Remove Metadata";
            this.actionBtn.UseVisualStyleBackColor = true;
            this.actionBtn.Click += new System.EventHandler(this.actionBtn_Click);
            // 
            // selectFileBtn
            // 
            this.selectFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFileBtn.Location = new System.Drawing.Point(561, 49);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(125, 30);
            this.selectFileBtn.TabIndex = 2;
            this.selectFileBtn.Text = "Select File...";
            this.selectFileBtn.UseVisualStyleBackColor = true;
            this.selectFileBtn.Click += new System.EventHandler(this.selectFileBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "PDFvanish - Remove all metadata from your PDF files";
            // 
            // clearListBtn
            // 
            this.clearListBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearListBtn.Location = new System.Drawing.Point(692, 49);
            this.clearListBtn.Name = "clearListBtn";
            this.clearListBtn.Size = new System.Drawing.Size(125, 30);
            this.clearListBtn.TabIndex = 4;
            this.clearListBtn.Text = "Clear List";
            this.clearListBtn.UseVisualStyleBackColor = true;
            this.clearListBtn.Click += new System.EventHandler(this.clearListBtn_Click);
            // 
            // PDFvanish
            // 
            this.AcceptButton = this.selectFileBtn;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.clearListBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectFileBtn);
            this.Controls.Add(this.actionBtn);
            this.Controls.Add(this.fileList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PDFvanish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDFvanish v1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Button actionBtn;
        private System.Windows.Forms.Button selectFileBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearListBtn;
    }
}

