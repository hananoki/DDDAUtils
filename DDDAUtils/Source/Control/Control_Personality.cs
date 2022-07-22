using System;
using System.Windows.Forms;

namespace DDDAUtils {
	public partial class Control_Personality : UserControl {

		UIPage_Personality tabPage;
		public DDPawnPersonality type { get; set; }

		public int Value {
			set {
				trackBar1.Value = value;
			}
			get {
				return trackBar1.Value;
			}
		}


		/////////////////////////////////////////
		public Control_Personality( UIPage_Personality tabPage, string text, DDPawnPersonality type ) {
			InitializeComponent();
			this.tabPage = tabPage;
			label1.Text = text;
			this.type = type;

			trackBar1.ValueChanged += _ValueChanged;
			trackBar1.MouseUp += _MouseUp;

			_ValueChanged( trackBar1 , null);
		}


		/////////////////////////////////////////
		void _ValueChanged( object sender, EventArgs e ) {
			var trackBar1 = sender as TrackBar;
			label2.Text = trackBar1.Value.ToString();
		}


		/////////////////////////////////////////
		void _MouseUp( object sender, MouseEventArgs e ) {
			tabPage.Emit();
		}
	}
}
