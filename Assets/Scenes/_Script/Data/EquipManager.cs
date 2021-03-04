using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

/*
 * {
 *   "name" : "Weapon";
 *   "type" : "Weapon";
 *   "phyAtk" : 10;
 *   "magAtk" : 0;
 * }
 */
 public enum EquipClass : int
{
    Thief = 0,
    Archer = 1,
    Mage = 2,
    Knight = 3,
    Priest = 4,
    All = 5
}

public enum EquipType : int
{
    Head = 0,
    Body = 1,
    Foot = 2,
    Weapon = 3,
    SubWeapon = 4
}

public enum EquipGrade : int
{
    Normal = 0,
    Rare = 1,
    Unique = 2,
    Mystic = 3
}

public class EquipManager
{
    private EquipManager()
    {

    }

    [System.Serializable]
    private class EquipStatus
    {
        public string img; // 장비 이미지 URL
        public string name; // 장비이름
        public EquipType type; // 장비종류 : 투구 - 갑옷 - 신발 - 무기 - 보조무기
        public EquipClass cls; // 직업제한 : 도적 - 궁수 - 법사 - 기사 - 사제
        public EquipGrade grade; // 장비등급 : 노말 - 레어 - 유니크 - 미스틱
        public float maxHP; // 체력
        public float maxHP_Rate; // 체력(비율)
        public float maxMP; // 마나
        public float maxMP_Rate; // 마나(비율)
        public float incMP; // 마나회복
        public float incAP; // 속도회복
        public float phyATK; // 물리공격력
        public float phyATK_Rate; // 물리공격력(비율)
        public float phyDEF; // 물리방어력
        public float phyDEF_Rate; // 물리방어력(비율)
        public float macATK; // 마법공격력
        public float macATK_Rate; // 마법공격력(비율)
        public float macDEF; // 마법방어력
        public float macDEF_Rate; // 마법방어력(비율)
        public float healEFC; // 회복효율
        public float critical; // 치명타확률
        public float speed;
        public int upgrade;
    }
    
    [System.Serializable]
    private class Data
    {
        public EquipStatus[] equipment;
    }
    /// <summary>
    /// Method summary
    /// </summary>
    /// <param name="equipName">Parameter Summary : Equip Name</param>
    /// <param name="equipLevel">Parameter Summary : Equip Level</param>
    /// <returns></returns>
    public static Equip GetEquip(string equipName, int equipLevel)
    {
        Data equipData = new Data();
        try
        {
            TextAsset localTextFile = Resources.Load(equipName) as TextAsset;
            //FileStream stream = new FileStream(Application.dataPath + equipName, FileMode.Open, FileAccess.Read, FileShare.Read);
            //byte[] data = new byte[stream.Length];
            //stream.Read(data, 0, data.Length);
            //stream.Close();
            //equipData = JsonUtility.FromJson<Data>(Encoding.UTF8.GetString(data));
            equipData = JsonUtility.FromJson<Data>(Encoding.UTF8.GetString(localTextFile.bytes));
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }


        Equip equip = new Equip();
        equip.img = equipData.equipment[equipLevel].img;
        equip.name = equipData.equipment[equipLevel].name;
        equip.grade = equipData.equipment[equipLevel].grade;
        equip.type = equipData.equipment[equipLevel].type;
        equip.cls = equipData.equipment[equipLevel].cls;
        equip.maxHP = equipData.equipment[equipLevel].maxHP;
        equip.maxMP = equipData.equipment[equipLevel].maxMP;
        equip.incMP = equipData.equipment[equipLevel].incMP;
        equip.speed = equipData.equipment[equipLevel].speed;
        equip.phyATK = equipData.equipment[equipLevel].phyATK;
        equip.phyDEF = equipData.equipment[equipLevel].phyDEF;
        equip.macATK = equipData.equipment[equipLevel].macATK;
        equip.macDEF = equipData.equipment[equipLevel].macDEF;
        equip.healEFC = equipData.equipment[equipLevel].healEFC;
        equip.critical = equipData.equipment[equipLevel].critical;
        equip.level = equipData.equipment[equipLevel].upgrade;

        return equip;

    }

    public static Equip GetEquip(string equipName)
    {
        return GetEquip(equipName, 0);

        EquipStatus equipStatus = new EquipStatus();

        try
        {
            FileStream stream = new FileStream(equipName, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            stream.Close();
            equipStatus = JsonUtility.FromJson<EquipStatus>(Encoding.UTF8.GetString(data));
        }catch(Exception e)
        {
            Debug.Log(e);
        }

        //Debug.Log(JsonUtility.ToJson(t));
        //JsonUtility.FromJson<EquipStatus>("");
        //FileStream stream = new FileStream(EquipmentFilePath.DataDirectory + EquipmentFilePath.Test, FileMode.Create);
        //byte[] data = Encoding.UTF8.GetBytes(JsonUtility.ToJson(t));
        //stream.Write(data, 0, data.Length);
        //stream.Close();
        //Debug.Log("TTTT");

        //FileStream readStream = new FileStream(EquipmentFilePath.DataDirectory + EquipmentFilePath.Test, FileMode.Open);
        //byte[] readData = new byte[readStream.Length];
        //readStream.Read(readData, 0, readData.Length);
        //readStream.Close();
        //EquipStatus tt = JsonUtility.FromJson<EquipStatus>(Encoding.UTF8.GetString(readData));
        //Debug.Log(tt.cls);
        //Debug.Log(tt.type);
        //Debug.Log(tt.cls == EquipClass.Archer);

        Equip equip = new Equip();
        equip.name = equipStatus.name;
        equip.img = equipStatus.img;
        return equip;
    }

    public static Equip GetEquipNextLevel(Equip equip)
    {
        //Debug.Log(equip.img);
        string upgradeEquip = equip.img.Replace("Image", "");
        return GetEquip(upgradeEquip, equip.level+1);
    }

    public static Equip GetEquipLowerLevel(Equip equip)
    {
        string upgradeEquip = equip.img.Replace("Image", "");
        if(equip.level == 0)
        {
            return GetEquip(upgradeEquip, equip.level);
        }
        return GetEquip(upgradeEquip, equip.level - 1);
    }

    public static Equip GetRandomEquip()
    {
        int currentFloor = PlayerPrefs.GetInt(PrefsEntity.CurrentFloor);
        int clsFlag = UnityEngine.Random.Range(0, 5);
        int partsFlag = UnityEngine.Random.Range(0, 5);
        
        string equipFilePath = "Equipment/";
        string fileCls = "";
        string fileParts = "";
        switch (clsFlag)
        {
            case 0:
                equipFilePath += "Thief/";
                fileCls = "thief";
                break;
            case 1:
                equipFilePath += "Archer/";
                fileCls = "archer";
                break;
            case 2:
                equipFilePath += "Mage/";
                fileCls = "mage";
                break;
            case 3:
                equipFilePath += "Knight/";
                fileCls = "knight";
                break;
            case 4:
                equipFilePath += "Priest/";
                fileCls = "priest";
                break;
        }
        switch (partsFlag)
        {
            case 0:
                equipFilePath += "Head/";
                fileParts = "Head";
                break;
            case 1:
                equipFilePath += "Body/";
                fileParts = "Body";
                break;
            case 2:
                equipFilePath += "Foot/";
                fileParts = "Foot";
                break;
            case 3:
                equipFilePath += "Weapon/";
                fileParts = "Weapon";
                break;
            case 4:
                if(clsFlag == 0)
                {
                    equipFilePath += "Weapon/";
                    fileParts = "Weapon";
                }
                else
                {
                    equipFilePath += "Subweapon/";
                    fileParts = "Subweapon";
                }
                break;
        }
        switch (GetEquipGrade(currentFloor))
        {
            case EquipGrade.Normal:
                equipFilePath += fileCls + "Normal" + fileParts;
                break;
            case EquipGrade.Rare:
                equipFilePath += fileCls + "Rare" + fileParts;
                break;
            case EquipGrade.Unique:
                equipFilePath += fileCls + "Unique" + fileParts;
                break;
            case EquipGrade.Mystic:
                equipFilePath += fileCls + "Mystic" + fileParts;
                break;
        }
        return GetEquip(equipFilePath, 0);
    }

    private static EquipGrade GetEquipGrade(int floor)
    {
        int flag = UnityEngine.Random.Range(1, 100);
        if(floor > 90 & floor <= 100)
        {
            if (flag >= 0 & flag < 60)
                return EquipGrade.Normal;
            else if (flag >= 60 & flag < 95)
                return EquipGrade.Rare;
            else if (flag >= 95 & flag < 100)
                return EquipGrade.Unique;
        }
        else if(floor > 80 & floor <= 90)
        {
            if (flag >= 0 & flag < 45)
                return EquipGrade.Normal;
            else if (flag >= 45 & flag < 90)
                return EquipGrade.Rare;
            else if (flag >= 90 & flag < 100)
                return EquipGrade.Unique;
        }
        else if (floor > 70 & floor <= 80)
        {
            if (flag >= 0 & flag < 25)
                return EquipGrade.Normal;
            else if (flag >= 25 & flag < 75)
                return EquipGrade.Rare;
            else if (flag >= 75 & flag < 95)
                return EquipGrade.Unique;
            else if (flag >= 95 & flag < 100)
                return EquipGrade.Mystic;
        }
        else if (floor > 60 & floor <= 70)
        {
            if (flag >= 0 & flag < 15)
                return EquipGrade.Normal;
            else if (flag >= 15 & flag < 65)
                return EquipGrade.Rare;
            else if (flag >= 65 & flag < 95)
                return EquipGrade.Unique;
            else if (flag >= 95 & flag < 100)
                return EquipGrade.Mystic;
        }
        else if (floor > 50 & floor <= 60)
        {
            if (flag >= 0 & flag < 10)
                return EquipGrade.Normal;
            else if (flag >= 10 & flag < 45)
                return EquipGrade.Rare;
            else if (flag >= 45 & flag < 90)
                return EquipGrade.Unique;
            else if (flag >= 90 & flag < 100)
                return EquipGrade.Mystic;
        }
        else if (floor > 40 & floor <= 50)
        {
            if (flag >= 0 & flag < 5)
                return EquipGrade.Normal;
            else if (flag >= 5 & flag < 30)
                return EquipGrade.Rare;
            else if (flag >= 30 & flag < 80)
                return EquipGrade.Unique;
            else if (flag >= 80 & flag < 100)
                return EquipGrade.Mystic;
        }
        else if (floor > 30 & floor <= 40)
        {
            if (flag >= 0 & flag < 5)
                return EquipGrade.Normal;
            else if (flag >= 5 & flag < 20)
                return EquipGrade.Rare;
            else if (flag >= 20 & flag < 70)
                return EquipGrade.Unique;
            else if (flag >= 70 & flag < 100)
                return EquipGrade.Mystic;
        }
        else if (floor > 20 & floor <= 30)
        {
            if (flag >= 0 & flag < 5)
                return EquipGrade.Normal;
            else if (flag >= 5 & flag < 15)
                return EquipGrade.Rare;
            else if (flag >= 15 & flag < 70)
                return EquipGrade.Unique;
            else if (flag >= 70 & flag < 100)
                return EquipGrade.Mystic;
        }
        else if (floor > 10 & floor <= 20)
        {
            if (flag >= 0 & flag < 5)
                return EquipGrade.Normal;
            else if (flag >= 5 & flag < 10)
                return EquipGrade.Rare;
            else if (flag >= 10 & flag < 70)
                return EquipGrade.Unique;
            else if (flag >= 70 & flag < 100)
                return EquipGrade.Mystic;
        }
        else if (floor > 0 & floor <= 10)
        {
            if (flag >= 0 & flag < 65)
                return EquipGrade.Unique;
            else if (flag >= 65 & flag < 100)
                return EquipGrade.Mystic;
        }

        return EquipGrade.Normal;
    }

    public static int GetUpgradeProbability(Equip equip)
    {
        switch (equip.level)
        {
            case 0:
                return 100;
            case 1:
                return 90;
            case 2:
                return 82;
            case 3:
                return 76;
            case 4:
                return 70;
            case 5:
                return 65;
            case 6:
                return 60;
            case 7:
                return 56;
            case 8:
                return 52;
            case 9:
                return 48;
            case 10:
                return 45;
            case 11:
                return 42;
            case 12:
                return 40;
            case 13:
                return 38;
            case 14:
                return 36;
            case 15:
                return 34;
            case 16:
                return 33;
            case 17:
                return 32;
            case 18:
                return 31;
            case 19:
                return 30;
        }
        return 0;
    }

    public static int GetRequireUpgradeScroll(Equip equip)
    {
        switch (equip.level)
        {
            case 0:
                return 1;
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
                return 2;
            case 4:
                return 3;
            case 5:
                return 3;
            case 6:
                return 4;
            case 7:
                return 4;
            case 8:
                return 5;
            case 9:
                return 5;
            case 10:
                return 6;
            case 11:
                return 6;
            case 12:
                return 7;
            case 13:
                return 7;
            case 14:
                return 8;
            case 15:
                return 8;
            case 16:
                return 9;
            case 17:
                return 9;
            case 18:
                return 10;
            case 19:
                return 10;
        }

        return 0;
    }

    public static bool UpgradeEquip(Equip equip)
    {
        int number = UnityEngine.Random.Range(0, 100);
        if(number < GetUpgradeProbability(equip))
        {
            return true;
        }
        return false;
    }
}
