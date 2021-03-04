
public class PrefsEntity
{
    private PrefsEntity()
    {

    }
    
    public static readonly string CurrentX = "Current X";
    public static readonly string CurrentY = "Current Y";
    public static readonly string Entrance = "Entrance";
    public static readonly string Exit = "Exit";
    public static readonly string StartX = "Start X";
    public static readonly string StartY = "Start Y";
    /// <summary>
    /// Type : int <br></br>
    /// 현재 선택된 난이도<br></br>
    /// 0 = Normal<br></br>
    /// 1 = Hard<br></br>
    /// 2 = Hell<br></br>
    /// </summary>
    public static readonly string CurrentLevel = "Current Level";
    public static readonly string CurrentFloor = "Current Floor";
    public static readonly string BridgeCount = "Bridge Count";
    public static readonly string SaveFlag = "Save Flag";
    public static readonly string InformationFlag = "Information Flag";
    public static readonly string BackgroundVolume = "Background Volume";
    public static readonly string EffectVolume = "Effect Volume";
    public static readonly string Bridge = "Bridge";
    /// <summary>
    /// Type : int<br>
    /// 현재 필드의 속성<br>
    /// 0 = 토 (Soil)<br>
    /// 1 = 수 (Water)<br>
    /// 2 = 화 (Fire)<br>
    /// 3 = 목 (Wood)<br>
    /// 4 = 금 (Steal)</br></br></br></br></br></br>
    /// </summary>
    public static readonly string FieldElement = "Field Element";
    public static readonly string SelectCharacter = "SelectCharacter";
    public static readonly string NumOfEnemy = "NumOfEnemy";
    public static readonly string NumOfTrap = "NumOfTrap";
    public static readonly string NumOfJail = "NumOfJail";
    public static readonly string NumOfBox = "NumOfBox";
    public static readonly string FieldEventVisibility = "FieldEventVisibility";
    public static readonly string DecomposeScroll = "DecomposeScroll";
    public static readonly string EquipmentUpgradeScroll = "EquipmentUpgradeScroll";
    public static readonly string SkillUpgradeScroll = "SkillUpgradeScroll";
    public static readonly string StatusUpgradeScrollOne = "StatusUpgradeScrollOne";
    public static readonly string StatusUpgradeScrollThree = "StatusUpgradeScrollThree";
    public static readonly string StatusUpgradeScrollFive = "StatusUpgradeScrollFive";
    public static readonly string StatusUpgradeScrollChaos = "StatusUpgradeScrollChaos";

    //????
    public static readonly string StatUP = "StatUP";

    /// <summary>
    /// Type : bool<br>
    /// True : 함정에서 적 능력치 강화가 출현<br>
    /// False : 그런거 없다</br></br>
    /// </summary>
    public static readonly string TrapEnemyStatUp = "TrapEventEnemyStatUp";
    /// <summary>
    /// Type : bool<br>
    /// True : 함정에서 아군 능력치 하락이 출현<br>
    /// False : 그런거 없다</br></br>
    /// </summary>
    public static readonly string TrapFriendStatDown = "TrapEventFriendStatDown";
    /// <summary>
    /// Type : bool<br>
    /// 보스전의 여부에 관련된 Entity
    /// True : 해당 전투가 보스전일 경우<br>
    /// False : 해당 전투가 보스전이 아닐 경우</br></br>
    /// </summary>
    public static readonly string BattleToBoss = "BattleToBoss";
    /// <summary>
    /// Type : bool<br>
    /// 중간 보스전의 여부에 관련된 Entity
    /// True : 해당 전투가 중간 보스전일 경우<br>
    /// False : 해당 전투가 중간 보스전이 아닐 경우</br></br>
    /// </summary>
    public static readonly string BattleToSemiBoss = "BattleToSemiBoss";
    /// <summary>
    /// Type : bool<br>
    /// 보스, 중간보스 클리어 여부와 관련된 Entity
    /// True : 해당 전투가 중간 보스전일 경우<br>
    /// False : 해당 전투가 중간 보스전이 아닐 경우</br></br>
    /// </summary>
    public static readonly string BossClearFlag = "BossClearFlag";
    public static readonly string ForceTerminateInBattle = "ForceTerminateInBattle";
    public static readonly string ForceTerminateInEvent = "ForceTerminateInEvent";
    public static readonly string OccurEvent = "OccurEvent";
    public static readonly string ForceTerminateInTrap = "ForceTerminateInTrap";
    public static readonly string OccurTrap = "OccurTrap";
    public static readonly string ForceTerminateInJail = "ForceTerminateInJail";
    public static readonly string OccurJailPrisoner = "OccurJailPrisoner";

}
