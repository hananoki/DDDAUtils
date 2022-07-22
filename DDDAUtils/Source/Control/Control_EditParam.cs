using HananokiLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DDDAUtils {
	public partial class Control_EditParam : UserControl {

		FieldInfo fieldInfo;

		/////////////////////////////////////////
		public Control_EditParam( string name, FieldInfo fieldInfo ) {
			InitializeComponent();
			label1.Text = name;
			
			this.fieldInfo = fieldInfo;

			var attr = fieldInfo.GetCustomAttribute( typeof( RangeAttribute ) );
			if( attr != null ) {
				var range = attr as RangeAttribute;
				trackBar1.Minimum = (int) range.Minimum;
				trackBar1.Maximum = (int) range.Maximum;
			}
			else {
				//trackBar1.Maximum = 1000;
			}
			trackBar1.ValueChanged += _ValueChanged;
			trackBar1.MouseUp += _MouseUp;
			textBox1.KeyPress += textBox1_KeyPress;
		}


		/////////////////////////////////////////
		public void SetValue( cSAVE_DATA_EDIT edit ) {
			var s = AppMain.csvLang[ label1.Text ];
			if( !s.IsEmpty() ) {
				label1.Text = s;
			}
			int value = 0;
			if( fieldInfo.FieldType == typeof( byte ) ) {
				byte b = (byte) fieldInfo.GetValue( edit );
				value = b;
			}
			else if( fieldInfo.FieldType == typeof( uint ) ) {
				uint b = (uint) fieldInfo.GetValue( edit );
				value = (int) b;
			}
			else {
				return;
			}
			try {
				if( trackBar1.Maximum <= value ) {
					trackBar1.Maximum = value;
				}
				trackBar1.Value = value;
				textBox1.Text = value.ToString();
			}
			catch( Exception ex ) {
				Debug.Exception( ex );
			}
		}

		/////////////////////////////////////////
		public int GetValue() {
			return trackBar1.Value;
		}


		/////////////////////////////////////////
		void _ValueChanged( object sender, EventArgs e ) {
			var trackBar1 = sender as TrackBar;
			textBox1.Text = trackBar1.Value.ToString();
		}


		/////////////////////////////////////////
		void _MouseUp( object sender, MouseEventArgs e ) {
			var uiEditData = Parent.Parent as UIPage_EditData;
			if( uiEditData == null ) {
				UINotifyStatus.Error( "Not Found: UI_EditData" );
				return;
			}
			uiEditData.Emit();
		}


		/////////////////////////////////////////
		void textBox1_KeyPress( object sender, KeyPressEventArgs e ) {
			if( ( e.KeyChar < '0' || '9' < e.KeyChar ) && e.KeyChar != '\b' ) {
				e.Handled = true;
			}
		}
	}
}
