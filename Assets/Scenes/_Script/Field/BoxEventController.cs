using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxEventController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject boxPanel;
    public Button btnConfirm;
    public GameObject btnRouletteMove;
    public Text txtRouletteMove;
    public Text txtRouletteMessage;
    public Image eventImage;
    private int currentLevel;
    private bool rouletteStartFlag;
    private bool rouletteStopFlag;
    private int rouletteBtnCounter;
    private int eventFlag;
    private int occurEvent;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstatnce();
        currentLevel = PlayerPrefs.GetInt(PrefsEntity.CurrentLevel, 0);
        RouletteInitialize();
        occurEvent = PlayerPrefs.GetInt(PrefsEntity.OccurEvent, -1);
        if (PlayerPrefsX.GetBool(PrefsEntity.ForceTerminateInEvent, false))
        {
            rouletteStartFlag = true;
            switch (occurEvent)
            {
                case 0:
                    BoxEventHpHeal();
                    break;
                case 1:
                    BoxEventMpHeal();
                    break;
                case 2:
                    BoxEventMapOpen();
                    break;
                case 3:
                    BoxEventGetEquipment();
                    break;
                case 4:
                    BoxEventGetScrollEquip();
                    break;
                case 5:
                    BoxEventGetScrollSkill();
                    break;
                case 6:
                    BoxEventGetScrollStat();
                    break;
                case 7:
                    BoxEventGetKey();
                    break;

            }
            OnClickRoulette();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rouletteStartFlag)
        {
            eventFlag = Random.Range(1, 101);
            OccurRoulette();
        }
    }

    private void RouletteInitialize()
    {
        rouletteBtnCounter = 0;
        rouletteStartFlag = false;
        rouletteStopFlag = false;
        btnConfirm.interactable = false;
        txtRouletteMessage.text = "";
        txtRouletteMove.text = "START";
        eventImage.sprite = Resources.Load<Sprite>(BoxEventImage.DefaultImage) as Sprite;
    }

    private void OccurRoulette(int flag)
    {
        switch (flag)
        {
            case 0:
                BoxEventHpHeal();
                break;
            case 1:
                BoxEventMpHeal();
                break;
            case 2:
                BoxEventMapOpen();
                break;
            case 3:
                BoxEventGetEquipment();
                break;
            case 4:
                BoxEventGetScrollEquip();
                break;
            case 5:
                BoxEventGetScrollSkill();
                break;
            case 6:
                BoxEventGetScrollStat();
                break;
            case 7:
                BoxEventGetKey();
                break;
        }
    }
    private void OccurRoulette()
    {
        switch (currentLevel)
        {
            case 0:
                RouletteNormal(eventFlag);
                break;
            case 1:
                RouletteHard(eventFlag);
                break;
            case 2:
                RouletteHell(eventFlag);
                break;
        }
    }

    private void RouletteNormal(int eventFlag)
    {
        if (eventFlag >= 1 & eventFlag <= 10) // 10%, HP Heal (30 ~ 50%)
        {
            BoxEventHpHeal();
        }
        else if (eventFlag >= 11 & eventFlag <= 20) // 10%, MP Heal (30 ~ 50%)
        {
            BoxEventMpHeal();
        }
        else if (eventFlag >= 21 & eventFlag <= 30) // 10%, Map open
        {
            BoxEventMapOpen();
        }
        else if (eventFlag >= 31 & eventFlag <= 40) // 10%, Get Equipment
        {
            BoxEventGetEquipment();
        }
        else if (eventFlag >= 41 & eventFlag <= 50) // 10%, Get Scroll Equip
        {
            BoxEventGetScrollEquip();
        }
        else if (eventFlag >= 51 & eventFlag <= 65) // 15%, Get Scroll Skill
        {
            BoxEventGetScrollSkill();
        }
        else if (eventFlag >= 66 & eventFlag <= 80) // 15%, Get Scroll Stat
        {
            BoxEventGetScrollStat();
        }
        else if (eventFlag >= 81 & eventFlag <= 100) // 20%, Get 1 Key
        {
            BoxEventGetKey();
        }
    }
    private void RouletteHard(int eventFlag)
    {
        if (eventFlag >= 1 & eventFlag <= 15) // 15%, HP Heal (30 ~ 50%)
        {
            BoxEventHpHeal();
        }
        else if (eventFlag >= 16 & eventFlag <= 30) // 15%, MP Heal (30 ~ 50%)
        {
            BoxEventMpHeal();
        }
        else if (eventFlag >= 31 & eventFlag <= 40) // 10%, Map open
        {
            BoxEventMapOpen();
        }
        else if (eventFlag >= 41 & eventFlag <= 50) // 10%, Get Equipment
        {
            BoxEventGetEquipment();
        }
        else if (eventFlag >= 51 & eventFlag <= 60) // 10%, Get Scroll Equip
        {
            BoxEventGetScrollEquip();
        }
        else if (eventFlag >= 61 & eventFlag <= 70) // 10%, Get Scroll Skill
        {
            BoxEventGetScrollSkill();
        }
        else if (eventFlag >= 71 & eventFlag <= 80) // 10%, Get Scroll Stat
        {
            BoxEventGetScrollStat();
        }
        else if (eventFlag >= 81 & eventFlag <= 100) // 20%, Get 1 Key
        {
            BoxEventGetKey();
        }
    }
    private void RouletteHell(int eventFlag)
    {
        if (eventFlag >= 1 & eventFlag <= 20) // 20%, HP Heal (30 ~ 50%)
        {
            BoxEventHpHeal();
        }
        else if (eventFlag >= 21 & eventFlag <= 40) // 20%, MP Heal (30 ~ 50%)
        {
            BoxEventMpHeal();
        }
        else if (eventFlag >= 41 & eventFlag <= 50) // 10%, Map open
        {
            BoxEventMapOpen();
        }
        else if (eventFlag >= 51 & eventFlag <= 60) // 10%, Get Equipment
        {
            BoxEventGetEquipment();
        }
        else if (eventFlag >= 61 & eventFlag <= 70) // 10%, Get Scroll Equip
        {
            BoxEventGetScrollEquip();
        }
        else if (eventFlag >= 71 & eventFlag <= 75) // 5%, Get Scroll Skill
        {
            BoxEventGetScrollSkill();
        }
        else if (eventFlag >= 76 & eventFlag <= 80) // 5%, Get Scroll Stat
        {
            BoxEventGetScrollStat();
        }
        else if (eventFlag >= 81 & eventFlag <= 100) // 20%, Get 1 Key
        {
            BoxEventGetKey();
        }
    }

    private void BoxEventHpHeal()
    {
        eventImage.sprite = Resources.Load<Sprite>(BoxEventImage.HpHeal) as Sprite;
        txtRouletteMessage.text = BoxEventMessage.HpHeal;
        occurEvent = 0;
        if (!rouletteStartFlag)
        {
            List<DataChar> list = gameManager.GetCharacterList();
            float healCoef = Random.Range(0.30f, 0.60f);
            for(int i=0; i<list.Count; i++)
            {
                list[i].addHPbyPercent(healCoef);
            }
            gameManager.UpdateCharacterList(list);
            Debug.Log("HpHeal : " + healCoef);
        }
    }

    private void BoxEventMpHeal()
    {
        eventImage.sprite = Resources.Load<Sprite>(BoxEventImage.MpHeal) as Sprite;
        txtRouletteMessage.text = BoxEventMessage.MpHeal;
        occurEvent = 1;
        if (!rouletteStartFlag)
        {
            List<DataChar> list = gameManager.GetCharacterList();
            float healCoef = Random.Range(0.30f, 0.60f);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].addMPbyPercent(healCoef);
            }
            gameManager.UpdateCharacterList(list);
            Debug.Log("MpHeal : " + healCoef);
        }
    }

    private void BoxEventMapOpen()
    {
        eventImage.sprite = Resources.Load<Sprite>(BoxEventImage.MapOpen) as Sprite;
        txtRouletteMessage.text = BoxEventMessage.MapOpen;
        occurEvent = 2;
        if (!rouletteStartFlag)
        {
            MapGenerator.FieldMapOpen();
            Debug.Log("Log by BoxEventController : MapOpen");
        }
    }

    private void BoxEventGetEquipment()
    {
        eventImage.sprite = Resources.Load<Sprite>(BoxEventImage.GetEquipment) as Sprite;
        txtRouletteMessage.text = BoxEventMessage.GetEquipment;
        occurEvent = 3;
        if (!rouletteStartFlag)
        {
            Equip equip = EquipManager.GetRandomEquip();
            txtRouletteMessage.text = BoxEventMessage.GetEquipment + " : " + equip.name;
            eventImage.sprite = Resources.Load<Sprite>(equip.img);
            gameManager.AddEquipment(equip);
            Debug.Log("GetEquip : " + equip.name);
        }
    }

    private void BoxEventGetScrollEquip()
    {
        eventImage.sprite = Resources.Load<Sprite>(BoxEventImage.GetScrollEquip) as Sprite;
        txtRouletteMessage.text = BoxEventMessage.GetScrollEquip;
        occurEvent = 4;
        if (!rouletteStartFlag)
        {
            PlayerPrefs.SetInt(PrefsEntity.EquipmentUpgradeScroll,
                PlayerPrefs.GetInt(PrefsEntity.EquipmentUpgradeScroll) + 1);
            Debug.Log("GetScrollEquip. Scroll : " 
                + PlayerPrefs.GetInt(PrefsEntity.EquipmentUpgradeScroll) 
                + "(+1)");
        }
    }

    private void BoxEventGetScrollSkill()
    {
        eventImage.sprite = Resources.Load<Sprite>(BoxEventImage.GetScrollSkill) as Sprite;
        txtRouletteMessage.text = BoxEventMessage.GetScrollSkill;
        occurEvent = 5;
        if (!rouletteStartFlag)
        {
            int scrollNum = Random.Range(2, 6);
            PlayerPrefs.SetInt(PrefsEntity.SkillUpgradeScroll,
                PlayerPrefs.GetInt(PrefsEntity.SkillUpgradeScroll) + scrollNum);
            Debug.Log("GetScrollSkill. Scroll : " 
                + PlayerPrefs.GetInt(PrefsEntity.SkillUpgradeScroll)
                + "(+" + scrollNum + ")");
        }
    }

    private void BoxEventGetScrollStat()
    {
        eventImage.sprite = Resources.Load<Sprite>(BoxEventImage.GetScrollStat) as Sprite;
        txtRouletteMessage.text = BoxEventMessage.GetScrollStat;
        occurEvent = 6;
        if (!rouletteStartFlag)
        {
            int scrollFlag = Random.Range(0, 4);
            switch (scrollFlag)
            {
                case 0:
                    PlayerPrefs.SetInt(PrefsEntity.StatusUpgradeScrollOne,
                        PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollOne) + 2);
                    Debug.Log("GetScrollStat(One). Scroll : "
                        + PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollOne)
                        + "(+2)");
                    break;
                case 1:
                    PlayerPrefs.SetInt(PrefsEntity.StatusUpgradeScrollThree,
                        PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollThree) + 2);
                    Debug.Log("GetScrollStat(Three). Scroll : "
                        + PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollThree)
                        + "(+2)");
                    break;
                case 2:
                    PlayerPrefs.SetInt(PrefsEntity.StatusUpgradeScrollFive,
                        PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollFive) + 2);
                    Debug.Log("GetScrollStat(Five). Scroll : "
                        + PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollFive)
                        + "(+2)");
                    break;
                case 3:
                    PlayerPrefs.SetInt(PrefsEntity.StatusUpgradeScrollChaos,
                        PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollChaos) + 2);
                    Debug.Log("GetScrollStat(Chaos). Scroll : "
                        + PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollChaos)
                        + "(+2)");
                    break;
            }
        }
    }

    private void BoxEventGetKey()
    {
        eventImage.sprite = Resources.Load<Sprite>(BoxEventImage.GetKey) as Sprite;
        txtRouletteMessage.text = BoxEventMessage.GetKey;
        occurEvent = 7;
        if (!rouletteStartFlag)
        {
            gameManager.AddKey(1);
            Debug.Log("GetKey. Key");
        }
    }

    //Not used
    private void BoxEventUpgradeEquipment()
    {
        eventImage.sprite = Resources.Load<Sprite>(BoxEventImage.UpgradeEquipment) as Sprite;
        txtRouletteMessage.text = BoxEventMessage.UpgradeEquipment;
        if (!rouletteStartFlag)
        {
            Debug.Log("UpgEquip");
        }
    }

    //Not used
    private void BoxEventUpgradeSkill()
    {
        eventImage.sprite = Resources.Load<Sprite>(BoxEventImage.UpgradeSkill) as Sprite;
        txtRouletteMessage.text = BoxEventMessage.UpgradeSkill;
        if (!rouletteStartFlag)
        {
            Debug.Log("UpgSkill");
        }
    }

    public void OnClickRoulette()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (!rouletteStartFlag) //Start
        {
            rouletteStartFlag = true;
            txtRouletteMove.text = "STOP";
        }else if (rouletteStartFlag) //Stop
        {
            PlayerPrefs.SetInt(PrefsEntity.OccurEvent, occurEvent);
            rouletteStartFlag = !rouletteStartFlag;
            Utility.ObjectVisibility(btnRouletteMove, false);
            btnConfirm.interactable = true;
        }
    }

    public void OnClickConfirm()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(boxPanel, false);
        Utility.ObjectVisibility(btnRouletteMove, true);
        txtRouletteMessage.text = "";
        txtRouletteMove.text = "START";
        eventImage.sprite = Resources.Load<Sprite>(BoxEventImage.DefaultImage) as Sprite;
        gameManager.PlaySound(SoundFilePath.OpenBox);
        OccurRoulette(occurEvent);
        PlayerPrefsX.SetBool(PrefsEntity.ForceTerminateInEvent, false);
        RouletteInitialize();
    }
}
