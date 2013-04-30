namespace MiniBackup
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSpecifiedDir = new System.Windows.Forms.TextBox();
            this.rdbSpecifiedDir = new System.Windows.Forms.RadioButton();
            this.rdbSameDir = new System.Windows.Forms.RadioButton();
            this.chkCompleteMsg = new System.Windows.Forms.CheckBox();
            this.chkSendToShortcut = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(16, 224);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(104, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSpecifiedDir);
            this.groupBox1.Controls.Add(this.rdbSpecifiedDir);
            this.groupBox1.Controls.Add(this.rdbSameDir);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 128);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "バックアップ先";
            // 
            // txtSpecifiedDir
            // 
            this.txtSpecifiedDir.Location = new System.Drawing.Point(32, 88);
            this.txtSpecifiedDir.Name = "txtSpecifiedDir";
            this.txtSpecifiedDir.Size = new System.Drawing.Size(288, 19);
            this.txtSpecifiedDir.TabIndex = 3;
            // 
            // rdbSpecifiedDir
            // 
            this.rdbSpecifiedDir.AutoSize = true;
            this.rdbSpecifiedDir.Location = new System.Drawing.Point(16, 64);
            this.rdbSpecifiedDir.Name = "rdbSpecifiedDir";
            this.rdbSpecifiedDir.Size = new System.Drawing.Size(82, 16);
            this.rdbSpecifiedDir.TabIndex = 1;
            this.rdbSpecifiedDir.TabStop = true;
            this.rdbSpecifiedDir.Text = "フォルダ作成";
            this.rdbSpecifiedDir.UseVisualStyleBackColor = true;
            // 
            // rdbSameDir
            // 
            this.rdbSameDir.AutoSize = true;
            this.rdbSameDir.Location = new System.Drawing.Point(16, 32);
            this.rdbSameDir.Name = "rdbSameDir";
            this.rdbSameDir.Size = new System.Drawing.Size(134, 16);
            this.rdbSameDir.TabIndex = 0;
            this.rdbSameDir.TabStop = true;
            this.rdbSameDir.Text = "対象ファイルと同じ場所";
            this.rdbSameDir.UseVisualStyleBackColor = true;
            // 
            // chkCompleteMsg
            // 
            this.chkCompleteMsg.AutoSize = true;
            this.chkCompleteMsg.Location = new System.Drawing.Point(32, 160);
            this.chkCompleteMsg.Name = "chkCompleteMsg";
            this.chkCompleteMsg.Size = new System.Drawing.Size(250, 16);
            this.chkCompleteMsg.TabIndex = 3;
            this.chkCompleteMsg.Text = "バックアップ完了時にメッセージボックスを表示する";
            this.chkCompleteMsg.UseVisualStyleBackColor = true;
            // 
            // chkSendToShortcut
            // 
            this.chkSendToShortcut.AutoSize = true;
            this.chkSendToShortcut.Location = new System.Drawing.Point(32, 192);
            this.chkSendToShortcut.Name = "chkSendToShortcut";
            this.chkSendToShortcut.Size = new System.Drawing.Size(199, 16);
            this.chkSendToShortcut.TabIndex = 4;
            this.chkSendToShortcut.Text = "送るフォルダにショートカットを作成する";
            this.chkSendToShortcut.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 263);
            this.Controls.Add(this.chkSendToShortcut);
            this.Controls.Add(this.chkCompleteMsg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "frmMain";
            this.Text = "MiniBackup 設定";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSpecifiedDir;
        private System.Windows.Forms.RadioButton rdbSpecifiedDir;
        private System.Windows.Forms.RadioButton rdbSameDir;
        private System.Windows.Forms.CheckBox chkCompleteMsg;
        private System.Windows.Forms.CheckBox chkSendToShortcut;
    }
}

