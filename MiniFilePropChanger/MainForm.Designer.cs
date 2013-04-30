namespace MiniFilePropChanger
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gviewFiles = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastWriteTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SummaryPropsFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.summaryPropsAuthorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryPropsCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryPropsCommentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryPropsCompanyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryPropsKeywordsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryPropsLastSavedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryPropsManagerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryPropsRevisionNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryPropsSubjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryPropsTemplateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryPropsTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryPropsVersionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filePropertiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fileDataSet = new MiniFilePropChanger.FileDataSet();
            this.btnExec = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.dlgAddFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgAddOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.addFileBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.addFolderBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.execBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btnFileSelectForm = new System.Windows.Forms.Button();
            this.cboxSendToShortcut = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gviewFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filePropertiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // gviewFiles
            // 
            this.gviewFiles.AllowUserToAddRows = false;
            this.gviewFiles.AllowUserToDeleteRows = false;
            this.gviewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gviewFiles.AutoGenerateColumns = false;
            this.gviewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gviewFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.lastWriteTimeDataGridViewTextBoxColumn,
            this.SummaryPropsFlag,
            this.summaryPropsAuthorDataGridViewTextBoxColumn,
            this.summaryPropsCategoryDataGridViewTextBoxColumn,
            this.summaryPropsCommentsDataGridViewTextBoxColumn,
            this.summaryPropsCompanyDataGridViewTextBoxColumn,
            this.summaryPropsKeywordsDataGridViewTextBoxColumn,
            this.summaryPropsLastSavedByDataGridViewTextBoxColumn,
            this.summaryPropsManagerDataGridViewTextBoxColumn,
            this.summaryPropsRevisionNumberDataGridViewTextBoxColumn,
            this.summaryPropsSubjectDataGridViewTextBoxColumn,
            this.summaryPropsTemplateDataGridViewTextBoxColumn,
            this.summaryPropsTitleDataGridViewTextBoxColumn,
            this.summaryPropsVersionDataGridViewTextBoxColumn});
            this.gviewFiles.DataSource = this.filePropertiesBindingSource;
            this.gviewFiles.Location = new System.Drawing.Point(12, 41);
            this.gviewFiles.Name = "gviewFiles";
            this.gviewFiles.RowHeadersWidth = 20;
            this.gviewFiles.RowTemplate.Height = 21;
            this.gviewFiles.Size = new System.Drawing.Size(760, 280);
            this.gviewFiles.TabIndex = 4;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.nameDataGridViewTextBoxColumn.Frozen = true;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.sizeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            this.sizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastWriteTimeDataGridViewTextBoxColumn
            // 
            this.lastWriteTimeDataGridViewTextBoxColumn.DataPropertyName = "LastWriteTime";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lastWriteTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.lastWriteTimeDataGridViewTextBoxColumn.HeaderText = "LastWriteTime";
            this.lastWriteTimeDataGridViewTextBoxColumn.Name = "lastWriteTimeDataGridViewTextBoxColumn";
            this.lastWriteTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SummaryPropsFlag
            // 
            this.SummaryPropsFlag.DataPropertyName = "SummaryPropsFlag";
            this.SummaryPropsFlag.HeaderText = "SummaryPropsFlag";
            this.SummaryPropsFlag.Name = "SummaryPropsFlag";
            this.SummaryPropsFlag.ReadOnly = true;
            this.SummaryPropsFlag.Visible = false;
            // 
            // summaryPropsAuthorDataGridViewTextBoxColumn
            // 
            this.summaryPropsAuthorDataGridViewTextBoxColumn.DataPropertyName = "SummaryPropsAuthor";
            this.summaryPropsAuthorDataGridViewTextBoxColumn.HeaderText = "Author";
            this.summaryPropsAuthorDataGridViewTextBoxColumn.Name = "summaryPropsAuthorDataGridViewTextBoxColumn";
            // 
            // summaryPropsCategoryDataGridViewTextBoxColumn
            // 
            this.summaryPropsCategoryDataGridViewTextBoxColumn.DataPropertyName = "SummaryPropsCategory";
            this.summaryPropsCategoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.summaryPropsCategoryDataGridViewTextBoxColumn.Name = "summaryPropsCategoryDataGridViewTextBoxColumn";
            // 
            // summaryPropsCommentsDataGridViewTextBoxColumn
            // 
            this.summaryPropsCommentsDataGridViewTextBoxColumn.DataPropertyName = "SummaryPropsComments";
            this.summaryPropsCommentsDataGridViewTextBoxColumn.HeaderText = "Comments";
            this.summaryPropsCommentsDataGridViewTextBoxColumn.Name = "summaryPropsCommentsDataGridViewTextBoxColumn";
            // 
            // summaryPropsCompanyDataGridViewTextBoxColumn
            // 
            this.summaryPropsCompanyDataGridViewTextBoxColumn.DataPropertyName = "SummaryPropsCompany";
            this.summaryPropsCompanyDataGridViewTextBoxColumn.HeaderText = "Company";
            this.summaryPropsCompanyDataGridViewTextBoxColumn.Name = "summaryPropsCompanyDataGridViewTextBoxColumn";
            // 
            // summaryPropsKeywordsDataGridViewTextBoxColumn
            // 
            this.summaryPropsKeywordsDataGridViewTextBoxColumn.DataPropertyName = "SummaryPropsKeywords";
            this.summaryPropsKeywordsDataGridViewTextBoxColumn.HeaderText = "Keywords";
            this.summaryPropsKeywordsDataGridViewTextBoxColumn.Name = "summaryPropsKeywordsDataGridViewTextBoxColumn";
            // 
            // summaryPropsLastSavedByDataGridViewTextBoxColumn
            // 
            this.summaryPropsLastSavedByDataGridViewTextBoxColumn.DataPropertyName = "SummaryPropsLastSavedBy";
            this.summaryPropsLastSavedByDataGridViewTextBoxColumn.HeaderText = "LastSavedBy";
            this.summaryPropsLastSavedByDataGridViewTextBoxColumn.Name = "summaryPropsLastSavedByDataGridViewTextBoxColumn";
            // 
            // summaryPropsManagerDataGridViewTextBoxColumn
            // 
            this.summaryPropsManagerDataGridViewTextBoxColumn.DataPropertyName = "SummaryPropsManager";
            this.summaryPropsManagerDataGridViewTextBoxColumn.HeaderText = "Manager";
            this.summaryPropsManagerDataGridViewTextBoxColumn.Name = "summaryPropsManagerDataGridViewTextBoxColumn";
            // 
            // summaryPropsRevisionNumberDataGridViewTextBoxColumn
            // 
            this.summaryPropsRevisionNumberDataGridViewTextBoxColumn.DataPropertyName = "SummaryPropsRevisionNumber";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.summaryPropsRevisionNumberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.summaryPropsRevisionNumberDataGridViewTextBoxColumn.HeaderText = "RevisionNumber";
            this.summaryPropsRevisionNumberDataGridViewTextBoxColumn.Name = "summaryPropsRevisionNumberDataGridViewTextBoxColumn";
            this.summaryPropsRevisionNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // summaryPropsSubjectDataGridViewTextBoxColumn
            // 
            this.summaryPropsSubjectDataGridViewTextBoxColumn.DataPropertyName = "SummaryPropsSubject";
            this.summaryPropsSubjectDataGridViewTextBoxColumn.HeaderText = "Subject";
            this.summaryPropsSubjectDataGridViewTextBoxColumn.Name = "summaryPropsSubjectDataGridViewTextBoxColumn";
            // 
            // summaryPropsTemplateDataGridViewTextBoxColumn
            // 
            this.summaryPropsTemplateDataGridViewTextBoxColumn.DataPropertyName = "SummaryPropsTemplate";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.summaryPropsTemplateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.summaryPropsTemplateDataGridViewTextBoxColumn.HeaderText = "Template";
            this.summaryPropsTemplateDataGridViewTextBoxColumn.Name = "summaryPropsTemplateDataGridViewTextBoxColumn";
            this.summaryPropsTemplateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // summaryPropsTitleDataGridViewTextBoxColumn
            // 
            this.summaryPropsTitleDataGridViewTextBoxColumn.DataPropertyName = "SummaryPropsTitle";
            this.summaryPropsTitleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.summaryPropsTitleDataGridViewTextBoxColumn.Name = "summaryPropsTitleDataGridViewTextBoxColumn";
            // 
            // summaryPropsVersionDataGridViewTextBoxColumn
            // 
            this.summaryPropsVersionDataGridViewTextBoxColumn.DataPropertyName = "SummaryPropsVersion";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.summaryPropsVersionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.summaryPropsVersionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.summaryPropsVersionDataGridViewTextBoxColumn.Name = "summaryPropsVersionDataGridViewTextBoxColumn";
            this.summaryPropsVersionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // filePropertiesBindingSource
            // 
            this.filePropertiesBindingSource.DataMember = "FileProperties";
            this.filePropertiesBindingSource.DataSource = this.fileDataSet;
            // 
            // fileDataSet
            // 
            this.fileDataSet.DataSetName = "FileDataSet";
            this.fileDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnExec
            // 
            this.btnExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExec.Location = new System.Drawing.Point(697, 327);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(75, 23);
            this.btnExec.TabIndex = 7;
            this.btnExec.Text = "反映";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(12, 12);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(75, 23);
            this.btnAddFolder.TabIndex = 0;
            this.btnAddFolder.Text = "フォルダ追加";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(174, 12);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "ファイル除外";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(93, 12);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(75, 23);
            this.btnAddFile.TabIndex = 1;
            this.btnAddFile.Text = "ファイル追加";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // dlgAddOpenFile
            // 
            this.dlgAddOpenFile.FileName = "openFileDialog1";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(616, 327);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "一覧保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.Filter = "カンマ区切りファイル|*.csv";
            // 
            // addFileBackgroundWorker
            // 
            this.addFileBackgroundWorker.WorkerReportsProgress = true;
            this.addFileBackgroundWorker.WorkerSupportsCancellation = true;
            this.addFileBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.addFileBackgroundWorker_DoWork);
            this.addFileBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.execBackgroundWorker_RunWorkerCompleted);
            this.addFileBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.execBackgroundWorker_ProgressChanged);
            // 
            // addFolderBackgroundWorker
            // 
            this.addFolderBackgroundWorker.WorkerReportsProgress = true;
            this.addFolderBackgroundWorker.WorkerSupportsCancellation = true;
            this.addFolderBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.addFolderBackgroundWorker_DoWork);
            this.addFolderBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.execBackgroundWorker_RunWorkerCompleted);
            this.addFolderBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.execBackgroundWorker_ProgressChanged);
            // 
            // execBackgroundWorker
            // 
            this.execBackgroundWorker.WorkerReportsProgress = true;
            this.execBackgroundWorker.WorkerSupportsCancellation = true;
            this.execBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.execBackgroundWorker_DoWork);
            this.execBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.execBackgroundWorker_RunWorkerCompleted);
            this.execBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.execBackgroundWorker_ProgressChanged);
            // 
            // btnFileSelectForm
            // 
            this.btnFileSelectForm.Location = new System.Drawing.Point(255, 12);
            this.btnFileSelectForm.Name = "btnFileSelectForm";
            this.btnFileSelectForm.Size = new System.Drawing.Size(150, 23);
            this.btnFileSelectForm.TabIndex = 3;
            this.btnFileSelectForm.Text = "テキストでファイル追加/削除";
            this.btnFileSelectForm.UseVisualStyleBackColor = true;
            this.btnFileSelectForm.Click += new System.EventHandler(this.btnFileSelectForm_Click);
            // 
            // cboxSendToShortcut
            // 
            this.cboxSendToShortcut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxSendToShortcut.AutoSize = true;
            this.cboxSendToShortcut.Location = new System.Drawing.Point(12, 331);
            this.cboxSendToShortcut.Name = "cboxSendToShortcut";
            this.cboxSendToShortcut.Size = new System.Drawing.Size(199, 16);
            this.cboxSendToShortcut.TabIndex = 5;
            this.cboxSendToShortcut.Text = "送るフォルダにショートカットを作成する";
            this.cboxSendToShortcut.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.cboxSendToShortcut);
            this.Controls.Add(this.btnFileSelectForm);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAddFolder);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.gviewFiles);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gviewFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filePropertiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gviewFiles;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.BindingSource filePropertiesBindingSource;
        private FileDataSet fileDataSet;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.FolderBrowserDialog dlgAddFolderBrowser;
        private System.Windows.Forms.OpenFileDialog dlgAddOpenFile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.ComponentModel.BackgroundWorker addFileBackgroundWorker;
        private System.ComponentModel.BackgroundWorker addFolderBackgroundWorker;
        private System.ComponentModel.BackgroundWorker execBackgroundWorker;
        private System.Windows.Forms.Button btnFileSelectForm;
        private System.Windows.Forms.CheckBox cboxSendToShortcut;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastWriteTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SummaryPropsFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryPropsAuthorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryPropsCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryPropsCommentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryPropsCompanyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryPropsKeywordsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryPropsLastSavedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryPropsManagerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryPropsRevisionNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryPropsSubjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryPropsTemplateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryPropsTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryPropsVersionDataGridViewTextBoxColumn;
    }
}