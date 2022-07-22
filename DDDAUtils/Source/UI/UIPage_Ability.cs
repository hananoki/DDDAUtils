using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DDDAUtils {

	//////////////////////////////////////////////////////////////////////////////////
	public partial class UIPage_Ability : UserControl {

		Control_AbilitySelect[] ability;
		bool inited;


		///////////////////////////////////////////
		public UIPage_Ability() {
			InitializeComponent();
			Dock = DockStyle.Fill;

			ability = new Control_AbilitySelect[6];
			for( int i = 6 - 1; 0 <= i; i-- ) {
				ability[ i ] = new Control_AbilitySelect( i );
				panel1.Controls.Add( ability[ i ] );
			}
		}


		///////////////////////////////////////////
		void Init() {
			if( inited ) return;

			var ss = AppMain.csvAbility.indexToKey.Select( p => $"{p}: {AppMain.csvAbility.GetFromKey( p )}" ).ToArray();

			foreach( var c in ability ) {
				c.Init( ss );
			}

			inited = true;
		}


		///////////////////////////////////////////
		public void ShowTab(  ) {
			var node = Utils.GetCharaNode();

			Init();

			if( node == null ) return;

			CharaData chr = node.GetCharaData();
			for( int i = 0; i < chr.mParam.mAbility.Length; i++ ) {
				ability[ i ].SetData( chr.mParam.mAbility[ i ] );
			}
		}


		///////////////////////////////////////////
		void toolStripButton1_Click( object sender, System.EventArgs e ) {
			var node = Utils.GetCharaNode();
			var chrData = node.GetCharaData();
			chrData.ResetAbility();
			MainForm.instance.dddaSaveData.Write( node.chrIndex, chrData, false, true, false );

			UINotifyStatus.Info( "アビリティを全てリセットしました" );
			ShowTab(  );
		}
	}
}
