using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class JailEventController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject jailPanel;
    public GameObject panelLackofKey;
    public GameObject panelGetCharacter;
    public GameObject panelDropCharacter;
    public GameObject eventController;
    private List<DataChar> characterData;
    private int prisonerFlag;
    private int selectedCharacterIndex;
    private DataChar prisoner;

    //Prisoner's Icon
    public GameObject prisonerDropCharacter;
    public GameObject prisonerGetCharacter;
    public Text txtGetCharacter;
    public GameObject prisonerLackOfKey;
    public Text txtLackOfKey;

    //Drop Character
    public GameObject dropCharacterParent;
    public GameObject characterIcon;
    public GameObject[] characterList;
    public Button dropCharacterConfirm;
    public Text txtDropCharacter;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstatnce();
        Utility.ObjectVisibility(jailPanel, false);
        characterList = new GameObject[10];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OccurJailEvent()
    {
        prisonerFlag = PlayerPrefs.GetInt(PrefsEntity.OccurJailPrisoner, -1);
        if (prisonerFlag == -1)
        {
            prisonerFlag = Random.Range(0, 5);
            PlayerPrefs.SetInt(PrefsEntity.OccurJailPrisoner, prisonerFlag);
        }
        SetPrisoner(prisonerFlag);
        if(gameManager.GetKey() == 0)
        {
            ShowLackOfKey();
        }
        else
        {
            ShowGetCharacter();
        }
        dropCharacterConfirm.interactable = false;
        Utility.ObjectVisibility(jailPanel, true);
    }

    private void ShowDropCharacter()
    {
        UpdateCharacterList();
        Utility.ObjectVisibility(panelDropCharacter, true);
    }

    private void UpdateCharacterList()
    {
        foreach (Transform child in dropCharacterParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        characterData = gameManager.GetCharacterList();
        int characterIndex;

        for (characterIndex = 0; characterIndex < characterData.Count; characterIndex++)
        {
            int i = characterIndex;
            characterList[characterIndex] = Instantiate(characterIcon, dropCharacterParent.transform);

            switch (characterData[characterIndex].cls)
            {
                case "Thief":
                    characterList[characterIndex].transform.Find("CharacterImage").GetComponent<Image>().sprite
                        = Resources.Load<Sprite>(Resource.ThiefIcon) as Sprite;
                    characterList[characterIndex].transform.Find("CharacterImage").GetComponent<Image>().color
                        = new Color(1, 1, 1, 1);
                    break;
                case "Archer":
                    characterList[characterIndex].transform.Find("CharacterImage").GetComponent<Image>().sprite
                        = Resources.Load<Sprite>(Resource.ArcherIcon) as Sprite;
                    characterList[characterIndex].transform.Find("CharacterImage").GetComponent<Image>().color
                        = new Color(1, 1, 1, 1);
                    break;
                case "Mage":
                    characterList[characterIndex].transform.Find("CharacterImage").GetComponent<Image>().sprite
                        = Resources.Load<Sprite>(Resource.MageIcon) as Sprite;
                    characterList[characterIndex].transform.Find("CharacterImage").GetComponent<Image>().color
                        = new Color(1, 1, 1, 1);
                    break;
                case "Knight":
                    characterList[characterIndex].transform.Find("CharacterImage").GetComponent<Image>().sprite
                        = Resources.Load<Sprite>(Resource.KnightIcon) as Sprite;
                    characterList[characterIndex].transform.Find("CharacterImage").GetComponent<Image>().color
                        = new Color(1, 1, 1, 1);
                    break;
                case "Priest":
                    characterList[characterIndex].transform.Find("CharacterImage").GetComponent<Image>().sprite
                        = Resources.Load<Sprite>(Resource.PriestIcon) as Sprite;
                    characterList[characterIndex].transform.Find("CharacterImage").GetComponent<Image>().color
                        = new Color(1, 1, 1, 1);
                    break;
                default:
                    Debug.Log("Error : Class is " + characterData[characterIndex].cls);
                    break;
            }
            if (characterList[characterIndex].GetComponent<TooltipManager>() == null)
                characterList[characterIndex].AddComponent<TooltipManager>();
            characterList[characterIndex].GetComponent<TooltipManager>()
                .SetCharacter(characterData[characterIndex], IconType.Character);

            characterList[characterIndex].AddComponent<Button>().onClick.AddListener(() =>{
                SelectDropCharacter(i);
            });
            //dropCharacterConfirm.onClick.RemoveAllListeners();
            //dropCharacterConfirm.onClick.AddListener(() =>{
            //    OnClickDropCharacterConfirm(i);
            //});
        }
    }

    private void SelectDropCharacter(int index)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        selectedCharacterIndex = index;
        switch (characterData[index].cls)
        {
            case "Thief":
                txtDropCharacter.text = "도적";
                break;
            case "Archer":
                txtDropCharacter.text = "궁수";
                break;
            case "Mage":
                txtDropCharacter.text = "마법사";
                break;
            case "Knight":
                txtDropCharacter.text = "기사";
                break;
            case "Priest":
                txtDropCharacter.text = "사제";
                break;
            default:
                Debug.Log("Error : Class is " + characterData[index].cls);
                break;
        }
        SetDropCharacterSelected(index);
        dropCharacterConfirm.interactable = true;
    }

    private void SetDropCharacterSelected(int index)
    {
        for(int i=0; i<10; i++)
        {
            characterList[i].transform.Find("SelectedFlag").GetComponent<Image>().color
                = new Color(0, 0, 0, 0);
        }
        characterList[index].transform.Find("SelectedFlag").GetComponent<Image>().color
            = new Color(1, 0, 0, 0.5f);
    }

    private void ShowGetCharacter()
    {
        Utility.ObjectVisibility(panelGetCharacter, true);
    }

    private void SetPrisoner(int flag)
    {
        switch (flag)
        {
            case 0:
                prisonerDropCharacter.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.ThiefIcon);
                prisonerGetCharacter.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.ThiefIcon);
                prisonerLackOfKey.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.ThiefIcon);
                txtGetCharacter.text = "도적";
                txtLackOfKey.text = "도적";
                prisoner = DataChar.getThief();
                break;
            case 1:
                prisonerDropCharacter.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.ArcherIcon);
                prisonerGetCharacter.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.ArcherIcon);
                prisonerLackOfKey.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.ArcherIcon);
                txtGetCharacter.text = "궁수";
                txtLackOfKey.text = "궁수";
                prisoner = DataChar.getArcher();
                break;
            case 2:
                prisonerDropCharacter.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.MageIcon);
                prisonerGetCharacter.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.MageIcon);
                prisonerLackOfKey.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.MageIcon);
                txtGetCharacter.text = "마법사";
                txtLackOfKey.text = "마법사";
                prisoner = DataChar.getMage();
                break;
            case 3:
                prisonerDropCharacter.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.KnightIcon);
                prisonerGetCharacter.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.KnightIcon);
                prisonerLackOfKey.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.KnightIcon);
                txtGetCharacter.text = "기사";
                txtLackOfKey.text = "기사";
                prisoner = DataChar.getKnight();
                break;
            case 4:
                prisonerDropCharacter.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.PriestIcon);
                prisonerGetCharacter.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.PriestIcon);
                prisonerLackOfKey.transform.Find("Icon").GetComponent<Image>().sprite
                    = Resources.Load<Sprite>(Resource.PriestIcon);
                txtGetCharacter.text = "사제";
                txtLackOfKey.text = "사제";
                prisoner = DataChar.getPriest();
                break;
        }
    }

    private void ShowLackOfKey()
    {
        Utility.ObjectVisibility(panelLackofKey, true);
    }

    public void OnClickLackOfKeyConfirm()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        PlayerPrefsX.SetBool(PrefsEntity.ForceTerminateInJail, false);
        Utility.ObjectVisibility(jailPanel, false);
        Utility.ObjectVisibility(panelDropCharacter, false);
        Utility.ObjectVisibility(panelGetCharacter, false);
        Utility.ObjectVisibility(panelLackofKey, false);
    }

    public void OnClickGetCharacterCancel()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        PlayerPrefsX.SetBool(PrefsEntity.ForceTerminateInJail, false);
        Utility.ObjectVisibility(jailPanel, false);
        Utility.ObjectVisibility(panelDropCharacter, false);
        Utility.ObjectVisibility(panelGetCharacter, false);
        Utility.ObjectVisibility(panelLackofKey, false);
    }

    public void OnClickGetCharacterConfirm()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Debug.Log(gameManager.NumOfCharacter());
        if(gameManager.NumOfCharacter() == 10)
        {
            ShowDropCharacter();
        }
        else
        {
            gameManager.PlaySound(SoundFilePath.UseKey);
            gameManager.UseKey(1);
            gameManager.AddCharacter(prisoner);
            RemoveJailEvent();
        }
    }

    public void OnClickDropCharacterConfirm()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        //List<DataChar> DCList = GameManager.GetInstatnce().GetCharacterList();
        int[,] myPosition = gameManager.GetFormation();
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (myPosition[i, j] > selectedCharacterIndex) myPosition[i, j]--;
                else if (myPosition[i, j] == selectedCharacterIndex) myPosition[i, j] = -1;
        gameManager.SetFormation(myPosition);

        characterData.RemoveAt(selectedCharacterIndex);
        gameManager.UpdateCharacterList(characterData);
        gameManager.PlaySound(SoundFilePath.UseKey);
        gameManager.AddCharacter(prisoner);
        RemoveJailEvent();
    }

    public void OnClickDropCharacterCancel()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        PlayerPrefsX.SetBool(PrefsEntity.ForceTerminateInJail, false);
        Utility.ObjectVisibility(jailPanel, false);
        Utility.ObjectVisibility(panelDropCharacter, false);
        Utility.ObjectVisibility(panelGetCharacter, false);
        Utility.ObjectVisibility(panelLackofKey, false);
    }


    private void RemoveJailEvent()
    {
        PlayerPrefsX.SetBool(PrefsEntity.ForceTerminateInJail, false);
        PlayerPrefs.SetInt(PrefsEntity.OccurJailPrisoner, -1);
        Utility.ObjectVisibility(jailPanel, false);
        Utility.ObjectVisibility(panelDropCharacter, false);
        Utility.ObjectVisibility(panelGetCharacter, false);
        Utility.ObjectVisibility(panelLackofKey, false);
        eventController.GetComponent<EventController>().JailEventEnd();
    }

    public void OnClickConfirm()
    {
        PlayerPrefsX.SetBool(PrefsEntity.ForceTerminateInJail, false);
        PlayerPrefs.SetInt(PrefsEntity.OccurJailPrisoner, -1);
        Utility.ObjectVisibility(jailPanel, false);
        Utility.ObjectVisibility(panelDropCharacter, false);
        Utility.ObjectVisibility(panelGetCharacter, false);
        Utility.ObjectVisibility(panelLackofKey, false);
    }
}
