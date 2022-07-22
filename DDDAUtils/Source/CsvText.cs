using HananokiLib;
using System.Collections.Generic;
using System.IO;

namespace DDDAUtils {

	//////////////////////////////////////////////////////////////////////////////////
	public class CsvText {
		public Dictionary<int, string> _data;
		public List<int> indexToKey;
		public Dictionary<int, int> keyToIndex;

		public List<string[]> line;

		public CsvText( string filePath ) {
			_data = new Dictionary<int, string>();
			indexToKey = new List<int>();
			keyToIndex = new Dictionary<int, int>();
			line = new List<string[]>();
			if( !filePath.IsExistsFile() ) {
				Debug.Error( $"File Not Found: {filePath}" );
				return;
			}
			int i = 0;
			foreach( var s in File.ReadAllLines( filePath ) ) {
				if( s.IsEmpty() ) continue;
				var ss = s.Split( "\t" );
				if( ss[ 0 ].IsEmpty() ) continue;

				int key = int.Parse( ss[ 0 ] );
				_data.Add( key, ss[ 1 ] );
				indexToKey.Add( key );
				keyToIndex.Add( key, i );
				line.Add( ss );
				i++;
			}
		}


		public string GetFromKey( int key ) {
			var has = _data.TryGetValue( key, out string value );
			return has ? value : "";
		}
		public string GetFromIndex( int index ) {
			return GetFromKey( indexToKey[ index ] );
		}
		public int KeyToIndex( int key ) {
			var has = keyToIndex.TryGetValue( key, out int value );
			return has ? value : -1;
		}
		public int IndexToKey( int index ) {
			if( index < 0 ) return -1;
			return indexToKey[ index ];
		}
	}


	//////////////////////////////////////////////////////////////////////////////////
	public class CsvStringToString {
		public Dictionary<string, string> keyToString;

		public CsvStringToString( string filePath ) {
			keyToString = new Dictionary<string, string>();
			if( !filePath.IsExistsFile() ) {
				Debug.Error( $"File Not Found: {filePath}" );
				return;
			}
			foreach( var s in File.ReadAllLines( filePath ) ) {
				if( s.IsEmpty() ) continue;
				var ss = s.Split( "\t" );
				if( ss[ 0 ].IsEmpty() ) continue;

				keyToString.Add( ss[ 0 ], ss[ 1 ] );
			}
		}

		public string this[ string key ] {
			get {
				var has = keyToString.TryGetValue( key, out string value );
				return has ? value : "";
			}
		}
	}

}
