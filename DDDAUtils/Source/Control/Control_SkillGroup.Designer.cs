namespace DDDAUtils {
	partial class Control_SkillGroup {
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
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox.AutoSize = true;
			this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox.Location = new System.Drawing.Point(0, 0);
			this.groupBox.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
			this.groupBox.Name = "groupBox1";
			this.groupBox.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
			this.groupBox.Size = new System.Drawing.Size(454, 163);
			this.groupBox.TabIndex = 5;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "groupBox1";
			// 
			// Control_SkillComboBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox);
			this.Name = "Control_SkillComboBox";
			this.Size = new System.Drawing.Size(454, 163);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.GroupBox groupBox;
	}
}
