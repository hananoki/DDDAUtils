using HananokiLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DDDAUtils {

	//////////////////////////////////////////////////////////////////////////////////
	[TypeConverter( typeof( TreeNode_CharaData_TypeConverter ) )]
	public class TreeNode_CharaData : TreeNode {
		XMLCharaData xmlchr;
		CharaData exportData;

		string filePath;
		internal int chrIndex = -1;

		SaveDataXML saveDataXML;

		/////////////////////////////////////////
		public TreeNode_CharaData( SaveDataXML xml, int index, string name, XMLCharaData xmlchr ) : base( name ) {
			this.saveDataXML = xml;
			this.xmlchr = xmlchr;
			this.chrIndex = index;
		}


		/////////////////////////////////////////
		public TreeNode_CharaData( SaveDataXML xml, string name, string filePath ) : base( name ) {
			this.saveDataXML = xml;
			this.filePath = filePath;
		}


		/////////////////////////////////////////
		public bool hasElement => xmlchr != null;


		/////////////////////////////////////////
		public void ClearExportData() => exportData = null;


		///////////////////////////////////////////
		void WriteXML( bool edit, bool ability, bool cmc ) {
			if( chrIndex < 0 ) return;

			saveDataXML.Write( chrIndex, exportData, edit, ability, cmc );
		}


		///////////////////////////////////////////
		public void SetEquipItem( int index, int itemNo, int lv ) {
			var equipItem = GetCharaData().mParam.mEquipItem[ index ];
			equipItem.mItemNo = (short) itemNo;
			equipItem.mFlag = (uint) lv;
			if( equipItem.mNum == 0 ) {
				equipItem.mNum = 1;
			}
			WriteXML( false, true, false );
		}


		///////////////////////////////////////////
		public void SetAbility( int index, int abilityNo ) {
			var chrData = GetCharaData();
			chrData.mParam.mAbility[ index ] = (sbyte) abilityNo;
			uint infoIndex = (uint) ( abilityNo / 32 );
			int infoBit = abilityNo % 32;

			chrData.mParam.mAbilityInfo[ infoIndex ].Enable( (uint) 1 << infoBit );
			WriteXML( false, true, false );
		}

		///////////////////////////////////////////
		public void ToggleNormalSkillFlag( int skillNo, bool flag ) {
			var chrData = GetCharaData();
			int infoIndex = ( skillNo / 32 );
			uint infoBit = (uint) 1 << ( skillNo % 32 );
			chrData.mParam.mSkillLv1[ infoIndex ].Toggle( infoBit, flag );
			WriteXML( false, true, false );
		}


		///////////////////////////////////////////
		public void SetSkill( DDWeaponType weaponType, int index, int skillNo, int lv ) {
			var chrData = GetCharaData();
			var weaponSkill = chrData.GetWeaponSkill( weaponType );

			weaponSkill[ index ] = (short) skillNo;

			if( skillNo < 0 ) return;

			uint infoIndex = (uint) ( skillNo / 32 );
			int infoBit = skillNo % 32;

			if( lv == 1 ) {
				chrData.mParam.mSkillLv1[ infoIndex ].Enable( (uint) 1 << infoBit );
				chrData.mParam.mSkillLv2[ infoIndex ].Disable( (uint) 1 << infoBit );
			}
			else if( lv == 2 ) {
				chrData.mParam.mSkillLv1[ infoIndex ].Disable( (uint) 1 << infoBit );
				chrData.mParam.mSkillLv2[ infoIndex ].Enable( (uint) 1 << infoBit );
			}
			WriteXML( false, true, false );
		}


		///////////////////////////////////////////
		public void SetUseSceneTalk( int index, DDTalkType ttype ) {
			var chrData = GetCharaData();
			chrData.mUseSceneTalk[ index ] = (uint) ttype;
			WriteXML( false, false, true );
		}


		///////////////////////////////////////////
		public void SetPawnPersonality( Control_Personality[] controls ) {
			var values = controls.Select( x => (float) x.Value ).ToArray();
			var chrData = GetCharaData();
			chrData.Set_DDPawnPersonality_Values( values );
			WriteXML( false, false, true );
		}


		/////////////////////////////////////////
		public void SetEditData( Dictionary<string, Control_EditParam> controls ) {
			var chrData = GetCharaData();

			var t = typeof( cSAVE_DATA_EDIT );

			foreach( var f in t.GetFields() ) {
				controls.TryGetValue( f.Name, out var ctrl );
				if( ctrl == null ) continue;
				f.SetValueInt( chrData.mEdit, ctrl.GetValue() );
			}

			WriteXML( true, false, false );
		}


		/////////////////////////////////////////
		public CharaData GetCharaData() {
			if( exportData == null ) {
				exportData = new CharaData();

				if( xmlchr != null ) {
					exportData.GetDataFromXml( xmlchr );
				}
				else if( filePath.IsExistsFile() ) {
					var xmlSerializer2 = new XmlSerializer( typeof( CharaData ) );

					using( var streamReader = new StreamReader( filePath, Encoding.UTF8 ) ) {
						exportData = (CharaData) xmlSerializer2.Deserialize( streamReader ); // （3）
					}
				}
			}
			return exportData;
		}

	}
}
