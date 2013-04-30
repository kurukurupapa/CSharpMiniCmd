namespace MiniFileList
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
            this.btnClose = new System.Windows.Forms.Button();
            this.tbInDir = new System.Windows.Forms.TextBox();
            this.tbOutFile = new System.Windows.Forms.TextBox();
            this.labelInDir = new System.Windows.Forms.Label();
            this.labelOutFile = new System.Windows.Forms.Label();
            this.btnInDir = new System.Windows.Forms.Button();
            this.btnOutFile = new System.Windows.Forms.Button();
            this.dlgInDir = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgOutFile = new System.Windows.Forms.SaveFileDialog();
            this.btnExec = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelExclusion = new System.Windows.Forms.Label();
            this.lboxExclusion = new System.Windows.Forms.ListBox();
            this.btnExclusionAdd = new System.Windows.Forms.Button();
            this.btnExclusionDel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboxSendToShortcut = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(505, 271);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbInDir
            // 
            this.tbInDir.Location = new System.Drawing.Point(76, 20);
            this.tbInDir.Name = "tbInDir";
            this.tbInDir.Size = new System.Drawing.Size(405, 19);
            this.tbInDir.TabIndex = 1;
            // 
            // tbOutFile
            // 
            this.tbOutFile.Location = new System.Drawing.Point(84, 20);
            this.tbOutFile.Name = "tbOutFile";
            this.tbOutFile.Size = new System.Drawing.Size(397, 19);
            this.tbOutFile.TabIndex = 6;
            // 
            // labelInDir
            // 
            this.labelInDir.AutoSize = true;
            this.labelInDir.Location = new System.Drawing.Point(6, 23);
            this.labelInDir.Name = "labelInDir";
            this.labelInDir.Size = new System.Drawing.Size(64, 12);
            this.labelInDir.TabIndex = 0;
            this.labelInDir.Text = "検索フォルダ";
            // 
            // labelOutFile
            // 
            this.labelOutFile.AutoSize = true;
            this.labelOutFile.Location = new System.Drawing.Point(6, 23);
            this.labelOutFile.Name = "labelOutFile";
            this.labelOutFile.Size = new System.Drawing.Size(63, 12);
            this.labelOutFile.TabIndex = 0;
            this.labelOutFile.Text = "出力ファイル";
            // 
            // btnInDir
            // 
            this.btnInDir.Location = new System.Drawing.Point(487, 18);
            this.btnInDir.Name = "btnInDir";
            this.btnInDir.Size = new System.Drawing.Size(75, 23);
            this.btnInDir.TabIndex = 2;
            this.btnInDir.Text = "選択...";
            this.btnInDir.UseVisualStyleBackColor = true;
            this.btnInDir.Click += new System.EventHandler(this.btnInDir_Click);
            // 
            // btnOutFile
            // 
            this.btnOutFile.Location = new System.Drawing.Point(487, 18);
            this.btnOutFile.Name = "btnOutFile";
            this.btnOutFile.Size = new System.Drawing.Size(75, 23);
            this.btnOutFile.TabIndex = 7;
            this.btnOutFile.Text = "選択...";
            this.btnOutFile.UseVisualStyleBackColor = true;
            this.btnOutFile.Click += new System.EventHandler(this.btnOutFile_Click);
            // 
            // dlgOutFile
            // 
            this.dlgOutFile.Filter = "カンマ区切りファイル|*.csv";
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(424, 271);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(75, 23);
            this.btnExec.TabIndex = 8;
            this.btnExec.Text = "実行";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(6, 15);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(556, 63);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "待機中";
            // 
            // labelExclusion
            // 
            this.labelExclusion.AutoSize = true;
            this.labelExclusion.Location = new System.Drawing.Point(6, 52);
            this.labelExclusion.Name = "labelExclusion";
            this.labelExclusion.Size = new System.Drawing.Size(64, 12);
            this.labelExclusion.TabIndex = 0;
            this.labelExclusion.Text = "除外フォルダ";
            // 
            // lboxExclusion
            // 
            this.lboxExclusion.FormattingEnabled = true;
            this.lboxExclusion.ItemHeight = 12;
            this.lboxExclusion.Items.AddRange(new object[] {
            ""});
            this.lboxExclusion.Location = new System.Drawing.Point(76, 47);
            this.lboxExclusion.Name = "lboxExclusion";
            this.lboxExclusion.Size = new System.Drawing.Size(405, 52);
            this.lboxExclusion.TabIndex = 3;
            // 
            // btnExclusionAdd
            // 
            this.btnExclusionAdd.Location = new System.Drawing.Point(487, 47);
            this.btnExclusionAdd.Name = "btnExclusionAdd";
            this.btnExclusionAdd.Size = new System.Drawing.Size(75, 23);
            this.btnExclusionAdd.TabIndex = 4;
            this.btnExclusionAdd.Text = "追加...";
            this.btnExclusionAdd.UseVisualStyleBackColor = true;
            this.btnExclusionAdd.Click += new System.EventHandler(this.btnExclusionAdd_Click);
            // 
            // btnExclusionDel
            // 
            this.btnExclusionDel.Location = new System.Drawing.Point(487, 76);
            this.btnExclusionDel.Name = "btnExclusionDel";
            this.btnExclusionDel.Size = new System.Drawing.Size(75, 23);
            this.btnExclusionDel.TabIndex = 5;
            this.btnExclusionDel.Text = "削除";
            this.btnExclusionDel.UseVisualStyleBackColor = true;
            this.btnExclusionDel.Click += new System.EventHandler(this.btnExclusionDel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelInDir);
            this.groupBox1.Controls.Add(this.tbInDir);
            this.groupBox1.Controls.Add(this.btnInDir);
            this.groupBox1.Controls.Add(this.labelExclusion);
            this.groupBox1.Controls.Add(this.lboxExclusion);
            this.groupBox1.Controls.Add(this.btnExclusionAdd);
            this.groupBox1.Controls.Add(this.btnExclusionDel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 108);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "対象ファイル";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelOutFile);
            this.groupBox2.Controls.Add(this.tbOutFile);
            this.groupBox2.Controls.Add(this.btnOutFile);
            this.groupBox2.Location = new System.Drawing.Point(12, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 52);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出力ファイル";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelStatus);
            this.groupBox3.Location = new System.Drawing.Point(12, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(568, 81);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "処理状況";
            // 
            // cboxSendToShortcut
            // 
            this.cboxSendToShortcut.AutoSize = true;
            this.cboxSendToShortcut.Location = new System.Drawing.Point(12, 275);
            this.cboxSendToShortcut.Name = "cboxSendToShortcut";
            this.cboxSendToShortcut.Size = new System.Drawing.Size(199, 16);
            this.cboxSendToShortcut.TabIndex = 13;
            this.cboxSendToShortcut.Text = "送るフォルダにショートカットを作成する";
            this.cboxSendToShortcut.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 306);
            this.Controls.Add(this.cboxSendToShortcut);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.btnClose);
            this.Name = "MainForm";
            this.Text = "MiniFileList";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbInDir;
        private System.Windows.Forms.TextBox tbOutFile;
        private System.Windows.Forms.Label labelInDir;
        private System.Windows.Forms.Label labelOutFile;
        private System.Windows.Forms.Button btnInDir;
        private System.Windows.Forms.Button btnOutFile;
        private System.Windows.Forms.FolderBrowserDialog dlgInDir;
        private System.Windows.Forms.SaveFileDialog dlgOutFile;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelExclusion;
        private System.Windows.Forms.ListBox lboxExclusion;
        private System.Windows.Forms.Button btnExclusionAdd;
        private System.Windows.Forms.Button btnExclusionDel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cboxSendToShortcut;
    }
}

