using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelController : MonoBehaviour
{
    //GameManager + 
    private GameManager gameManager;
    private List<DataChar> characterData;
    public GameObject characterListParent;
    public GameObject[] characterList;
    public GameObject characterIcon;
    public GameObject characterImage;
    private DataChar selectedCharStatAllocate;
    private DataChar selectedChar;
    private int selectedCharIndex;

    //Used Equipment
    public GameObject equipHead;
    public GameObject equipBody;
    public GameObject equipFoot;
    public GameObject equipWeapon;
    public GameObject equipSubweapon;

    //Equipment List
    public GameObject itemListParent;
    public GameObject itemPrefab;
    private List<Equip> itemList;
    private GameObject[] itemSlot;
    public Text equipUpgradeScroll;

    //Upgrade Panels
    public GameObject panelStatusUp;
    public GameObject panelSkillUp;
    public GameObject panelEquipUp;

    //Status Allocate
    private int hpAllocate;
    private int mpAllocate;
    private int phyAtkAllocate;
    private int phyDefAllocate;
    private int magAtkAllocate;
    private int magDefAllocate;
    private int criticalAllocate;
    private int speedAllocate;

    //Status Show
    public Text hp;
    public Text mp;
    public Text phyAtk;
    public Text phyDef;
    public Text magAtk;
    public Text magDef;
    public Text critical;
    public Text speed;
    public Text statUpPoint;
    public Text statUpScrollOne;
    public Text statUpScrollThree;
    public Text statUpScrollFive;
    public Text statUpScrollChaos;

    //Skill Show
    public GameObject skillPrefab;
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
    public List<GameObject> activeSkillList;
    public List<GameObject> passiveSkillList;

    //Status Upgrade Panel
    public GameObject statUpPanel;
    public Text statUpScrollName;
    public GameObject statUpScrollIcon;
    public Text statUpPoseScroll;
    public Text statUpUseScroll;
    public Text statUpGainPoint;
    private int statUpGainPointValue;
    public Slider statUpSlider;
    public bool statUpPanelRoutine;
    public Button btnStatUpConfirm;

    //Status Upgrade Chaos Panel
    public GameObject statUpChaosPanel;
    public Text statUpPoseScrollChaos;
    public GameObject statUpChaosResultPanel;
    public Text chaosHpPoint;
    public Text chaosMpPoint;
    public Text chaosPhyAtkPoint;
    public Text chaosPhyDefPoint;
    public Text chaosMagAtkPoint;
    public Text chaosMagDefPoint;
    public Text chaosCriticalPoint;
    public Text chaosSpeedPoint;
    public Text chaosHpResult;
    public Text chaosMpResult;
    public Text chaosPhyAtkResult;
    public Text chaosPhyDefResult;
    public Text chaosMagAtkResult;
    public Text chaosMagDefResult;
    public Text chaosCriticalResult;
    public Text chaosSpeedResult;

    //Skill Upgrade Panel
    public GameObject skillUpgradeDescription;
    public Image skillUpBeforeIcon;
    public Text skillUpBeforeName;
    public Text skillUpBeforeType;
    public Text skillUpBeforeCost;
    public Text skillUpBeforeDescription;
    public Image skillUpAfterIcon;
    public Text skillUpAfterName;
    public Text skillUpAfterType;
    public Text skillUpAfterCost;
    public Text skillUpAfterDescription;
    public Button btnSkillUpConfirm;
    public Text skillUpReqScroll;
    public Text skillUpPanelReqScroll;
    public Text skillUpPoseScroll;

    //Equipment Upgrade Panel
    public GameObject equipUpgradeDescription;
    public Image equipUpBeforeIcon;
    public Text equipUpBeforeName;
    public Text equipUpBeforeType;
    public Text equipUpBeforeGrade;
    public Text equipUpBeforeHp;
    public Text equipUpBeforeMp;
    public Text equipUpBeforeAp;
    public Text equipUpBeforePhyAtk;
    public Text equipUpBeforePhyDef;
    public Text equipUpBeforeMagAtk;
    public Text equipUpBeforeMagDef;
    public Text equipUpBeforeCritical;
    public Text equipUpBeforeHealEf;
    public Image equipUpAfterIcon;
    public Text equipUpAfterName;
    public Text equipUpAfterType;
    public Text equipUpAfterGrade;
    public Text equipUpAfterHp;
    public Text equipUpAfterMp;
    public Text equipUpAfterAp;
    public Text equipUpAfterPhyAtk;
    public Text equipUpAfterPhyDef;
    public Text equipUpAfterMagAtk;
    public Text equipUpAfterMagDef;
    public Text equipUpAfterCritical;
    public Text equipUpAfterHealEf;
    public Text equipUpProbability;
    public Text equipUpRequireScroll;
    public Text equipUpPanelPossessScroll;
    public Button btnEquipUpgrade;

    //Message Panel
    public GameObject messagePanel;
    public Text messagePanelText;


    //public GameObject activeSkillParent;
    //public GameObject passiveSkillParent;
    //public GameObject[] activeSkillList;
    //public GameObject[] passiveSkillList;

    void Awake()
    {
        gameManager = GameManager.GetInstatnce();
        //characterData = gameManager.GetCharacterList();
        characterData = new List<DataChar>();
        //gameManager.AddEquipment(EquipManager.GetEquip(EquipmentFilePath.Knight.Body.mystic, 15));
        //gameManager.AddEquipment(EquipManager.GetEquip(EquipmentFilePath.Mage.Weapon.mystic, 19));
        //gameManager.AddEquipment(EquipManager.GetEquip(EquipmentFilePath.Thief.Weapon.mystic, 5));
        //gameManager.DataReset();
        //gameManager.AddCharacter(DataChar.getArcher());
        //gameManager.AddCharacter(DataChar.getKnight());
        //gameManager.AddCharacter(DataChar.getMage());
        //gameManager.AddCharacter(DataChar.getArcher());
        //gameManager.AddCharacter(DataChar.getKnight());
        //gameManager.AddCharacter(DataChar.getThief());
        //gameManager.AddCharacter(DataChar.getPriest());
        //gameManager.AddCharacter(DataChar.getPriest());
        //gameManager.AddCharacter(DataChar.getMage());
        //gameManager.AddCharacter(DataChar.getArcher());
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PanelSwapObserver());
        itemSlot = new GameObject[49];
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

        hpAllocate = 0;
        mpAllocate = 0;
        phyAtkAllocate = 0;
        phyDefAllocate = 0;
        magAtkAllocate = 0;
        magDefAllocate = 0;
        criticalAllocate = 0;
        speedAllocate = 0;
        //To Test
        //EquipManager.GetEquip(EquipmentFilePath.SampleArcher);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PanelSwapObserver()
    {
        while (true)
        {
            int flag = PlayerPrefs.GetInt(PrefsEntity.InformationFlag, -1);
            //Debug.Log(flag);
            if (flag == 3)
            {
                CharacterListUpdate();
                PlayerPrefs.SetInt(PrefsEntity.InformationFlag, -1);
            }
            //if (flag != startFlag)
            //{
            //    SetPanelActivate(flag);
            //}
            yield return null;
        }
    }

    private void CharacterListUpdate()
    {
        foreach (GameObject i in characterList)
        {
            Destroy(i);
        }
        characterData = gameManager.GetCharacterList();
        //Test
        //characterData.Add(DataChar.getArcher());
        //characterData.Add(DataChar.getArcher());
        //characterData.Add(DataChar.getArcher());
        //characterData.Add(DataChar.getArcher());
        //characterData.Add(DataChar.getArcher());
        //characterData.Add(DataChar.getArcher());
        //characterData.Add(DataChar.getArcher());

        //
        characterList = new GameObject[gameManager.NumOfCharacter()];
        //characterList = new GameObject[7];
        for (int i = 0; i < characterList.Length; i++)
        {
            int iconIndex = i;
            characterList[i] = Instantiate(characterIcon, characterListParent.transform);
            //characterList[i].transform.localPosition = new Vector3(-260f + 115*i, 0f, 0f);
            //Debug.Log(characterList[i].transform.position);
            //Debug.Log(characterList[i].transform.localPosition);
            switch (characterData[i].cls)
            {
                case "Thief":
                    characterList[i].transform.Find("CharacterImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(Resource.ThiefIcon) as Sprite;
                    characterList[i].GetComponent<Button>().onClick.AddListener(() => {
                        CharacterSelect(iconIndex);
                    });
                    break;
                case "Archer":
                    characterList[i].transform.Find("CharacterImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(Resource.ArcherIcon) as Sprite;
                    characterList[i].GetComponent<Button>().onClick.AddListener(() => {
                        CharacterSelect(iconIndex);
                    });
                    break;
                case "Mage":
                    characterList[i].transform.Find("CharacterImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(Resource.MageIcon) as Sprite;
                    characterList[i].GetComponent<Button>().onClick.AddListener(() => {
                        CharacterSelect(iconIndex);
                    });
                    break;
                case "Knight":
                    characterList[i].transform.Find("CharacterImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(Resource.KnightIcon) as Sprite;
                    characterList[i].GetComponent<Button>().onClick.AddListener(() => {
                        CharacterSelect(iconIndex);
                    });
                    break;
                case "Priest":
                    characterList[i].transform.Find("CharacterImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(Resource.PriestIcon) as Sprite;
                    characterList[i].GetComponent<Button>().onClick.AddListener(() => {
                        CharacterSelect(iconIndex);
                    });
                    break;
                default:
                    Debug.Log("Error : Class is " + characterData[i].cls);
                    break;
            }
        }
        characterImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);

        hp.text = "";
        mp.text = "";
        phyAtk.text = "";
        phyDef.text = "";
        magAtk.text = "";
        magDef.text = "";
        critical.text = "";
        speed.text = "";

        equipHead.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(0, 0, 0, 0);
        equipBody.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(0, 0, 0, 0);
        equipFoot.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(0, 0, 0, 0);
        equipWeapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(0, 0, 0, 0);
        equipSubweapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(0, 0, 0, 0);

        for (int i = 0; i < 5; i++)
        {
            activeSkillList[i].transform.Find("SkillIcon").GetComponent<Image>().color =
                Color.clear;
            passiveSkillList[i].transform.Find("SkillIcon").GetComponent<Image>().color =
                Color.clear;
        }
        UpdateSkillScroll();
        EquipmentListUpdate(EquipClass.All);
        UpdateEquipScroll();
        OnClickActiveEquip();
    }

    public void CharacterSelect(int index)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        selectedChar = characterData[index];
        selectedCharStatAllocate = new DataChar(selectedChar);
        selectedCharIndex = index;
        switch (characterData[index].cls)
        {
            case "Thief":
                characterImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(Resource.ThiefIdle) as Sprite;
                characterImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case "Archer":
                characterImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(Resource.ArcherIdle) as Sprite;
                characterImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case "Mage":
                characterImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(Resource.MagicianIdle) as Sprite;
                characterImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case "Knight":
                characterImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(Resource.KnightIdle) as Sprite;
                characterImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case "Priest":
                characterImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(Resource.PriestIdle) as Sprite;
                characterImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            default:
                Debug.Log("Error : Class is " + characterData[index].cls);
                break;

        }

        ShowCharacterEquipment(index);
        ShowCharacterStatus(characterData[index]);
        EquipmentListUpdate(EquipClass.All);
        ShowCharacterSkill(index);

    }

    private void ShowCharacterStatus(DataChar character)
    {
        hp.text = "HP  :  " + character.curHP + " / " + character.getMaxHP();
        mp.text = "MP  :  " + character.curMP + " / " + character.getMaxMP();
        phyAtk.text = "무력  :  " + character.getPhyATK();
        phyDef.text = "근성  :  " + character.getPhyDEF();
        magAtk.text = "마력  :  " + character.getMgcATK();
        magDef.text = "의지  :  " + character.getMgcDEF();
        critical.text = "치명타  :  " + character.critical * 100 + "%";
        speed.text = "행동력  :  " + character.getSPD();
        statUpPoint.text = "잔여 능력치  :  " + character.statPoint;
        UpdateStatScroll();
    }

    public void OnClickHpAllocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (selectedCharStatAllocate.statPoint > 0)
        {
            selectedCharStatAllocate.upMaxHP();
            selectedCharStatAllocate.statPoint--;
            hpAllocate++;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickMpAllocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (selectedCharStatAllocate.statPoint > 0)
        {
            selectedCharStatAllocate.upMaxMP();
            selectedCharStatAllocate.statPoint--;
            mpAllocate++;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickPhyAtkAllocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (selectedCharStatAllocate.statPoint > 0)
        {
            selectedCharStatAllocate.upPhyATK();
            selectedCharStatAllocate.statPoint--;
            phyAtkAllocate++;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickPhyDefAllocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (selectedCharStatAllocate.statPoint > 0)
        {
            selectedCharStatAllocate.upPhyDEF();
            selectedCharStatAllocate.statPoint--;
            phyDefAllocate++;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickMagAtkAllocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (selectedCharStatAllocate.statPoint > 0)
        {
            selectedCharStatAllocate.upMgcATK();
            selectedCharStatAllocate.statPoint--;
            magAtkAllocate++;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickMagDefAllocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (selectedCharStatAllocate.statPoint > 0)
        {
            selectedCharStatAllocate.upMgcDEF();
            selectedCharStatAllocate.statPoint--;
            magDefAllocate++;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickCriticalAllocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (selectedCharStatAllocate.statPoint > 0)
        {
            selectedCharStatAllocate.upCritical();
            selectedCharStatAllocate.statPoint--;
            criticalAllocate++;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickSpeedAllocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (selectedCharStatAllocate.statPoint > 0)
        {
            selectedCharStatAllocate.upIncAP();
            selectedCharStatAllocate.statPoint--;
            speedAllocate++;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }

    public void OnClickHpDeallocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (hpAllocate > 0)
        {
            selectedCharStatAllocate.downMaxHP();
            selectedCharStatAllocate.statPoint++;
            hpAllocate--;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickMpDeallocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (mpAllocate > 0)
        {
            selectedCharStatAllocate.downMaxMP();
            selectedCharStatAllocate.statPoint++;
            mpAllocate--;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickPhyAtkDeallocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (phyAtkAllocate > 0)
        {
            selectedCharStatAllocate.downPhyATK();
            selectedCharStatAllocate.statPoint++;
            phyAtkAllocate--;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickPhyDefDeallocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (phyDefAllocate > 0)
        {
            selectedCharStatAllocate.downPhyDEF();
            selectedCharStatAllocate.statPoint++;
            phyDefAllocate--;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickMagAtkDeallocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (magAtkAllocate > 0)
        {
            selectedCharStatAllocate.downMgcATK();
            selectedCharStatAllocate.statPoint++;
            magAtkAllocate--;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickMagDefDeallocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (magDefAllocate > 0)
        {
            selectedCharStatAllocate.downMgcDEF();
            selectedCharStatAllocate.statPoint++;
            magDefAllocate--;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickCriticalDeallocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (criticalAllocate > 0)
        {
            selectedCharStatAllocate.downCritical();
            selectedCharStatAllocate.statPoint++;
            criticalAllocate--;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }
    public void OnClickSpeedDeallocate()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (speedAllocate > 0)
        {
            selectedCharStatAllocate.downIncAP();
            selectedCharStatAllocate.statPoint++;
            speedAllocate--;
            ShowCharacterStatus(selectedCharStatAllocate);
        }
    }

    public void OnClickStatAllocateCancel()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        hpAllocate = 0;
        mpAllocate = 0;
        phyAtkAllocate = 0;
        phyDefAllocate = 0;
        magAtkAllocate = 0;
        magDefAllocate = 0;
        criticalAllocate = 0;
        speedAllocate = 0;
        selectedCharStatAllocate = new DataChar(selectedChar);
        ShowCharacterStatus(selectedChar);
    }

    public void OnClickStatAllocateConfirm()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        characterData[selectedCharIndex] = selectedCharStatAllocate;
        gameManager.UpdateCharacterList(characterData);
        characterData = gameManager.GetCharacterList();
        CharacterSelect(selectedCharIndex);
    }

    IEnumerator StatUpScrollSlider(int statCoef)
    {
        while (statUpPanelRoutine)
        {
            //statUpSlider.value = Mathf.RoundToInt(statUpSlider.value);
            statUpUseScroll.text = "사용 주문서 : " + (int)statUpSlider.value;
            statUpGainPointValue = statCoef * (int)statUpSlider.value;
            statUpGainPoint.text = "획득 포인트 : " + statUpGainPointValue;
            yield return null;
        }
    }

    public void OnClickStatUpOne()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        statUpScrollName.text = "능력치 +1 주문서";
        statUpPoseScroll.text = "보유 주문서 : " + PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollOne);
        statUpScrollIcon.transform.Find("ScrollIcon").GetComponent<Image>().sprite
            = Resources.Load<Sprite>(Resource.ScrollOne);
        statUpSlider.maxValue = PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollOne);
        statUpPanelRoutine = true;
        btnStatUpConfirm.onClick.RemoveAllListeners();
        btnStatUpConfirm.onClick.AddListener(() =>
        {
            OnClickStatUpConfirm(1);
        });
        StartCoroutine(StatUpScrollSlider(1));
        Utility.ObjectVisibility(statUpPanel, true);
    }
    public void OnClickStatUpThree()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        statUpScrollName.text = "능력치 +3 주문서";
        statUpPoseScroll.text = "보유 주문서 : " + PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollThree);
        statUpScrollIcon.transform.Find("ScrollIcon").GetComponent<Image>().sprite
            = Resources.Load<Sprite>(Resource.ScrollThree);
        statUpSlider.maxValue = PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollThree);
        statUpPanelRoutine = true;
        btnStatUpConfirm.onClick.RemoveAllListeners();
        btnStatUpConfirm.onClick.AddListener(() =>
        {
            OnClickStatUpConfirm(3);
        });
        StartCoroutine(StatUpScrollSlider(3));
        Utility.ObjectVisibility(statUpPanel, true);
    }
    public void OnClickStatUpFive()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        statUpScrollName.text = "능력치 +5 주문서";
        statUpPoseScroll.text = "보유 주문서 : " + PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollFive);
        statUpScrollIcon.transform.Find("ScrollIcon").GetComponent<Image>().sprite
            = Resources.Load<Sprite>(Resource.ScrollFive);
        statUpSlider.maxValue = PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollFive);
        statUpPanelRoutine = true;
        btnStatUpConfirm.onClick.RemoveAllListeners();
        btnStatUpConfirm.onClick.AddListener(() =>
        {
            OnClickStatUpConfirm(5);
        });
        StartCoroutine(StatUpScrollSlider(5));
        Utility.ObjectVisibility(statUpPanel, true);
    }
    public void OnClickStatUpChaos()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        statUpPoseScrollChaos.text = "보유 주문서 : " + PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollChaos);
        statUpScrollIcon.transform.Find("ScrollIcon").GetComponent<Image>().sprite
            = Resources.Load<Sprite>(Resource.ScrollChaos);
        Utility.ObjectVisibility(statUpChaosPanel, true);
    }

    public void OnClickStatUpCancel()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        statUpPanelRoutine = false;
        Utility.ObjectVisibility(statUpPanel, false);
    }

    public void OnClickStatUpConfirm(int coef)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        selectedChar.statPoint += statUpGainPointValue;
        switch (coef)
        {
            case 1:
                PlayerPrefs.SetInt(PrefsEntity.StatusUpgradeScrollOne,
                    PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollOne) - (int)statUpSlider.value);
                break;
            case 3:
                PlayerPrefs.SetInt(PrefsEntity.StatusUpgradeScrollThree,
                    PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollThree) - (int)statUpSlider.value);
                break;
            case 5:
                PlayerPrefs.SetInt(PrefsEntity.StatusUpgradeScrollFive,
                    PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollFive) - (int)statUpSlider.value);
                break;
        }
        gameManager.UpdateCharacterList(characterData);
        characterData = gameManager.GetCharacterList();
        statUpPanelRoutine = false;
        CharacterSelect(selectedCharIndex);
        Utility.ObjectVisibility(statUpPanel, false);
    }

    public void OnClickStatUpChaosCancel()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(statUpChaosPanel, false);
    }
    public void OnClickStatUpChaosConfirm()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        int i = Random.Range(-10, 11);
        selectedChar = CharacterHpAllocate(selectedChar, i);
        i = Random.Range(-10, 11);
        selectedChar = CharacterMpAllocate(selectedChar, i);
        i = Random.Range(-10, 11);
        selectedChar = CharacterPhyAtkAllocate(selectedChar, i);
        i = Random.Range(-10, 11);
        selectedChar = CharacterPhyDefAllocate(selectedChar, i);
        i = Random.Range(-10, 11);
        selectedChar = CharacterMagAtkAllocate(selectedChar, i);
        i = Random.Range(-10, 11);
        selectedChar = CharacterMagDefAllocate(selectedChar, i);
        i = Random.Range(-10, 11);
        selectedChar = CharacterCriticalAllocate(selectedChar, i);
        i = Random.Range(-10, 11);
        selectedChar = CharacterSpeedAllocate(selectedChar, i);
        ShowStatUpChaosResult();
        Utility.ObjectVisibility(statUpChaosPanel, false);
    }
    private void ShowStatUpChaosResult()
    {
        chaosHpResult.text = "HP  :  " + selectedChar.curHP + " / " + selectedChar.getMaxHP();
        chaosMpResult.text = "MP  :  " + selectedChar.curMP + " / " + selectedChar.getMaxMP();
        chaosPhyAtkResult.text = "무력  :  " + selectedChar.getPhyATK();
        chaosPhyDefResult.text = "근성  :  " + selectedChar.getPhyDEF();
        chaosMagAtkResult.text = "마력  :  " + selectedChar.getMgcATK();
        chaosMagDefResult.text = "의지  :  " + selectedChar.getMgcDEF();
        chaosCriticalResult.text = "치명타  :  " + selectedChar.critical * 100 + "%";
        chaosSpeedResult.text = "행동력  :  " + selectedChar.getSPD();
        PlayerPrefs.SetInt(PrefsEntity.StatusUpgradeScrollChaos,
            PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollChaos) - 1);
        CharacterSelect(selectedCharIndex);
        gameManager.UpdateCharacterList(characterData);
        characterData = gameManager.GetCharacterList();
        Utility.ObjectVisibility(statUpChaosResultPanel, true);
    }

    public void OnClickStatUpChaosResultConfirm()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(statUpChaosResultPanel, false);
    }
    private DataChar CharacterHpAllocate(DataChar character, int times)
    {
        if(times < 0)
            for(int i=0; i<Mathf.Abs(times); i++)
            {
                character.downMaxHP();
                chaosHpPoint.text = times + "P";
                chaosHpPoint.color = new Color(0.688f, 0.152f, 0.152f, 1);
            }
        else if (times > 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.upMaxHP();
                chaosHpPoint.text = "+" + times + "P";
                chaosHpPoint.color = new Color(0.602f, 1, 0.372f, 1);
            }
        else
        {
            chaosHpPoint.text = "+" + 0 + "P";
            chaosHpPoint.color = new Color(1, 1, 1, 1);
        }
        return character;
    }
    private DataChar CharacterMpAllocate(DataChar character, int times)
    {
        if (times < 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.downMaxMP();
                chaosMpPoint.text = times + "P";
                chaosMpPoint.color = new Color(0.688f, 0.152f, 0.152f, 1);
            }
        else if (times > 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.upMaxMP();
                chaosMpPoint.text = "+" + times + "P";
                chaosMpPoint.color = new Color(0.602f, 1, 0.372f, 1);
            }
        else
        {
            chaosMpPoint.text = "+" + 0 + "P";
            chaosMpPoint.color = new Color(1, 1, 1, 1);
        }
        return character;
    }
    private DataChar CharacterPhyAtkAllocate(DataChar character, int times)
    {
        if (times < 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.downPhyATK();
                chaosPhyAtkPoint.text = times + "P";
                chaosPhyAtkPoint.color = new Color(0.688f, 0.152f, 0.152f, 1);
            }
        else if (times > 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.upPhyATK();
                chaosPhyAtkPoint.text = "+" + times + "P";
                chaosPhyAtkPoint.color = new Color(0.602f, 1, 0.372f, 1);
            }
        else
        {
            chaosPhyAtkPoint.text = "+" + 0 + "P";
            chaosPhyAtkPoint.color = new Color(1, 1, 1, 1);
        }
        return character;
    }
    private DataChar CharacterPhyDefAllocate(DataChar character, int times)
    {
        if (times < 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.downPhyDEF();
                chaosPhyDefPoint.text = times + "P";
                chaosPhyDefPoint.color = new Color(0.688f, 0.152f, 0.152f, 1);
            }
        else if (times > 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.upPhyDEF();
                chaosPhyDefPoint.text = "+" + times + "P";
                chaosPhyDefPoint.color = new Color(0.602f, 1, 0.372f, 1);
            }
        else
        {
            chaosPhyDefPoint.text = "+" + 0 + "P";
            chaosPhyDefPoint.color = new Color(1, 1, 1, 1);
        }
        return character;
    }
    private DataChar CharacterMagAtkAllocate(DataChar character, int times)
    {
        if (times < 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.downMgcATK();
                chaosMagAtkPoint.text = times + "P";
                chaosMagAtkPoint.color = new Color(0.688f, 0.152f, 0.152f, 1);
            }
        else if (times > 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.upMgcATK();
                chaosMagAtkPoint.text = "+" + times + "P";
                chaosMagAtkPoint.color = new Color(0.602f, 1, 0.372f, 1);
            }
        else
        {
            chaosMagAtkPoint.text = "+" + 0 + "P";
            chaosMagAtkPoint.color = new Color(1, 1, 1, 1);
        }
        return character;
    }
    private DataChar CharacterMagDefAllocate(DataChar character, int times)
    {
        if (times < 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.downMgcDEF();
                chaosMagDefPoint.text = times + "P";
                chaosMagDefPoint.color = new Color(0.688f, 0.152f, 0.152f, 1);
            }
        else if (times > 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.upMgcDEF();
                chaosMagDefPoint.text = "+" + times + "P";
                chaosMagDefPoint.color = new Color(0.602f, 1, 0.372f, 1);
            }
        else
        {
            chaosMagDefPoint.text = "+" + 0 + "P";
            chaosMagDefPoint.color = new Color(1, 1, 1, 1);
        }
        return character;
    }
    private DataChar CharacterCriticalAllocate(DataChar character, int times)
    {
        if (times < 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.downCritical();
                chaosCriticalPoint.text = times + "P";
                chaosCriticalPoint.color = new Color(0.688f, 0.152f, 0.152f, 1);
            }
        else if (times > 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.upCritical();
                chaosCriticalPoint.text = "+" + times + "P";
                chaosCriticalPoint.color = new Color(0.602f, 1, 0.372f, 1);
            }
        else
        {
            chaosCriticalPoint.text = "+" + 0 + "P";
            chaosCriticalPoint.color = new Color(1, 1, 1, 1);
        }
        return character;
    }
    private DataChar CharacterSpeedAllocate(DataChar character, int times)
    {
        if (times < 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.downIncAP();
                chaosSpeedPoint.text = times + "P";
                chaosSpeedPoint.color = new Color(0.688f, 0.152f, 0.152f, 1);
            }
        else if (times > 0)
            for (int i = 0; i < Mathf.Abs(times); i++)
            {
                character.upIncAP();
                chaosSpeedPoint.text = "+" + times + "P";
                chaosSpeedPoint.color = new Color(0.602f, 1, 0.372f, 1);
            }
        else
        {
            chaosSpeedPoint.text = "+" + 0 + "P";
            chaosSpeedPoint.color = new Color(1, 1, 1, 1);
        }
        return character;
    }

    private void EquipmentListUpdate(EquipClass sort)
    {
        foreach (Transform child in itemListParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        int additionalSpace = 0;
        itemList = gameManager.GetEquipment();
        for (int i = 0; i < itemList.Count; i++)
        {
            if (sort == itemList[i].cls | sort == EquipClass.All)
            {
                int itemIndex = i;
                itemSlot[i] = Instantiate(itemPrefab, itemListParent.transform);
                itemSlot[i].transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(itemList[i].img) as Sprite;
                itemSlot[i].gameObject
                    .AddComponent<TooltipManager>()
                    .SetEquip(itemList[i], itemIndex, IconType.Equipment);
                itemSlot[i].gameObject.AddComponent<Button>().onClick.AddListener(() =>
                {
                    OnClickItem(itemIndex);
                });
            }
            else
            {
                additionalSpace++;
            }
        }
        for (int i = itemList.Count - additionalSpace; i < itemSlot.Length; i++)
        {
            itemSlot[i] = Instantiate(itemPrefab, itemListParent.transform);
            itemSlot[i].transform.Find("ItemImage").gameObject.GetComponent<Image>().color
                = Color.clear;

        }
        UpdateEquipScroll();
    }

    public void OnClickItem(int index)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (itemList[index].level == 20)
        {
            MessageEquipMaxLevel();
            return;
        }
        //Debug.Log(index + "th Item : " + itemList[index].name);
        Equip upgradeEquip = EquipManager.GetEquipNextLevel(itemList[index]);
        SetEquipUpgradeDescriptionBefore(itemList[index]);
        SetEquipUpgradeDescriptionAfter(upgradeEquip);
        btnEquipUpgrade.onClick.RemoveAllListeners();
        btnEquipUpgrade.onClick.AddListener(() =>
        {
            OnClickInventoryEquipUpgradeConfirm(index);
        });
        Utility.ObjectVisibility(equipUpgradeDescription, true);
    }

    public void OnClickWearItem(int charIndex, int equipIndex)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (characterData[charIndex].charEquipSet.set[equipIndex].level == 20)
        {
            MessageEquipMaxLevel();
            return;
        }
        Equip upgradeEquip = EquipManager.GetEquipNextLevel(characterData[charIndex].charEquipSet.set[equipIndex]);
        SetEquipUpgradeDescriptionBefore(characterData[charIndex].charEquipSet.set[equipIndex]);
        SetEquipUpgradeDescriptionAfter(upgradeEquip);
        btnEquipUpgrade.onClick.RemoveAllListeners();
        btnEquipUpgrade.onClick.AddListener(() =>
        {
            OnClickWearEquipUpgradeConfirm(charIndex, equipIndex);
        });
        Utility.ObjectVisibility(equipUpgradeDescription, true);
    }

    private void SetEquipUpgradeDescriptionBefore(Equip equip)
    {
        equipUpBeforeName.text = "+" + equip.level + " " + equip.name;
        string grade = "";
        Color gradeColor = new Color(0, 0, 0);
        switch (equip.grade)
        {
            case EquipGrade.Normal:
                grade = "노멀";
                gradeColor = new Color(0.83f, 0.746f, 0.661f);
                break;
            case EquipGrade.Rare:
                grade = "레어";
                gradeColor = new Color(0.589f, 0.934f, 1.0f);
                break;
            case EquipGrade.Unique:
                grade = "유니크";
                gradeColor = new Color(1.0f, 0.589f, 0.699f);
                break;
            case EquipGrade.Mystic:
                grade = "미스틱";
                gradeColor = new Color(1.0f, 0.849f, 0.0f);
                break;
        }
        equipUpBeforeGrade.text = "(" + grade + " 아이템)";
        equipUpBeforeGrade.color = gradeColor;
        string equipType = "";
        string equipReq = "";
        switch (equip.type)
        {
            case EquipType.Body:
                equipType = "갑옷";
                break;
            case EquipType.Foot:
                equipType = "신발";
                break;
            case EquipType.Head:
                equipType = "머리";
                break;
            case EquipType.SubWeapon:
                equipType = "보조무기";
                break;
            case EquipType.Weapon:
                equipType = "무기";
                break;
        }
        switch (equip.cls)
        {
            case EquipClass.Archer:
                equipReq = "궁수";
                break;
            case EquipClass.Knight:
                equipReq = "기사";
                break;
            case EquipClass.Mage:
                equipReq = "마법사";
                break;
            case EquipClass.Priest:
                equipReq = "사제";
                break;
            case EquipClass.Thief:
                equipReq = "도적";
                break;
        }
        equipUpBeforeIcon.sprite = Resources.Load<Sprite>(equip.img);
        equipUpBeforeType.text = equipType + "/" + equipReq + " 착용 가능";
        equipUpBeforeAp.text = "행동력 : " + equip.getIncAP();
        equipUpBeforeCritical.text = "치명타 : " + equip.getCritical() * 100 + "%";
        equipUpBeforeHealEf.text = "회복효율 : " + equip.getHealEFC() * 100 + "%";
        equipUpBeforeHp.text = "HP : " + equip.getHP();
        equipUpBeforeMagAtk.text = "마력 : " + equip.getMgcATK();
        if(equip.getMgcATKRate() != 0)
            equipUpBeforeMagAtk.text = equipUpBeforeMagAtk.text + " + " + equip.getMgcATKRate() * 100 + "%";
        equipUpBeforeMagDef.text = "의지 : " + equip.getMgcDEF();
        if (equip.getMgcDEFRate() != 0)
            equipUpBeforeMagDef.text = equipUpBeforeMagDef.text + " + " + equip.getMgcDEFRate() * 100 + "%";
        equipUpBeforeMp.text = "MP : " + equip.getMP();
        equipUpBeforePhyAtk.text = "무력 : " + equip.getPhyATK();
        if (equip.getPhyATKRate() != 0)
            equipUpBeforePhyAtk.text = equipUpBeforePhyAtk.text + " + " + equip.getPhyATKRate() * 100 + "%";
        equipUpBeforePhyDef.text = "근성 : " + equip.getPhyDEF();
        if (equip.getPhyDEFRate() != 0)
            equipUpBeforePhyDef.text = equipUpBeforePhyDef.text + " + " + equip.getPhyDEFRate() * 100 + "%";
        equipUpRequireScroll.text = "요구 주문서 : " + EquipManager.GetRequireUpgradeScroll(equip);
        equipUpPanelPossessScroll.text = "보유 주문서 : " + PlayerPrefs.GetInt(PrefsEntity.EquipmentUpgradeScroll, 0);
        equipUpProbability.text = "성공확률 : " + EquipManager.GetUpgradeProbability(equip) + "%";
        equipUpProbability.color = new Color(1.0f - equip.level / 40f, 1f - equip.level / 20f, 1f - equip.level/20f, 1);
    }

    private void SetEquipUpgradeDescriptionAfter(Equip equip)
    {
        equipUpAfterName.text = "+" + equip.level + " " + equip.name;
        string grade = "";
        Color gradeColor = new Color(0, 0, 0);
        switch (equip.grade)
        {
            case EquipGrade.Normal:
                grade = "노멀";
                gradeColor = new Color(0.83f, 0.746f, 0.661f);
                break;
            case EquipGrade.Rare:
                grade = "레어";
                gradeColor = new Color(0.589f, 0.934f, 1.0f);
                break;
            case EquipGrade.Unique:
                grade = "유니크";
                gradeColor = new Color(1.0f, 0.589f, 0.699f);
                break;
            case EquipGrade.Mystic:
                grade = "미스틱";
                gradeColor = new Color(1.0f, 0.849f, 0.0f);
                break;
        }
        equipUpAfterGrade.text = "(" + grade + " 아이템)";
        equipUpAfterGrade.color = gradeColor;
        string equipType = "";
        string equipReq = "";
        switch (equip.type)
        {
            case EquipType.Body:
                equipType = "갑옷";
                break;
            case EquipType.Foot:
                equipType = "신발";
                break;
            case EquipType.Head:
                equipType = "머리";
                break;
            case EquipType.SubWeapon:
                equipType = "보조무기";
                break;
            case EquipType.Weapon:
                equipType = "무기";
                break;
        }
        switch (equip.cls)
        {
            case EquipClass.Archer:
                equipReq = "궁수";
                break;
            case EquipClass.Knight:
                equipReq = "기사";
                break;
            case EquipClass.Mage:
                equipReq = "마법사";
                break;
            case EquipClass.Priest:
                equipReq = "사제";
                break;
            case EquipClass.Thief:
                equipReq = "도적";
                break;
        }
        equipUpAfterIcon.sprite = Resources.Load<Sprite>(equip.img);
        equipUpAfterType.text = equipType + "/" + equipReq + " 착용 가능";
        equipUpAfterAp.text = "행동력 : " + equip.getIncAP();
        equipUpAfterCritical.text = "치명타 : " + equip.getCritical() * 100 + "%";
        equipUpAfterHealEf.text = "회복효율 : " + equip.getHealEFC() * 100 + "%";
        equipUpAfterHp.text = "HP : " + equip.getHP();
        equipUpAfterMagAtk.text = "마력 : " + equip.getMgcATK();
        if (equip.getMgcATKRate() != 0)
            equipUpAfterMagAtk.text = equipUpAfterMagAtk.text + " + " + equip.getMgcATKRate() * 100 + "%";
        equipUpAfterMagDef.text = "의지 : " + equip.getMgcDEF();
        if (equip.getMgcDEFRate() != 0)
            equipUpAfterMagDef.text = equipUpAfterMagDef.text + " + " + equip.getMgcDEFRate() * 100 + "%";
        equipUpAfterMp.text = "MP : " + equip.getMP();
        equipUpAfterPhyAtk.text = "무력 : " + equip.getPhyATK();
        if (equip.getPhyATKRate() != 0)
            equipUpAfterPhyAtk.text = equipUpAfterPhyAtk.text + " + " + equip.getPhyATKRate() * 100 + "%";
        equipUpAfterPhyDef.text = "근성 : " + equip.getPhyDEF();
        if (equip.getPhyDEFRate() != 0)
            equipUpAfterPhyDef.text = equipUpAfterPhyDef.text + " + " + equip.getPhyDEFRate() * 100 + "%";

    }

    public void OnClickEquipUpgradeCancel()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(equipUpgradeDescription, false);
    }

    public void OnClickInventoryEquipUpgradeConfirm(int itemIndex)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        int requireScroll = EquipManager.GetRequireUpgradeScroll(itemList[itemIndex]);
        if (requireScroll > PlayerPrefs.GetInt(PrefsEntity.EquipmentUpgradeScroll, 0))
        {
            MessageEquipUpLackScroll();
        }
        else
        {
            if (EquipManager.UpgradeEquip(itemList[itemIndex]))
            {
                itemList[itemIndex] = EquipManager.GetEquipNextLevel(itemList[itemIndex]);
                gameManager.SetEquipment(itemList);
                MessageEquipUpSuccess();
            }
            else
            {
                MessageEquipUpFail();
            }
            PlayerPrefs.SetInt(PrefsEntity.EquipmentUpgradeScroll,
                PlayerPrefs.GetInt(PrefsEntity.EquipmentUpgradeScroll) - requireScroll);
            EquipmentListUpdate(EquipClass.All);
        }
        
        Utility.ObjectVisibility(equipUpgradeDescription, false);
    }

    public void OnClickWearEquipUpgradeConfirm(int charIndex, int equipIndex)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        int requireScroll = EquipManager.GetRequireUpgradeScroll(characterData[charIndex].charEquipSet.set[equipIndex]);
        if (requireScroll > PlayerPrefs.GetInt(PrefsEntity.EquipmentUpgradeScroll, 0))
        {
            MessageEquipUpLackScroll();
        }
        else
        {
            if (EquipManager.UpgradeEquip(characterData[charIndex].charEquipSet.set[equipIndex]))
            {
                characterData[charIndex].charEquipSet.set[equipIndex] =
                    EquipManager.GetEquipNextLevel(characterData[charIndex].charEquipSet.set[equipIndex]);
                gameManager.UpdateCharacterList(characterData);
                CharacterSelect(charIndex);
                MessageEquipUpSuccess();
            }
            else
            {
                MessageEquipUpFail();
            }
            PlayerPrefs.SetInt(PrefsEntity.EquipmentUpgradeScroll,
                PlayerPrefs.GetInt(PrefsEntity.EquipmentUpgradeScroll) - requireScroll);
            EquipmentListUpdate(EquipClass.All);
        }
        
        Utility.ObjectVisibility(equipUpgradeDescription, false);
    }

    private void MessageEquipUpSuccess()
    {
        gameManager.PlaySound(SoundFilePath.SuccessEquip);
        Utility.ObjectVisibility(messagePanel, true);
        messagePanelText.text = "강화에 성공했습니다 !";
        messagePanelText.color = new Color(0.83f, 0.759f, 0.27f, 1);
    }

    private void MessageEquipUpFail()
    {
        gameManager.PlaySound(SoundFilePath.FailEquip);
        Utility.ObjectVisibility(messagePanel, true);
        messagePanelText.text = "강화에 실패했습니다...";
        messagePanelText.color = new Color(0.377f, 0.377f, 0.377f, 1);
    }

    private void MessageEquipUpLackScroll()
    {
        Utility.ObjectVisibility(messagePanel, true);
        messagePanelText.text = "주문서가 부족합니다.";
        messagePanelText.color = new Color(1, 1, 1, 1);
    }

    private void MessageEquipMaxLevel()
    {
        Utility.ObjectVisibility(messagePanel, true);
        messagePanelText.text = "최고 단계의 장비입니다.";
        messagePanelText.color = new Color(1, 1, 1, 1);
    }

    public void EquipUpResultClose()
    {
        Utility.ObjectVisibility(messagePanel, false);
    }

    private void ShowCharacterEquipment(int index)
    {
        equipHead.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(characterData[index].charEquipSet.set[0].img) as Sprite;
        equipHead.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        equipHead.gameObject
            .AddComponent<TooltipManager>()
            .SetEquip(characterData[index].charEquipSet.set[0], index, IconType.Equipment);
        equipHead.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        equipHead.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnClickWearItem(index, 0);
        });

        equipBody.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(characterData[index].charEquipSet.set[1].img) as Sprite;
        equipBody.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        equipBody.gameObject
            .AddComponent<TooltipManager>()
            .SetEquip(characterData[index].charEquipSet.set[1], index, IconType.Equipment);
        equipBody.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        equipBody.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnClickWearItem(index, 1);
        });

        equipFoot.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(characterData[index].charEquipSet.set[2].img) as Sprite;
        equipFoot.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        equipFoot.gameObject
            .AddComponent<TooltipManager>()
            .SetEquip(characterData[index].charEquipSet.set[2], index, IconType.Equipment);
        equipFoot.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        equipFoot.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnClickWearItem(index, 2);
        });

        equipWeapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(characterData[index].charEquipSet.set[3].img) as Sprite;
        equipWeapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        equipWeapon.gameObject
            .AddComponent<TooltipManager>()
            .SetEquip(characterData[index].charEquipSet.set[3], index, IconType.Equipment);
        equipWeapon.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        equipWeapon.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnClickWearItem(index, 3);
        });

        equipSubweapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(characterData[index].charEquipSet.set[4].img) as Sprite;
        equipSubweapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        equipSubweapon.gameObject
            .AddComponent<TooltipManager>()
            .SetEquip(characterData[index].charEquipSet.set[4], index, IconType.Equipment);
        equipSubweapon.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        equipSubweapon.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnClickWearItem(index, 4);
        });

    }

    private void ShowCharacterSkill(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            int skillIndex = i;
            activeSkillList[skillIndex].transform.Find("SkillIcon").GetComponent<Image>().sprite =
                Resources.Load<Sprite>(characterData[index].charSkillSet.act[skillIndex].image);
            activeSkillList[skillIndex].transform.Find("SkillIcon").GetComponent<Image>().color =
                new Color(1, 1, 1, 1);
            if (activeSkillList[skillIndex].GetComponent<TooltipManager>() == null)
            {
                activeSkillList[skillIndex].AddComponent<TooltipManager>();
            }
            activeSkillList[skillIndex].GetComponent<TooltipManager>().SetSkill(
                characterData[index].charSkillSet.act[skillIndex], skillIndex, IconType.Skill,
                characterData[index].cls, SKILLTYPE.ACT);

            activeSkillList[skillIndex].GetComponent<Button>().onClick.RemoveAllListeners();
            activeSkillList[skillIndex].GetComponent<Button>().onClick.AddListener(() => {
                OnClickSkill(index, skillIndex, SKILLTYPE.ACT);
            });
        }

        for (int i = 0; i < 5; i++)
        {
            int skillIndex = i;

            passiveSkillList[skillIndex].transform.Find("SkillIcon").GetComponent<Image>().sprite =
                Resources.Load<Sprite>(characterData[index].charSkillSet.pas[skillIndex].image);
            passiveSkillList[skillIndex].transform.Find("SkillIcon").GetComponent<Image>().color =
                new Color(1, 1, 1, 1);
            if (passiveSkillList[skillIndex].GetComponent<TooltipManager>() == null)
            {
                passiveSkillList[skillIndex].AddComponent<TooltipManager>();
            }
            passiveSkillList[skillIndex].GetComponent<TooltipManager>().SetSkill(
                characterData[index].charSkillSet.pas[skillIndex], skillIndex, IconType.Skill,
                characterData[index].cls, SKILLTYPE.PAS);

            passiveSkillList[skillIndex].GetComponent<Button>().onClick.RemoveAllListeners();
            passiveSkillList[skillIndex].GetComponent<Button>().onClick.AddListener(() => {
                OnClickSkill(index, skillIndex, SKILLTYPE.PAS);
            });
        }

        UpdateSkillScroll();
    }

    private void OnClickSkill(int characterIndex, int skillIndex, SKILLTYPE skillType)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        SkillExplain beforeSkillInfo = new SkillExplain();
        SkillExplain afterSkillInfo = new SkillExplain();
        string type = "";
        switch (skillType)
        {
            case SKILLTYPE.ACT:
                if (characterData[characterIndex].charSkillSet.act[skillIndex].level == 10)
                {
                    MessageSkillMaxLevel();
                    return;
                }
                beforeSkillInfo =
                    SkillParser.GetSkill(
                        SkillName.GetSkillNameFile(characterData[characterIndex].charSkillSet.act[skillIndex].name,
                        characterData[characterIndex].cls, SKILLTYPE.ACT),
                        characterData[characterIndex].charSkillSet.act[skillIndex].level);
                afterSkillInfo =
                    SkillParser.GetSkill(
                        SkillName.GetSkillNameFile(characterData[characterIndex].charSkillSet.act[skillIndex].name,
                        characterData[characterIndex].cls, SKILLTYPE.ACT),
                        characterData[characterIndex].charSkillSet.act[skillIndex].level + 1);

                skillUpBeforeIcon.sprite = Resources.Load<Sprite>(characterData[characterIndex].charSkillSet.act[skillIndex].image);
                skillUpAfterIcon.sprite = Resources.Load<Sprite>(characterData[characterIndex].charSkillSet.act[skillIndex].image);
                type = "액티브";
                break;
            case SKILLTYPE.PAS:
                if (characterData[characterIndex].charSkillSet.pas[skillIndex].level == 10)
                {
                    MessageSkillMaxLevel();
                    return;
                }
                beforeSkillInfo =
                    SkillParser.GetSkill(
                        SkillName.GetSkillNameFile(characterData[characterIndex].charSkillSet.pas[skillIndex].name,
                        characterData[characterIndex].cls, SKILLTYPE.PAS),
                        characterData[characterIndex].charSkillSet.pas[skillIndex].level);
                afterSkillInfo =
                    SkillParser.GetSkill(
                        SkillName.GetSkillNameFile(characterData[characterIndex].charSkillSet.pas[skillIndex].name,
                        characterData[characterIndex].cls, SKILLTYPE.PAS),
                        characterData[characterIndex].charSkillSet.pas[skillIndex].level + 1);
                skillUpBeforeIcon.sprite = Resources.Load<Sprite>(characterData[characterIndex].charSkillSet.pas[skillIndex].image);
                skillUpAfterIcon.sprite = Resources.Load<Sprite>(characterData[characterIndex].charSkillSet.pas[skillIndex].image);
                type = "패시브";
                break;
        }
        skillUpBeforeName.text = "Lv." + beforeSkillInfo.upgrade + " " + beforeSkillInfo.skillName;
        skillUpBeforeType.text = "(" + type + " 스킬)";
        skillUpBeforeCost.text = "Cost : " + beforeSkillInfo.cost.ToString();
        skillUpBeforeDescription.text = beforeSkillInfo.ability;

        skillUpAfterName.text = "Lv." + afterSkillInfo.upgrade + " " + afterSkillInfo.skillName;
        skillUpAfterType.text = "(" + type + " 스킬)";
        skillUpAfterCost.text = "Cost : " + afterSkillInfo.cost.ToString();
        skillUpAfterDescription.text = afterSkillInfo.ability;

        btnSkillUpConfirm.onClick.RemoveAllListeners();
        btnSkillUpConfirm.onClick.AddListener(()=> {
            OnClickSkillUpgradeConfirm(characterIndex, skillIndex, skillType);
        });

        skillUpPanelReqScroll.text = "요구 주문서 : " + SkillParser.GetRequireUpgradeScroll(beforeSkillInfo);
        skillUpPoseScroll.text = "보유 주문서 : " + PlayerPrefs.GetInt(PrefsEntity.SkillUpgradeScroll);
        Utility.ObjectVisibility(skillUpgradeDescription, true);
    }

    public void OnClickSkillUpgradeCancel()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(skillUpgradeDescription, false);
    }

    public void OnClickSkillUpgradeConfirm(int characterIndex, int skillIndex, SKILLTYPE skillType)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        int poseScroll = PlayerPrefs.GetInt(PrefsEntity.SkillUpgradeScroll);
        SkillExplain beforeSkillInfo = new SkillExplain();
        switch (skillType)
        {
            case SKILLTYPE.ACT:
                beforeSkillInfo =
                    SkillParser.GetSkill(
                        SkillName.GetSkillNameFile(characterData[characterIndex].charSkillSet.act[skillIndex].name,
                        characterData[characterIndex].cls, SKILLTYPE.ACT),
                        characterData[characterIndex].charSkillSet.act[skillIndex].level);
                break;
            case SKILLTYPE.PAS:
                beforeSkillInfo =
                    SkillParser.GetSkill(
                        SkillName.GetSkillNameFile(characterData[characterIndex].charSkillSet.pas[skillIndex].name,
                        characterData[characterIndex].cls, SKILLTYPE.PAS),
                        characterData[characterIndex].charSkillSet.pas[skillIndex].level);
                break;
        }

        int reqScroll = SkillParser.GetRequireUpgradeScroll(beforeSkillInfo);
        if (reqScroll > poseScroll)
        {
            MessageSkillUpLackScroll();
        }
        else
        {
            switch (skillType)
            {
                case SKILLTYPE.ACT:
                    characterData[characterIndex].charSkillSet.act[skillIndex].level++;
                    break;
                case SKILLTYPE.PAS:
                    characterData[characterIndex].charSkillSet.pas[skillIndex].level++;
                    break;
            }
            PlayerPrefs.SetInt(PrefsEntity.SkillUpgradeScroll,
                poseScroll - reqScroll);
        }
        gameManager.UpdateCharacterList(characterData);
        ShowCharacterSkill(characterIndex);
        Utility.ObjectVisibility(skillUpgradeDescription, false);
    }

    private void MessageSkillUpLackScroll()
    {
        Utility.ObjectVisibility(messagePanel, true);
        messagePanelText.text = "주문서가 부족합니다.";
        messagePanelText.color = new Color(1, 1, 1, 1);
    }

    private void MessageSkillMaxLevel()
    {
        Utility.ObjectVisibility(messagePanel, true);
        messagePanelText.text = "최고 단계의 스킬입니다.";
        messagePanelText.color = new Color(1, 1, 1, 1);
    }

    public void OnClickActiveStatus()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(panelStatusUp, true);
        Utility.ObjectVisibility(panelSkillUp, false);
        Utility.ObjectVisibility(panelEquipUp, false);
    }

    public void OnClickActiveEquip()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        EquipmentListUpdate(EquipClass.All);
        Utility.ObjectVisibility(panelStatusUp, false);
        Utility.ObjectVisibility(panelSkillUp, false);
        Utility.ObjectVisibility(panelEquipUp, true);
    }

    public void OnClickActiveSkill()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        UpdateSkillScroll();
        Utility.ObjectVisibility(panelStatusUp, false);
        Utility.ObjectVisibility(panelSkillUp, true);
        Utility.ObjectVisibility(panelEquipUp, false);
    }

    private void UpdateSkillScroll()
    {
        skillUpReqScroll.text = "보유 스킬 강화 주문서  :  " + PlayerPrefs.GetInt(PrefsEntity.SkillUpgradeScroll, 0);
    }

    private void UpdateEquipScroll()
    {
        equipUpgradeScroll.text = "보유 장비 강화 주문서  :  " + PlayerPrefs.GetInt(PrefsEntity.EquipmentUpgradeScroll, 0);
    }

    private void UpdateStatScroll()
    {
        statUpScrollOne.text = "" + PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollOne);
        statUpScrollThree.text = "" + PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollThree);
        statUpScrollFive.text = "" + PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollFive);
        statUpScrollChaos.text = "" + PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollChaos);
    }

    public void OnClickExclusiveEquip()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        OnClickActiveEquip();
        EquipmentListUpdate(selectedChar.charEquipSet.set[0].cls);
    }
}
