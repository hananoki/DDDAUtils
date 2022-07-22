namespace DDDAUtils {
	partial class UIPage_Skill {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIPage_Skill));
			this.panelL = new System.Windows.Forms.Panel();
			this.panelR = new System.Windows.Forms.Panel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelL
			// 
			this.panelL.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelL.Location = new System.Drawing.Point(0, 25);
			this.panelL.Name = "panelL";
			this.panelL.Size = new System.Drawing.Size(130, 361);
			this.panelL.TabIndex = 0;
			// 
			// panelR
			// 
			this.panelR.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelR.Location = new System.Drawing.Point(130, 25);
			this.panelR.Name = "panelR";
			this.panelR.Size = new System.Drawing.Size(444, 361);
			this.panelR.TabIndex = 1;
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(574, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(179, 22);
			this.toolStripButton1.Text = "獲得したスキルを全てリセットする";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// UIPage_Skill
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelR);
			this.Controls.Add(this.panelL);
			this.Controls.Add(this.toolStrip1);
			this.Name = "UIPage_Skill";
			this.Size = new System.Drawing.Size(574, 386);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panelL;
		private System.Windows.Forms.Panel panelR;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
	}
}
