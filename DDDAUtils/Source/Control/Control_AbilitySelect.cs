using HananokiLib;
using System;
using System.Windows.Forms;

namespace DDDAUtils {
	public partial class Control_AbilitySelect : UserControl {

		int index;


		/////////////////////////////////////////
		public Control_AbilitySelect( int index ) {
			InitializeComponent();
			Dock = DockStyle.Top;
			
			this.index = index;
			comboBox1.SelectedIndexChanged += _SelectedIndexChanged;
		}


		/////////////////////////////////////////
		public void Init( string[] items ) {
			comboBox1.Items.AddRange( items );
		}


		/////////////////////////////////////////
		public void SetData( int abilityNo ) {
			var index = AppMain.csvAbility.KeyToIndex( abilityNo );
			WindowsFormExtended.DoSomethingWithoutEvents(
					comboBox1,
					() => comboBox1.SelectedIndex = AppMain.csvAbility.KeyToIndex( abilityNo )
					);
		}


		/////////////////////////////////////////
		void _SelectedIndexChanged( object sender, EventArgs e ) {
			var comboBox = sender as ComboBox;
			if( comboBox == null ) return;

			var node = Utils.GetCharaNode();

			node?.SetAbility( index, AppMain.csvAbility.IndexToKey( comboBox.SelectedIndex ) );
		}
	}
}
