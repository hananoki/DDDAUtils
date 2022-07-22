
using HananokiLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;


namespace DDDAUtils {

	/////////////////////////////////////////
	public class XMLCharaData {
		public XElement CMC;
		public XElement mEdit;
		public XElement mParam;
	}


	/////////////////////////////////////////
	public class SaveDataXML {
		public XDocument xdoc;

		public List<XMLCharaData> PlayerDataManual;

		public XElement mSystemData_mEditPl;
		public XElement mSystemData_mEditPawn;
		public XElement mSystemData_mOption;

		public XElement mSaveShop;


		

		/////////////////////////////////////////
		void Read_cSAVE_DATA_PL( XElement element ) {
			var xmlchr = new XMLCharaData();

			foreach( var e in element.Elements() ) {
				switch( e.attrbute_name() ) {
					case "mEdit":
						xmlchr.mEdit = e;
						break;
					case "mParam":
						xmlchr.mParam = e;
						break;
				}
			}
			PlayerDataManual.Add( xmlchr );
		}


		/////////////////////////////////////////
		void Read_cSAVE_DATA_CMC( XElement element ) {
			var xmlchr = new XMLCharaData();

			xmlchr.CMC = element;

			foreach( var e in element.Elements() ) {
				switch( e.attrbute_name() ) {
					case "mEdit":
						xmlchr.mEdit = e;
						break;
					case "mParam":
						xmlchr.mParam = e;
						break;
				}
			}
			PlayerDataManual.Add( xmlchr );
		}


		/////////////////////////////////////////
		void Read_cSAVE_SHOP( XElement element ) {
		}


		/////////////////////////////////////////
		public void Read() {
			var saveFolderPath = Utils.SaveFolder;
			if( !saveFolderPath.IsExistsDirectory() ) {
				UINotifyStatus.Error( $"Not Found: {saveFolderPath}" );
				return;
			}
			//var savPath = $"{saveFolderPath}\\{D.DDDA_sav}";
			var filepath = $"{saveFolderPath}\\{D.DDDA_sav_xml}";

			if( !filepath.IsExistsFile() ) {
				return;
			}

			xdoc = XDocument.Load( filepath );

			foreach( var e1 in xdoc.Root.Elements() ) {
				switch( e1.attrbute_name() ) {
					case "mPlayerDataManual":
						PlayerDataManual = new List<XMLCharaData>();
						foreach( var e2 in e1.Elements() ) {
							switch( e2.attrbute_name() ) {
								case "mPlCmcEditAndParam":
									foreach( var e3 in e2.Elements() ) {
										switch( e3.attrbute_name() ) {
											case "mPl":
												Read_cSAVE_DATA_PL( e3 );
												break;
											case "mCmc":
												foreach( var e4 in e3.Elements() ) {
													Read_cSAVE_DATA_CMC( e4 );
												}
												break;
										}
									}
									break;
								case "mPlGameData":
									foreach( var e3 in e2.Elements() ) {
										if( e3.attrbute_name() == "mSaveShop" ) {
											mSaveShop = e3;
										}
									}
									break;
							}
						}
						break;

					case "mSystemData":
						foreach( var e2 in e1.Elements() ) {
							switch( e2.attrbute_name() ) {
								case "mOption":
									mSystemData_mOption = e2;
									break;
								case "mEditPl":
									mSystemData_mEditPl = e2;
									break;
								case "mEditPawn":
									mSystemData_mEditPawn = e2;
									break;
							}
						}
						break;
				}
			}
		}



		/////////////////////////////////////////
		void InternalWrite( XElement element, cSAVE_DATA_EDIT saveDataEdit ) {

			void writeArray( XElement e, FieldInfo field ) {
				var s = Utils.ModifyFieldName( e.attrbute_name() );

				Array a = (Array) field.GetValue( saveDataEdit );
				int i = 0;
				foreach( var p in e.Elements() ) {
					p.SetAttributeValue( "value", a.GetValue( i ) );
					i++;
				}
			}

			foreach( var e in element.Elements() ) {

				var atbName = Utils.ModifyFieldName( e.attrbute_name() );

				var field = Utils.GetField<cSAVE_DATA_EDIT>( atbName );
				if( field == null ) continue;

				switch( e.Name.ToString() ) {
					case "array":
						writeArray( e, field );
						break;
					case "u8":
					case "u32":
						e.SetAttributeValue( "value", field.GetValue( saveDataEdit ) );
						break;
				}
			}
		}


		/////////////////////////////////////////
		void Write_cSAVE_DATA<T>( XElement element, T data, List<string> ignoreFileds = null ) {
			var t = typeof( T );
			if( ignoreFileds == null ) {
				ignoreFileds = new List<string>();
			}
			void writeArray( XElement e, FieldInfo field ) {
				Array a = (Array) field.GetValue( data );
				int i = 0;
				foreach( var p in e.Elements() ) {
					p.SetAttributeValue( "value", a.GetValue( i ) );
					i++;
				}
			}

			void writeClass( XElement e, Array array ) {
				if( array == null ) {
					Debug.Error( "不正なデータ、エクスポートが不完全" );
					return;
				}
				int i = 0;
				foreach( var e1 in e.Elements() ) {
					var arrayElement = array.GetValue( i );
					if( e1.attrbute_type() == "sItemManager::cITEM_PARAM_DATA" ) {
						var type = typeof( cITEM_PARAM_DATA );
						foreach( var e2 in e1.Elements() ) {
							var atbName = e2.attrbute_name().Replace( "data.", "" );
							var field = type.GetField( atbName );
							if( field == null ) continue;
							e2.SetAttributeValue( "value", field.GetValue( arrayElement ) );
						}
					}
					i++;
				}
			}

			foreach( var e in element.Elements() ) {
				var atbName = Utils.ModifyFieldName( e.attrbute_name() );

				var field = Utils.GetField<T>( atbName );
				if( field == null ) continue;
				if( 0 <= ignoreFileds.FindIndex( x => x == atbName ) ) continue;

				switch( e.Name.ToString() ) {
					case "array":
						if( e.attrbute_type() == "class" ) {
							writeClass( e, (Array) field.GetValue( data ) );
						}
						else {
							writeArray( e, field );
						}
						break;
					case "u8":
					case "u32":
					case "f32":
						e.SetAttributeValue( "value", field.GetValue( data ) );

						break;
				}
			}
		}


		/////////////////////////////////////////
		public void Write( int index, CharaData chrData, bool edit, bool ability, bool cmc ) {
			if( index < 0 ) {
				Debug.Warning( $"indexが-1" );
				return;
			}

			#region 容姿
			if( edit ) {
				InternalWrite( PlayerDataManual[ index ].mEdit, chrData.mEdit );

				if( index == 0 ) {
					InternalWrite( mSystemData_mEditPl, chrData.mEdit );
				}
				else if( index == 1 ) {
					InternalWrite( mSystemData_mEditPawn, chrData.mEdit );
				}
			}
			#endregion

			if( ability ) {
				var lst = new List<string>();
				//lst.Add( "mLevel" );
				//lst.Add( "mJob" );
				Write_cSAVE_DATA( PlayerDataManual[ index ].mParam, chrData.mParam, lst );
			}
			if( cmc ) {
				if( PlayerDataManual[ index ].CMC == null ) return;
				if( !chrData.isPawn ) return;
				Write_cSAVE_DATA( PlayerDataManual[ index ].CMC, chrData );
			}
		}


		/////////////////////////////////////////
		public void WriteShop( cSAVE_SHOP[] shopList ) {
			void writeArray( XElement e, object obj, FieldInfo field ) {
				Array a = (Array) field.GetValue( obj );
				int i = 0;
				foreach( var p in e.Elements() ) {
					p.SetAttributeValue( "value", a.GetValue( i ) );
					i++;
				}
			}
			int i = 0;
			foreach( var e1 in mSaveShop.Elements() ) {
				var shop = shopList[ i ];
				foreach( var e2 in e1.Elements() ) {
					switch( e2.Name.ToString() ) {
						case "s32":
							e2.SetAttributeValue( "value", shop.mNpcId );
							break;
						case "array":
							var field = typeof( cSAVE_SHOP ).GetField( e2.attrbute_name() );
							writeArray( e2, shop, field );
							//switch( e2.attrbute_type() ) {
							//	case "s16":
							//		field.SetValue( shop, e2.GetArrayS16() );
							//		e2.SetAttributeValue( "value", shop.mNpcId );
							//		break;
							//	case "s8":
							//		field.SetValue( shop, e2.GetArrayS8() );
							//		break;
							//	case "s32":
							//		field.SetValue( shop, e2.GetArrayS32() );
							//		break;
							//}
							break;
					}
				}
				i++;
			}
		}
	}
}
