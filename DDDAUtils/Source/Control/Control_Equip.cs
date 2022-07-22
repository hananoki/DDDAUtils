using HananokiLib;
using System;
using System.Windows.Forms;

namespace DDDAUtils {

	public partial class Control_Equip : UserControl {

		int equipItemIndex;

		///////////////////////////////////////////
		public Control_Equip( string text, int itemIndex ) {
			InitializeComponent();

			label1.Text = text;
			equipItemIndex = itemIndex;

			string[] tbl = { "ー", "☆1", "☆2", "☆3", "竜1", "竜2", "竜3" };

			comboBox2.Items.Clear();

			comboBox2.BeginUpdate();
			{
				comboBox2.Items.AddRange( tbl );
				WindowsFormExtended.DoSomethingWithoutEvents(
					comboBox2,
					() => comboBox2.SelectedIndex = 0
					);
			}
			comboBox2.EndUpdate();

			comboBox1.SelectedIndexChanged += _SelectedIndexChanged;
			comboBox2.SelectedIndexChanged += _SelectedIndexChanged;

			switch( itemIndex ) {
				case 9:
				case 10:
					comboBox2.Visible = false;
					break;
			}
		}


		///////////////////////////////////////////
		public void InitComboBox( string[] items ) {
			comboBox1.Items.Clear();
			//comboBox1.BeginUpdate();
			comboBox1.Items.AddRange( items );
			//comboBox1.EndUpdate();
		}
		///////////////////////////////////////////
		public void BeginUpdate(  ) {
			comboBox1.BeginUpdate();
		}
		///////////////////////////////////////////
		public void EndUpdate(  ) {
			comboBox1.EndUpdate();
		}


		///////////////////////////////////////////
		public void SetData( cITEM_PARAM_DATA data ) {
			WindowsFormExtended.DoSomethingWithoutEvents(
				comboBox1,
				() => comboBox1.SelectedIndex = AppMain.csvItem.KeyToIndex( data.mItemNo )
				);

			var lv = DDItemUpgrade.Lv0;
			switch( data.mFlag ) {
				case 11:
					lv = DDItemUpgrade.Lv1;
					break;
				case 19:
					lv = DDItemUpgrade.Lv2;
					break;
				case 35:
					lv = DDItemUpgrade.Lv3;
					break;
				case 67:
					lv = DDItemUpgrade.Lv4;
					break;
				case 515:
					lv = DDItemUpgrade.Lv5;
					break;
				case 1027:
					lv = DDItemUpgrade.Lv6;
					break;
			}
			WindowsFormExtended.DoSomethingWithoutEvents(
				comboBox2,
				() => comboBox2.SelectedIndex = (int) lv
				);
		}


		/////////////////////////////////////////
		void _SelectedIndexChanged( object sender, EventArgs e ) {
			var node = MainForm.instance.treeView1.SelectedNode as TreeNode_CharaData;
			if( node == null ) {
				Utils.WarningNode();
				return;
			}
			int[] flags = { 3, 11, 19, 35, 67, 515, 1027 };
			node.SetEquipItem( equipItemIndex, AppMain.csvItem.IndexToKey( comboBox1.SelectedIndex ), flags[ comboBox2.SelectedIndex ] );
		}
	}
}
