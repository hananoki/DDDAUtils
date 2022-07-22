
using HananokiLib;
//using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace DDDAUtils {
	public partial class MainForm : Form {

		public static MainForm instance;

		public StatusBarMessage m_statusBarMessage;

		public SaveDataXML dddaSaveData;

		TreeNode node_SaveXML;
		TreeNode node_EditData;

		List<TreeNode_CharaData> node_plcmc;


		List<ToolStripSplitButton> tsbList;

		Dictionary<TabPage, Action> pageEvent;

		UIPage_SystemData uiSystemData;
		UIPage_Settings uiPage_Settings;
		UIPage_TalkPage uiTalkPage;
		UIPage_Skill uiSkillPage;
		UIPage_Personality uiPersonality;
		UIPage_EditData uiEditData;
		UIPage_BackupFiles uiPageBackupFiles;
		UIPage_Equip uiEquip;
		UIPage_Ability uiAbility;
		UIPage_Status uiStatus;

		Control_ResetButtons pageResetFunction;


		public static Config config => AppMain.config;
		public static CsvText csvJob => AppMain.csvJob;

		//protected override CreateParams CreateParams {
		//	get {
		//		CreateParams cp = base.CreateParams;
		//		//拡張ウィンドウスタイルにWS_EX_COMPOSITEDを追加する
		//		cp.ExStyle |= 0x02000000;
		//		return cp;
		//	}
		//}

		/////////////////////////////////////////
		public MainForm() {
			InitializeComponent();
			instance = this;

			node_plcmc = new List<TreeNode_CharaData>();

			uiPage_Settings = new UIPage_Settings();
			tabPage_Settings.Controls.Add( uiPage_Settings );

			uiSystemData = new UIPage_SystemData();
			panel2.Controls.Add( uiSystemData );

			uiSkillPage = new UIPage_Skill();
			tabPage_Skill.Controls.Add( uiSkillPage );

			pageResetFunction = new Control_ResetButtons( treeView1 );
			tabPage_Reset.Controls.Add( pageResetFunction );


			uiTalkPage = new UIPage_TalkPage();
			tabPage_Talk.Controls.Add( uiTalkPage );


			uiPersonality = new UIPage_Personality();
			tabPage_Personality.Controls.Add( uiPersonality );

			uiEditData = new UIPage_EditData();
			tabPage_EditData.Controls.Add( uiEditData );

			uiPageBackupFiles = new UIPage_BackupFiles();
			tabPage_Backup.Controls.Add( uiPageBackupFiles );

			uiEquip = new UIPage_Equip();
			tabPage_Equip.Controls.Add( uiEquip );

			uiAbility = new UIPage_Ability();
			tabPage_Ability.Controls.Add( uiAbility );

			uiStatus = new UIPage_Status();
			tabPage_Status.Controls.Add( uiStatus );

			tsbList = new List<ToolStripSplitButton>();
			tsbList.Add( toolStripSplitButton_Import01 );
			tsbList.Add( toolStripSplitButton_Import02 );
			tsbList.Add( toolStripSplitButton_Import03 );
			tsbList.Add( toolStripSplitButton_Import04 );

			foreach( var p in tsbList ) {
				var buttons = new List<ToolStripMenuItem>();
				var b1 = new ToolStripMenuItem();
				b1 = new ToolStripMenuItem();
				b1.Size = new System.Drawing.Size( 180, 22 );
				b1.Text = "全て";
				b1.Click += toolStripSplitButton1_ButtonClick;
				var b2 = new ToolStripMenuItem();

				b2.Name = "容姿のみToolStripMenuItem";
				b2.Size = new System.Drawing.Size( 180, 22 );
				b2.Text = "エディット";
				b2.Click += ToolStripMenuItem_Click_Edit;
				// 
				// アビリティToolStripMenuItem
				// 
				//this.アビリティToolStripMenuItem.Name = "アビリティToolStripMenuItem";
				//this.アビリティToolStripMenuItem.Size = new System.Drawing.Size( 180, 22 );
				//this.アビリティToolStripMenuItem.Text = "アビリティ";
				buttons.Add( b1 );
				buttons.Add( b2 );
				p.DropDownItems.AddRange( buttons.ToArray() );
			}
		}


		//////////////////////////////////////////////////////////////////////////////////
		#region MainForm


		/////////////////////////////////////////
		async void MainForm_Load( object sender, EventArgs e ) {
			Font = SystemFonts.IconTitleFont;
			Text = $"{Text} {Helper.version}";

			AppMain.RollbackWindow( this );

			m_statusBarMessage = new StatusBarMessage( this, toolStripStatusLabel1 );


			string[] toolPaths = { $@"{Helper.s_appPath}\bin" };
			shell.SetProcessEnvironmentPath( toolPaths );

			panel_Main.Visible = true;

			toolStripButton_Export.Visible = false;

			for( int i = 0; i < tsbList.Count; i++ ) {
				tsbList[ i ].Tag = i;
			}
			tsbList.SetVisible( false );



			node_SaveXML = new TreeNode( D.DDDA_sav_xml, 1, 1 );
			treeView1.Nodes.Add( node_SaveXML );

			node_EditData = new TreeNode( D.export, 2, 2 );
			treeView1.Nodes.Add( node_EditData );


			pageEvent = new Dictionary<TabPage, Action>();
			pageEvent.Add( tabPage_Equip, uiEquip.ShowTab );
			pageEvent.Add( tabPage_Skill, uiSkillPage.ShowTab );
			pageEvent.Add( tabPage_Ability, uiAbility.ShowTab );
			pageEvent.Add( tabPage_Talk, uiTalkPage.ShowTab );
			pageEvent.Add( tabPage_Property, UpdatePropertyTab );
			pageEvent.Add( tabPage_Personality, uiPersonality.ShowTab );
			pageEvent.Add( tabPage_EditData, uiEditData.ShowTab );
			pageEvent.Add( tabPage_Status, uiStatus.OnEnter );

			uiPageBackupFiles.InitProfile();

#if !DEBUG
			tabControl2.Controls.Remove( tabPage_Property );
			tabControl2.Controls.Remove( tabPage_Status );
			tabControl2.Controls.Remove( tabPage_Reset );
#endif
			InitEditDataFiles();

			if( config.isAutoRead ) {
				ReadSaveFile();
			}
			uiPageBackupFiles.StartBackup();


			await AppMain.instance.LoadText();
		}


		/////////////////////////////////////////
		void MainForm_FormClosing( object sender, FormClosingEventArgs e ) {
			uiPageBackupFiles.exit = true;
			AppMain.OnFormClosing( this );
		}


		/////////////////////////////////////////
		void MainForm_KeyUp( object sender, KeyEventArgs e ) {
			//if( e.KeyCode == Keys.F5 ) {
			//	RegisterOpenFolder( config.lastOpenFolderPath );
			//}
			if( e.KeyCode == Keys.F11 ) {
				LogWindow.Visible = !LogWindow.Visible;
			}
		}


		/////////////////////////////////////////
		void MainForm_Activated( object sender, EventArgs e ) {
			if( tabControl_Main.SelectedTab == tabPage_Settings ) {
				uiPage_Settings.ShowTab();
			}
		}

		#endregion



		//////////////////////////////////////////////////////////////////////////////////
		#region TreeView

		/////////////////////////////////////////
		void treeView1_AfterSelect( object sender, TreeViewEventArgs e ) {

			if( e.Node.Text == D.DDDA_sav_xml ) {
				uiSystemData.Visible = true;
				tabControl2.Visible = false;
			}

			var node = e.Node as TreeNode_CharaData;

			if( node != null ) {
				uiSystemData.Visible = false;
				tabControl2.Visible = true;

				toolStripButton_Export.Visible = node.hasElement;
				tsbList.SetVisible( !node.hasElement );

				var chr = node.GetCharaData();

				uiSkillPage.SelectJob( chr );

				pageEvent.TryGetValue( tabControl2.SelectedTab, out Action func );
				func?.Invoke(  );
			}
		}

		#endregion



		//////////////////////////////////////////////////////////////////////////////////

		#region TabPage

		/////////////////////////////////////////
		void tabPage_Equip_Enter( object sender, EventArgs e )
			=> uiEquip.ShowTab(  );


		/////////////////////////////////////////
		void tabPage_Skill_Enter( object sender, EventArgs e ) {
			var node = Utils.GetCharaNode();

			if( node != null ) {
				uiSkillPage.SelectJob( node.GetCharaData() );
			}

			uiSkillPage.ShowTab(  );
		}


		/////////////////////////////////////////
		void tabPage_Ability_Enter( object sender, EventArgs e )
		=> uiAbility.ShowTab(  );



		/////////////////////////////////////////
		void tabPage_Property_Enter( object sender, EventArgs e )
			=> UpdatePropertyTab(  );


		/////////////////////////////////////////
		void tabPage_Talk_Enter( object sender, EventArgs e )
			=> uiTalkPage.ShowTab(  );


		/////////////////////////////////////////
		void tabPage_EditData_Enter( object sender, EventArgs e )
		 => uiEditData.ShowTab(  );

		/////////////////////////////////////////
		void tabPage_Personality_Enter( object sender, EventArgs e )
			=> uiPersonality.ShowTab(  );

		/////////////////////////////////////////
		void tabPage_Status_Enter( object sender, EventArgs e )
		 => uiStatus.OnEnter();

		#endregion



		//////////////////////////////////////////////////////////////////////////////////
		#region ToolStrip

		/////////////////////////////////////////
		/// セーブデータをリパック
		void Click_UpdateSaveFile( object sender, EventArgs e )
			=> WriteSaveFile();


		/////////////////////////////////////////
		void toolStripButton_Click_ReadSaveFile( object sender, EventArgs e )
			=> ReadSaveFile();



		/////////////////////////////////////////
		/// キャラクタデータをエクスポート
		void toolStripButton_Export_CharaData( object sender, EventArgs e ) {
			var node = treeView1.SelectedNode as TreeNode_CharaData;

			if( node == null ) return;

			var exportData = node.GetCharaData();

			var filePath = $"{Utils.ExportDataFolder}\\{exportData.mEdit.GetConvertToName()}.xml";

			var setting = new XmlWriterSettings() {
				NewLineChars = Environment.NewLine,
				Indent = true,
				NewLineOnAttributes = true,
				OmitXmlDeclaration = false
			};

			XmlSerializer ser = new XmlSerializer( typeof( CharaData ) );
			using( XmlWriter wr = XmlWriter.Create( filePath, setting ) ) {
				ser.Serialize( wr, exportData );
			}

			InitEditDataFiles();

			UINotifyStatus.Info( $"エディットデータをエクスポート: {filePath}" );
		}


		/////////////////////////////////////////
		/// エディットデータをインポート
		void Import_EditData( object sender, bool edit, bool ability, bool cmc ) {
			var node = treeView1.SelectedNode as TreeNode_CharaData;
			if( node == null ) {
				Utils.WarningNode();
				return;
			}

			var toolStripButton = sender as ToolStripSplitButton;
			if( toolStripButton == null ) {
				var aa = sender as ToolStripMenuItem;
				toolStripButton = aa.OwnerItem as ToolStripSplitButton;
			}
			var index = int.Parse( toolStripButton.Tag.ToString() );
			var chrData = node.GetCharaData();

			dddaSaveData.Write( index, chrData, edit, ability, cmc );

			node_plcmc[ index ].Text = $"{PlNames[ index ]}（{chrData.mEdit.GetConvertToName()}）";
			node_plcmc[ index ].ClearExportData();

			UINotifyStatus.Info( $"「{PlNames[ index ]}」のエディットを「{chrData.mEdit.GetConvertToName()}」に変更" );
		}


		/////////////////////////////////////////
		/// すべてインポート
		void toolStripSplitButton1_ButtonClick( object sender, EventArgs e ) {
			Import_EditData( sender, true, true, true );
		}


		/////////////////////////////////////////
		/// エディットのみインポート
		void ToolStripMenuItem_Click_Edit( object sender, EventArgs e )
			=> Import_EditData( sender, true, false, false );



		/////////////////////////////////////////
		/// セーブデータフォルダを開く
		void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
			=> shell.openFolder( Utils.SaveFolder );


		#endregion


		//////////////////////////////////////////////////////////////////////////////////
		#region TabControll

		void tabPage2_Enter( object sender, EventArgs e )
			=> uiPageBackupFiles.UpdateFileList();

		/////////////////////////////////////////
		void tabControl_Main_Enter( object sender, EventArgs e )
			=> uiPage_Settings.ShowTab();



		#endregion


	}
}


