using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public enum Class { KNIGHT, ARCHER, THIEF, MAGE, PRIEST }

[System.Serializable]
public class DataChar// : MonoBehaviour
{
    public string cls;

    public int level;

    // Start is called before the first frame update
    [Header("- Health Point")]
    public float maxHP;//최대 체력
    public float curHP;

    [Header("- Mana Point")]
    public float maxMP;//최대 마나
    public float curMP;

    [Header("- Action Point")]
    public float incAP;//AP 증가 => 속도

    [Header("- Physical Stat")]
    public float phyATK;//물리공 + 장비뎀
    public float phyDEF;//물리방 + 장비방

    [Header("- Magical Stat")]
    public float mgcATK;//마법공 + 장비뎀
    public float mgcDEF;//마법방 + 장비방

    [Header("- Speed, Critical")]
    public float spd;//속도, 공갈값
    public float critical;//크리티컬 확률

    //public float acc;//명중
    //public float buffAcc;

    //public float avoid;//회피
    //public float buffAvoid;

    public SkillSet charSkillSet;

    public EquipSet charEquipSet;

    public int statPoint;

    public DataChar(string cls, float HP, float MP, float AP, float pATK, float pDEF, float mATK, float mDEF, float spd, float critical) {
        this.cls = cls;
        curHP = maxHP = HP;
        curMP = maxMP = MP;
        incAP = AP;
        phyATK = pATK;
        phyDEF = pDEF;
        mgcATK = mATK;
        mgcDEF = mDEF;
        this.spd = spd;
        this.critical = critical;
        statPoint = 0;
    }

    public DataChar(DataChar origin) {
        this.cls = origin.cls;
        maxHP = origin.maxHP;
        maxMP = origin.maxMP;
        curHP = origin.curHP;
        curMP = origin.curMP;
        incAP = origin.incAP;
        phyATK = origin.phyATK;
        phyDEF = origin.phyDEF;
        mgcATK = origin.mgcATK;
        mgcDEF = origin.mgcDEF;
        this.spd = origin.spd;
        this.critical = origin.critical;
        statPoint = origin.statPoint;

        charEquipSet = new EquipSet(origin.charEquipSet);
        charSkillSet = origin.charSkillSet;
    }

    public float getMaxHP() {
        return maxHP * charEquipSet.getHP();
    }

    public float getMaxMP() {
        return maxMP * charEquipSet.getMP();
    }

    public static DataChar getKnight() {
        DataChar tmp = new DataChar("Knight", 85, 30, 100.0f, 18, 15, 10, 15, 0, 0.05f);
        tmp.charSkillSet = new SkillKnight();
        tmp.charEquipSet = new EquipSet(3);
        return tmp;
    }

    public static DataChar getThief()
    {
        DataChar tmp = new DataChar("Thief", 65, 50, 140.0f, 20, 12, 17, 12, 0, 0.1f);
        tmp.charSkillSet = new SkillThief();
        tmp.charEquipSet = new EquipSet(0);
        return tmp;
    }

    public static DataChar getArcher()
    {
        DataChar tmp = new DataChar("Archer", 60, 45, 135.0f, 21, 11, 15, 12, 0, 0.1f);
        tmp.charSkillSet = new SkillArcher();
        tmp.charEquipSet = new EquipSet(1);
        return tmp;
    }

    public static DataChar getMage()
    {
        DataChar tmp = new DataChar("Mage", 55, 70, 125.0f, 12, 10, 22, 16, 0, 0.1f);
        tmp.charSkillSet = new SkillMage();
        tmp.charEquipSet = new EquipSet(2);
        return tmp;
    }

    public static DataChar getPriest()
    {
        DataChar tmp = new DataChar("Priest", 60, 65, 120.0f, 12, 12, 17, 16, 0, 0.05f);
        tmp.charSkillSet = new SkillPriest();
        tmp.charEquipSet = new EquipSet(4);
        return tmp;
    }

    public static DataChar getEnemyDC(string Name, SkillSet set, float HP, float MP, float AP, float pATK, float pDEF, float mATK, float mDEF, float spd, float critical)
    {
        DataChar tmp = new DataChar(Name, HP, MP, AP, pATK, pDEF, mATK, mDEF, spd, critical);
        tmp.charSkillSet = set;
        tmp.charEquipSet = new EquipSet(-1);
        return tmp;
    }

    public float getPhyATK() { return phyATK + charEquipSet.getPhyATK(); }
    public float getPhyDEF() { return phyDEF + charEquipSet.getPhyDEF(); }
    public float getMgcATK() { return mgcATK + charEquipSet.getMgcATK(); }
    public float getMgcDEF() { return mgcDEF + charEquipSet.getMgcDEF(); }
    public float getIncAP() { return incAP * charEquipSet.getIncAP(); }
    public float getSPD() { return incAP * charEquipSet.getIncAP(); }

    public void upMaxHP()
    {
        maxHP += 5;
    }

    public void downMaxHP() {
        if (maxHP > 5) maxHP -= 5;
        else maxHP = 1;

        if(curHP > maxHP)curHP = maxHP;
    }
    public void upMaxMP()
    {
        maxMP += 5;
    }
    public void downMaxMP() {
        if (maxMP > 5) maxMP -= 5;
        else maxMP = 1;
        if (curMP > maxMP) curMP = maxMP;
    }
    public void upPhyATK()
    {
        phyATK += 2;
    }
    public void downPhyATK()
    {
        if (phyATK > 2) phyATK -= 2;
        else phyATK = 1;
    }
    public void upPhyDEF()
    {
        phyDEF += 1;
    }
    public void downPhyDEF()
    {
        if (phyDEF > 1) phyDEF -= 1;
        else phyDEF = 1;
    }
    public void upMgcATK()
    {
        mgcATK += 2;
    }
    public void downMgcATK()
    {
        if (mgcATK > 2) mgcATK -= 2;
        else mgcATK = 1;
    }
    public void upMgcDEF()
    {
        mgcDEF += 1;
    }
    public void downMgcDEF()
    {
        if (mgcDEF > 1) mgcDEF -= 1;
        else mgcDEF = 1;
    }
    public void upIncAP()
    {
        incAP += 5;
    }
    public void downIncAP()
    {
        if (incAP > 5) incAP -= 5;
        else incAP = 1;
    }
    public void upCritical()
    {
        critical += 0.002f;
    }
    public void downCritical()
    {
        if (critical > 0.002f) critical -= 0.002f;
        else critical = 0;
    }

    public void addHPbyPercent(float p) {
        curHP +=getMaxHP() * p;
        if (curHP > getMaxHP()) curHP = getMaxHP();
    }

    public void addMPbyPercent(float p)
    {
        curMP += getMaxMP() * p;
        if (curMP > getMaxMP()) curMP = getMaxMP();
    }

    public void subHPbyPercent(float p)
    {
        curHP -= getMaxHP() * p;
        if (curHP < 1.0f) curHP = 1.0f;
    }

    public void subMPbyPercent(float p)
    {
        curMP -= getMaxMP() * p;
        if (curMP < 1.0f) curMP = 1.0f;
    }
}
