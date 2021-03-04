using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEventMessage
{
    private TrapEventMessage() { }

    public static readonly string HpDecrease = "체력 감소";
    public static readonly string MpDecrease = "마나 감소";
    public static readonly string EnemyStatUp = "적 능력치 강화";
    public static readonly string FriendStatDown = "아군 능력치 하락";
    public static readonly string EnemyRegen = "적 추가 생성";
    public static readonly string BattleStart = "기습이다!";
    public static readonly string NothingHappen = "아무 일도 없었다";
}
