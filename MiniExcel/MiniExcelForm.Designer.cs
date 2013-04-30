namespace MiniExcel
{
    partial class MiniExcelForm
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.chkSendToShortcut = new System.Windows.Forms.CheckBox();
            this.checkBoxLineNo = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxFileName = new System.Windows.Forms.CheckBox();
            this.checkBoxSheetName = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCompleteMsg = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(12, 227);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(93, 227);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // chkSendToShortcut
            // 
            this.chkSendToShortcut.AutoSize = true;
            this.chkSendToShortcut.Location = new System.Drawing.Point(20, 205);
            this.chkSendToShortcut.Name = "chkSendToShortcut";
            this.chkSendToShortcut.Size = new System.Drawing.Size(199, 16);
            this.chkSendToShortcut.TabIndex = 5;
            this.chkSendToShortcut.Text = "送るフォルダにショートカットを作成する";
            this.chkSendToShortcut.UseVisualStyleBackColor = true;
            // 
            // checkBoxLineNo
            // 
            this.checkBoxLineNo.AutoSize = true;
            this.checkBoxLineNo.Location = new System.Drawing.Point(136, 88);
            this.checkBoxLineNo.Name = "checkBoxLineNo";
            this.checkBoxLineNo.Size = new System.Drawing.Size(67, 16);
            this.checkBoxLineNo.TabIndex = 6;
            this.checkBoxLineNo.Text = "出力する";
            this.checkBoxLineNo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxFormat);
            this.groupBox1.Controls.Add(this.checkBoxSheetName);
            this.groupBox1.Controls.Add(this.checkBoxFileName);
            this.groupBox1.Controls.Add(this.checkBoxLineNo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 137);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "テキスト変換時設定";
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Items.AddRange(new object[] {
            "CSV",
            "TSV"});
            this.comboBoxFormat.Location = new System.Drawing.Point(136, 18);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(121, 20);
            this.comboBoxFormat.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "出力形式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "行番号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "ファイル名";
            // 
            // checkBoxFileName
            // 
            this.checkBoxFileName.AutoSize = true;
            this.checkBoxFileName.Location = new System.Drawing.Point(136, 44);
            this.checkBoxFileName.Name = "checkBoxFileName";
            this.checkBoxFileName.Size = new System.Drawing.Size(67, 16);
            this.checkBoxFileName.TabIndex = 6;
            this.checkBoxFileName.Text = "出力する";
            this.checkBoxFileName.UseVisualStyleBackColor = true;
            // 
            // checkBoxSheetName
            // 
            this.checkBoxSheetName.AutoSize = true;
            this.checkBoxSheetName.Location = new System.Drawing.Point(136, 66);
            this.checkBoxSheetName.Name = "checkBoxSheetName";
            this.checkBoxSheetName.Size = new System.Drawing.Size(67, 16);
            this.checkBoxSheetName.TabIndex = 6;
            this.checkBoxSheetName.Text = "出力する";
            this.checkBoxSheetName.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "シート名";
            // 
            // chkCompleteMsg
            // 
            this.chkCompleteMsg.AutoSize = true;
            this.chkCompleteMsg.Location = new System.Drawing.Point(20, 183);
            this.chkCompleteMsg.Name = "chkCompleteMsg";
            this.chkCompleteMsg.Size = new System.Drawing.Size(250, 16);
            this.chkCompleteMsg.TabIndex = 8;
            this.chkCompleteMsg.Text = "バックアップ完了時にメッセージボックスを表示する";
            this.chkCompleteMsg.UseVisualStyleBackColor = true;
            // 
            // MiniExcelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.chkCompleteMsg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkSendToShortcut);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "MiniExcelForm";
            this.Text = "MiniExcel設定";
            this.Shown += new System.EventHandler(this.MiniExcelForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox chkSendToShortcut;
        private System.Windows.Forms.CheckBox checkBoxLineNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxSheetName;
        private System.Windows.Forms.CheckBox checkBoxFileName;
        private System.Windows.Forms.CheckBox chkCompleteMsg;
    }
}

