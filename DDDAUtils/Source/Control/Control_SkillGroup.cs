using HananokiLib;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace DDDAUtils {
	public partial class Control_SkillGroup : UserControl {

		int height6;
		int height3;

		Control_SkillComboBox[] comboBoxs;

		/////////////////////////////////////////
		public Control_SkillGroup(  /*int no*/ ) {
			InitializeComponent();
			height6 = Height;
			height3 = Height / 2 + 12;

			comboBoxs = new Control_SkillComboBox[ 6 ];
			for( int i = 6 - 1; 0 <= i; i-- ) {
				var control = new Control_SkillComboBox( i );
				control.Dock = DockStyle.Top;
				comboBoxs[ i ] = control;
				groupBox.Controls.Add( control );
			}
		}


		/////////////////////////////////////////
		void Visible3( bool b ) {
			comboBoxs[ 5 ].Enabled = b;
			comboBoxs[ 5 ].Visible = b;
			comboBoxs[ 4 ].Enabled = b;
			comboBoxs[ 4 ].Visible = b;
			comboBoxs[ 3 ].Enabled = b;
			comboBoxs[ 3 ].Visible = b;
		}


		/////////////////////////////////////////
		public void InitComboBox() {
			var items = AppMain.csvSkill.indexToKey
				.Select( x => $"{x}: {AppMain.csvSkill.GetFromKey( x )}" )
				.ToArray();
			foreach( var c in comboBoxs ) {
				c.Init( items );
			}
		}


		/////////////////////////////////////////
		public void UpdateData( TreeNode_CharaData node, DDWeaponType weaponType ) {
			if( node == null ) return;

			CharaData charaData = node.GetCharaData();

			var names = new string[] {
				"片手剣",
				"メイス",
				"両手剣",
				"ダガー",

				"杖",
				"大杖",
				"ウォーハンマー",
				"盾",

				"魔道盾",
				"弓",
				"大弓",
				"魔道弓",
				};

			short[] data = charaData.GetWeaponSkill( weaponType );

			groupBox.Text = names[ (int) weaponType ];

			switch( weaponType ) {
				case DDWeaponType.WAND:
				case DDWeaponType.WAND_DX:
					Height = height6;
					Visible3( true );
					break;
				default:
					Height = height3;
					Visible3( false );
					break;
			}

			for( int i = 0; i < comboBoxs.Length; i++ ) {
				var c = comboBoxs[ i ];

				int skillNo = data[ i ];
				var lv2 = charaData.GetSkillLevel( skillNo );

				c.Update( node, weaponType, skillNo, lv2 );
			}
		}
	}
}
