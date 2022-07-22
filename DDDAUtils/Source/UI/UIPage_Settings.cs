using HananokiLib;
using System.Windows.Forms;

namespace DDDAUtils {
	public partial class UIPage_Settings : UserControl {
		public UIPage_Settings() {
			InitializeComponent();
			Dock = DockStyle.Fill;

			checkBox1.CheckedChanged += AppMain.ChangeConfigFlag;
			checkBox1.Checked = AppMain.config.isAutoRead;
			textBox1.Text = "1000";
		}


		public void ShowTab() {
			var mes1 = $"インストールされています: {Helper.s_appPath}\\bin\\DDsavetool.exe";
			var mes2 = $"ファイルが見つかりません: binフォルダにDDsavetool.exeを配置してください";
			label1.Text = Utils.HasDDsavetool() ? mes1 : mes2;
		}

		void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
			=> shell.openFolder( Utils.BinFolder );

	}
}
