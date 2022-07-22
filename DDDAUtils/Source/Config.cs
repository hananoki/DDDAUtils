using HananokiLib;
using System;

namespace DDDAUtils {

	//////////////////////////////////////////////////////////////////////////////////
	public class Config {
		public int width = 800;
		public int height = 600;
		public int x;
		public int y;

		public string selectProfile;

		public int flag;

		public bool isAutoRead => flag.Has( (int) EConfigOptions.AutoRead );
		public bool isAutoSave => flag.Has( (int) EConfigOptions.AutoSave );


		/////////////////////////////////////////
		public static Config Load() {
			var config = new Config();
			Helper.ReadJson( ref config, Helper.configPath );

			return config;
		}

		/////////////////////////////////////////
		public void Save() {
			Helper.WriteJson( this );
		}
	}
}
