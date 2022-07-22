using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDDAUtils {
	public partial class UIPage_Status : UserControl {

		Control_LevelSlider[] group1;
		Control_LevelSlider[] group2;
		Control_LevelSlider[] group3;

		///////////////////////////////////////////
		public UIPage_Status() {
			InitializeComponent();
			Dock = DockStyle.Fill;

			string[] tbl = { "ファイター", "ストライダー", "メイジ", "ウォリアー", "レンジャー", "ソーサラー" };

			group1 = new Control_LevelSlider[ 3 ];
			for( int i = 0; i < group1.Length; i++ ) {
				group1[ i ] = new Control_LevelSlider( tbl[ i ], i, 10, 0 );
			}
			foreach( var p in group1.Reverse() ) {
				panel1.Controls.Add( p );
				p._ValueChanged( p.trackBar1, null );
			}
			panel1.Height = 24 * 3;


			group2 = new Control_LevelSlider[ 6 ];
			for( int i = 0; i < group2.Length; i++ ) {
				group2[ i ] = new Control_LevelSlider( tbl[ i ], i, 90, 1 );
			}
			foreach( var p in group2.Reverse() ) {
				panel2.Controls.Add( p );
				p._ValueChanged( p.trackBar1, null );
			}
			panel2.Height = 24 * 6;

			group3 = new Control_LevelSlider[ 6 ];
			for( int i = 0; i < group2.Length; i++ ) {
				group3[ i ] = new Control_LevelSlider( tbl[ i ], i, 99, 2 );
			}
			foreach( var p in group3.Reverse() ) {
				panel3.Controls.Add( p );
				p._ValueChanged( p.trackBar1, null );
			}
			panel3.Height = 24 * 6;
		}


		///////////////////////////////////////////
		public void OnEnter() {
			var node = Utils.GetCharaNode();
			if( node == null ) return;
			var chrData = node.GetCharaData();
			//label1.Text = $"Level {chrData.mParam.mLevel} HP {chrData.mParam.mHpMax} Stamina {chrData.mParam.mStamina}";
		}


		///////////////////////////////////////////
		public void ChangeLevelSlider( int group, int no ) {
			int limit = 0;

			Control_LevelSlider[] checkgroup = null;

			switch( group ) {
				case 0:
					limit = 10;
					checkgroup = group1;
					break;
				case 1:
					limit = 90;
					checkgroup = group2;
					break;
				case 2:
					limit = 99;
					checkgroup = group3;
					break;
			}

			int sum = 0;
			int sum2 = 0;

			for( int i = 0; i < checkgroup.Length; i++ ) {
				sum2 += checkgroup[ i ].trackBar1.Value;
				if( i == no ) continue;
				sum += checkgroup[ i ].trackBar1.Value;
			}

			if( limit <= sum2 ) {
				if( limit <= sum ) {
					checkgroup[ no ].trackBar1.Value = 0;
				}
				else {
					checkgroup[ no ].trackBar1.Value = limit - sum;
				}
			}
		}
	}
}
