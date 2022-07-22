
using HananokiLib;
using System.Windows.Forms;

namespace DDDAUtils {
	partial class MainForm {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.tabControl_Main = new System.Windows.Forms.TabControl();
			this.tabPage_Chara = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage_Equip = new System.Windows.Forms.TabPage();
			this.tabPage_Skill = new System.Windows.Forms.TabPage();
			this.tabPage_Ability = new System.Windows.Forms.TabPage();
			this.tabPage_Personality = new System.Windows.Forms.TabPage();
			this.tabPage_Talk = new System.Windows.Forms.TabPage();
			this.tabPage_EditData = new System.Windows.Forms.TabPage();
			this.tabPage_Status = new System.Windows.Forms.TabPage();
			this.tabPage_Property = new System.Windows.Forms.TabPage();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.tabPage_Reset = new System.Windows.Forms.TabPage();
			this.toolStrip_CharaData = new System.Windows.Forms.ToolStrip();
			this.toolStripButton_Export = new System.Windows.Forms.ToolStripButton();
			this.toolStripSplitButton_Import01 = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripSplitButton_Import02 = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripSplitButton_Import03 = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripSplitButton_Import04 = new System.Windows.Forms.ToolStripSplitButton();
			this.tabPage_Backup = new System.Windows.Forms.TabPage();
			this.tabPage_Settings = new System.Windows.Forms.TabPage();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.panel_Main = new System.Windows.Forms.Panel();
			this.statusStrip.SuspendLayout();
			this.tabControl_Main.SuspendLayout();
			this.tabPage_Chara.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage_Property.SuspendLayout();
			this.toolStrip_CharaData.SuspendLayout();
			this.panel_Main.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.GripMargin = new System.Windows.Forms.Padding(0);
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip.Location = new System.Drawing.Point(0, 412);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(814, 22);
			this.statusStrip.TabIndex = 8;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 22);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.linkLabel1.Location = new System.Drawing.Point(713, 0);
			this.linkLabel1.Margin = new System.Windows.Forms.Padding(0);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Padding = new System.Windows.Forms.Padding(0, 4, 4, 0);
			this.linkLabel1.Size = new System.Drawing.Size(101, 19);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "セーブフォルダを開く";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// tabControl_Main
			// 
			this.tabControl_Main.Controls.Add(this.tabPage_Chara);
			this.tabControl_Main.Controls.Add(this.tabPage_Backup);
			this.tabControl_Main.Controls.Add(this.tabPage_Settings);
			this.tabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl_Main.ImageList = this.imageList1;
			this.tabControl_Main.Location = new System.Drawing.Point(0, 0);
			this.tabControl_Main.Margin = new System.Windows.Forms.Padding(0);
			this.tabControl_Main.Name = "tabControl_Main";
			this.tabControl_Main.SelectedIndex = 0;
			this.tabControl_Main.Size = new System.Drawing.Size(814, 412);
			this.tabControl_Main.TabIndex = 13;
			this.tabControl_Main.Enter += new System.EventHandler(this.tabControl_Main_Enter);
			// 
			// tabPage_Chara
			// 
			this.tabPage_Chara.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage_Chara.Controls.Add(this.splitContainer1);
			this.tabPage_Chara.ImageIndex = 0;
			this.tabPage_Chara.Location = new System.Drawing.Point(4, 24);
			this.tabPage_Chara.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_Chara.Name = "tabPage_Chara";
			this.tabPage_Chara.Size = new System.Drawing.Size(806, 384);
			this.tabPage_Chara.TabIndex = 0;
			this.tabPage_Chara.Text = "キャラクター";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.treeView1);
			this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel2);
			this.splitContainer1.Panel2.Controls.Add(this.toolStrip_CharaData);
			this.splitContainer1.Size = new System.Drawing.Size(806, 384);
			this.splitContainer1.SplitterDistance = 193;
			this.splitContainer1.TabIndex = 8;
			// 
			// treeView1
			// 
			this.treeView1.BackColor = System.Drawing.SystemColors.Window;
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.FullRowSelect = true;
			this.treeView1.HideSelection = false;
			this.treeView1.ImageIndex = 0;
			this.treeView1.ImageList = this.imageList2;
			this.treeView1.Location = new System.Drawing.Point(0, 25);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = 0;
			this.treeView1.ShowRootLines = false;
			this.treeView1.Size = new System.Drawing.Size(193, 359);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// imageList2
			// 
			this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList2.Images.SetKeyName(0, "人物アイコン.png");
			this.imageList2.Images.SetKeyName(1, "XMLアイコン.png");
			this.imageList2.Images.SetKeyName(2, "ブックマークのアイコン4.png");
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton11,
            this.toolStripButton12});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(193, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton11
			// 
			this.toolStripButton11.AutoToolTip = false;
			this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
			this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton11.Name = "toolStripButton11";
			this.toolStripButton11.Size = new System.Drawing.Size(72, 22);
			this.toolStripButton11.Text = "読み込む";
			this.toolStripButton11.Click += new System.EventHandler(this.toolStripButton_Click_ReadSaveFile);
			// 
			// toolStripButton12
			// 
			this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
			this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton12.Name = "toolStripButton12";
			this.toolStripButton12.Size = new System.Drawing.Size(70, 22);
			this.toolStripButton12.Text = "保存する";
			this.toolStripButton12.Click += new System.EventHandler(this.Click_UpdateSaveFile);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tabControl2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 25);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(609, 359);
			this.panel2.TabIndex = 13;
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tabPage_Equip);
			this.tabControl2.Controls.Add(this.tabPage_Skill);
			this.tabControl2.Controls.Add(this.tabPage_Ability);
			this.tabControl2.Controls.Add(this.tabPage_Personality);
			this.tabControl2.Controls.Add(this.tabPage_Talk);
			this.tabControl2.Controls.Add(this.tabPage_EditData);
			this.tabControl2.Controls.Add(this.tabPage_Status);
			this.tabControl2.Controls.Add(this.tabPage_Property);
			this.tabControl2.Controls.Add(this.tabPage_Reset);
			this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl2.Location = new System.Drawing.Point(0, 0);
			this.tabControl2.Margin = new System.Windows.Forms.Padding(0);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.Padding = new System.Drawing.Point(0, 0);
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(609, 359);
			this.tabControl2.TabIndex = 16;
			// 
			// tabPage_Equip
			// 
			this.tabPage_Equip.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage_Equip.Location = new System.Drawing.Point(4, 24);
			this.tabPage_Equip.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_Equip.Name = "tabPage_Equip";
			this.tabPage_Equip.Size = new System.Drawing.Size(601, 331);
			this.tabPage_Equip.TabIndex = 0;
			this.tabPage_Equip.Text = "装備";
			this.tabPage_Equip.Enter += new System.EventHandler(this.tabPage_Equip_Enter);
			// 
			// tabPage_Skill
			// 
			this.tabPage_Skill.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage_Skill.Location = new System.Drawing.Point(4, 24);
			this.tabPage_Skill.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_Skill.Name = "tabPage_Skill";
			this.tabPage_Skill.Size = new System.Drawing.Size(601, 331);
			this.tabPage_Skill.TabIndex = 3;
			this.tabPage_Skill.Text = "スキル";
			this.tabPage_Skill.Enter += new System.EventHandler(this.tabPage_Skill_Enter);
			// 
			// tabPage_Ability
			// 
			this.tabPage_Ability.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage_Ability.Location = new System.Drawing.Point(4, 24);
			this.tabPage_Ability.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_Ability.Name = "tabPage_Ability";
			this.tabPage_Ability.Size = new System.Drawing.Size(601, 331);
			this.tabPage_Ability.TabIndex = 4;
			this.tabPage_Ability.Text = "アビリティ";
			this.tabPage_Ability.Enter += new System.EventHandler(this.tabPage_Ability_Enter);
			// 
			// tabPage_Personality
			// 
			this.tabPage_Personality.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage_Personality.Location = new System.Drawing.Point(4, 24);
			this.tabPage_Personality.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_Personality.Name = "tabPage_Personality";
			this.tabPage_Personality.Size = new System.Drawing.Size(601, 331);
			this.tabPage_Personality.TabIndex = 5;
			this.tabPage_Personality.Text = "性格";
			this.tabPage_Personality.Enter += new System.EventHandler(this.tabPage_Personality_Enter);
			// 
			// tabPage_Talk
			// 
			this.tabPage_Talk.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage_Talk.Location = new System.Drawing.Point(4, 24);
			this.tabPage_Talk.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_Talk.Name = "tabPage_Talk";
			this.tabPage_Talk.Size = new System.Drawing.Size(601, 331);
			this.tabPage_Talk.TabIndex = 6;
			this.tabPage_Talk.Text = "口調";
			this.tabPage_Talk.Enter += new System.EventHandler(this.tabPage_Talk_Enter);
			// 
			// tabPage_EditData
			// 
			this.tabPage_EditData.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage_EditData.Location = new System.Drawing.Point(4, 24);
			this.tabPage_EditData.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_EditData.Name = "tabPage_EditData";
			this.tabPage_EditData.Size = new System.Drawing.Size(601, 331);
			this.tabPage_EditData.TabIndex = 7;
			this.tabPage_EditData.Text = "エディットデータ";
			this.tabPage_EditData.Enter += new System.EventHandler(this.tabPage_EditData_Enter);
			// 
			// tabPage_Status
			// 
			this.tabPage_Status.BackColor = System.Drawing.Color.Transparent;
			this.tabPage_Status.Location = new System.Drawing.Point(4, 24);
			this.tabPage_Status.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_Status.Name = "tabPage_Status";
			this.tabPage_Status.Size = new System.Drawing.Size(601, 331);
			this.tabPage_Status.TabIndex = 8;
			this.tabPage_Status.Text = "ステータス";
			this.tabPage_Status.Enter += new System.EventHandler(this.tabPage_Status_Enter);
			// 
			// tabPage_Property
			// 
			this.tabPage_Property.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage_Property.Controls.Add(this.propertyGrid1);
			this.tabPage_Property.Location = new System.Drawing.Point(4, 24);
			this.tabPage_Property.Name = "tabPage_Property";
			this.tabPage_Property.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_Property.Size = new System.Drawing.Size(601, 331);
			this.tabPage_Property.TabIndex = 1;
			this.tabPage_Property.Text = "プロパティ・内部データ";
			this.tabPage_Property.Enter += new System.EventHandler(this.tabPage_Property_Enter);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized;
			this.propertyGrid1.Size = new System.Drawing.Size(595, 325);
			this.propertyGrid1.TabIndex = 11;
			this.propertyGrid1.ToolbarVisible = false;
			// 
			// tabPage_Reset
			// 
			this.tabPage_Reset.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage_Reset.Location = new System.Drawing.Point(4, 24);
			this.tabPage_Reset.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_Reset.Name = "tabPage_Reset";
			this.tabPage_Reset.Size = new System.Drawing.Size(601, 331);
			this.tabPage_Reset.TabIndex = 2;
			this.tabPage_Reset.Text = "リセット機能";
			// 
			// toolStrip_CharaData
			// 
			this.toolStrip_CharaData.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip_CharaData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Export,
            this.toolStripSplitButton_Import01,
            this.toolStripSplitButton_Import02,
            this.toolStripSplitButton_Import03,
            this.toolStripSplitButton_Import04});
			this.toolStrip_CharaData.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_CharaData.Name = "toolStrip_CharaData";
			this.toolStrip_CharaData.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip_CharaData.Size = new System.Drawing.Size(609, 25);
			this.toolStrip_CharaData.TabIndex = 9;
			this.toolStrip_CharaData.Text = "toolStrip2";
			// 
			// toolStripButton_Export
			// 
			this.toolStripButton_Export.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton_Export.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Export.Image")));
			this.toolStripButton_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Export.Name = "toolStripButton_Export";
			this.toolStripButton_Export.Size = new System.Drawing.Size(158, 22);
			this.toolStripButton_Export.Text = "キャラクタデータをエクスポート";
			this.toolStripButton_Export.Click += new System.EventHandler(this.toolStripButton_Export_CharaData);
			// 
			// toolStripSplitButton_Import01
			// 
			this.toolStripSplitButton_Import01.AutoToolTip = false;
			this.toolStripSplitButton_Import01.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_Import01.Image")));
			this.toolStripSplitButton_Import01.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton_Import01.Name = "toolStripSplitButton_Import01";
			this.toolStripSplitButton_Import01.Size = new System.Drawing.Size(84, 22);
			this.toolStripSplitButton_Import01.Tag = "0";
			this.toolStripSplitButton_Import01.Text = "プレイヤー";
			this.toolStripSplitButton_Import01.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
			// 
			// toolStripSplitButton_Import02
			// 
			this.toolStripSplitButton_Import02.AutoToolTip = false;
			this.toolStripSplitButton_Import02.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_Import02.Image")));
			this.toolStripSplitButton_Import02.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton_Import02.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
			this.toolStripSplitButton_Import02.Name = "toolStripSplitButton_Import02";
			this.toolStripSplitButton_Import02.Size = new System.Drawing.Size(92, 22);
			this.toolStripSplitButton_Import02.Tag = "1";
			this.toolStripSplitButton_Import02.Text = "メインポーン";
			this.toolStripSplitButton_Import02.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
			// 
			// toolStripSplitButton_Import03
			// 
			this.toolStripSplitButton_Import03.AutoToolTip = false;
			this.toolStripSplitButton_Import03.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_Import03.Image")));
			this.toolStripSplitButton_Import03.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton_Import03.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
			this.toolStripSplitButton_Import03.Name = "toolStripSplitButton_Import03";
			this.toolStripSplitButton_Import03.Size = new System.Drawing.Size(108, 22);
			this.toolStripSplitButton_Import03.Tag = "2";
			this.toolStripSplitButton_Import03.Text = "サポートポーン1";
			this.toolStripSplitButton_Import03.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
			// 
			// toolStripSplitButton_Import04
			// 
			this.toolStripSplitButton_Import04.AutoToolTip = false;
			this.toolStripSplitButton_Import04.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_Import04.Image")));
			this.toolStripSplitButton_Import04.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton_Import04.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
			this.toolStripSplitButton_Import04.Name = "toolStripSplitButton_Import04";
			this.toolStripSplitButton_Import04.Size = new System.Drawing.Size(108, 22);
			this.toolStripSplitButton_Import04.Tag = "3";
			this.toolStripSplitButton_Import04.Text = "サポートポーン2";
			this.toolStripSplitButton_Import04.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
			// 
			// tabPage_Backup
			// 
			this.tabPage_Backup.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage_Backup.ImageIndex = 1;
			this.tabPage_Backup.Location = new System.Drawing.Point(4, 24);
			this.tabPage_Backup.Name = "tabPage_Backup";
			this.tabPage_Backup.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_Backup.Size = new System.Drawing.Size(806, 384);
			this.tabPage_Backup.TabIndex = 1;
			this.tabPage_Backup.Text = "自動バックアップ";
			this.tabPage_Backup.Enter += new System.EventHandler(this.tabPage2_Enter);
			// 
			// tabPage_Settings
			// 
			this.tabPage_Settings.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage_Settings.ImageIndex = 2;
			this.tabPage_Settings.Location = new System.Drawing.Point(4, 24);
			this.tabPage_Settings.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_Settings.Name = "tabPage_Settings";
			this.tabPage_Settings.Size = new System.Drawing.Size(806, 384);
			this.tabPage_Settings.TabIndex = 2;
			this.tabPage_Settings.Text = "設定";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "メモアイコン.png");
			this.imageList1.Images.SetKeyName(1, "データベースアイコン1.png");
			this.imageList1.Images.SetKeyName(2, "無料の設定歯車アイコン.png");
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "名前";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "更新日時";
			// 
			// panel_Main
			// 
			this.panel_Main.Controls.Add(this.linkLabel1);
			this.panel_Main.Controls.Add(this.tabControl_Main);
			this.panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Main.Location = new System.Drawing.Point(0, 0);
			this.panel_Main.Name = "panel_Main";
			this.panel_Main.Size = new System.Drawing.Size(814, 412);
			this.panel_Main.TabIndex = 10;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(814, 434);
			this.Controls.Add(this.panel_Main);
			this.Controls.Add(this.statusStrip);
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.Text = "DDDAUtils";
			this.Activated += new System.EventHandler(this.MainForm_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.tabControl_Main.ResumeLayout(false);
			this.tabPage_Chara.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage_Property.ResumeLayout(false);
			this.toolStrip_CharaData.ResumeLayout(false);
			this.toolStrip_CharaData.PerformLayout();
			this.panel_Main.ResumeLayout(false);
			this.panel_Main.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private StatusStrip statusStrip;
		private SplitContainer splitContainer1;
		public TreeView treeView1;
		private Panel panel_Main;
		private ToolStrip toolStrip_CharaData;
		private ToolStripButton toolStripButton_Export;
		private ToolStripStatusLabel toolStripStatusLabel1;
		private PropertyGrid propertyGrid1;
		private Panel panel2;
		private ToolStrip toolStrip1;
		private ToolStripButton toolStripButton11;
		private ToolStripButton toolStripButton12;
		private TabControl tabControl_Main;
		private TabPage tabPage_Chara;
		private TabPage tabPage_Backup;
		private LinkLabel linkLabel1;
		private TabPage tabPage_Settings;
		private ToolStripSplitButton toolStripSplitButton_Import01;
		private ToolStripSplitButton toolStripSplitButton_Import02;
		private ToolStripSplitButton toolStripSplitButton_Import03;
		private ToolStripSplitButton toolStripSplitButton_Import04;
		private TabControl tabControl2;
		private TabPage tabPage_Equip;
		private TabPage tabPage_Property;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private TabPage tabPage_Reset;
		private TabPage tabPage_Skill;
		private TabPage tabPage_Ability;
		private TabPage tabPage_Personality;
		private TabPage tabPage_Talk;
		private ImageList imageList1;
		private TabPage tabPage_EditData;
		private ImageList imageList2;
		private TabPage tabPage_Status;
	}
}