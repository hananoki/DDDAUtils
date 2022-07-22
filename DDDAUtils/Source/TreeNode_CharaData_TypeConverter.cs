using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace DDDAUtils {
	//////////////////////////////////////////////////////////////////////////////////
	public class TreeNode_CharaData_TypeConverter : TypeConverter {

		protected readonly Type type;

		/////////////////////////////////////////
		public TreeNode_CharaData_TypeConverter( Type type ) {
			this.type = type;
		}

		/////////////////////////////////////////
		public override bool GetPropertiesSupported( ITypeDescriptorContext context ) => true;

		/////////////////////////////////////////
		public override PropertyDescriptorCollection GetProperties( ITypeDescriptorContext context, object value, Attribute[] attributes ) {
			var list = new List<PropertyDescriptor>();

			var ini = value as TreeNode_CharaData;

			var data = ini.GetCharaData();
			foreach(var f in typeof( cSAVE_DATA_EDIT ).GetFields() ) {
				list.Add( new IniDescriptor( type, data.mEdit, f, new CategoryAttribute( nameof( cSAVE_DATA_EDIT ) ) ) );
			}

			foreach( var f in typeof( cSAVE_DATA_PARAM ).GetFields() ) {
				list.Add( new IniDescriptor( type, data.mParam, f, new CategoryAttribute( nameof( cSAVE_DATA_PARAM ) ) ) );
			}

			foreach( var f in typeof( cSAVE_DATA_CMC ).GetFields() ) {
				var browsable = f.GetCustomAttribute(typeof( BrowsableAttribute ) ) as BrowsableAttribute;
				if( browsable!=null ) {
					if( !browsable.Browsable ) continue;
				}
				list.Add( new IniDescriptor( type, data, f, new CategoryAttribute( nameof( cSAVE_DATA_CMC ) ) ) );
			}
			return new PropertyDescriptorCollection( list.ToArray() );
		}


		//////////////////////////////////////////////////////////////////////////////////
		class IniDescriptor : SimplePropertyDescriptor {
			public override TypeConverter Converter { get; }

			object target;
			FieldInfo fieldInfo;

			public IniDescriptor( Type componentType, object target, FieldInfo fieldInfo, params Attribute[] attributes )
				: base( componentType, fieldInfo.Name, fieldInfo.FieldType, attributes ) {
				this.target = target;
				this.fieldInfo = fieldInfo;
			}

			public override object GetValue( object component ) {
				return fieldInfo.GetValue( target );
			}

			public override void SetValue( object component, object value ) {
				fieldInfo.SetValue( target, value );
			}

		}
	}
}

