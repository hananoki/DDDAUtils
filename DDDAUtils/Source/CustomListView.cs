using HananokiLib;
using System;
using System.IO;
using System.Windows.Forms;

namespace DDDAUtils {

	//////////////////////////////////////////////////////////////////////////////////
	public class ListView_Files : HListView<ListViewItem_Files> {

	}


	//////////////////////////////////////////////////////////////////////////////////
	public class ListViewItem_Files : ListViewItem {
		public ListViewItem_Files( string fullpath ) : base( new String[] { fullpath.GetBaseName(), "" } ) {
			this.fullpath = fullpath;
			var fileInfo = new FileInfo( fullpath );
			SubItems[ 1 ].Text = fileInfo.LastWriteTime.ToString();
		}

		public string fullpath;
	}
}
