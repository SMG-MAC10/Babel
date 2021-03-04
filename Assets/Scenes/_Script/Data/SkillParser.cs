using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;


[System.Serializable]
public class SkillExplain
{
    public string skillName;
    public string img;
    /// <summary>
    /// 스킬 능력치(수치 포함)
    /// </summary>
    public string ability;
    /// <summary>
    /// 스킬 한줄 설명
    /// </summary>
    public string explain;
    public int cost;
    public int upgrade;
}


public class SkillParser
{
    private SkillParser()
    {

    }

    [System.Serializable]
    private class Data
    {
        public SkillExplain[] skill;
    }

    public static SkillExplain GetSkill(string skillName, int skillLevel)
    {
        Data skillData = new Data();

        try
        {
            TextAsset localTextFile = Resources.Load(SkillName.SkillDirectory + skillName) as TextAsset;
            //FileStream stream = new FileStream(SkillName.SkillDirectory + skillName, FileMode.Open, FileAccess.Read, FileShare.Read);
            //byte[] data = new byte[stream.Length];
            //stream.Read(data, 0, data.Length);
            //stream.Close();
            //skillData = JsonUtility.FromJson<Data>(Encoding.UTF8.GetString(data));
            skillData = JsonUtility.FromJson<Data>(Encoding.UTF8.GetString(localTextFile.bytes));
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        

        return skillData.skill[skillLevel-1];
    }

    public static SkillExplain GetEnemySkill(string skillName)
    {
        Data skillData = new Data();

        try
        {
            TextAsset localTextFile = Resources.Load(skillName) as TextAsset;
            //FileStream stream = new FileStream(SkillName.SkillDirectory + skillName, FileMode.Open, FileAccess.Read, FileShare.Read);
            //byte[] data = new byte[stream.Length];
            //stream.Read(data, 0, data.Length);
            //stream.Close();
            //skillData = JsonUtility.FromJson<Data>(Encoding.UTF8.GetString(data));
            skillData = JsonUtility.FromJson<Data>(Encoding.UTF8.GetString(localTextFile.bytes));
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }


        return skillData.skill[0];
    }

    public static int GetRequireUpgradeScroll(SkillExplain skill)
    {
        switch (skill.upgrade)
        {
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
        }
        return 0;
    }
}
