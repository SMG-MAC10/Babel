using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryMonsterPanelController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject targetPanel;
    public GameObject monsterImage;

    public GameObject skillListCircleMonster;
    public GameObject skillListSquareMonster;
    public GameObject skillListTriangleMonster;
    public GameObject skillListSemibossMonster;
    public GameObject skillListSemibossPawnMonster;
    public GameObject skillListBossMonster;
    public GameObject skillListBossPawnMonster;
    public GameObject bossFloorChange;
    public GameObject semiBossFloorChange;


    private string selectedMonster;
    private int selectedElement;
    private int selectedFloor;

    public GameObject skillIcon;
    public Text skillName;
    public Text skillType;
    public Text skillCooltime;
    public Text skillAbility;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstatnce();
        PanelActivation();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PanelActivation()
    {
        selectedElement = PlayerPrefs.GetInt(PrefsEntity.FieldElement);
        selectedMonster = "";
        SkillExplainInit();
        monsterImage.GetComponent<Image>().sprite = null;
        monsterImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Utility.ObjectVisibility(skillListCircleMonster, false);
        Utility.ObjectVisibility(skillListSquareMonster, false);
        Utility.ObjectVisibility(skillListTriangleMonster, false);
        Utility.ObjectVisibility(skillListSemibossMonster, false);
        Utility.ObjectVisibility(skillListSemibossPawnMonster, false);
        Utility.ObjectVisibility(skillListBossMonster, false);
        Utility.ObjectVisibility(skillListBossPawnMonster, false);
        Utility.ObjectVisibility(bossFloorChange, false);
        Utility.ObjectVisibility(semiBossFloorChange, false);
        Utility.ObjectVisibility(targetPanel, true);
    }

    public void PanelDeactivation()
    {
        selectedElement = PlayerPrefs.GetInt(PrefsEntity.FieldElement);
        monsterImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        selectedMonster = "";
        SkillExplainInit();
        monsterImage.GetComponent<Image>().sprite = null;
        Utility.ObjectVisibility(skillListCircleMonster, false);
        Utility.ObjectVisibility(skillListSquareMonster, false);
        Utility.ObjectVisibility(skillListTriangleMonster, false);
        Utility.ObjectVisibility(skillListSemibossMonster, false);
        Utility.ObjectVisibility(skillListSemibossPawnMonster, false);
        Utility.ObjectVisibility(skillListBossMonster, false);
        Utility.ObjectVisibility(skillListBossPawnMonster, false);
        Utility.ObjectVisibility(bossFloorChange, false);
        Utility.ObjectVisibility(semiBossFloorChange, false);
        Utility.ObjectVisibility(targetPanel, false);
    }

    private void SkillExplainInit()
    {
        skillIcon.transform.Find("SkillIcon").GetComponent<Image>().color = new Color(0, 0, 0, 0);
        skillName.text = "";
        skillType.text = "";
        skillCooltime.text = "";
        skillAbility.text = "";
    }

    public void OnClickElementChange(int element)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        selectedElement = element;
        monsterImage.GetComponent<Image>().sprite 
            = Resources.Load<Sprite>(EnemyImagePath.GetMonsterImageByElement(selectedElement, selectedMonster));
        if(selectedMonster == "Boss" | selectedMonster == "Semiboss")
        {
            monsterImage.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(EnemyImagePath.GetMonsterImageByFloor(selectedElement, selectedFloor, selectedMonster));
        }

    }
    
    public void OnClickFloorChange(int floor)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        selectedFloor = floor;
        monsterImage.GetComponent<Image>().sprite
            = Resources.Load<Sprite>(EnemyImagePath.GetMonsterImageByFloor(selectedElement, floor, selectedMonster));
    }

    public void OnClickSkillIcon(string skill)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        string[] skillSplit = skill.Split(',');
        switch (skillSplit[0])
        {
            case "active":
                skillType.text = "Active";
                skillType.color = new Color(1, 0.8f, 0.8f);
                break;
            case "passive":
                skillType.text = "Passive";
                skillType.color = new Color(0.7f, 0.8f, 1.0f);
                break;
        }
        SkillExplain skillInfo = SkillParser.GetEnemySkill("Script/Skill/Enemy/" + skillSplit[1]);
        skillIcon.transform.Find("SkillIcon").GetComponent<Image>().sprite
            = Resources.Load<Sprite>(skillInfo.img);
        skillIcon.transform.Find("SkillIcon").GetComponent<Image>().color = new Color(1, 1, 1, 1);
        skillName.text = skillInfo.skillName;
        skillCooltime.text = "Cool Time : " + skillInfo.cost;
        skillAbility.text = skillInfo.ability;
    }

    public void OnClickCircleMonsterIcon()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(skillListCircleMonster, true);
        Utility.ObjectVisibility(skillListSquareMonster, false);
        Utility.ObjectVisibility(skillListTriangleMonster, false);
        Utility.ObjectVisibility(skillListSemibossMonster, false);
        Utility.ObjectVisibility(skillListSemibossPawnMonster, false);
        Utility.ObjectVisibility(skillListBossMonster, false);
        Utility.ObjectVisibility(skillListBossPawnMonster, false);
        Utility.ObjectVisibility(bossFloorChange, false);
        Utility.ObjectVisibility(semiBossFloorChange, false);
        selectedMonster = "Circle";
        monsterImage.GetComponent<Image>().sprite
            = Resources.Load<Sprite>(EnemyImagePath.GetMonsterImageByElement(selectedElement, selectedMonster));
        monsterImage.GetComponent<Image>().color = new Color(1,1,1,1);
        SkillExplainInit();
    }


    public void OnClickSquareMonsterIcon()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(skillListCircleMonster, false);
        Utility.ObjectVisibility(skillListSquareMonster, true);
        Utility.ObjectVisibility(skillListTriangleMonster, false);
        Utility.ObjectVisibility(skillListSemibossMonster, false);
        Utility.ObjectVisibility(skillListSemibossPawnMonster, false);
        Utility.ObjectVisibility(skillListBossMonster, false);
        Utility.ObjectVisibility(skillListBossPawnMonster, false);
        Utility.ObjectVisibility(bossFloorChange, false);
        Utility.ObjectVisibility(semiBossFloorChange, false);
        selectedMonster = "Square";
        monsterImage.GetComponent<Image>().sprite
            = Resources.Load<Sprite>(EnemyImagePath.GetMonsterImageByElement(selectedElement, selectedMonster));
        monsterImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        SkillExplainInit();
    }

    public void OnClickTriangleMonsterIcon()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(skillListCircleMonster, false);
        Utility.ObjectVisibility(skillListSquareMonster, false);
        Utility.ObjectVisibility(skillListTriangleMonster, true);
        Utility.ObjectVisibility(skillListSemibossMonster, false);
        Utility.ObjectVisibility(skillListSemibossPawnMonster, false);
        Utility.ObjectVisibility(skillListBossMonster, false);
        Utility.ObjectVisibility(skillListBossPawnMonster, false);
        Utility.ObjectVisibility(bossFloorChange, false);
        Utility.ObjectVisibility(semiBossFloorChange, false);
        selectedMonster = "Triangle";
        monsterImage.GetComponent<Image>().sprite
            = Resources.Load<Sprite>(EnemyImagePath.GetMonsterImageByElement(selectedElement, selectedMonster));
        monsterImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        SkillExplainInit();
    }

    public void OnClickSemibossMonsterIcon()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(skillListCircleMonster, false);
        Utility.ObjectVisibility(skillListSquareMonster, false);
        Utility.ObjectVisibility(skillListTriangleMonster, false);
        Utility.ObjectVisibility(skillListSemibossMonster, true);
        Utility.ObjectVisibility(skillListSemibossPawnMonster, false);
        Utility.ObjectVisibility(skillListBossMonster, false);
        Utility.ObjectVisibility(skillListBossPawnMonster, false);
        Utility.ObjectVisibility(bossFloorChange, false);
        Utility.ObjectVisibility(semiBossFloorChange, true);
        selectedMonster = "Semiboss";
        monsterImage.GetComponent<Image>().sprite
            = Resources.Load<Sprite>(EnemyImagePath.GetMonsterImageByElement(selectedElement, selectedMonster));
        monsterImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        SkillExplainInit();
    }
    public void OnClickSemibossPawnMonsterIcon()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(skillListCircleMonster, false);
        Utility.ObjectVisibility(skillListSquareMonster, false);
        Utility.ObjectVisibility(skillListTriangleMonster, false);
        Utility.ObjectVisibility(skillListSemibossMonster, false);
        Utility.ObjectVisibility(skillListSemibossPawnMonster, true);
        Utility.ObjectVisibility(skillListBossMonster, false);
        Utility.ObjectVisibility(skillListBossPawnMonster, false);
        Utility.ObjectVisibility(bossFloorChange, false);
        Utility.ObjectVisibility(semiBossFloorChange, false);
        selectedMonster = "SemibossPawn";
        monsterImage.GetComponent<Image>().sprite
            = Resources.Load<Sprite>(EnemyImagePath.GetMonsterImageByElement(selectedElement, selectedMonster));
        monsterImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        SkillExplainInit();
    }
    public void OnClickBossMonsterIcon()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(skillListCircleMonster, false);
        Utility.ObjectVisibility(skillListSquareMonster, false);
        Utility.ObjectVisibility(skillListTriangleMonster, false);
        Utility.ObjectVisibility(skillListSemibossMonster, false);
        Utility.ObjectVisibility(skillListSemibossPawnMonster, false);
        Utility.ObjectVisibility(skillListBossMonster, true);
        Utility.ObjectVisibility(skillListBossPawnMonster, false);
        Utility.ObjectVisibility(bossFloorChange, true);
        Utility.ObjectVisibility(semiBossFloorChange, false);
        selectedMonster = "Boss";
        monsterImage.GetComponent<Image>().sprite
            = Resources.Load<Sprite>(EnemyImagePath.GetMonsterImageByElement(selectedElement, selectedMonster));
        monsterImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        SkillExplainInit();
    }
    public void OnClickBossPawnMonsterIcon()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(skillListCircleMonster, false);
        Utility.ObjectVisibility(skillListSquareMonster, false);
        Utility.ObjectVisibility(skillListTriangleMonster, false);
        Utility.ObjectVisibility(skillListSemibossMonster, false);
        Utility.ObjectVisibility(skillListSemibossPawnMonster, false);
        Utility.ObjectVisibility(skillListBossMonster, false);
        Utility.ObjectVisibility(skillListBossPawnMonster, true);
        Utility.ObjectVisibility(bossFloorChange, false);
        Utility.ObjectVisibility(semiBossFloorChange, false);
        selectedMonster = "BossPawn";
        monsterImage.GetComponent<Image>().sprite
            = Resources.Load<Sprite>(EnemyImagePath.GetMonsterImageByElement(selectedElement, selectedMonster));
        monsterImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        SkillExplainInit();
    }
}
