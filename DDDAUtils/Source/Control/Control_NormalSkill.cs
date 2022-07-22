using HananokiLib;
using System;
using System.Windows.Forms;

namespace DDDAUtils {
	public partial class Control_NormalSkill : UserControl {

		CheckBox[] checkBox;

		///////////////////////////////////////////
		public Control_NormalSkill() {
			InitializeComponent();
			Dock = DockStyle.Top;

			checkBox = new CheckBox[]{
				checkBox1,        checkBox2,        checkBox3,        checkBox4,
				checkBox5,        checkBox6,        checkBox7,        checkBox8,
				checkBox9,        checkBox10,       checkBox11,       checkBox12,
				checkBox13,       checkBox14,       checkBox15,       checkBox16,
				checkBox17,       checkBox18,
				};

			var tbl = new int[] {
				30,31,32,
				90,91,92,
				140,141,142,143,
				200,201,202,
				260,
				300,
				340, 390, 341
				};

			for( int i = 0; i < tbl.Length; i++ ) {
				checkBox[ i ].Tag = tbl[ i ];
				checkBox[ i ].CheckedChanged += checkBox1_CheckedChanged;
			}
		}


		///////////////////////////////////////////
		public void UpdateData( TreeNode_CharaData node ) {
			CharaData charaData = node.GetCharaData();

			int i = 0;
			foreach( var t in checkBox ) {
				var index = (int) t.Tag / 32;
				var shift = (int) t.Tag % 32;
				WindowsFormExtended.DoSomethingWithoutEvents(
					checkBox[ i ],
					() => checkBox[ i ].Checked = charaData.mParam.mSkillLv1[ index ].Has( 1 << shift )
					);
				i++;
			}
		}


		///////////////////////////////////////////
		void checkBox1_CheckedChanged( object sender, EventArgs e ) {
			CheckBox checkBox = (CheckBox) sender;
			if( checkBox == null ) return;
			Utils.GetCharaNode()?.ToggleNormalSkillFlag( (int) checkBox.Tag, checkBox.Checked );
		}
	}
}
