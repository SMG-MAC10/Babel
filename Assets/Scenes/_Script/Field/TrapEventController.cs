using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrapEventController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject trapPanel;
    public GameObject controlBlocker;
    private int currentLevel;

    public Button btnConfirm;
    public GameObject btnRouletteMove;
    public Text txtRouletteMove;
    public Text txtRouletteMessage;
    public Image eventImage;
    private bool rouletteStartFlag;
    private bool rouletteStopFlag;
    private int rouletteBtnCounter;
    private int eventFlag;
    private int occurTrap;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstatnce();
        currentLevel = PlayerPrefs.GetInt(PrefsEntity.CurrentLevel, 0);
        RouletteInitialize();
        occurTrap = PlayerPrefs.GetInt(PrefsEntity.OccurTrap, -1);
        if (PlayerPrefsX.GetBool(PrefsEntity.ForceTerminateInTrap, false))
        {
            Debug.Log("ForceTrap");
            rouletteStartFlag = true;
            switch (occurTrap)
            {
                case 0:
                    FriendHpDecrease();
                    break;
                case 1:
                    FriendMpDecrease();
                    break;
                case 2:
                    EnemyStatUp();
                    break;
                case 3:
                    FriendStatDown();
                    break;
                case 4:
                    BattleStart();
                    break;
                case 5:
                    NothingHappen();
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
    private void OccurRoulette()
    {
        switch (currentLevel)
        {
            case 0:
                TrapNormal(eventFlag);
                break;
            case 1:
                TrapHard(eventFlag);
                break;
            case 2:
                TrapHell(eventFlag);
                break;
        }
    }
    private void OccurRoulette(int flag)
    {
        switch (flag)
        {
            case 0:
                FriendHpDecrease();
                break;
            case 1:
                FriendMpDecrease();
                break;
            case 2:
                EnemyStatUp();
                break;
            case 3:
                FriendStatDown();
                break;
            case 4:
                BattleStart();
                break;
            case 5:
                NothingHappen();
                break;
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

    private void TrapNormal(int eventFlag)
    {
        if (eventFlag >= 1 & eventFlag <= 10) // 10%, Friend HP Decrease (10 ~ 20%)
        {
            FriendHpDecrease();
        }
        else if (eventFlag >= 11 & eventFlag <= 20) // 10%, Friend MP Decrease (10 ~ 20%)
        {
            FriendMpDecrease();
        }
        else if (eventFlag >= 21 & eventFlag <= 35) // 15%, Enemy Stat Up
        {
            EnemyStatUp();
        }
        else if (eventFlag >= 36 & eventFlag <= 50) // 15%, Friend Stat Down
        {
            FriendStatDown();
        }
        else if (eventFlag >= 51 & eventFlag <= 70) // 20%, Battle Start
        {
            BattleStart();
        }
        else if (eventFlag >= 71 & eventFlag <= 100) // 30%, Nothing Happen
        {
            NothingHappen();
        }
    }

    private void TrapHard(int eventFlag)
    {
        if (eventFlag >= 1 & eventFlag <= 15) // 15%, Friend HP Decrease (10 ~ 20%)
        {
            FriendHpDecrease();
        }
        else if (eventFlag >= 16 & eventFlag <= 30) // 15%, Friend MP Decrease (10 ~ 20%)
        {
            FriendMpDecrease();
        }
        else if (eventFlag >= 31 & eventFlag <= 45) // 15%, Enemy Stat Up
        {
            EnemyStatUp();
        }
        else if (eventFlag >= 46 & eventFlag <= 60) // 15%, Friend Stat Down
        {
            FriendStatDown();
        }
        else if (eventFlag >= 61 & eventFlag <= 80) // 10%, Battle Start
        {
            BattleStart();
        }
        else if (eventFlag >= 81 & eventFlag <= 100) // 20%, Nothing Happen
        {
            NothingHappen();
        }
    }   

    private void TrapHell(int eventFlag)
    {

        if (eventFlag >= 1 & eventFlag <= 20) // 20%, Friend HP Decrease (10 ~ 20%)
        {
            FriendHpDecrease();
        }
        else if (eventFlag >= 21 & eventFlag <= 40) // 20%, Friend MP Decrease (10 ~ 20%)
        {
            FriendMpDecrease();
        }
        else if (eventFlag >= 41 & eventFlag <= 55) // 15%, Enemy Stat Up
        {
            EnemyStatUp();
        }
        else if (eventFlag >= 56 & eventFlag <= 70) // 15%, Friend Stat Down
        {
            FriendStatDown();
        }
        else if (eventFlag >= 71 & eventFlag <= 90) // 10%, Battle Start
        {
            BattleStart();
        }
        else if (eventFlag >= 91 & eventFlag <= 100) // 10%, Nothing Happen
        {
            NothingHappen();
        }
    }
    
    private void FriendHpDecrease()
    {
        eventImage.sprite = Resources.Load<Sprite>(TrapEventImage.HpDecrease) as Sprite;
        txtRouletteMessage.text = TrapEventMessage.HpDecrease;
        occurTrap = 0;
        if (!rouletteStartFlag)
        {
            List<DataChar> list = gameManager.GetCharacterList();
            float healCoef = Random.Range(0.10f, 0.20f);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].subHPbyPercent(healCoef);
            }
            gameManager.UpdateCharacterList(list);
            Debug.Log("HpDecrease");
        }
    }

    private void FriendMpDecrease()
    {
        eventImage.sprite = Resources.Load<Sprite>(TrapEventImage.MpDecrease) as Sprite;
        txtRouletteMessage.text = TrapEventMessage.MpDecrease;
        occurTrap = 1;
        if (!rouletteStartFlag)
        {
            List<DataChar> list = gameManager.GetCharacterList();
            float healCoef = Random.Range(0.10f, 0.20f);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].subMPbyPercent(healCoef);
            }
            gameManager.UpdateCharacterList(list);
            Debug.Log("MpDecrease");
        }
    }

    private void EnemyStatUp()
    {
        eventImage.sprite = Resources.Load<Sprite>(TrapEventImage.EnemyStatUp) as Sprite;
        txtRouletteMessage.text = TrapEventMessage.EnemyStatUp;
        occurTrap = 2;
        if (!rouletteStartFlag)
        {
            PlayerPrefsX.SetBool(PrefsEntity.TrapEnemyStatUp, true);
            Debug.Log("EnemyStatUp");
        }
    }

    private void FriendStatDown()
    {
        eventImage.sprite = Resources.Load<Sprite>(TrapEventImage.FriendStatDown) as Sprite;
        txtRouletteMessage.text = TrapEventMessage.FriendStatDown;
        occurTrap = 3;
        if (!rouletteStartFlag)
        {
            PlayerPrefsX.SetBool(PrefsEntity.TrapFriendStatDown, true);
            Debug.Log("FriendStatDown");
        }
    }

    //Not Use
    private void EnemyRegen()
    {
        eventImage.sprite = Resources.Load<Sprite>(BoxEventImage.HpHeal) as Sprite;
        txtRouletteMessage.text = TrapEventMessage.EnemyRegen;
        if (!rouletteStartFlag)
        {
            Debug.Log("EnemyRegen");
        }
    }

    private void BattleStart()
    {
        eventImage.sprite = Resources.Load<Sprite>(TrapEventImage.BattleStart) as Sprite;
        txtRouletteMessage.text = TrapEventMessage.BattleStart;
        occurTrap = 4;
        if (!rouletteStartFlag)
        {
            LoadingManager.LoadSceneFieldToBattle();
            Debug.Log("BattleStart");
        }
    }

    private void NothingHappen()
    {
        eventImage.sprite = Resources.Load<Sprite>(TrapEventImage.NothingHappen) as Sprite;
        txtRouletteMessage.text = TrapEventMessage.NothingHappen;
        occurTrap = 5;
        if (!rouletteStartFlag)
        {
            Debug.Log("NothingHappen");
        }
    }

    public void OnClickRoulette()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (!rouletteStartFlag) //Start
        {
            rouletteStartFlag = true;
            txtRouletteMove.text = "STOP";
        }
        else if (rouletteStartFlag) //Stop
        {
            PlayerPrefs.SetInt(PrefsEntity.OccurTrap, occurTrap);
            rouletteStartFlag = !rouletteStartFlag;
            Utility.ObjectVisibility(btnRouletteMove, false);
            btnConfirm.interactable = true;
        }
    }
    public void OnClickConfirm()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(controlBlocker, false);
        Utility.ObjectVisibility(trapPanel, false);
        Utility.ObjectVisibility(btnRouletteMove, true);
        txtRouletteMessage.text = "";
        txtRouletteMove.text = "START";
        eventImage.sprite = Resources.Load<Sprite>(TrapEventImage.DefaultImage) as Sprite;
        OccurRoulette(occurTrap);
        PlayerPrefsX.SetBool(PrefsEntity.ForceTerminateInTrap, false);
        RouletteInitialize();
    }
}
