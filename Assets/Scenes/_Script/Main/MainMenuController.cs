using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private GameManager gameManager;
    public Button btnContinue;
    public GameObject startPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstatnce();
        Utility.ObjectVisibility(startPanel, false);
        if (!PlayerPrefsX.GetBool(PrefsEntity.SaveFlag, false))
        {
            btnContinue.interactable = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickStart()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        //No saved data
        if (PlayerPrefsX.GetBool(PrefsEntity.SaveFlag, false))
        {
            Utility.ObjectVisibility(startPanel, true);
        }
        else
        {
            Debug.Log("BtnClick : Start");
            PlayerPrefs.DeleteAll();
            GameManager.GetInstatnce().DataReset();
            SceneManager.LoadScene("SelectLevel");
        }
    }
    public void OnClickContinue()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Debug.Log("BtnClick : Continue");
        LoadingManager.LoadSceneContinue();
        GameManager.GetInstatnce();
        //TODO
    }
    public void OnClickOption()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Debug.Log("BtnClick : Option");
        SceneManager.LoadScene("Option", LoadSceneMode.Additive);
    }
    public void OnClickExit()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Debug.Log("BtnClick : Exit");
        Application.Quit();
    }
    public void OnClickReStartCancel()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(startPanel, false);
    }
    public void OnClickReStartConfirm()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Debug.Log("BtnClick : Start");
        PlayerPrefs.DeleteAll();
        GameManager.GetInstatnce().DataReset();
        SceneManager.LoadScene("SelectLevel");
    }
}
