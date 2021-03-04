using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum IconType : int
{
    Equipment = 0,
    Skill = 1,
    Character = 2
}

public class TooltipManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public int index;
    public GameObject test;
    private GameObject frame;
    private Equip equip;
    private Skill skill;
    private bool btnDown = false;
    private float durationThreshold = 0.7f;
    private float timePressStarted;
    private bool longPressTriger = false;
    private IconType iconType;
    private DataChar character;

    private string cls;
    private SKILLTYPE skillType;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            frame = transform.parent.Find("Frame").gameObject;
            frame.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
        }
        catch (System.NullReferenceException e)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (btnDown && !longPressTriger)
        {
            if(Time.time - timePressStarted > durationThreshold)
            {
                longPressTriger = true;
                if(iconType == IconType.Equipment)
                {
                    GameObject.FindGameObjectWithTag("TooltipEquipment")
                        .GetComponent<EquipmentTooltip>()
                        .Tooltip(Input.mousePosition, equip);
                }
                else if (iconType == IconType.Skill)
                {
                    GameObject.FindGameObjectWithTag("TooltipSkill")
                        .GetComponent<SkillTooltip>()
                        .Tooltip(Input.mousePosition, skill, cls, skillType);
                }
                else
                {
                    GameObject.FindGameObjectWithTag("TooltipCharacter")
                        .GetComponent<CharacterTooltip>()
                        .Tooltip(Input.mousePosition, character);
                }
                //Debug.Log(Input.mousePosition + " : " + index + " : " + equip.name);
            }
        }
    }
    
    public void SetEquip(Equip equip, int index, IconType iconType)
    {
        this.equip = equip;
        this.index = index;
        this.iconType = iconType;
    }

    public void SetSkill(Skill skill, int index, IconType iconType, string cls, SKILLTYPE skillType)
    {
        this.skill = skill;
        this.index = index;
        this.iconType = iconType;
        this.cls = cls;
        this.skillType = skillType;
    }
    
    public void SetCharacter(DataChar character, IconType iconType)
    {
        this.character = character;
        this.iconType = iconType;
    }

    public void SetCharacter()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        timePressStarted = Time.time;
        btnDown = true;
        longPressTriger = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        btnDown = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        btnDown = false;
    }

}
