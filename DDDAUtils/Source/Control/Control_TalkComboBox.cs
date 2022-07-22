using HananokiLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace DDDAUtils {
	public partial class Control_TalkComboBox : UserControl {

		bool inited;
		TreeNode_CharaData m_targetNode;
		int m_useSceneTalkIndex;

		/////////////////////////////////////////
		public Control_TalkComboBox( string text, int useSceneTalkIndex ) {
			InitializeComponent();
			label1.Text = text;
			m_useSceneTalkIndex = useSceneTalkIndex;
		}


		/////////////////////////////////////////
		public void InitComboBox() {
			if( inited ) return;

			var tbl = new List<DDTalkType>();
			tbl.Add( DDTalkType.普通 );
			tbl.Add( DDTalkType.臆病 );
			tbl.Add( DDTalkType.野蛮 );
			tbl.Add( DDTalkType.無口 );
			tbl.Add( DDTalkType.自信家 );
			tbl.Add( DDTalkType.内気 );
			tbl.Add( DDTalkType.気取り屋 );

			comboBox1.Items.AddRange( tbl.Select( x => x.ToString() ).ToArray() );

			comboBox1.SelectedIndexChanged += comboBox_SelectedIndexChanged;

			inited = true;
		}


		/////////////////////////////////////////
		void comboBox_SelectedIndexChanged( object sender, EventArgs e ) {
			var comboBox = sender as ComboBox;
			if( comboBox == null ) {
				UINotifyStatus.Warning( "comboBox_SelectedIndexChanged: ComboBox conversion failed" );
				return;
			}
			m_targetNode?.SetUseSceneTalk( m_useSceneTalkIndex, (DDTalkType) comboBox.SelectedIndex );
		}


		/////////////////////////////////////////
		public void ShowControl( TreeNode_CharaData node ) {
			InitComboBox();

			m_targetNode = node;
			var chr = node.GetCharaData();

			if( chr.isPawn ) {
				comboBox1.Enabled = true;
				WindowsFormExtended.DoSomethingWithoutEvents(
						comboBox1,
						() => comboBox1.SelectedIndex = (int) chr.mUseSceneTalk[ m_useSceneTalkIndex ]
						);
			}
			else {
				comboBox1.Enabled = false;
			}
		}
	}
}
