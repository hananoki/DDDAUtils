
using HananokiLib;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DDDAUtils {
	public class AppMain {

		public static AppMain instance;

		Config m_config;
		public CsvText m_skill;
		public CsvText m_job;
		public CsvText m_ability;
		public CsvText m_item;
		public CsvStringToString m_lang;

		public static Config config => instance.m_config;


		public static CsvText csvSkill => instance.m_skill;
		public static CsvText csvJob => instance.m_job;
		public static CsvText csvAbility => instance.m_ability;
		public static CsvText csvItem => instance.m_item;
		public static CsvStringToString csvLang => instance.m_lang;


		/////////////////////////////////////////
		public AppMain() {
			instance = this;
			m_config = Config.Load();
		}


		async public Task<int> LoadText() {
			await Task.Run( () => {
				m_skill   = new CsvText( $"{Helper.s_appPath}\\csv\\Skill.txt" );
				m_job     = new CsvText( $"{Helper.s_appPath}\\csv\\Job.txt" );
				m_ability = new CsvText( $"{Helper.s_appPath}\\csv\\Ability.txt" );
				m_item    = new CsvText( $"{Helper.s_appPath}\\csv\\Item.txt" );
				m_lang = new CsvStringToString( $"{Helper.s_appPath}\\csv\\Lang.txt" );
			} );
			return 0;
		}


		/////////////////////////////////////////
		public static void OnFormClosing( MainForm form ) {
			BackupWindow( form );
			config.Save();
		}


		/////////////////////////////////////////
		public static void RollbackWindow( MainForm form ) {
			form.Location = new Point( config.x, config.y );
			form.Width = config.width;
			form.Height = config.height;
		}


		/////////////////////////////////////////
		public static void BackupWindow( MainForm form ) {
			config.x = form.Location.X;
			config.y = form.Location.Y;
			config.width = form.Width;
			config.height = form.Height;
		}


		/////////////////////////////////////////
		public static void ChangeConfigFlag( object sender, EventArgs e ) {
			var chkbox = (CheckBox) sender;
			AppMain.config.flag.Toggle( (int) chkbox.Tag, chkbox.Checked );
		}
		
	}
}
