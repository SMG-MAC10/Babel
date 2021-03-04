using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    public GameObject page0;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;

    private List<GameObject> pageList;

    private int pageNumber;
    // Start is called before the first frame update
    void Start()
    {
        pageList = new List<GameObject>();
        pageList.Add(page0);
        pageList.Add(page1);
        pageList.Add(page2);
        pageList.Add(page3);
        pageList.Add(page4);
        pageNumber = 0;
        ShowPage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowPage()
    {
        for (int i = 0; i < pageList.Count; i++)
        {
            Utility.ObjectVisibility(pageList[i], false);
        }
        Utility.ObjectVisibility(pageList[pageNumber], true);
    }
    public void OnClickReturnToMainMenu()
    {
        LoadingManager.LoadSceneMainMenuInEnding();
    }

    public void OnClickForward()
    {
        if (pageNumber < 4)
        {
            pageNumber++;
        }
        ShowPage();
    }

    public void OnClickBackward()
    {
        if (pageNumber > 0)
        {
            pageNumber--;
        }
        ShowPage();
    }
}
