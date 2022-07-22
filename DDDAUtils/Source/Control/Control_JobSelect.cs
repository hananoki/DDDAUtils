using System.Windows.Forms;

namespace DDDAUtils {
	public partial class Control_JobSelect : UserControl {

		UIPage_Skill skillPage;
		RadioButton[] m_jobRadioButotns;

		public Control_JobSelect( UIPage_Skill skillPage ) {
			InitializeComponent();
			Dock = DockStyle.Fill;

			this.skillPage = skillPage;

			m_jobRadioButotns = new RadioButton[] {
				radioButton_Job01,
				radioButton_Job02,
				radioButton_Job03,
				radioButton_Job04,
				radioButton_Job05,
				radioButton_Job06,
				radioButton_Job07,
				radioButton_Job08,
				radioButton_Job09,
				radioButton_Norm,
			};
		}


		///////////////////////////////////////////
		public void SelectJob( int jobNo ) {
			m_jobRadioButotns[ jobNo ].Checked = true;
		}


		///////////////////////////////////////////
		public void Init() {
			int i = 1;
			foreach( var p in m_jobRadioButotns ) {
				p.Tag = i;
				i++;

				p.CheckedChanged += ( sender, e ) => {
					var radio = sender as RadioButton;
					if( !radio.Checked ) return;
					skillPage.ShowTab(  );
				};
			}
		}


		///////////////////////////////////////////
		public RadioButton GetCheckedRadioButton() {
			foreach( var p in m_jobRadioButotns ) {
				if( p.Checked ) return p;
			}
			return null;
		}

	}
}
