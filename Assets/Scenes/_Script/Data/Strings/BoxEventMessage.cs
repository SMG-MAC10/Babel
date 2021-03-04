using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEventMessage
{
    private BoxEventMessage() { }

    public static readonly string HpHeal = "체력 회복";
    public static readonly string MpHeal = "마나 회복";
    public static readonly string MapOpen = "지도 획득";
    public static readonly string GetEquipment = "장비 획득";
    public static readonly string GetScrollDecomp = "Get Scroll Decomposition";
    public static readonly string GetScrollEquip = "장비 강화 주문서 획득";
    public static readonly string GetScrollSkill = "스킬 강화 주문서 획득";
    public static readonly string GetScrollStat = "능력 강화 주문서 획득";
    public static readonly string GetKey = "열쇠 획득";
    public static readonly string UpgradeEquipment = "Upgrade Equipment";
    public static readonly string UpgradeSkill = "Upgrade Skill";
}
