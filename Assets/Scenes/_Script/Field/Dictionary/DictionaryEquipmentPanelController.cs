using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryEquipmentPanelController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject targetPanel;
    public GameObject equipIcon;
    public Text equipName;
    public Text equipGrade;
    public Text equipRequire;
    public Text hp;
    public Text mp;
    public Text ap;
    public Text phyAtk;
    public Text phyDef;
    public Text magAtk;
    public Text magDef;
    public Text critical;
    public Text healEf;

    public GameObject equipGrade0;
    public GameObject equipGrade1;
    public GameObject equipGrade2;
    public GameObject equipGrade3;

    private int equipLevel;
    private Equip selectedEquip;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstatnce();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PanelActivation()
    {
        hp.text = "HP : ";
        mp.text = "MP : ";
        phyAtk.text = "무력 : ";
        phyDef.text = "근성 : ";
        magAtk.text = "마력 : ";
        magDef.text = "의지 : ";
        critical.text = "치명타 : ";
        healEf.text = "회복효율 : ";
        ap.text = "행동력 : ";
        equipName.text = "";
        equipGrade.text = "";
        equipRequire.text = "";
        equipIcon.transform.Find("EquipIcon").GetComponent<Image>().color
            = new Color(0, 0, 0, 0);
        equipGrade0.transform.Find("EquipIcon").GetComponent<Image>().color
            = new Color(0, 0, 0, 0);
        equipGrade1.transform.Find("EquipIcon").GetComponent<Image>().color
            = new Color(0, 0, 0, 0);
        equipGrade2.transform.Find("EquipIcon").GetComponent<Image>().color
            = new Color(0, 0, 0, 0);
        equipGrade3.transform.Find("EquipIcon").GetComponent<Image>().color
            = new Color(0, 0, 0, 0);
        equipLevel = 0;
        Utility.ObjectVisibility(targetPanel, true);
    }

    public void PanelDeactivation()
    {
        Utility.ObjectVisibility(targetPanel, false);
    }

    public void OnClickEquipment(string classAndParts)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        //classAndParts = "nm" (n, m = 0 ~ 4 Number)
        //classAndParts[0] = n, Class
        //classAndParts[1] = m, Parts
        //n : 0 = Thief, 1 = Archer, 2 = Mage, 3 = Knight, 4 = Priest;
        //m : 0 = Head, 1 = Body, 2 = Foot, 3 = Weapon, 4 = Subweapon
        EquipClass equipClass = EquipClass.Thief;
        EquipType equipType = EquipType.Body;
        switch (classAndParts[0])
        {
            case '0':
                equipClass = EquipClass.Thief;
                break;
            case '1':
                equipClass = EquipClass.Archer;
                break;
            case '2':
                equipClass = EquipClass.Mage;
                break;
            case '3':
                equipClass = EquipClass.Knight;
                break;
            case '4':
                equipClass = EquipClass.Priest;
                break;
        }
        switch (classAndParts[1])
        {
            case '0':
                equipType = EquipType.Head;
                break;
            case '1':
                equipType = EquipType.Body;
                break;
            case '2':
                equipType = EquipType.Foot;
                break;
            case '3':
                equipType = EquipType.Weapon;
                break;
            case '4':
                if(equipClass == EquipClass.Thief)
                {
                    equipType = EquipType.Weapon;
                }
                else
                {
                    equipType = EquipType.SubWeapon;
                }
                break;
        }

        EquipmentSetting(equipClass, equipType);
    }

    private void EquipmentSetting(EquipClass equipClass, EquipType equipType)
    {
        //Equipment/Thief/Head/thiefNormalHead
        //EquipURL : Equipment/{Class}/{Parts(Type)}/{class}{Grade}{Parts(Type)}
        string equipURL = "Equipment";
        string equipClassLower = "";
        string equipClassUpper = "";
        string equipParts = "";
        switch (equipClass)
        {
            case EquipClass.Thief:
                equipClassUpper = "Thief";
                equipClassLower = "thief";
                break;
            case EquipClass.Archer:
                equipClassUpper = "Archer";
                equipClassLower = "archer";
                break;
            case EquipClass.Mage:
                equipClassUpper = "Mage";
                equipClassLower = "mage";
                break;
            case EquipClass.Knight:
                equipClassUpper = "Knight";
                equipClassLower = "knight";
                break;
            case EquipClass.Priest:
                equipClassUpper = "Priest";
                equipClassLower = "priest";
                break;
        }
        switch (equipType)
        {
            case EquipType.Head:
                equipParts = "Head";
                break;
            case EquipType.Body:
                equipParts = "Body";
                break;
            case EquipType.Foot:
                equipParts = "Foot";
                break;
            case EquipType.Weapon:
                equipParts = "Weapon";
                break;
            case EquipType.SubWeapon:
                equipParts = "Subweapon";
                break;
        }

        Equip equipNormal = EquipManager.GetEquip(
            equipURL + "/" + equipClassUpper + "/" + equipParts + "/" + equipClassLower + "Normal" + equipParts, 0);
        Equip equipRare = EquipManager.GetEquip(
            equipURL + "/" + equipClassUpper + "/" + equipParts + "/" + equipClassLower + "Rare" + equipParts, 0);
        Equip equipUnique = EquipManager.GetEquip(
            equipURL + "/" + equipClassUpper + "/" + equipParts + "/" + equipClassLower + "Unique" + equipParts, 0);
        Equip equipMystic = EquipManager.GetEquip(
            equipURL + "/" + equipClassUpper + "/" + equipParts + "/" + equipClassLower + "Mystic" + equipParts, 0);

        equipGrade0.transform.Find("EquipIcon").GetComponent<Image>().sprite
            = Resources.Load<Sprite>(equipNormal.img);
        equipGrade0.transform.Find("EquipIcon").GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        equipGrade0.GetComponent<Button>().onClick.RemoveAllListeners();
        equipGrade0.GetComponent<Button>().onClick.AddListener(()=>{
            selectedEquip = equipNormal;
            equipLevel = 0;
            OnClickSelectedEquipment(equipNormal);
        });

        equipGrade1.transform.Find("EquipIcon").GetComponent<Image>().sprite
            = Resources.Load<Sprite>(equipRare.img);
        equipGrade1.transform.Find("EquipIcon").GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        equipGrade1.GetComponent<Button>().onClick.RemoveAllListeners();
        equipGrade1.GetComponent<Button>().onClick.AddListener(() => {
            selectedEquip = equipRare;
            equipLevel = 0;
            OnClickSelectedEquipment(equipRare);
        });

        equipGrade2.transform.Find("EquipIcon").GetComponent<Image>().sprite
            = Resources.Load<Sprite>(equipUnique.img);
        equipGrade2.transform.Find("EquipIcon").GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        equipGrade2.GetComponent<Button>().onClick.RemoveAllListeners();
        equipGrade2.GetComponent<Button>().onClick.AddListener(() => {
            selectedEquip = equipUnique;
            equipLevel = 0;
            OnClickSelectedEquipment(equipUnique);
        });

        equipGrade3.transform.Find("EquipIcon").GetComponent<Image>().sprite
            = Resources.Load<Sprite>(equipMystic.img);
        equipGrade3.transform.Find("EquipIcon").GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        equipGrade3.GetComponent<Button>().onClick.RemoveAllListeners();
        equipGrade3.GetComponent<Button>().onClick.AddListener(() => {
            selectedEquip = equipMystic;
            equipLevel = 0;
            OnClickSelectedEquipment(equipMystic);
        });

    }

    private void OnClickSelectedEquipment(Equip equip)
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        equipIcon.transform.Find("EquipIcon").GetComponent<Image>().color
            = new Color(1, 1, 1, 1);
        equipIcon.transform.Find("EquipIcon").GetComponent<Image>().sprite
            = Resources.Load<Sprite>(equip.img);
        equipName.text = "+" + equip.level + " " + equip.name;
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
        equipGrade.text = "(" + grade + " 아이템)";
        equipGrade.color = gradeColor;
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
        equipRequire.text = equipType + "/" + equipReq + " 착용 가능";
        hp.text = "HP : " + equip.maxHP;
        mp.text = "MP : " + equip.maxMP;
        ap.text = "행동력 : " + equip.speed;
        phyAtk.text = "무력 : " + equip.phyATK;
        phyDef.text = "근성 : " + equip.phyDEF;
        magAtk.text = "마력 : " + equip.macATK;
        magDef.text = "의지 : " + equip.macDEF;
        critical.text = "치명타 : " + equip.critical + "%";
        healEf.text = "회복효율 : " + equip.healEFC + "%";
    }

    public void OnClickEquipLevelUp()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (equipLevel < 20)
        {
            equipLevel++;
            selectedEquip = EquipManager.GetEquipNextLevel(selectedEquip);
        }
        OnClickSelectedEquipment(selectedEquip);
    }

    public void OnClickEquipLevelDown()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (equipLevel > 0)
        {
            equipLevel--;
            selectedEquip = EquipManager.GetEquipLowerLevel(selectedEquip);
        }
        OnClickSelectedEquipment(selectedEquip);
    }
}
