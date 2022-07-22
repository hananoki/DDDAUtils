using HananokiLib;
using System;
using System.Windows.Forms;

namespace DDDAUtils {
	public partial class Control_SkillComboBox : UserControl {

		DDWeaponType weaponType;
		TreeNode_CharaData node;
		int index;


		/////////////////////////////////////////
		public Control_SkillComboBox( int index ) {
			InitializeComponent();
			this.index = index;
			comboBox.SelectedIndexChanged += _SelectedIndexChanged;
			radioButton1.CheckedChanged += _CheckedChanged;
			radioButton2.CheckedChanged += _CheckedChanged;
		}


		/////////////////////////////////////////
		void _SelectedIndexChanged( object sender, EventArgs e ) {
			var comboBox = sender as ComboBox;
			if( comboBox == null ) return;

			int lv = 0;
			if( radioButton1.Checked ) lv = 1;
			if( radioButton2.Checked ) lv = 2;
			InternalSetSkill( AppMain.csvSkill.IndexToKey( comboBox.SelectedIndex ), lv );
		}


		/////////////////////////////////////////
		void _CheckedChanged( object sender, EventArgs e ) {
			var radioButton = sender as RadioButton;
			if( radioButton == null ) return;

			if( !radioButton.Checked ) return;

			int lv = 0;
			if( radioButton1.Checked ) lv = 1;
			if( radioButton2.Checked ) lv = 2;
			InternalSetSkill( AppMain.csvSkill.IndexToKey( comboBox.SelectedIndex ), lv );
		}


		/////////////////////////////////////////
		void InternalSetSkill( int skillNo, int lv )
			=> node?.SetSkill( weaponType, index, skillNo, lv );


		/////////////////////////////////////////
		public void Init( string[] items ) {
			comboBox.Items.AddRange( items );
		}


		/////////////////////////////////////////
		public void Update( TreeNode_CharaData node, DDWeaponType weaponType, int skillNo, int lv ) {
			this.node = node;
			this.weaponType = weaponType;

			WindowsFormExtended.DoSomethingWithoutEvents(
				comboBox,
				() => comboBox.SelectedIndex = AppMain.csvSkill.KeyToIndex( skillNo )
				);

			if( lv == 0 ) {
				WindowsFormExtended.DoSomethingWithoutEvents(
					radioButton2,
					() => radioButton1.Checked = false
					);
				WindowsFormExtended.DoSomethingWithoutEvents(
					radioButton1,
					() => radioButton2.Checked = false
					);
			}
			else {
				WindowsFormExtended.DoSomethingWithoutEvents(
					radioButton2,
					() => radioButton1.Checked = lv == 1
					);
				WindowsFormExtended.DoSomethingWithoutEvents(
					radioButton1,
					() => radioButton2.Checked = lv == 2
					);
			}
		}
	}
}
