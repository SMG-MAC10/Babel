using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextFloorRequest : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject requestNextFloorPanel;
    public GameObject controlBlocker;

    void Start()
    {
        gameManager = GameManager.GetInstatnce();
    }
    public void OnClickConfirm()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        int currentFloor = PlayerPrefs.GetInt(PrefsEntity.CurrentFloor, 100);
        PlayerPrefsX.SetBool(PrefsEntity.SaveFlag, false);
        if(PlayerPrefs.GetInt(PrefsEntity.CurrentFloor) == 1)
        {
            LoadingManager.LoadSceneEnding();
        }
        PlayerPrefs.SetInt(PrefsEntity.CurrentFloor, --currentFloor);
        LoadingManager.LoadSceneFieldToField();
    }

    public void OnClickCancel()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(controlBlocker, false);
        Utility.ObjectVisibility(requestNextFloorPanel, false);
    }
}
