using System.Runtime.Serialization;
using System;
namespace Zola.MsfClient.Models {
    /// <summary>Does not progress to the next combat wave until the condition is met.- `OwnDeadThisWave` Met if `holdNum` units from this combat wave are dead.- `AllOwnDeadThisWave` Met if all of the units from this combat wave are dead.- `AllOwnDeadThisCombat` Met if the side has no units remaining, from this or any other combat wave.- `AnyVipKilled` Met after any unit with the `vip` NodeEffect is killed.- `AllOwnVipKilled` Met after all units with the `vip` NodeEffect are killed on the side.- `AnyVipDoesBasic` Met after any unit with the `vip` NodeEffect performs their basic ability.- `AnyVipDoesSpecial` Met after any unit with the `vip` NodeEffect performs their special ability.- `AnyVipDoesUltimate` Met after any unit with the `vip` NodeEffect performs their ultimate ability.- `OwnActionsThisWave` Met after `holdNum` actions have been performed by units on the side since the combat wave was first triggered.- `OwnActionsThisCombat` Met after `holdNum` actions have been performed by units on the side since the start of combat.- `EnemyActionsThisCombat` Met after `holdNum` actions have been performed by units on the enemy side since the start of combat.</summary>
    public enum CombatWave_holdNextWaveUntil {
        [EnumMember(Value = "OwnDeadThisWave")]
        OwnDeadThisWave,
        [EnumMember(Value = "AllOwnDeadThisWave")]
        AllOwnDeadThisWave,
        [EnumMember(Value = "AllOwnDeadThisCombat")]
        AllOwnDeadThisCombat,
        [EnumMember(Value = "AnyVipKilled")]
        AnyVipKilled,
        [EnumMember(Value = "AllOwnVipKilled")]
        AllOwnVipKilled,
        [EnumMember(Value = "AnyVipDoesBasic")]
        AnyVipDoesBasic,
        [EnumMember(Value = "AnyVipDoesSpecial")]
        AnyVipDoesSpecial,
        [EnumMember(Value = "AnyVipDoesUltimate")]
        AnyVipDoesUltimate,
        [EnumMember(Value = "OwnActionsThisWave")]
        OwnActionsThisWave,
        [EnumMember(Value = "OwnActionsThisCombat")]
        OwnActionsThisCombat,
        [EnumMember(Value = "EnemyActionsThisCombat")]
        EnemyActionsThisCombat,
    }
}
