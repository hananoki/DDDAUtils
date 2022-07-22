using System;
using System.Linq;
using System.Windows.Forms;

namespace DDDAUtils {
	//////////////////////////////////////////////////////////////////////////////////
	public partial class UIPage_Skill : UserControl {

		Control_JobSelect m_jobSelectControl;
		Control_SkillGroup[] m_skillControl;
		Control_NormalSkill m_normalSkill;

		bool initSkillBox;


		/////////////////////////////////////////
		public UIPage_Skill() {
			InitializeComponent();
			Dock = DockStyle.Fill;

			m_skillControl = new Control_SkillGroup[ 4 ];

			for( int i = m_skillControl.Length - 1; 0 <= i; i-- ) {
				m_skillControl[ i ] = new Control_SkillGroup( /*names[ i ], i */ );
				m_skillControl[ i ].Dock = DockStyle.Top;
				panelR.Controls.Add( m_skillControl[ i ] );
			}

			m_jobSelectControl = new Control_JobSelect( this );
			panelL.Controls.Add( m_jobSelectControl );

			m_normalSkill = new Control_NormalSkill();
			panelR.Controls.Add( m_normalSkill );
		}


		/////////////////////////////////////////
		public void SelectJob( CharaData chr ) {
			m_jobSelectControl.SelectJob( chr.mParam.mJob - 1 );
		}


		///////////////////////////////////////////
		void InitSkillTab() {
			if( initSkillBox ) return;

			foreach( var p in m_skillControl ) {
				p.InitComboBox();
			}

			m_jobSelectControl.Init();

			initSkillBox = true;
		}


		///////////////////////////////////////////
		void VisibleRadioButton( TreeNode_CharaData node, params DDWeaponType[] visibles ) {

			var lst = visibles.ToList();
			
			int i;
			for( i = 0; i < visibles.Length; i++ ) {
				var p = m_skillControl[ i ];
				p.Visible = true;
				p.UpdateData( node, visibles[ i ] );
			}

			for( ; i < m_skillControl.Length; i++ ) {
				var p = m_skillControl[ i ];
				p.Visible = false;
			}

			m_normalSkill.Visible = visibles.Count() == 0;
			if( m_normalSkill.Visible ) {
				m_normalSkill.UpdateData( node );
			}
		}


		///////////////////////////////////////////
		public void ShowTab(  ) {
			var node = Utils.GetCharaNode();

			InitSkillTab();

			if( node == null ) return;

			var radio = m_jobSelectControl.GetCheckedRadioButton();

			switch( radio.Tag ) {
				case 1:
					VisibleRadioButton( node, DDWeaponType.SWORD, DDWeaponType.SHIELD );
					break;
				case 2:
					VisibleRadioButton( node, DDWeaponType.DAGGER, DDWeaponType.BOW );
					break;
				case 3:
					VisibleRadioButton( node, DDWeaponType.WAND );
					break;
				case 4:
					VisibleRadioButton( node, DDWeaponType.SWORD, DDWeaponType.MACE, DDWeaponType.SHIELD_L, DDWeaponType.WAND );
					break;
				case 5:
					VisibleRadioButton( node, DDWeaponType.SWORD, DDWeaponType.DAGGER, DDWeaponType.SHIELD, DDWeaponType.BOW );
					break;
				case 6:
					VisibleRadioButton( node, DDWeaponType.DAGGER, DDWeaponType.BOW_MG, DDWeaponType.WAND );
					break;
				case 7:
					VisibleRadioButton( node, DDWeaponType.GSWORD, DDWeaponType.HAMMER );
					break;
				case 8:
					VisibleRadioButton( node, DDWeaponType.DAGGER, DDWeaponType.BOW_L );
					break;
				case 9:
					VisibleRadioButton( node, DDWeaponType.WAND_DX );
					break;
				case 10:
					VisibleRadioButton( node );
					break;
			}
		}


		///////////////////////////////////////////
		void toolStripButton1_Click( object sender, EventArgs e ) {
			var node = Utils.GetCharaNode();
			var chrData = node.GetCharaData();
			chrData.ResetSkill();
			MainForm.instance.dddaSaveData.Write( node.chrIndex, chrData, false, true, false );

			UINotifyStatus.Info( "スキルを全てリセットしました" );
			ShowTab(  );
		}
	}
}
