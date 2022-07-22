using HananokiLib;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DDDAUtils {
	//////////////////////////////////////////////////////////////////////////////////
	public static class D {
		public static string DDDA_sav = "DDDA.sav";
		public static string DDDA_sav_xml = "DDDA.sav.xml";
		public static string export = "export";
		public static string profile = "profile";
	}


	//////////////////////////////////////////////////////////////////////////////////
	internal class Utils {

		static FieldInfoCache fields_cSAVE_DATA_EDIT;
		static FieldInfoCache fields_cSAVE_DATA_PARAM;
		static FieldInfoCache fields_cSAVE_DATA_CMC;

		/////////////////////////////////////////
		public static string SaveFolder {
			get => $@"{GetSteamFolder()}\userdata\115406340\367500\remote".SeparatorToOS();
		}

		/////////////////////////////////////////
		public static string BinFolder {
			get => $@"{Helper.s_appPath}\bin".SeparatorToOS();
		}

		/////////////////////////////////////////
		public static bool HasDDsavetool() {
			return $@"{BinFolder}\DDsavetool.exe".IsExistsFile();
		}


		/////////////////////////////////////////
		public static string GetSteamFolder() {
			using( var regkey = Registry.CurrentUser.OpenSubKey( @"Software\Valve\Steam", false ) ) {
				//キーが存在しないときは null が返される
				if( regkey == null ) {
					Debug.Log( $@"Software\Valve\Steam None" );
					return "";
				}
				string stringValue = (string) regkey.GetValue( "SteamPath" );

				return stringValue;
			}
		}


		/////////////////////////////////////////
		public static string ExportDataFolder
			=> $"{Helper.s_appPath}\\{D.export}";



		/////////////////////////////////////////
		public static TreeNode_CharaData GetCharaNode()
			=> MainForm.instance.treeView1.SelectedNode as TreeNode_CharaData;



		/////////////////////////////////////////
		public static void WarningNode()
			=> UINotifyStatus.Warning( "ノードを選択してください" );


		/////////////////////////////////////////
		public static string ModifyFieldName( string str ) {
			var s = str;
			s = s.Replace( " ", "" );
			s = s.Replace( "[nWeapon::", "_" ).Replace( "]", "" );
			s = s.Replace( "(u8*)", "" );
			s = s.Replace( ".", "_" );
			s = s.Replace( "[", "_" ).Replace( "].", "_" );
			return s;
		}


		/////////////////////////////////////////
		public static FieldInfo GetField<T>( string filedName ) {
			var t = typeof( T );
			if( t == typeof( cSAVE_DATA_EDIT ) ) {
				FieldInfoCache.Make( ref fields_cSAVE_DATA_EDIT, typeof( cSAVE_DATA_EDIT ) );
				return fields_cSAVE_DATA_EDIT[ filedName ];
			}
			else if( t == typeof( cSAVE_DATA_PARAM ) ) {
				FieldInfoCache.Make( ref fields_cSAVE_DATA_PARAM, typeof( cSAVE_DATA_PARAM ) );
				return fields_cSAVE_DATA_PARAM[ filedName ];
			}
			else if( t == typeof( cSAVE_DATA_CMC ) || t == typeof( CharaData ) ) {
				FieldInfoCache.Make( ref fields_cSAVE_DATA_CMC, typeof( cSAVE_DATA_CMC ) );
				return fields_cSAVE_DATA_CMC[ filedName ];
			}
			return null;
		}
	}


	/////////////////////////////////////////
	public class FieldInfoCache {
		Dictionary<string, FieldInfo> cache = new Dictionary<string, FieldInfo>();

		/////////////////////////////////////////
		public static void Make( ref FieldInfoCache self, Type type ) {
			if( self != null ) return;

			self = new FieldInfoCache();
			foreach( var f in type.GetFields() ) {
				self.cache.Add( f.Name, f );
			}
		}

		/////////////////////////////////////////
		public FieldInfo this[ string name ] {
			get {
				cache.TryGetValue( name, out FieldInfo field );
				return field;
			}
		}
	}
}
