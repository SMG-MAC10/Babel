using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DigitalRuby.SoundManagerNamespace;

public class HamburgerController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject hamburgerPanel;
    public GameObject inventoryPanel;
    public GameObject controlBlocker;
    public GameObject helpPaenl;
    public GameObject titlePanel;

    private bool hamburgerOnOff = false;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstatnce();
        Utility.ObjectVisibility(hamburgerPanel, hamburgerOnOff);
    }

    public void OnClickHamburger()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        hamburgerOnOff = !hamburgerOnOff;
        Utility.ObjectVisibility(hamburgerPanel, hamburgerOnOff);
    }

    public void OnClickTitle()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        titlePanel.GetComponent<TitleController>().PanelActivate();
    }

    public void OnClickOption()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        SceneManager.LoadScene("Option", LoadSceneMode.Additive);
    }

    public void OnClickInventory()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        PlayerPrefs.SetInt(PrefsEntity.InformationFlag, 0);
        UpperTabController.SetFlag(0);
        Utility.ObjectVisibility(inventoryPanel, true);
        Utility.ObjectVisibility(controlBlocker, true);
        //SceneManager.LoadScene("Information", LoadSceneMode.Additive);

    }

    public void OnClickFormation()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        PlayerPrefs.SetInt(PrefsEntity.InformationFlag, 5);
        UpperTabController.SetFlag(5);
        Utility.ObjectVisibility(inventoryPanel, true);
        Utility.ObjectVisibility(controlBlocker, true);
        //SceneManager.LoadScene("Information", LoadSceneMode.Additive);

    }

    public void OnClickHelp()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        helpPaenl.GetComponent<HelpController>().PanelActivete();

    }
}
