namespace DDDAUtils {
	partial class UIPage_Status {
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 15);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(415, 109);
			this.panel1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Level 1 ～10";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(0, 124);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.label2.Size = new System.Drawing.Size(84, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Level 11 ～ 100";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label3.Location = new System.Drawing.Point(0, 231);
			this.label3.Name = "label3";
			this.label3.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.label3.Size = new System.Drawing.Size(93, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "Level 101 ～ 200";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Control;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 147);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(415, 84);
			this.panel2.TabIndex = 2;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.Control;
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 254);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(415, 84);
			this.panel3.TabIndex = 3;
			// 
			// UIPage_Status
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Name = "UIPage_Status";
			this.Size = new System.Drawing.Size(415, 390);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
	}
}
