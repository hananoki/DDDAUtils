namespace DDDAUtils {
	partial class Control_SkillComboBox {
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
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.comboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Dock = System.Windows.Forms.DockStyle.Right;
			this.radioButton2.Location = new System.Drawing.Point(463, 0);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(31, 23);
			this.radioButton2.TabIndex = 0;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "2";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Dock = System.Windows.Forms.DockStyle.Right;
			this.radioButton1.Location = new System.Drawing.Point(424, 0);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
			this.radioButton1.Size = new System.Drawing.Size(39, 23);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "1";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// comboBox
			// 
			this.comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox.FormattingEnabled = true;
			this.comboBox.Location = new System.Drawing.Point(0, 0);
			this.comboBox.Name = "comboBox";
			this.comboBox.Size = new System.Drawing.Size(424, 23);
			this.comboBox.TabIndex = 2;
			// 
			// Control_SkillComboBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.comboBox);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.radioButton2);
			this.Name = "Control_SkillComboBox";
			this.Size = new System.Drawing.Size(494, 23);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		public System.Windows.Forms.ComboBox comboBox;
	}
}
