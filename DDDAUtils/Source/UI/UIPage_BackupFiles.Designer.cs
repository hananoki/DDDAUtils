namespace DDDAUtils {
	partial class UIPage_BackupFiles {
		/// <summary> 
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIPage_BackupFiles));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripComboBox_Profile = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.listView_Files = new DDDAUtils.ListView_Files();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox_Profile,
            this.toolStripButton1,
            this.toolStripButton2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(701, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripComboBox_Profile
			// 
			this.toolStripComboBox_Profile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.toolStripComboBox_Profile.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.toolStripComboBox_Profile.Name = "toolStripComboBox_Profile";
			this.toolStripComboBox_Profile.Size = new System.Drawing.Size(121, 25);
			this.toolStripComboBox_Profile.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(118, 22);
			this.toolStripButton1.Text = "最新の情報に更新";
			this.toolStripButton1.Click += new System.EventHandler(this.Click_UpdateFileList);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(191, 22);
			this.toolStripButton2.Text = "選択したセーブファイルに入れ替える";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton_Click_ReplaceSaveFile);
			// 
			// listView_Files
			// 
			this.listView_Files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listView_Files.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView_Files.FullRowSelect = true;
			this.listView_Files.GridLines = true;
			this.listView_Files.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView_Files.Location = new System.Drawing.Point(0, 25);
			this.listView_Files.Name = "listView_Files";
			this.listView_Files.Size = new System.Drawing.Size(701, 406);
			this.listView_Files.TabIndex = 1;
			this.listView_Files.UseCompatibleStateImageBehavior = false;
			this.listView_Files.View = System.Windows.Forms.View.Details;
			this.listView_Files.VirtualMode = true;
			this.listView_Files.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView_Files_KeyUp);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "名前";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "更新日付";
			// 
			// checkBox2
			// 
			this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(533, 0);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.checkBox2.Size = new System.Drawing.Size(168, 24);
			this.checkBox2.TabIndex = 4;
			this.checkBox2.Tag = DDDAUtils.EConfigOptions.AutoSave;
			this.checkBox2.Text = "変更があったらバックアップする";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// UIPage_BackupFiles
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.listView_Files);
			this.Controls.Add(this.toolStrip1);
			this.Name = "UIPage_BackupFiles";
			this.Size = new System.Drawing.Size(701, 431);
			this.Load += new System.EventHandler(this.UI_BackupFiles_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private DDDAUtils.ListView_Files listView_Files;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox_Profile;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
	}
}
