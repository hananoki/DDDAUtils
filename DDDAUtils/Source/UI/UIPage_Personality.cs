using System;
using System.Windows.Forms;

namespace DDDAUtils {

	//////////////////////////////////////////////////////////////////////////////////
	public partial class UIPage_Personality : UserControl {

		Control_Personality[] m_controls;
		bool inited;


		/////////////////////////////////////////
		public UIPage_Personality() {
			InitializeComponent();
			Dock = DockStyle.Fill;

			var text2 = new string[] {
				"強い魔物に率先して挑む",
				"安全を優先して行動する",
				"弱い標的から仕留める",
				"厄介な魔物から狙う",
				"多角的な戦術で動く",
				"覚者の安全を心掛ける",
				"ポーンたちを助け支える",
				"積極的に動き道を開く",
				"様々な物資を探し集める",
			};

			m_controls = new Control_Personality[ text2.Length ];
			for( int i = text2.Length - 1; 0 <= i; i-- ) {
				var t = text2[ i ];
				var a = new Control_Personality( this, t, (DDPawnPersonality) i );
				Controls.Add( a );
				a.Dock = DockStyle.Top;
				m_controls[ i ] = a;
			}
		}


		/////////////////////////////////////////
		void _Enter( object sender, EventArgs e ) {
			
		}


		/////////////////////////////////////////
		public void InitTab() {
			if( inited ) return;

			inited = true;
		}


		/////////////////////////////////////////
		public void ShowTab(  ) {
			var node = Utils.GetCharaNode();

			InitTab();

			if( node == null ) {
				Utils.WarningNode();
				return;
			}

			var chr = node.GetCharaData();

			foreach( var c in m_controls ) {
				c.Value = (int) chr.Get_DDPawnPersonality_Value( c.type );
			}
		}


		/////////////////////////////////////////
		public void Emit() {
			var node = MainForm.instance.treeView1.SelectedNode as TreeNode_CharaData;
			if( node == null ) {
				Utils.WarningNode();
				return;
			}
			node.SetPawnPersonality( m_controls );
		}
	}
}
