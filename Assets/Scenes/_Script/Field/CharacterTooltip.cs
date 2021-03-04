using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterTooltip : MonoBehaviour, IPointerClickHandler
{
    public GameObject tooltipPanel;
    public GameObject tooltip;
    public GameObject panelEquipment;
    public GameObject panelSkillAndStatus;

    //Equipment Panel
    public Image characterImage;
    public GameObject equipHead;
    public GameObject equipBody;
    public GameObject equipFoot;
    public GameObject equipWeapon;
    public GameObject equipSubweapon;

    //Skill and Status Panel
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

    // Start is called before the first frame update
    void Start()
    {
        Utility.ObjectVisibility(tooltipPanel, false);
        characterSkillSet.Add(selectedSkill0);
        characterSkillSet.Add(selectedSkill1);
        characterSkillSet.Add(selectedSkill2);
        characterSkillSet.Add(selectedSkill3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tooltip(Vector3 position, DataChar character)
    {
        //Set Position
        tooltip.transform.localPosition = position +
            new Vector3(-960.0f, -540.0f, 0) +
            new Vector3(-355.0f, -222.5f, 0);
        if (tooltip.transform.localPosition.y < -540 + 222.5)
        {
            tooltip.transform.localPosition =
                new Vector3(tooltip.transform.localPosition.x, -540 + 222.5f, tooltip.transform.localPosition.z);
        }
        if (tooltip.transform.localPosition.x < -960 + 355.0)
        {
            tooltip.transform.localPosition =
                new Vector3(-960 + 355.0f, tooltip.transform.localPosition.y, tooltip.transform.localPosition.z);
        }

        SetCharacterSkillAndStatus(character);
        SetCharacterEquipment(character);
        Utility.ObjectVisibility(tooltipPanel, true);

    }

    public void SetCharacterSkillAndStatus(DataChar character)
    {
        hp.text = "HP  :  " + character.curHP + " / " + character.getMaxHP();
        mp.text = "MP  :  " + character.curMP + " / " + character.getMaxMP();
        phyAtk.text = "무력  :  " + character.getPhyATK();
        phyDef.text = "근성  :  " + character.getPhyDEF();
        magAtk.text = "마력  :  " + character.getMgcATK();
        magDef.text = "의지  :  " + character.getMgcDEF();
        critical.text = "치명타  :  " + character.critical * 100 + "%";
        speed.text = "속력  :  " + character.getSPD();

        for (int i = 0; i < 4; i++)
        {
            int skillNumber = i;
            characterSkillSet[skillNumber].transform.Find("SkillIcon").GetComponent<Image>().sprite
                = Resources.Load<Sprite>(character.charSkillSet.set[skillNumber].image);
            characterSkillSet[skillNumber].transform.Find("SkillIcon").GetComponent<Image>().color
                = new Color(1, 1, 1, 1);
            if (characterSkillSet[skillNumber].GetComponent<TooltipManager>() == null)
            {
                characterSkillSet[skillNumber].AddComponent<TooltipManager>();
            }
            characterSkillSet[skillNumber].GetComponent<TooltipManager>().SetSkill(
                character.charSkillSet.set[skillNumber], skillNumber, IconType.Skill,
                character.cls, character.charSkillSet.set[skillNumber].type);
        }

        switch (character.cls)
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
                Debug.Log("Error : Class is " + character.cls);
                break;
        }
    }

    public void SetCharacterEquipment(DataChar character)
    {
        equipHead.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(character.charEquipSet.set[0].img) as Sprite;
        equipHead.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        if (equipHead.gameObject.GetComponent<TooltipManager>() == null)
            equipHead.gameObject.AddComponent<TooltipManager>();
        equipHead.gameObject
            .GetComponent<TooltipManager>()
            .SetEquip(character.charEquipSet.set[0], 0, IconType.Equipment);

        equipBody.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(character.charEquipSet.set[1].img) as Sprite;
        equipBody.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        if (equipBody.gameObject.GetComponent<TooltipManager>() == null)
            equipBody.gameObject.AddComponent<TooltipManager>();
        equipBody.gameObject
            .GetComponent<TooltipManager>()
            .SetEquip(character.charEquipSet.set[1], 1, IconType.Equipment);

        equipFoot.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(character.charEquipSet.set[2].img) as Sprite;
        equipFoot.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        if (equipFoot.gameObject.GetComponent<TooltipManager>() == null)
            equipFoot.gameObject.AddComponent<TooltipManager>();
        equipFoot.gameObject
            .GetComponent<TooltipManager>()
            .SetEquip(character.charEquipSet.set[2], 2, IconType.Equipment);

        equipWeapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(character.charEquipSet.set[3].img) as Sprite;
        equipWeapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        if (equipWeapon.gameObject.GetComponent<TooltipManager>() == null)
            equipWeapon.gameObject.AddComponent<TooltipManager>();
        equipWeapon.gameObject
            .GetComponent<TooltipManager>()
            .SetEquip(character.charEquipSet.set[3], 3, IconType.Equipment);

        equipSubweapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(character.charEquipSet.set[4].img) as Sprite;
        equipSubweapon.transform.Find("ItemImage").gameObject.GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        if (equipSubweapon.gameObject.GetComponent<TooltipManager>() == null)
            equipSubweapon.gameObject.AddComponent<TooltipManager>();
        equipSubweapon.gameObject
            .GetComponent<TooltipManager>()
            .SetEquip(character.charEquipSet.set[4], 4, IconType.Equipment);

    }

    public void OnClickSwapToEquipment()
    {
        Utility.ObjectVisibility(panelEquipment, true);
        Utility.ObjectVisibility(panelSkillAndStatus, false);
    }

    public void OnClickSwapToSkillAndStatus()
    {
        Utility.ObjectVisibility(panelEquipment, false);
        Utility.ObjectVisibility(panelSkillAndStatus, true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Utility.ObjectVisibility(tooltipPanel, false);
    }
}
