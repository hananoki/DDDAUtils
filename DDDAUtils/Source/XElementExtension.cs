using System;
using System.Xml.Linq;

namespace DDDAUtils {

	public static class XElementExtension {
		public static string attrbute_name( this XElement element ) {
			return element.Attribute( "name" ).Value;
		}
		public static string attrbute_type( this XElement element ) {
			return element.Attribute( "type" ).Value;
		}

		public static sbyte attrbute_value_s8( this XElement element ) {
			return Convert.ToSByte( element.Attribute( "value" ).Value );
		}
		public static short attrbute_value_s16( this XElement element ) {
			return Convert.ToInt16( element.Attribute( "value" ).Value );
		}
		public static int attrbute_value_s32( this XElement element ) {
			return Convert.ToInt32( element.Attribute( "value" ).Value );
		}

		public static byte attrbute_value_u8( this XElement element ) {
			return Convert.ToByte( element.Attribute( "value" ).Value );
		}
		public static ushort attrbute_value_u16( this XElement element ) {
			return Convert.ToUInt16( element.Attribute( "value" ).Value );
		}
		public static uint attrbute_value_u32( this XElement element ) {
			return Convert.ToUInt32( element.Attribute( "value" ).Value );
		}

		public static float attrbute_value_f32( this XElement element ) {
			return Convert.ToSingle( element.Attribute( "value" ).Value );
		}

		public static int attrbute_count( this XElement element ) {
			return Convert.ToInt32( element.Attribute( "count" ).Value );
		}



		public static sbyte[] GetArrayS8( this XElement element ) {
			var result = new sbyte[ element.attrbute_count() ];
			int i = 0;
			foreach( var e in element.Elements() ) {
				result[ i ] = e.attrbute_value_s8();
				i++;
			}
			return result;
		}

		public static int[] GetArrayU8( this XElement element ) {
			var result = new int[ element.attrbute_count() ];
			int i = 0;
			foreach( var e in element.Elements() ) {
				result[ i ] = e.attrbute_value_u8();
				i++;
			}
			return result;
		}

		public static short[] GetArrayS16( this XElement element ) {
			var result = new short[ element.attrbute_count() ];
			int i = 0;
			foreach( var e in element.Elements() ) {
				result[ i ] = e.attrbute_value_s16();
				i++;
			}
			return result;
		}

		public static int[] GetArrayS32( this XElement element ) {
			var result = new int[ element.attrbute_count() ];
			int i = 0;
			foreach( var e in element.Elements() ) {
				result[ i ] = e.attrbute_value_s32();
				i++;
			}
			return result;
		}

		public static uint[] GetArrayU32( this XElement element ) {
			var result = new uint[ element.attrbute_count() ];
			int i = 0;
			foreach( var e in element.Elements() ) {
				result[ i ] = e.attrbute_value_u32();
				i++;
			}
			return result;
		}

		public static float[] GetArrayF32( this XElement element ) {
			var result = new float[ element.attrbute_count() ];
			int i = 0;
			foreach( var e in element.Elements() ) {
				result[ i ] = e.attrbute_value_f32();
				i++;
			}
			return result;
		}

		public static cITEM_PARAM_DATA[] GetArrayITEM_PARAM_DATA( this XElement element ) {
			var result = new cITEM_PARAM_DATA[ element.attrbute_count() ];
			int i = 0;
			foreach( var e in element.Elements() ) {
				if( e.attrbute_type() == "sItemManager::cITEM_PARAM_DATA" ) {
					var buf = new cITEM_PARAM_DATA();
					var t = typeof( cITEM_PARAM_DATA );
					foreach( var e2 in e.Elements() ) {
						var atbName = e2.attrbute_name().Replace( "data.", "" );
						var field = t.GetField( atbName );
						if( field == null ) continue;
						switch( e2.Name.ToString() ) {
							case "s8":
								field.SetValue( buf, e2.attrbute_value_s8() );
								break;
							case "s16":
								field.SetValue( buf, e2.attrbute_value_s16() );
								break;
							case "u16":
								field.SetValue( buf, e2.attrbute_value_u16() );
								break;
							case "u32":
								field.SetValue( buf, e2.attrbute_value_u32() );
								break;
						}
					}
					result[ i ] = buf;
				}
				i++;
			}
			return result;
		}
	}

}
