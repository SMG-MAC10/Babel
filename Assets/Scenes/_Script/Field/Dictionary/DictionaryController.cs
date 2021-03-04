using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject dictionaryPanel;
    public GameObject controlBlocker;
    public GameObject panelMonster;
    public GameObject panelEquipment;
    public GameObject panelSkill;

    public GameObject monsterPanelController;
    public GameObject equipmentPanelController;
    public GameObject skillPanelController;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstatnce();
        Utility.ObjectVisibility(dictionaryPanel, false);
        OnClickMonster();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickDictionaryOpen()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(controlBlocker, true);
        Utility.ObjectVisibility(dictionaryPanel, true);
    }
    public void OnClickDictionaryClose()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        skillPanelController.GetComponent<DictionarySkillPanelController>().PanelDeactivation();
        equipmentPanelController.GetComponent<DictionaryEquipmentPanelController>().PanelDeactivation();
        monsterPanelController.GetComponent<DictionaryMonsterPanelController>().PanelDeactivation();
        Utility.ObjectVisibility(controlBlocker, false);
        Utility.ObjectVisibility(dictionaryPanel, false);
    }

    public void OnClickMonster()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        skillPanelController.GetComponent<DictionarySkillPanelController>().PanelDeactivation();
        equipmentPanelController.GetComponent<DictionaryEquipmentPanelController>().PanelDeactivation();
        monsterPanelController.GetComponent<DictionaryMonsterPanelController>().PanelActivation();
    }

    public void OnClickSkill()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        skillPanelController.GetComponent<DictionarySkillPanelController>().PanelActivation();
        equipmentPanelController.GetComponent<DictionaryEquipmentPanelController>().PanelDeactivation();
        monsterPanelController.GetComponent<DictionaryMonsterPanelController>().PanelDeactivation();
    }
    public void OnClickEquipment()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        skillPanelController.GetComponent<DictionarySkillPanelController>().PanelDeactivation();
        equipmentPanelController.GetComponent<DictionaryEquipmentPanelController>().PanelActivation();
        monsterPanelController.GetComponent<DictionaryMonsterPanelController>().PanelDeactivation();
    }
}
