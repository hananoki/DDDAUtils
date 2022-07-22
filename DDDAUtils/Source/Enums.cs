using System;

namespace DDDAUtils {
	
	[Flags]
	public enum EConfigOptions {
		AutoRead = 1 << 0,
		AutoSave = 1 << 1,
	}

	public enum DDWeaponType {
		SWORD,
		MACE,
		GSWORD,
		DAGGER,

		WAND,
		WAND_DX,
		HAMMER,
		SHIELD,

		SHIELD_L,
		BOW,
		BOW_L,
		BOW_MG,
	}

	public enum DDTalkType {
		普通, // usually
		臆病, // timidity
		野蛮,
		無口,
		自信家,
		内気,
		気取り屋,
	}

	public enum DDPawnPersonality {
		Belligerent, // Scather  強い魔物に率先して挑む
		Prudent,     // Medicant 安全を優先して行動する
		PoorAim,     // Mitigator 弱い標的から仕留める
		Strategy,    // Callenger 厄介な魔物から狙う
		Tactics,     // Utilitarian 多角的な戦術で動く
		Protection,  // Guardian 覚者の安全を心掛ける
		SameSupport, // Nexus ポーンたちを助け支える
		Curiosity,   // Pioneer 積極的に動き道を開く
		Gather,      // Acquisitor  様々な物資を探し集める
	}

	public enum DDItemUpgrade {
		Lv0,
		Lv1,
		Lv2,
		Lv3,
		Lv4,
		Lv5,
		Lv6,
	}
}
