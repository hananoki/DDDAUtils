using HananokiLib;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DDDAUtils {
	//////////////////////////////////////////////////////////////////////////////////
	public partial class UIPage_SystemData : UserControl {

		OptionData optionData;


		/////////////////////////////////////////
		public UIPage_SystemData() {
			InitializeComponent();
			Dock = DockStyle.Fill;

			radioButton1.CheckedChanged += _CheckedChanged;
			radioButton1.Tag = (byte) 1;
			radioButton2.CheckedChanged += _CheckedChanged;
			radioButton2.Tag = (byte) 0;
			radioButton3.CheckedChanged += _CheckedChanged;
			radioButton3.Tag = (byte) 4;
		}


		/////////////////////////////////////////
		public void SetOptionData( SaveDataXML dddaSaveData ) {
			this.optionData = new OptionData( dddaSaveData );

			RadioButton button = null;

			switch( optionData.GetFlag() ) {
				case 0:
					button = radioButton2;
					break;
				case 1:
					button = radioButton1;
					break;
				case 4:
					button = radioButton3;
					break;
			}

			if( button == null ) return;

			WindowsFormExtended.DoSomethingWithoutEvents(
				button,
				() => button.Checked = true
				);
		}


		/////////////////////////////////////////
		void _CheckedChanged( object sender, EventArgs e ) {
			var radioButton = sender as RadioButton;
			if( radioButton == null ) return;
			if( !radioButton.Checked ) return;

			optionData.SetFlag( (byte) radioButton.Tag );
		}


		/////////////////////////////////////////
		void click_StoreReset( object sender, EventArgs e ) {

			var shopList = new List<cSAVE_SHOP>();
			foreach( var e1 in MainForm.instance.dddaSaveData.mSaveShop.Elements() ) {
				var shop = new cSAVE_SHOP();
				foreach( var e2 in e1.Elements() ) {
					switch( e2.Name.ToString() ) {
						case "s32":
							shop.mNpcId = e2.attrbute_value_s32();
							break;
						case "array":
							var field = typeof( cSAVE_SHOP ).GetField( e2.attrbute_name() );
							switch( e2.attrbute_type() ) {
								case "s16":
									field.SetValue( shop, e2.GetArrayS16() );
									break;
								case "s8":
									field.SetValue( shop, e2.GetArrayS8() );
									break;
								case "u32":
									field.SetValue( shop, e2.GetArrayU32() );
									break;
							}
							break;
					}
				}
				shopList.Add( shop );
			}

			foreach( var s in shopList ) {
				s.mNpcId = -1;
				s.mItemNo.Fill( -1 );
				s.mNowDay.Fill( 0 );
				s.mNowNum.Fill( -1 );
				s.mInitDay.Fill( 0 );
				s.mInitNum.Fill( -1 );
				s.mOpF.Fill( 0 );
			}

			MainForm.instance.dddaSaveData.WriteShop( shopList.ToArray() );
		}
	}
}
