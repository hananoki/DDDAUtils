using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DDDAUtils {

	//////////////////////////////////////////////////////////////////////////////////
	public partial class UIPage_Equip : UserControl {

		List<Control_Equip> m_equipControl;
		bool initComboBox;


		/////////////////////////////////////////
		public UIPage_Equip() {
			InitializeComponent();
			Dock = DockStyle.Fill;

			var tbl = new string[] {
				"メイン",
				"サブ",
				"胴（ウェア）",
				"脚（ウェア）",
				"頭",
				"胴",
				"腕",
				"脚",
				"オーバーウェア",
				"ジュエリー1",
				"ジュエリー2",
			};

			m_equipControl = new List<Control_Equip>();
			for( int i = 0; i < tbl.Length; i++ ) {
				var p = tbl[ i ];
				var ui = new Control_Equip( p, i );
				m_equipControl.Add( ui );
			}

			foreach( var ui in m_equipControl.ToArray().Reverse() ) {
				ui.Dock = DockStyle.Top;
				Controls.Add( ui );
			}
		}


		///////////////////////////////////////////
		void Init() {
			if( initComboBox ) return;

			var cc = AppMain.csvItem.indexToKey.Select( x => $"{x}: {AppMain.csvItem.GetFromKey( x )}" ).ToArray();
			foreach( var p in m_equipControl ) {
				p.BeginUpdate();
			}
			foreach( var p in m_equipControl ) {
				p.InitComboBox( cc );
			}
			foreach( var p in m_equipControl ) {
				p.EndUpdate();
			}
			initComboBox = true;
		}


		/////////////////////////////////////////
		public void ShowTab() {
			Init();
			
			var node = Utils.GetCharaNode();
			if( node == null ) return;
			
			var chrData = node.GetCharaData();
			
			for( int i = 0; i < chrData.mParam.mEquipItem.Length - 1; i++ ) {
				m_equipControl[ i ].SetData( chrData.mParam.mEquipItem[ i ] );
			}
		}
	}
}
