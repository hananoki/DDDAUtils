using HananokiLib;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DDDAUtils {
	public partial class MainForm : Form {

		string[] PlNames = { "プレイヤー", "メインポーン", "サポートポーン1", "サポートポーン2" };

		/////////////////////////////////////////
		void InitEditDataFiles() {
			fs.mkDir( Utils.ExportDataFolder );

			node_EditData.Nodes.Clear();
			
			var files = Directory.GetFiles( Utils.ExportDataFolder, "*.xml" );
			foreach( var f in files ) {
				var node = new TreeNode_CharaData( dddaSaveData, f.GetBaseName(), f );
				node_EditData.Nodes.Add( node );
			}
			node_EditData.ExpandAll();
		}



		///////////////////////////////////////////
		void UpdatePropertyTab(  ) {
			var node = Utils.GetCharaNode();

			propertyGrid1.SelectedObject = node;
		}


		///////////////////////////////////////////
		async void ReadSaveFile() {
			node_SaveXML.Nodes.Clear();
			node_plcmc.Clear();
			dddaSaveData = null;

			if( !Utils.HasDDsavetool() ) {
				UINotifyStatus.Error( $"DDsavetool.exeが見つかりませんでした" );
				return;
			}

			UINotifyStatus.Info( $"セーブデータの読み込み: 開始" );

			var saveFolderPath = Utils.SaveFolder;
			var savPath = $"{saveFolderPath}\\{D.DDDA_sav}";
			var xmlPath = $"{saveFolderPath}\\{D.DDDA_sav_xml}";

			await Task.Run( () => {
				shell.startProcess( "DDsavetool.exe", savPath );

				if( xmlPath.IsExistsFile() ) {
					dddaSaveData = new SaveDataXML();
					dddaSaveData.Read();
				}
			} );

			if( dddaSaveData == null ) {
				UINotifyStatus.Error( $"セーブデータの読み込みに失敗" );
				return;
			}

			uiSystemData.SetOptionData( dddaSaveData );
			//uiEditData.SetData( dddaSaveData );

			//node_edits = new List<TreeNode_CharaData>();

			for( int i = 0; i < 4; i++ ) {
				var v = dddaSaveData.PlayerDataManual[ i ];
				var data = CharaData.Read_cSAVE_DATA_EDIT( v.mEdit );
				var n = new TreeNode_CharaData( dddaSaveData, i, $"{PlNames[ i ]}（{data.GetConvertToName()}）", v );
				node_SaveXML.Nodes.Add( n );
				node_plcmc.Add( n );
			}
			node_SaveXML.ExpandAll();
			UINotifyStatus.Info( $"セーブデータの読み込み: 完了" );
		}


		///////////////////////////////////////////
		async void WriteSaveFile() {
			if( !Utils.HasDDsavetool() ) {
				UINotifyStatus.Error( $"DDsavetool.exeが見つかりませんでした" );
				return;
			}

			UINotifyStatus.Info( $"セーブデータを書き込み: 開始" );

			var saveFolderPath = Utils.SaveFolder;
			var xmlPath = $"{saveFolderPath}\\{D.DDDA_sav_xml}";

			await Task.Run( () => {
				// ファイル書き込み設定
				var setting = new XmlWriterSettings() {
					NewLineChars = "\n",
					Indent = true,
					NewLineOnAttributes = false,
					OmitXmlDeclaration = false
				};

				// ファイルへオブジェクトを書き込み（シリアライズ）
				using( var writer = XmlWriter.Create( xmlPath, setting ) ) {
					dddaSaveData.xdoc.Save( writer );
				}
				List<string> lst = new List<string>();
				foreach( var s in File.ReadAllLines( xmlPath ) ) {
					var ss = s.TrimStart();
					lst.Add( ss );
				}
				File.WriteAllText( xmlPath, string.Join( "\n", lst ) );
			} );

			await shell.startProcessAsync( "DDsavetool.exe", $"-r -pc {xmlPath.Quote()}" );

			UINotifyStatus.Info( $"セーブデータを書き込み: 完了" );
		}
	}
}
