using HananokiLib;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace DDDAUtils {
	public partial class Control_ResetButtons : UserControl {

		TreeView treeView1;

		/////////////////////////////////////////
		public Control_ResetButtons( TreeView treeView1 ) {
			InitializeComponent();
			Dock = DockStyle.Fill;
			this.treeView1 = treeView1;

			button1.Tag = 0;
			button3.Tag = 2;
		}



		/////////////////////////////////////////
		private void button1_Click( object sender, EventArgs e ) {
			var node = treeView1.SelectedNode as TreeNode_CharaData;
			if( node == null ) return;

			var button = sender as Button;

			var chrData = node.GetCharaData();
			chrData.mParam.mLevel = 1;
			chrData.mParam.mJob = 1;
			chrData.mParam.mExp = 0;

			chrData.mParam.mStamina = chrData.mParam.mStaminaBase;
			chrData.mParam.mStaminaLv = 0;

			switch( (int) button.Tag ) {
				case 0:
					chrData.mParam.mHp =
						chrData.mParam.mHpMax =
						chrData.mParam.mHpMaxWhite = 450;
					chrData.mParam.mBasicAttack = 80;
					chrData.mParam.mBasicDefend = 80;
					chrData.mParam.mBasicMgcAttack = 60;
					chrData.mParam.mBasicMgcDefend = 60;
					break;
				case 2:
					chrData.mParam.mHp =
						chrData.mParam.mHpMax =
						chrData.mParam.mHpMaxWhite = 410;
					chrData.mParam.mBasicAttack = 60;
					chrData.mParam.mBasicDefend = 60;
					chrData.mParam.mBasicMgcAttack = 80;
					chrData.mParam.mBasicMgcDefend = 80;
					break;
			}

			chrData.ResetSkillAndAbility();

			MainForm.instance.dddaSaveData.Write( node.chrIndex, chrData, false, true, false );
		}
	}
}
