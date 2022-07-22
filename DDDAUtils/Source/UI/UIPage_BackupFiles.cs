using HananokiLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDDAUtils {
	//////////////////////////////////////////////////////////////////////////////////
	public partial class UIPage_BackupFiles : UserControl {

		List<string> folders;

		/////////////////////////////////////////
		public UIPage_BackupFiles() {
			InitializeComponent();
			Dock = DockStyle.Fill;
		}


		/////////////////////////////////////////
		void UI_BackupFiles_Load( object sender, EventArgs e ) {
			WindowsFormExtended.DoSomethingWithoutEvents(
					checkBox2,
					() => checkBox2.Checked = AppMain.config.isAutoSave
					);

		}


		/////////////////////////////////////////
		public void InitProfile() {
			var comboBox = toolStripComboBox_Profile;

			folders = new List<string>();
			folders.AddRange( DirectoryUtils.GetDirectories( "Profile" ).Select( x => x.GetBaseName() ) );

			comboBox.Items.Clear();
			comboBox.Items.AddRange( folders.ToArray() );

			comboBox.SelectedIndex = folders.FindIndex( x => x == AppMain.config.selectProfile );
		}


		///////////////////////////////////////////
		void checkBox2_CheckedChanged( object sender, EventArgs e ) {
			var chkbox = sender as CheckBox;

			AppMain.config.flag.Toggle( (int) EConfigOptions.AutoSave, chkbox.Checked );
			cancellationTokenSource?.Cancel();
			StartBackup();
		}


		///////////////////////////////////////////
		public void StartBackup() {
			if( !AppMain.config.isAutoSave ) return;
			cancellationTokenSource = new CancellationTokenSource();
			var token = cancellationTokenSource.Token;
			task = Task.Run( () => FolderKnasi( token ) );
		}

		//List<int> m_itemKey;
		CancellationTokenSource cancellationTokenSource;
		public bool exit;
		Task task;

		///////////////////////////////////////////
		void FolderKnasi( CancellationToken token ) {
			//UINotifyStatus.Info( "バックアップを開始します" );
			var saveFolderPath = Utils.SaveFolder;
			var savPath = $"{saveFolderPath}\\{D.DDDA_sav}";
			var start = new FileInfo( savPath );
			while( !exit ) {
				//すべてのプロセスを列挙する
				bool find = false;
				foreach( System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses() ) {
					//指定された文字列がメインウィンドウのタイトルに含まれているか調べる
					if( "Dragon’s Dogma: Dark Arisen" == p.MainWindowTitle ) {
						//含まれていたら、コレクションに追加
						find = true;
					}
				}
				if( !find ) {
					Thread.Sleep( 5000 );
					continue;
				}

				if( token.IsCancellationRequested ) {
					// ループを終了します。
					break;
				}

				var now = new FileInfo( savPath );
				var path = $"Profile\\{AppMain.config.selectProfile}\\{now.LastWriteTime.ToString( "yyyyMMdd_HHmmss" )}.sav";
				if( !path.IsExistsFile() ) {
					fs.cp( savPath, path );
				}
				Thread.Sleep( 5000 );
			}
			UINotifyStatus.Info( "バックアップを終了します" );
		}


		///////////////////////////////////////////
		/// ファイルリストを更新
		public void UpdateFileList() {
			listView_Files.ClearItems();

			foreach( var f in DirectoryUtils.GetFiles( $"{D.profile}\\{AppMain.config.selectProfile}" ) ) {
				var item = new ListViewItem_Files( f );
				listView_Files.m_items.Add( item );
			}
			listView_Files.ApplyVirtualListSize();

			foreach( ColumnHeader ch in listView_Files.Columns ) {
				ch.Width = -1;
			}
		}


		/////////////////////////////////////////
		///最新の情報に更新
		void Click_UpdateFileList( object sender, EventArgs e )
			=> UpdateFileList();


		/////////////////////////////////////////
		void toolStripButton_Click_ReplaceSaveFile( object sender, EventArgs e ) {
			var item = listView_Files.GetSelectItem();

			fs.cp( item.fullpath, $"{Utils.SaveFolder}\\{D.DDDA_sav}", true );

			UINotifyStatus.Info( $"セーブデータを更新: from {item.fullpath.GetFileName()}" );
		}


		/////////////////////////////////////////
		void toolStripComboBox1_SelectedIndexChanged( object sender, EventArgs e ) {
			var combobox = sender as ToolStripComboBox;
			AppMain.config.selectProfile = combobox.Text;

			UpdateFileList();
		}


		/////////////////////////////////////////
		void listView_Files_KeyUp( object sender, KeyEventArgs e ) {
			var lstView = (ListView_Files) sender;
			if( lstView == null ) return;

			if( e.KeyCode == Keys.Delete ) {
				var items = lstView.GetSelectItems();
				foreach( var item in items ) {
					fs.rm2( item.fullpath );
					listView_Files.m_items.Remove( item );
				}
				listView_Files.ApplyVirtualListSize();
			}
		}
	}
}
