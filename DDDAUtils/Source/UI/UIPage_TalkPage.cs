using System;
using System.Windows.Forms;

namespace DDDAUtils {

	//////////////////////////////////////////////////////////////////////////////////
	public partial class UIPage_TalkPage : UserControl {

		Control_TalkComboBox[] m_talkControl;

		public UIPage_TalkPage() {
			InitializeComponent();
			Dock = DockStyle.Fill;

			var text = new string[] {
				"覚者様の指示に対し",
				"魔物との戦闘に勝利した際",
				"危機に瀕し助けていただいた際",
				"覚者様を助け起こす時",
				"無念にも力尽きた覚者様が、再び力を取り戻した際",
				"私が苛烈な痛手を受け、地に伏した時…",
			};

			m_talkControl = new Control_TalkComboBox[ text.Length ];
			for( int i = text.Length - 1; 0 <= i; i-- ) {
				var t = text[ i ];
				var a = new Control_TalkComboBox( t, i );
				a.Dock = DockStyle.Top;
				panel1.Controls.Add( a );
				m_talkControl[ i ] = a;
			}
		}


		///////////////////////////////////////////
		public void ShowTab() {
			var node = Utils.GetCharaNode();

			if( node == null ) return;

			foreach( var a in m_talkControl ) {
				a.ShowControl( node );
			}
		}


		///////////////////////////////////////////
		void Click_ResetTalk( object sender, EventArgs e ) {

			var node = MainForm.instance.treeView1.SelectedNode as TreeNode_CharaData;
			if( node == null ) return;
			var chrData = node.GetCharaData();
			chrData.ResetTalk();
			MainForm.instance.dddaSaveData.Write( node.chrIndex, chrData, false, false, true );

			ShowTab(  );
		}
	}
}
