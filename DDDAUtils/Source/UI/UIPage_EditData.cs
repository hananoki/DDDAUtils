using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DDDAUtils {

	//////////////////////////////////////////////////////////////////////////////////
	public partial class UIPage_EditData : UserControl {

		CharaData charaData;
		Dictionary<string, Control_EditParam> dict;

		///////////////////////////////////////////
		public UIPage_EditData() {
			InitializeComponent();
			Dock = DockStyle.Fill;

			dict = new Dictionary<string, Control_EditParam>();

			var t = typeof( cSAVE_DATA_EDIT );
			foreach( var f in t.GetFields().Reverse() ) {

				if( f.FieldType.IsArray ) continue;

				var a = new Control_EditParam( f.Name, f );
				a.Dock = DockStyle.Top;
				panel1.Controls.Add( a );

				dict.Add( f.Name, a );
			}
		}


		///////////////////////////////////////////
		public void ShowTab() {
			var node = Utils.GetCharaNode();
			if( node == null ) return;

			charaData = node.GetCharaData();

			foreach( var p in dict.Keys ) {
				dict[ p ].SetValue( charaData.mEdit );
			}
		}


		/////////////////////////////////////////
		public void Emit() {
			var node = MainForm.instance.treeView1.SelectedNode as TreeNode_CharaData;
			if( node == null ) {
				Utils.WarningNode();
				return;
			}
			node.SetEditData( dict );
		}
	}
}
