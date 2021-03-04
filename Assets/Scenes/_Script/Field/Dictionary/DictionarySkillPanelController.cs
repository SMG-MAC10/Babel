using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionarySkillPanelController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject targetPanel;
    public GameObject activeSkill0;
    public GameObject activeSkill1;
    public GameObject activeSkill2;
    public GameObject activeSkill3;
    public GameObject activeSkill4;
    public GameObject passiveSkill0;
    public GameObject passiveSkill1;
    public GameObject passiveSkill2;
    public GameObject passiveSkill3;
    public GameObject passiveSkill4;
    private List<GameObject> activeSkillList;
    private List<GameObject> passiveSkillList;

    private string[] skillTrigger;
    private DataChar selectedCharacter;
    public GameObject characterAnimation;

    public Text txtSkillName;
    public Text txtSkillType;
    public Text txtSkillCost;
    public Text txtSkillAbility;
    public GameObject selectedSkillIcon;


    private int skillLevel;
    private string cls;
    private SKILLTYPE skillType;
    private Skill skill;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstatnce();
        skillTrigger = new string[5];
        activeSkillList = new List<GameObject>();
        passiveSkillList = new List<GameObject>();
        activeSkillList.Add(activeSkill0);
        activeSkillList.Add(activeSkill1);
        activeSkillList.Add(activeSkill2);
        activeSkillList.Add(activeSkill3);
        activeSkillList.Add(activeSkill4);
        passiveSkillList.Add(passiveSkill0);
        passiveSkillList.Add(passiveSkill1);
        passiveSkillList.Add(passiveSkill2);
        passiveSkillList.Add(passiveSkill3);
        passiveSkillList.Add(passiveSkill4);
        skillLevel = 0;
        PanelDeactivation();
        //test.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PanelActivation()
    {
        for (int i = 0; i < 5; i++)
        {
            activeSkillList[i].transform.Find("SkillIcon").GetComponent<Image>().color
                = new Color(0, 0, 0, 0);
        }
        for (int i = 0; i < 5; i++)
        {
            passiveSkillList[i].transform.Find("SkillIcon").GetComponent<Image>().color
                = new Color(0, 0, 0, 0);
        }
        selectedSkillIcon.transform.Find("SkillIcon").GetComponent<Image>().color
            = new Color(0, 0, 0, 0);
        txtSkillAbility.text = "";
        txtSkillCost.text = "";
        txtSkillName.text = "";
        txtSkillType.text = "";
        skillLevel = 1;
        Utility.ObjectVisibility(targetPanel, true);
    }

    public void PanelDeactivation()
    {
        characterAnimation.GetComponent<Animator>().enabled = false;
        characterAnimation.GetComponent<SpriteRenderer>().sprite = null;
        Utility.ObjectVisibility(targetPanel, false);
    }

    private void SkillSetting(DataChar character)
    {
        selectedCharacter = character;
        for (int i=0; i<5; i++)
        {
            int index = i;
            activeSkillList[i].transform.Find("SkillIcon").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(character.charSkillSet.act[i].image);
            activeSkillList[i].transform.Find("SkillIcon").GetComponent<Image>().color
                = new Color(1, 1, 1, 1);
            activeSkillList[i].GetComponent<Button>().onClick.RemoveAllListeners();
            activeSkillList[i].GetComponent<Button>().onClick.AddListener(() => {
                OnClickActiveSkill(index);
                skillLevel = 1;
                skill = character.charSkillSet.act[index];
                cls = character.cls;
                skillType = SKILLTYPE.ACT;
                txtSkillType.text = "Active";
                txtSkillType.color = new Color(1, 0.8f, 0.8f);
                selectedSkillIcon.transform.Find("SkillIcon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(character.charSkillSet.act[index].image);
                selectedSkillIcon.transform.Find("SkillIcon").GetComponent<Image>().color
                    = new Color(1, 1, 1, 1);
                SetSkillInformation();
            });
        }
        for (int i = 0; i < 5; i++)
        {
            int index = i;
            passiveSkillList[i].transform.Find("SkillIcon").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(character.charSkillSet.pas[i].image);
            passiveSkillList[i].transform.Find("SkillIcon").GetComponent<Image>().color
                = new Color(1, 1, 1, 1);
            passiveSkillList[i].GetComponent<Button>().onClick.RemoveAllListeners();
            passiveSkillList[i].GetComponent<Button>().onClick.AddListener(() => {
                skillLevel = 1;
                skill = character.charSkillSet.pas[index];
                cls = character.cls;
                skillType = SKILLTYPE.PAS;
                txtSkillType.text = "Passive";
                txtSkillType.color = new Color(0.7f, 0.8f, 1.0f);
                selectedSkillIcon.transform.Find("SkillIcon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(character.charSkillSet.pas[index].image);
                selectedSkillIcon.transform.Find("SkillIcon").GetComponent<Image>().color
                    = new Color(1, 1, 1, 1);
                SetSkillInformation();
            });
        }
        switch (character.cls)
        {
            case "Thief":
                skillTrigger = new string[5] { "act1", "act2", "act3", "act4", "act5" };
                break;
            case "Archer":
                skillTrigger = new string[5] { "act1", "act2", "normalAttack", "act3", "act4" };
                break;
            case "Mage":
                skillTrigger = new string[5] { "act1", "act2", "act3", "act4", "act5" };
                break;
            case "Knight":
                skillTrigger = new string[5] { "act1", "act2", "act3", "act4", "act5" };
                break;
            case "Priest":
                skillTrigger = new string[5] { "act1", "act2", "act3", "act4", "act5" };
                break;
        }
        characterAnimation.GetComponent<Animator>().enabled = true;
    }

    public void OnClickActiveSkill(int skillIndex)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        characterAnimation.GetComponent<Animator>().Play(skillTrigger[skillIndex]);
    }

    public void SetSkillInformation()
    {
        SkillExplain skillExplain = SkillParser.GetSkill(SkillName.GetSkillNameFile(skill.name, cls, skillType), skillLevel);
        txtSkillName.text = "Lv." + skillExplain.upgrade + " " + skillExplain.skillName;
        txtSkillCost.text = "Cost : " + skillExplain.cost;
        txtSkillAbility.text = skillExplain.ability;
    }

    public void OnClickSkillLevelUp()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (skillLevel < 10)
        {
            skillLevel++;
        }
        SetSkillInformation();
    }

    public void OnClickSkillLevelDown()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (skillLevel > 1)
        {
            skillLevel--;
        }
        SetSkillInformation();
    }

    public void OnClickThief()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        characterAnimation.GetComponent<Animator>().runtimeAnimatorController
            = Resources.Load<RuntimeAnimatorController>(AnimationControllerPath.ThiefController);
        SkillSetting(DataChar.getThief());
    }

    public void OnClickArcher()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        characterAnimation.GetComponent<Animator>().runtimeAnimatorController
            = Resources.Load<RuntimeAnimatorController>(AnimationControllerPath.ArcherController);
        SkillSetting(DataChar.getArcher());
    }
    public void OnClickMage()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        characterAnimation.GetComponent<Animator>().runtimeAnimatorController
            = Resources.Load<RuntimeAnimatorController>(AnimationControllerPath.MageController);
        SkillSetting(DataChar.getMage());
    }
    public void OnClickKnight()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        characterAnimation.GetComponent<Animator>().runtimeAnimatorController
            = Resources.Load<RuntimeAnimatorController>(AnimationControllerPath.KnightController);
        SkillSetting(DataChar.getKnight());
    }
    public void OnClickPriest()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        characterAnimation.GetComponent<Animator>().runtimeAnimatorController
            = Resources.Load<RuntimeAnimatorController>(AnimationControllerPath.PriestController);
        SkillSetting(DataChar.getPriest());
    }
}
