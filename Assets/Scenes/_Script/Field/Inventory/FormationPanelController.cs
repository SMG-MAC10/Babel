﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormationPanelController : MonoBehaviour
{
    private GameManager gameManager;
    private List<DataChar> characterData;

    public GameObject characterListParent;
    public GameObject[] characterList;
    public GameObject characterIconPrefab;
    public GameObject formation00;
    public GameObject formation01;
    public GameObject formation02;
    public GameObject formation10;
    public GameObject formation11;
    public GameObject formation12;
    public GameObject formation20;
    public GameObject formation21;
    public GameObject formation22;
    public GameObject panelSkillInfo;
    public GameObject panelEquipInfo;
    public GameObject panelDeploy;
    public GameObject panelMessage;
    public Text noticeMessage;
    public GameObject btnUndeploy;

    public Text hp;
    public Text mp;
    public Text phyAtk;
    public Text phyDef;
    public Text magAtk;
    public Text magDef;
    public Text critical;
    public Text speed;
    public GameObject selectedSkill0;
    public GameObject selectedSkill1;
    public GameObject selectedSkill2;
    public GameObject selectedSkill3;
    public List<GameObject> characterSkillSet;

    public Image characterImage;
    public GameObject equipHead;
    public GameObject equipBody;
    public GameObject equipFoot;
    public GameObject equipWeapon;
    public GameObject equipSubweapon;

    public GameObject formationChangeNotice;
    private bool foramtionSetFlag;
    private Color originColor;
    private float flicker;
    private float flicker2;

    private int changeStandbyCharacter;
    private int[,] newFormation;
    private int deployCharacterCount;
    private string selectedCharacterIndex;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstatnce();
        characterList = new GameObject[10];

        characterSkillSet.Add(selectedSkill0);
        characterSkillSet.Add(selectedSkill1);
        characterSkillSet.Add(selectedSkill2);
        characterSkillSet.Add(selectedSkill3);

        newFormation = (int[,])gameManager.GetFormation().Clone();
        //ForamtionPanelUpdate();
        originColor = new Color(0.79f,0.68f,0.6f,0);
        deployCharacterCount = 0;
        Utility.ObjectVisibility(panelMessage, false);
        Utility.ObjectVisibility(btnUndeploy, false);
        Utility.ObjectVisibility(formationChangeNotice, false);
        StartCoroutine(PanelSwapObserver());
    }

    IEnumerator PanelSwapObserver()
    {
        while (true)
        {
            int flag = PlayerPrefs.GetInt(PrefsEntity.InformationFlag, -1);
            //Debug.Log(flag);
            if (flag == 5)
            {
                ForamtionPanelUpdate();
                PlayerPrefs.SetInt(PrefsEntity.InformationFlag, -1);
            }
            //if (flag != startFlag)
            //{
            //    SetPanelActivate(flag);
            //}
            yield return null;
        }
    }

    IEnumerator SelectFormationFlicker()
    {
        Utility.ObjectVisibility(formationChangeNotice, true);
        while (foramtionSetFlag)
        {
            flicker = Mathf.Abs(Mathf.Sin(Time.time * 3)) - 0.4f;
            flicker2 = Mathf.Abs(Mathf.Sin(Time.time * 3)) + 0.3f;
            formation00.transform.Find("FlickEffect").GetComponent<Image>().color = originColor + new Color(0,0,0, flicker);
            formation01.transform.Find("FlickEffect").GetComponent<Image>().color = originColor + new Color(0, 0, 0, flicker);
            formation02.transform.Find("FlickEffect").GetComponent<Image>().color = originColor + new Color(0, 0, 0, flicker);
            formation10.transform.Find("FlickEffect").GetComponent<Image>().color = originColor + new Color(0, 0, 0, flicker);
            formation11.transform.Find("FlickEffect").GetComponent<Image>().color = originColor + new Color(0, 0, 0, flicker);
            formation12.transform.Find("FlickEffect").GetComponent<Image>().color = originColor + new Color(0, 0, 0, flicker);
            formation20.transform.Find("FlickEffect").GetComponent<Image>().color = originColor + new Color(0, 0, 0, flicker);
            formation21.transform.Find("FlickEffect").GetComponent<Image>().color = originColor + new Color(0, 0, 0, flicker);
            formation22.transform.Find("FlickEffect").GetComponent<Image>().color = originColor + new Color(0, 0, 0, flicker);
            formationChangeNotice.GetComponent<Image>().color = new Color(1,1,1,1) * flicker2;
            formationChangeNotice.transform.Find("Image").GetComponent<Image>().color = new Color(1, 1, 1, 1) * flicker2;
            formationChangeNotice.transform.Find("Text").GetComponent<Text>().color = new Color(1, 1, 1, 1) * flicker2;
            yield return null;
        }
        FlickSetOriginal();
    }

    private void FlickSetOriginal()
    {
        formationChangeNotice.GetComponent<Image>().color = originColor;
        formationChangeNotice.transform.Find("Image").GetComponent<Image>().color = originColor;
        formationChangeNotice.transform.Find("Text").GetComponent<Text>().color = originColor;
        Utility.ObjectVisibility(formationChangeNotice, false);
        formation00.transform.Find("FlickEffect").GetComponent<Image>().color = originColor;
        formation01.transform.Find("FlickEffect").GetComponent<Image>().color = originColor;
        formation02.transform.Find("FlickEffect").GetComponent<Image>().color = originColor;
        formation10.transform.Find("FlickEffect").GetComponent<Image>().color = originColor;
        formation11.transform.Find("FlickEffect").GetComponent<Image>().color = originColor;
        formation12.transform.Find("FlickEffect").GetComponent<Image>().color = originColor;
        formation20.transform.Find("FlickEffect").GetComponent<Image>().color = originColor;
        formation21.transform.Find("FlickEffect").GetComponent<Image>().color = originColor;
        formation22.transform.Find("FlickEffect").GetComponent<Image>().color = originColor;
        changeStandbyCharacter = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ForamtionPanelUpdate()
    {
        foreach (Transform child in characterListParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        newFormation = (int[,])gameManager.GetFormation().Clone();
        characterData = gameManager.GetCharacterList();
        int characterIndex;

        for(characterIndex = 0; characterIndex<characterData.Count; characterIndex++)
        {
            int i = characterIndex;
            characterList[characterIndex] = Instantiate(characterIconPrefab, characterListParent.transform);

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
            characterList[characterIndex].AddComponent<Button>()
                .onClick.AddListener(() =>
               {
                   OnClickCharacterIcon(i);
               });
        }

        for (int i = characterIndex; i<10; i++)
        {
            characterList[characterIndex] = Instantiate(characterIconPrefab, characterListParent.transform);
        }
        
        hp.text = "";
        mp.text = "";
        phyAtk.text = "";
        phyDef.text = "";
        magAtk.text = "";
        magDef.text = "";
        critical.text = "";
        speed.text = "";

        for (int i = 0; i < 4; i++)
        {
            characterSkillSet[i].transform.Find("SkillIcon").GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        characterImage.color = new Color(0, 0, 0, 0);
        SwapInformationToSkill();
        Utility.ObjectVisibility(panelDeploy, false);

        changeStandbyCharacter = -1;
        foramtionSetFlag = false;
        PrintFormation(newFormation);
    }

    private void PrintFormation(int[,] formation)
    {
        deployCharacterCount = 0;
        if (formation[0, 0] != -1)
        {
            //Debug.Log("00" + characterData[formation[0, 0]].cls);
            formation00.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(Resource.GetClassImage(characterData[formation[0, 0]].cls));
            formation00.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(1, 1, 1, 1);
            deployCharacterCount++;
        }
        else
        {
            formation00.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = null;
            formation00.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(0,0,0,0);
        }
        if (formation[0, 1] != -1)
        {
            //Debug.Log("01" + characterData[formation[0, 1]].cls);
            formation01.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(Resource.GetClassImage(characterData[formation[0, 1]].cls));
            formation01.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(1, 1, 1, 1);
            deployCharacterCount++;
        }
        else
        {
            formation01.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = null;
            formation01.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(0, 0, 0, 0);
        }
        if (formation[0, 2] != -1)
        {
            //Debug.Log("02" + characterData[formation[0, 2]].cls);
            formation02.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(Resource.GetClassImage(characterData[formation[0, 2]].cls));
            formation02.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(1, 1, 1, 1);
            deployCharacterCount++;
        }
        else
        {
            formation02.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = null;
            formation02.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(0, 0, 0, 0);
        }
        if (formation[1, 0] != -1)
        {
            //Debug.Log("10" + characterData[formation[1, 0]].cls);
            formation10.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(Resource.GetClassImage(characterData[formation[1, 0]].cls));
            formation10.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(1, 1, 1, 1);
            deployCharacterCount++;
        }
        else
        {
            formation10.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = null;
            formation10.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(0, 0, 0, 0);
        }
        if (formation[1, 1] != -1)
        {
            //Debug.Log("11" + characterData[formation[1, 1]].cls);
            formation11.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(Resource.GetClassImage(characterData[formation[1, 1]].cls));
            formation11.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(1, 1, 1, 1);
            deployCharacterCount++;
        }
        else
        {
            formation11.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = null;
            formation11.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(0, 0, 0, 0);
        }
        if (formation[1, 2] != -1)
        {
            //Debug.Log("12" + characterData[formation[1, 2]].cls);
            formation12.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(Resource.GetClassImage(characterData[formation[1, 2]].cls));
            formation12.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(1, 1, 1, 1);
            deployCharacterCount++;
        }
        else
        {
            formation12.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = null;
            formation12.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(0, 0, 0, 0);
        }
        if (formation[2, 0] != -1)
        {
            //Debug.Log("20" + characterData[formation[2, 0]].cls);
            formation20.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(Resource.GetClassImage(characterData[formation[2, 0]].cls));
            formation20.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(1, 1, 1, 1);
            deployCharacterCount++;
        }
        else
        {
            formation20.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = null;
            formation20.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(0, 0, 0, 0);
        }
        if (formation[2, 1] != -1)
        {
            //Debug.Log("21" + characterData[formation[2, 1]].cls);
            formation21.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(Resource.GetClassImage(characterData[formation[2, 1]].cls));
            formation21.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(1, 1, 1, 1);
            deployCharacterCount++;
        }
        else
        {
            formation21.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = null;
            formation21.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(0, 0, 0, 0);
        }
        if (formation[2, 2] != -1)
        {
            //Debug.Log("22" + characterData[formation[2, 2]].cls);
            formation22.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(Resource.GetClassImage(characterData[formation[2, 2]].cls));
            formation22.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(1, 1, 1, 1);
            deployCharacterCount++;
        }
        else
        {
            formation22.transform.Find("CharacterImage").GetComponent<Image>().sprite
                = null;
            formation22.transform.Find("CharacterImage").GetComponent<Image>().color
                = new Color(0, 0, 0, 0);
        }
    }
    
    public void OnClickFormation(string index)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (newFormation[int.Parse(index[0].ToString()), int.Parse(index[1].ToString())] != -1)
        {
            changeStandbyCharacter = newFormation[int.Parse(index[0].ToString()), int.Parse(index[1].ToString())];
            selectedCharacterIndex = index;
            Utility.ObjectVisibility(btnUndeploy, true);

            foramtionSetFlag = true;
            StartCoroutine(SelectFormationFlicker());
            Utility.ObjectVisibility(panelDeploy, true);
            return;
        }
        for(int i=0; i<newFormation.GetLength(0); i++)
        {
            for(int j=0; j<newFormation.GetLength(1); j++)
            {
                if(newFormation[i, j] == changeStandbyCharacter)
                {
                    newFormation[i, j] = newFormation[int.Parse(index[0].ToString()), int.Parse(index[1].ToString())];
                }
            }
        }
        if (foramtionSetFlag)
        {
            newFormation[int.Parse(index[0].ToString()), int.Parse(index[1].ToString())]
                = changeStandbyCharacter;
        }
        Utility.ObjectVisibility(btnUndeploy, false);
        PrintFormation(newFormation);
        DeployCancel();
    }

    public void OnClickFormationReset()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Debug.Log("Reset");
        newFormation = (int[,])gameManager.GetFormation().Clone();
        //int[,] temp = gameManager.GetFormation();
        //for (int i = 0; i < newFormation.GetLength(0); i++)
        //{
        //    for (int j = 0; j < newFormation.GetLength(1); j++)
        //    {
        //        Debug.Log(temp[i,j]);
        //    }
        //}
        //Debug.Log(gameManager.GetFormation());
        //Debug.Log(newFormation);
        PrintFormation(newFormation);
    }

    public void OnClickFormationConfirm()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (deployCharacterCount == 0)
        {
            noticeMessage.text = "진형이 비어있습니다.";
            Utility.ObjectVisibility(panelMessage, true);
        }
        gameManager.SetFormation(newFormation);
        newFormation = (int[,])gameManager.GetFormation().Clone();
        PrintFormation(newFormation);
    }


    public void OnClickDeploy()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (deployCharacterCount == 5)
        {
            noticeMessage.text = "더 이상 배치할 수 없습니다.";
            Utility.ObjectVisibility(panelMessage, true);
            PrintFormation(newFormation);
            return;
        }
        if (changeStandbyCharacter == -1)
        {

            return;
        }
        foramtionSetFlag = true;
        StartCoroutine(SelectFormationFlicker());
        Utility.ObjectVisibility(panelDeploy, true);
    }

    public void OnClickUndeploy()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        newFormation[int.Parse(selectedCharacterIndex[0].ToString()), int.Parse(selectedCharacterIndex[1].ToString())]
            = -1;
        Utility.ObjectVisibility(btnUndeploy, false);
        DeployCancel();
        PrintFormation(newFormation);
    }

    public void DeployCancel()
    {
        foramtionSetFlag = false;
        Utility.ObjectVisibility(panelDeploy, false);
    }

    public void OnClickRemoveMessage()
    {
        Utility.ObjectVisibility(panelMessage, false);
    }

    private void OnClickCharacterIcon(int charIndex)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        //Debug.Log("<>>" + index);
        changeStandbyCharacter = charIndex;
        hp.text = "HP  :  " + characterData[charIndex].curHP + " / " + characterData[charIndex].getMaxHP();
        mp.text = "MP  :  " + characterData[charIndex].curMP + " / " + characterData[charIndex].getMaxMP();
        phyAtk.text = "무력  :  " + characterData[charIndex].getPhyATK();
        phyDef.text = "근성  :  " + characterData[charIndex].getPhyDEF();
        magAtk.text = "마력  :  " + characterData[charIndex].getMgcATK();
        magDef.text = "의지  :  " + characterData[charIndex].getMgcDEF();
        critical.text = "치명타  :  " + characterData[charIndex].critical * 100 + "%";
        speed.text = "행동력  :  " + characterData[charIndex].getSPD();

        for (int i = 0; i < 4; i++)
        {
            int skillNumber = i;
            characterSkillSet[skillNumber].transform.Find("SkillIcon").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(characterData[charIndex].charSkillSet.set[skillNumber].image);
            characterSkillSet[skillNumber].transform.Find("SkillIcon").GetComponent<Image>().color
                = new Color(1, 1, 1, 1);
            if (characterSkillSet[skillNumber].GetComponent<TooltipManager>() == null)
            {
                characterSkillSet[skillNumber].AddComponent<TooltipManager>();
            }
            characterSkillSet[skillNumber].GetComponent<TooltipManager>().SetSkill(
                characterData[charIndex].charSkillSet.set[skillNumber], skillNumber, IconType.Skill,
                characterData[charIndex].cls, characterData[charIndex].charSkillSet.set[skillNumber].type);
        }

        switch (characterData[charIndex].cls)
        {
            case "Thief":
                characterImage.sprite = Resources.Load<Sprite>(Resource.ThiefIdle);
                characterImage.color = new Color(1, 1, 1, 1);
                break;
            case "Archer":
                characterImage.sprite = Resources.Load<Sprite>(Resource.ArcherIdle);
                characterImage.color = new Color(1, 1, 1, 1);
                break;
            case "Mage":
                characterImage.sprite = Resources.Load<Sprite>(Resource.MagicianIdle);
                characterImage.color = new Color(1, 1, 1, 1);
                break;
            case "Knight":
                characterImage.sprite = Resources.Load<Sprite>(Resource.KnightIdle);
                characterImage.color = new Color(1, 1, 1, 1);
                break;
            case "Priest":
                characterImage.sprite = Resources.Load<Sprite>(Resource.PriestIdle);
                characterImage.color = new Color(1, 1, 1, 1);
                break;
            default:
                Debug.Log("Error : Class is " + characterData[charIndex].cls);
                break;
        }
        ShowCharacterEquipment(charIndex);

    }

    private void ShowCharacterEquipment(int index)
    {
        equipHead.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(characterData[index].charEquipSet.set[0].img) as Sprite;
        equipHead.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        if (equipHead.gameObject.GetComponent<TooltipManager>() == null)
            equipHead.gameObject.AddComponent<TooltipManager>();
        equipHead.gameObject
            .GetComponent<TooltipManager>()
            .SetEquip(characterData[index].charEquipSet.set[0], index, IconType.Equipment);

        equipBody.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(characterData[index].charEquipSet.set[1].img) as Sprite;
        equipBody.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        if (equipBody.gameObject.GetComponent<TooltipManager>() == null)
            equipBody.gameObject.AddComponent<TooltipManager>();
        equipBody.gameObject
            .GetComponent<TooltipManager>()
            .SetEquip(characterData[index].charEquipSet.set[1], index, IconType.Equipment);

        equipFoot.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(characterData[index].charEquipSet.set[2].img) as Sprite;
        equipFoot.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        if (equipFoot.gameObject.GetComponent<TooltipManager>() == null)
            equipFoot.gameObject.AddComponent<TooltipManager>();
        equipFoot.gameObject
            .GetComponent<TooltipManager>()
            .SetEquip(characterData[index].charEquipSet.set[2], index, IconType.Equipment);

        equipWeapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(characterData[index].charEquipSet.set[3].img) as Sprite;
        equipWeapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        if (equipWeapon.gameObject.GetComponent<TooltipManager>() == null)
            equipWeapon.gameObject.AddComponent<TooltipManager>();
        equipWeapon.gameObject
            .GetComponent<TooltipManager>()
            .SetEquip(characterData[index].charEquipSet.set[3], index, IconType.Equipment);

        equipSubweapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(characterData[index].charEquipSet.set[4].img) as Sprite;
        equipSubweapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        if (equipSubweapon.gameObject.GetComponent<TooltipManager>() == null)
            equipSubweapon.gameObject.AddComponent<TooltipManager>();
        equipSubweapon.gameObject
            .GetComponent<TooltipManager>()
            .SetEquip(characterData[index].charEquipSet.set[4], index, IconType.Equipment);

    }

    public void SwapInformationToSkill()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(panelSkillInfo, true);
        Utility.ObjectVisibility(panelEquipInfo, false);
    }
    public void SwapInformationToEquipment()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(panelSkillInfo, false);
        Utility.ObjectVisibility(panelEquipInfo, true);
    }
}
