using HananokiLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

namespace DDDAUtils {

	//////////////////////////////////////////////////////////////////////////////////
	public class cSAVE_DATA_CMC {
		[Browsable( false )]
		public cSAVE_DATA_EDIT mEdit;
		[Browsable( false )]
		public cSAVE_DATA_PARAM mParam;

		public uint[] mUseSceneTalk;
		public uint[] mStudyFlag;
		public uint[] mLocalStudyFlag;
		public float[] mStudyData_EncountFrame;
		public uint[] mStudyData_KillCnt;
		public int[] mStudyData_UniqueCnt; ///<<<

		public uint mInfo_INFO_TYPE_BELLIGERENT_mInfoType;
		public float mInfo_INFO_TYPE_BELLIGERENT_mValue;
		public uint mInfo_INFO_TYPE_BELLIGERENT_mStatus;

		public uint mInfo_INFO_TYPE_PRUDENT_mInfoType;
		public float mInfo_INFO_TYPE_PRUDENT_mValue;
		public uint mInfo_INFO_TYPE_PRUDENT_mStatus;

		public uint mInfo_INFO_TYPE_POOR_AIM_mInfoType;
		public float mInfo_INFO_TYPE_POOR_AIM_mValue;
		public uint mInfo_INFO_TYPE_POOR_AIM_mStatus;

		public uint mInfo_INFO_TYPE_STRATEGY_mInfoType;
		public float mInfo_INFO_TYPE_STRATEGY_mValue;
		public uint mInfo_INFO_TYPE_STRATEGY_mStatus;

		public uint mInfo_INFO_TYPE_TACTICS_mInfoType;
		public float mInfo_INFO_TYPE_TACTICS_mValue;
		public uint mInfo_INFO_TYPE_TACTICS_mStatus;

		public uint mInfo_INFO_TYPE_PROTECTION_mInfoType;
		public float mInfo_INFO_TYPE_PROTECTION_mValue;
		public uint mInfo_INFO_TYPE_PROTECTION_mStatus;

		public uint mInfo_INFO_TYPE_SAME_SUPPORT_mInfoType;
		public float mInfo_INFO_TYPE_SAME_SUPPORT_mValue;
		public uint mInfo_INFO_TYPE_SAME_SUPPORT_mStatus;

		public uint mInfo_INFO_TYPE_CURIOSITY_mInfoType;
		public float mInfo_INFO_TYPE_CURIOSITY_mValue;
		public uint mInfo_INFO_TYPE_CURIOSITY_mStatus;

		public uint mInfo_INFO_TYPE_GATHER_mInfoType;
		public float mInfo_INFO_TYPE_GATHER_mValue;
		public uint mInfo_INFO_TYPE_GATHER_mStatus;

		public uint mInfoEx_INFO_TYPE_EX_TALK_mInfoType;
		public float mInfoEx_INFO_TYPE_EX_TALK_mValue;

		public uint mInfoEx_INFO_TYPE_EX_SKILL_USE_mInfoType;
		public float mInfoEx_INFO_TYPE_EX_SKILL_USE_mValue;
	}


	//////////////////////////////////////////////////////////////////////////////////
	public class cSAVE_DATA_EDIT {
		public string GetConvertToName() {
			var bytes = mNameStr.Where( s => s != 0 ).Select( x => (byte) x ).ToArray();
			return System.Text.Encoding.UTF8.GetString( bytes );
		}

		public int[] mNameStr; ///<<<
		[Range( 0, 1 )]
		public byte mGender;
		public uint mNickname;
		[Range( 0, 11 )]
		public byte mVoice; // 0-11
		public byte mPersonality;
		[Range( 0, 47*2 )]
		public byte mFaceBase;
		public byte mFaceEye;
		public byte mFaceEyebrow;

		public byte mFaceNose;
		public byte mFaceMouth;
		public byte mFaceEar;
		public byte mOfsXFaceEye;
		public byte mOfsYFaceEye;
		public byte mOfsXFaceEyebrow;
		public byte mOfsYFaceEyebrow;

		public byte mOfsYFaceNose;
		public byte mOfsYFaceMouth;
		public byte mOfsYFaceEar;
		public byte mOfsZFaceEar;
		public byte mSclFaceEye;
		public byte mSclFaceNose;

		public byte mHumanHead;

		public byte mColorEyeR;
		public byte mColorEyeL;
		
		
		public byte mColorMakeup;

		[Range( 0, 61 )]
		public byte mHairNo;
		[Range( 0, 41 )]
		public byte mBeardNo;


		// 体系のエディット--

		//////
		[Range( 0, 8 )]
		public byte mHumanBodyAll;//体系のエディット・身長
		[Range( 0, 4 )]
		public byte mBodySlender;//体系のエディット・体重
		[Range( 0, 52 )] //体形のエディット
		public byte mColorBody;

		//////
		[Range( 0, 4 )]
		public byte mBodyMuscle;//体系のエディット・筋肉量
		[Range( 0, 4 )]
		public byte mBustScale;//体系のエディット・バスト

		//////
		[Range( 0, 11 )]
		public byte mHumanBody;//体系のエディット・胴

		//////
		[Range( 0, 11 )]
		public byte mHumanArm;//体系のエディット・腕

		//////
		[Range( 0, 11 )]
		public byte mHumanLeg;//体系のエディット・脚

		//////
		[Range( 0, 4 )]
		public byte mPosture; // 姿勢　かがむ　そらす
		[Range( 0, 4 )] //体形のエディット
		public byte mMovement; // 動き　女らしい　男らしい

		// 特徴のエディット--
		[Range( 0, 47 )]
		public byte mScarNo; // 傷
		[Range( 0, 4 )]
		public byte mWrinkleFace; // しわ
		[Range( 0, 15 )]
		public byte mMakeupFace; // 化粧

		// 全体の色を調整
		public byte mColorBeard; // 毛髪の色
		public byte mColorHair; // 毛髪の色
		public byte mColorEyebrow;// 毛髪の色
	}


	//////////////////////////////////////////////////////////////////////////////////
	public class cSAVE_DATA_PARAM {
		public byte mLevel;
		public byte mJob;
		public int[] mJobLevel; ///<<<

		public short[] mWeaponSkill_SWORD;
		public short[] mWeaponSkill_MACE;
		public short[] mWeaponSkill_GSWORD;
		public short[] mWeaponSkill_DAGGER;
		public short[] mWeaponSkill_WAND;
		public short[] mWeaponSkill_WAND_DX;
		public short[] mWeaponSkill_HAMMER;
		public short[] mWeaponSkill_SHIELD;
		public short[] mWeaponSkill_SHIELD_L;
		public short[] mWeaponSkill_BOW;
		public short[] mWeaponSkill_BOW_L;
		public short[] mWeaponSkill_BOW_MG;

		public uint[] mSkillLv1;
		public uint[] mSkillLv2;
		public sbyte[] mAbility;
		public uint[] mAbilityInfo;

		public cITEM_PARAM_DATA[] mEquipItem;

		public float mHp;
		public float mHpMax;
		public float mHpMaxWhite;

		public float mStamina;
		public float mStaminaBase;
		public float mStaminaLv;

		public float mBasicAttack;
		public float mBasicDefend;
		public float mBasicMgcAttack;
		public float mBasicMgcDefend;

		public uint mExp;
	}


	//////////////////////////////////////////////////////////////////////////////////
	public class cITEM_PARAM_DATA {
		public short mNum;
		public short mItemNo;
		public uint mFlag;
		public ushort mChgNum;
		public ushort mDay1;
		public ushort mDay2;
		public ushort mDay3;
		public sbyte mMutationPool;
		//public sbyte mOwnerId;
		public uint mKey;
	}

	//////////////////////////////////////////////////////////////////////////////////
	public class cSAVE_SHOP {
		public int mNpcId;
		public short[] mItemNo;
		public sbyte[] mNowDay;
		public short[] mNowNum;
		public sbyte[] mInitDay;
		public short[] mInitNum;
		public uint[] mOpF;
	}


	//////////////////////////////////////////////////////////////////////////////////
	public class OptionData {
		SaveDataXML xml;
		XElement mFlag2;

		public OptionData( SaveDataXML xml ) {
			this.xml = xml;
			foreach( var e in xml.mSystemData_mOption.Elements() ) {
				if( e.attrbute_name() == "mFlag2" ) {
					mFlag2 = e;
					break;
				}
			}
		}
		public byte GetFlag() {
			return mFlag2.attrbute_value_u8();
		}
		public void SetFlag( byte flag ) {
			mFlag2.SetAttributeValue( "value", flag );
		}
	}


	//////////////////////////////////////////////////////////////////////////////////
	public static class cSAVE_DATA_CMC_Extension {
		/////////////////////////////////////////
		public static short[] GetWeaponSkill( this cSAVE_DATA_CMC self, DDWeaponType weaponType ) {
			var tbl = new short[][]{
				self.mParam.mWeaponSkill_SWORD,
				self.mParam.mWeaponSkill_MACE,
				self.mParam.mWeaponSkill_GSWORD,
				self.mParam.mWeaponSkill_DAGGER,

				self.mParam.mWeaponSkill_WAND,
				self.mParam.mWeaponSkill_WAND_DX,
				self.mParam.mWeaponSkill_HAMMER,
				self.mParam.mWeaponSkill_SHIELD,

				self.mParam.mWeaponSkill_SHIELD_L,
				self.mParam.mWeaponSkill_BOW,
				self.mParam.mWeaponSkill_BOW_L,
				self.mParam.mWeaponSkill_BOW_MG,
			};
			return tbl[ (int) weaponType ];
		}

		/////////////////////////////////////////
		public static (int index, int bit) GetBitInfo( this cSAVE_DATA_CMC self, int no ) {
			return (no / 32, no % 32);
		}

		/////////////////////////////////////////
		public static int GetSkillLevel( this cSAVE_DATA_CMC self, int skillNo ) {
			if( skillNo < 0 ) return 0;
			var info = GetBitInfo( self, skillNo );
			return self.mParam.mSkillLv2[ info.index ].Has( 1 << info.bit ) ? 2 : 1;
		}

		/////////////////////////////////////////
		public static uint Get_DDPawnPersonality_Status( this cSAVE_DATA_CMC self, DDPawnPersonality t ) {
			switch( t ) {
				case DDPawnPersonality.Belligerent:
					return self.mInfo_INFO_TYPE_BELLIGERENT_mStatus;
				case DDPawnPersonality.Prudent:
					return self.mInfo_INFO_TYPE_PRUDENT_mStatus;
				case DDPawnPersonality.PoorAim:
					return self.mInfo_INFO_TYPE_POOR_AIM_mStatus;
				case DDPawnPersonality.Strategy:
					return self.mInfo_INFO_TYPE_STRATEGY_mStatus;
				case DDPawnPersonality.Tactics:
					return self.mInfo_INFO_TYPE_TACTICS_mStatus;
				case DDPawnPersonality.Protection:
					return self.mInfo_INFO_TYPE_PROTECTION_mStatus;
				case DDPawnPersonality.SameSupport:
					return self.mInfo_INFO_TYPE_SAME_SUPPORT_mStatus;
				case DDPawnPersonality.Curiosity:
					return self.mInfo_INFO_TYPE_CURIOSITY_mStatus;
				case DDPawnPersonality.Gather:
					return self.mInfo_INFO_TYPE_GATHER_mStatus;
			}
			return 0;
		}


		/////////////////////////////////////////
		public static void Set_DDPawnPersonality_Status( this cSAVE_DATA_CMC self, DDPawnPersonality t, uint status ) {
			switch( t ) {
				case DDPawnPersonality.Belligerent:
					self.mInfo_INFO_TYPE_BELLIGERENT_mStatus = status;
					break;
				case DDPawnPersonality.Prudent:
					self.mInfo_INFO_TYPE_PRUDENT_mStatus = status;
					break;
				case DDPawnPersonality.PoorAim:
					self.mInfo_INFO_TYPE_POOR_AIM_mStatus = status;
					break;
				case DDPawnPersonality.Strategy:
					self.mInfo_INFO_TYPE_STRATEGY_mStatus = status;
					break;
				case DDPawnPersonality.Tactics:
					self.mInfo_INFO_TYPE_TACTICS_mStatus = status;
					break;
				case DDPawnPersonality.Protection:
					self.mInfo_INFO_TYPE_PROTECTION_mStatus = status;
					break;
				case DDPawnPersonality.SameSupport:
					self.mInfo_INFO_TYPE_SAME_SUPPORT_mStatus = status;
					break;
				case DDPawnPersonality.Curiosity:
					self.mInfo_INFO_TYPE_CURIOSITY_mStatus = status;
					break;
				case DDPawnPersonality.Gather:
					self.mInfo_INFO_TYPE_GATHER_mStatus = status;
					break;
			}
		}


		/////////////////////////////////////////
		public static float Get_DDPawnPersonality_Value( this cSAVE_DATA_CMC self, DDPawnPersonality t ) {
			switch( t ) {
				case DDPawnPersonality.Belligerent:
					return self.mInfo_INFO_TYPE_BELLIGERENT_mValue;
				case DDPawnPersonality.Prudent:
					return self.mInfo_INFO_TYPE_PRUDENT_mValue;
				case DDPawnPersonality.PoorAim:
					return self.mInfo_INFO_TYPE_POOR_AIM_mValue;
				case DDPawnPersonality.Strategy:
					return self.mInfo_INFO_TYPE_STRATEGY_mValue;
				case DDPawnPersonality.Tactics:
					return self.mInfo_INFO_TYPE_TACTICS_mValue;
				case DDPawnPersonality.Protection:
					return self.mInfo_INFO_TYPE_PROTECTION_mValue;
				case DDPawnPersonality.SameSupport:
					return self.mInfo_INFO_TYPE_SAME_SUPPORT_mValue;
				case DDPawnPersonality.Curiosity:
					return self.mInfo_INFO_TYPE_CURIOSITY_mValue;
				case DDPawnPersonality.Gather:
					return self.mInfo_INFO_TYPE_GATHER_mValue;
			}
			return 500.0f;
		}


		/////////////////////////////////////////
		public static void Set_DDPawnPersonality_Value( this cSAVE_DATA_CMC self, DDPawnPersonality t, float value ) {
			switch( t ) {
				case DDPawnPersonality.Belligerent:
					self.mInfo_INFO_TYPE_BELLIGERENT_mValue = value;
					break;
				case DDPawnPersonality.Prudent:
					self.mInfo_INFO_TYPE_PRUDENT_mValue = value;
					break;
				case DDPawnPersonality.PoorAim:
					self.mInfo_INFO_TYPE_POOR_AIM_mValue = value;
					break;
				case DDPawnPersonality.Strategy:
					self.mInfo_INFO_TYPE_STRATEGY_mValue = value;
					break;
				case DDPawnPersonality.Tactics:
					self.mInfo_INFO_TYPE_TACTICS_mValue = value;
					break;
				case DDPawnPersonality.Protection:
					self.mInfo_INFO_TYPE_PROTECTION_mValue = value;
					break;
				case DDPawnPersonality.SameSupport:
					self.mInfo_INFO_TYPE_SAME_SUPPORT_mValue = value;
					break;
				case DDPawnPersonality.Curiosity:
					self.mInfo_INFO_TYPE_CURIOSITY_mValue = value;
					break;
				case DDPawnPersonality.Gather:
					self.mInfo_INFO_TYPE_GATHER_mValue = value;
					break;
			}
		}


		/////////////////////////////////////////
		public static void Set_DDPawnPersonality_Values( this cSAVE_DATA_CMC self, float[] values ) {
			var symbols = EnumUtils.GetArray<DDPawnPersonality>();
			for( int i = 0; i < symbols.Length; i++ ) {
				Set_DDPawnPersonality_Value( self, symbols[ i ], values[ i ] );
				Set_DDPawnPersonality_Status( self, symbols[ i ], 0 );
			}

			var tpl = new List<System.Tuple<DDPawnPersonality, float>>();
			foreach( var e in symbols ) {
				tpl.Add( new System.Tuple<DDPawnPersonality, float>( e, Get_DDPawnPersonality_Value( self, e ) ) );
			}
			var sort = tpl.OrderBy( x => x.Item2 ).Reverse().ToArray();

			Set_DDPawnPersonality_Status( self, sort[ 0 ].Item1, 2 );
			Set_DDPawnPersonality_Status( self, sort[ 1 ].Item1, 1 );
		}
	}

}
