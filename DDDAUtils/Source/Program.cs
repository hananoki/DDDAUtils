using HananokiLib;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DDDAUtils {
	internal static class Program {
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main( string[] args ) {
			using( var mutex = new Mutex( false, typeof( MainForm ).ToString() ) ) {
				if( mutex.WaitOne( 0, false ) == false ) {
					MessageBox.Show( "[DDDAUtils] instance is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
					return;
				}
				ApplicationConfiguration.Initialize();
				Helper._init();
				if( 0 < args.Length ) {
					Debug.Log( args[ 0 ] );
					Helper.s_appPath = args[ 0 ];
				}
#if NET6_0_OR_GREATER
				Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );
#endif
				new AppMain();
				Application.Run( new MainForm() );
			}
		}
	}
}