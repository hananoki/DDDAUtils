using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDDAUtils {
	public partial class Control_LevelSlider : UserControl {

		int group;
		int no;



		///////////////////////////////////////////
		public Control_LevelSlider( string text, int no, int levelCount, int group ) {
			InitializeComponent();
			Dock = DockStyle.Top;
			label1.Text = text;
			this.group = group;
			this.no = no;
			trackBar1.Maximum = levelCount;
			trackBar1.ValueChanged += _ValueChanged;
			trackBar1.MouseUp += _MouseUp;
		}


		/////////////////////////////////////////
		public void _ValueChanged( object sender, EventArgs e ) {
			var trackBar1 = sender as TrackBar;
			label2.Text = trackBar1.Value.ToString();
		}


		/////////////////////////////////////////
		void _MouseUp( object sender, MouseEventArgs e ) {
			//tabPage.Emit();
			var page = Parent.Parent as UIPage_Status;
			if( page == null ) return;
			page.ChangeLevelSlider( group, no );
		}
	}
}
