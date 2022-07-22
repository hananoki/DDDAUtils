using HananokiLib;
using System.Xml.Linq;

namespace DDDAUtils {

	//////////////////////////////////////////////////////////////////////////////////
	public class CharaData : cSAVE_DATA_CMC {

		public bool isPawn;

		/////////////////////////////////////////
		public void GetDataFromXml( XMLCharaData xmlchr ) {
			mEdit = Read_cSAVE_DATA_EDIT( xmlchr.mEdit );
			mParam = Read_cSAVE_DATA_PARAM( xmlchr.mParam );

			if( xmlchr.CMC == null ) return;

			isPawn = true;

			var t = typeof( cSAVE_DATA_CMC );

			foreach( var e in xmlchr.CMC.Elements() ) {
				var atbName = Utils.ModifyFieldName( e.attrbute_name() );
				var field = t.GetField( atbName );
				if( field == null ) {
					Debug.Log( atbName );
					continue;
				}
				switch( e.Name.ToString() ) {
					case "array":
						switch( e.attrbute_type() ) {
							//case "s8":
							//	field.SetValue( this, e.GetArrayS8() );
							//	break;
							case "u8":
								field.SetValue( this, e.GetArrayU8() );
								break;
							//case "s16":
							//	field.SetValue( this, e.GetArrayS16() );
							//	break;
							case "u32":
								field.SetValue( this, e.GetArrayU32() );
								break;
							case "f32":
								field.SetValue( this, e.GetArrayF32() );
								break;
						}
						break;
					case "u32":
						field.SetValue( this, e.attrbute_value_u32() );
						break;
					case "f32":
						field.SetValue( this, e.attrbute_value_f32() );
						break;
				}
			}
		}


		/////////////////////////////////////////
		public static cSAVE_DATA_EDIT Read_cSAVE_DATA_EDIT( XElement element ) {
			var result = new cSAVE_DATA_EDIT();

			foreach( var e in element.Elements() ) {

				var atbName = Utils.ModifyFieldName( e.attrbute_name() );

				var field = Utils.GetField<cSAVE_DATA_EDIT>( atbName );
				if( field == null ) continue;

				switch( e.Name.ToString() ) {
					case "array":
						field.SetValue( result, e.GetArrayU8() );
						break;

					case "u8":
						field.SetValue( result, e.attrbute_value_u8() );
						break;

					case "u32":
						field.SetValue( result, e.attrbute_value_u32() );
						break;
				}
			}

			return result;
		}


		/////////////////////////////////////////
		cSAVE_DATA_PARAM Read_cSAVE_DATA_PARAM( XElement element ) {

			var t = typeof( cSAVE_DATA_PARAM );

			var result = new cSAVE_DATA_PARAM();

			foreach( var e in element.Elements() ) {

				var atbName = Utils.ModifyFieldName( e.attrbute_name() );

				var field = Utils.GetField<cSAVE_DATA_PARAM>( atbName );
				if( field == null ) continue;

				switch( e.Name.ToString() ) {
					case "array":
						switch( e.attrbute_type() ) {
							case "class":
								if( atbName == "mEquipItem" ) {
									field.SetValue( result, e.GetArrayITEM_PARAM_DATA() );
								}
								break;
							case "s8":
								field.SetValue( result, e.GetArrayS8() );
								break;
							case "u8":
								field.SetValue( result, e.GetArrayU8() );
								break;
							case "s16":
								field.SetValue( result, e.GetArrayS16() );
								break;
							case "u32":
								field.SetValue( result, e.GetArrayU32() );
								break;
						}
						break;

					case "u8":
						field.SetValue( result, e.attrbute_value_u8() );
						break;
					case "f32":
						field.SetValue( result, e.attrbute_value_f32() );
						break;
				}
			}

			return result;
		}

		/////////////////////////////////////////
		public void ResetSkill() {
			mParam.mWeaponSkill_SWORD.Fill( -1 );
			mParam.mWeaponSkill_MACE.Fill( -1 );
			mParam.mWeaponSkill_GSWORD.Fill( -1 );
			mParam.mWeaponSkill_DAGGER.Fill( -1 );
			mParam.mWeaponSkill_WAND.Fill( -1 );
			mParam.mWeaponSkill_WAND_DX.Fill( -1 );
			mParam.mWeaponSkill_HAMMER.Fill( -1 );
			mParam.mWeaponSkill_SHIELD.Fill( -1 );
			mParam.mWeaponSkill_SHIELD_L.Fill( -1 );
			mParam.mWeaponSkill_BOW.Fill( -1 );
			mParam.mWeaponSkill_BOW_L.Fill( -1 );
			mParam.mWeaponSkill_BOW_MG.Fill( -1 );
			mParam.mSkillLv1.Fill( 0 );
			mParam.mSkillLv2.Fill( 0 );
		}

		/////////////////////////////////////////
		public void ResetAbility() {
			mParam.mAbility.Fill( -1 );
			mParam.mAbilityInfo.Fill( 0 );
		}

		/////////////////////////////////////////
		public void ResetSkillAndAbility() {
			mParam.mWeaponSkill_SWORD.Fill( -1 );
			mParam.mWeaponSkill_MACE.Fill( -1 );
			mParam.mWeaponSkill_GSWORD.Fill( -1 );
			mParam.mWeaponSkill_DAGGER.Fill( -1 );
			mParam.mWeaponSkill_WAND.Fill( -1 );
			mParam.mWeaponSkill_WAND_DX.Fill( -1 );
			mParam.mWeaponSkill_HAMMER.Fill( -1 );
			mParam.mWeaponSkill_SHIELD.Fill( -1 );
			mParam.mWeaponSkill_SHIELD_L.Fill( -1 );
			mParam.mWeaponSkill_BOW.Fill( -1 );
			mParam.mWeaponSkill_BOW_L.Fill( -1 );
			mParam.mWeaponSkill_BOW_MG.Fill( -1 );
			mParam.mSkillLv1.Fill( 0 );
			mParam.mSkillLv2.Fill( 0 );
			mParam.mAbility.Fill( -1 );
			mParam.mAbilityInfo.Fill( 0 );
		}


		/////////////////////////////////////////
		public void ResetTalk() {
			mUseSceneTalk.Fill( 0 );
		}
	}
}
