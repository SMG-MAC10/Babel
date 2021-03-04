using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject explainPanel;
    public Button btnThief;
    public Button btnArcher;
    public Button btnMagician;
    public Button btnKnight;
    public Button btnPriest;
    public Text flag;
    private Vector3 btnPosition;
    public Text selectedClass;
    public Text characterExplain;
    private int selectCharacter;
    private static bool selectFlag;

    public GameObject characterAnimation;

    public GameObject skill0;
    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    public GameObject skill4;
    private List<GameObject> skillSet;
    private string[] skillTrigger;

    private void Awake()
    {
        selectFlag = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstatnce();
        Utility.ObjectVisibility(explainPanel, false);
        characterExplain.text = "";
        selectCharacter = -1;
        btnPosition = new Vector3(-718f, 0, 0);
        skillTrigger = new string[5];
        skillSet = new List<GameObject>();
        skillSet.Add(skill0);
        skillSet.Add(skill1);
        skillSet.Add(skill2);
        skillSet.Add(skill3);
        skillSet.Add(skill4);
        characterAnimation.GetComponent<Animator>().enabled = false;
        characterAnimation.GetComponent<SpriteRenderer>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Position Anchor = Top / Left
    public void OnClickThiefSelect()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (!selectFlag)
        {
            btnArcher.gameObject.SetActive(false);
            btnMagician.gameObject.SetActive(false);
            btnKnight.gameObject.SetActive(false);
            btnPriest.gameObject.SetActive(false);

            selectFlag = true;
            Debug.Log("Selected : Thief");
            Utility.ObjectVisibility(explainPanel, true);
            btnThief.transform.localPosition = btnPosition;
            flag.text = "0";
            selectCharacter = 0;
            selectedClass.text = "도적";
            SetSampleSkill("Thief");
            characterExplain.text = Utility.ScriptReader(ScriptFilePath.ExplainThief);
            characterAnimation.GetComponent<Animator>().runtimeAnimatorController
                = Resources.Load<RuntimeAnimatorController>(AnimationControllerPath.ThiefController);
            characterAnimation.GetComponent<Animator>().enabled = true;
        }
    }
    public void OnClickArcherSelect()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (!selectFlag)
        {
            btnThief.gameObject.SetActive(false);
            btnMagician.gameObject.SetActive(false);
            btnKnight.gameObject.SetActive(false);
            btnPriest.gameObject.SetActive(false);

            selectFlag = true;
            Debug.Log("Selected : Archer");
            Utility.ObjectVisibility(explainPanel, true);
            btnArcher.transform.localPosition = btnPosition;
            flag.text = "1";
            selectCharacter = 1;
            selectedClass.text = "궁수";
            SetSampleSkill("Archer");
            characterExplain.text = Utility.ScriptReader(ScriptFilePath.ExplainArcher);
            characterAnimation.GetComponent<Animator>().runtimeAnimatorController
                = Resources.Load<RuntimeAnimatorController>(AnimationControllerPath.ArcherController);
            characterAnimation.GetComponent<Animator>().enabled = true;
        }
    }
    public void OnClickMagicianSelect()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (!selectFlag)
        {
            btnThief.gameObject.SetActive(false);
            btnArcher.gameObject.SetActive(false);
            btnKnight.gameObject.SetActive(false);
            btnPriest.gameObject.SetActive(false);

            selectFlag = true;
            Debug.Log("Selected : Magician");
            Utility.ObjectVisibility(explainPanel, true);
            btnMagician.transform.localPosition = btnPosition;
            flag.text = "2";
            selectCharacter = 2;
            selectedClass.text = "마법사";
            SetSampleSkill("Mage");
            characterExplain.text = Utility.ScriptReader(ScriptFilePath.ExplainMage);
            characterAnimation.GetComponent<Animator>().runtimeAnimatorController
                = Resources.Load<RuntimeAnimatorController>(AnimationControllerPath.MageController);
            characterAnimation.GetComponent<Animator>().enabled = true;
        }
    }
    public void OnClickKnightSelect()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (!selectFlag)
        {
            btnThief.gameObject.SetActive(false);
            btnArcher.gameObject.SetActive(false);
            btnMagician.gameObject.SetActive(false);
            btnPriest.gameObject.SetActive(false);

            selectFlag = true;
            Debug.Log("Selected : Knight");
            Utility.ObjectVisibility(explainPanel, true);
            btnKnight.transform.localPosition = btnPosition;
            flag.text = "3";
            selectCharacter = 3;
            selectedClass.text = "기사";
            SetSampleSkill("Knight");
            characterExplain.text = Utility.ScriptReader(ScriptFilePath.ExplainKnight);
            characterAnimation.GetComponent<Animator>().runtimeAnimatorController
                = Resources.Load<RuntimeAnimatorController>(AnimationControllerPath.KnightController);
            characterAnimation.GetComponent<Animator>().enabled = true;
        }
    }
    public void OnClickPriestSelect()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (!selectFlag)
        {
            btnThief.gameObject.SetActive(false);
            btnArcher.gameObject.SetActive(false);
            btnMagician.gameObject.SetActive(false);
            btnKnight.gameObject.SetActive(false);

            selectFlag = true;
            Debug.Log("Selected : Priest");
            Utility.ObjectVisibility(explainPanel, true);
            btnPriest.transform.localPosition = btnPosition;
            flag.text = "4";
            selectCharacter = 4;
            selectedClass.text = "사제";
            SetSampleSkill("Priest");
            characterExplain.text = Utility.ScriptReader(ScriptFilePath.ExplainPriest);
            characterAnimation.GetComponent<Animator>().runtimeAnimatorController
                = Resources.Load<RuntimeAnimatorController>(AnimationControllerPath.PriestController);
            characterAnimation.GetComponent<Animator>().enabled = true;
        }
    }

    private void SetSampleSkill(string cls)
    {
        DataChar character = DataChar.getArcher();
        switch (cls)
        {
            case "Thief":
                character = DataChar.getThief();
                skillTrigger = new string[5] { "act1", "act2", "act3", "act4", "act5" };
                break;
            case "Archer":
                character = DataChar.getArcher();
                skillTrigger = new string[5] { "act1", "act2", "normalAttack", "act3", "act4" };
                break;
            case "Mage":
                character = DataChar.getMage();
                skillTrigger = new string[5] { "act1", "act2", "act3", "act4", "act5" };
                break;
            case "Knight":
                character = DataChar.getKnight();
                skillTrigger = new string[5] { "act1", "act2", "act3", "act4", "act5" };
                break;
            case "Priest":
                character = DataChar.getPriest();
                skillTrigger = new string[5] { "act1", "act2", "act3", "act4", "act5" };
                break;
        }

        for(int i=0; i<5; i++)
        {
            int index = i;
            skillSet[i].transform.Find("SkillIcon").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(character.charSkillSet.act[i].image);
            skillSet[i].GetComponent<Button>().onClick.RemoveAllListeners();
            skillSet[i].GetComponent<Button>().onClick.AddListener(()=>{
                OnClickActiveSkill(index);
            });
        }
    }
    public void OnClickActiveSkill(int skillIndex)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        characterAnimation.GetComponent<Animator>().Play(skillTrigger[skillIndex]);
    }

    public void OnClickCancel()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        btnThief.gameObject.SetActive(true);
        btnArcher.gameObject.SetActive(true);
        btnMagician.gameObject.SetActive(true);
        btnKnight.gameObject.SetActive(true);
        btnPriest.gameObject.SetActive(true);
        Utility.ObjectVisibility(explainPanel, false);
        Vector3 buttonGap = new Vector3(370f, 0, 0);
        Vector3 temp = new Vector3(-740f, 0, 0);
        btnThief.transform.localPosition = temp + buttonGap * 0;
        btnArcher.transform.localPosition = temp + buttonGap * 1;
        btnMagician.transform.localPosition = temp + buttonGap * 2;
        btnKnight.transform.localPosition = temp + buttonGap * 3;
        btnPriest.transform.localPosition = temp + buttonGap * 4;
        selectFlag = false;
        characterAnimation.GetComponent<Animator>().enabled = false;
        characterAnimation.GetComponent<SpriteRenderer>().sprite = null;
    }

    public void OnClickConfirm()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        //Debug.Log("Clicked : Confirm. " + flag.text);
        // 0 = Thief, 1 = Archer, 2 = Magician, 3 = Knight, 4 = Priest
        switch (selectCharacter)
        {
            case 0:
                gameManager.AddCharacter(DataChar.getThief());
                break;
            case 1:
                gameManager.AddCharacter(DataChar.getArcher());
                break;
            case 2:
                gameManager.AddCharacter(DataChar.getMage());
                break;
            case 3:
                gameManager.AddCharacter(DataChar.getKnight());
                break;
            case 4:
                gameManager.AddCharacter(DataChar.getPriest());
                break;
        }
        SceneManager.LoadScene("Intro");
    }


    //Not used
    private void ExplainPanelHide()
    {
        explainPanel.GetComponent<CanvasGroup>().alpha = 0f;
        explainPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    //Not used
    private void ExplainPanelShow()
    {
        explainPanel.GetComponent<CanvasGroup>().alpha = 1f;
        explainPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
