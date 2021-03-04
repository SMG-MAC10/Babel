using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject targetPanel;

    public GameObject page0;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    public GameObject page6;
    public GameObject page7;
    public GameObject page8;
    public GameObject page9;
    public GameObject page10;
    public GameObject page11;
    public GameObject page12;
    public GameObject page13;
    public GameObject page14;
    public GameObject page15;
    public GameObject page16;
    public GameObject page17;
    public GameObject page18;

    private List<GameObject> pageList;

    private int pageNumber;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstatnce();
        pageList = new List<GameObject>();
        pageList.Add(page0);
        pageList.Add(page1);
        pageList.Add(page2);
        pageList.Add(page3);
        pageList.Add(page4);
        pageList.Add(page5);
        pageList.Add(page6);
        pageList.Add(page7);
        pageList.Add(page8);
        pageList.Add(page9);
        pageList.Add(page10);
        pageList.Add(page11);
        pageList.Add(page12);
        pageList.Add(page13);
        pageList.Add(page14);
        pageList.Add(page15);
        pageList.Add(page16);
        pageList.Add(page17);
        pageList.Add(page18);
        pageNumber = 0;
        ShowPage();
        OnClickExit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PanelActivete()
    {
        pageNumber = 0;
        ShowPage();
        Utility.ObjectVisibility(targetPanel, true);

    }

    private void ShowPage()
    {
        for(int i=0; i<pageList.Count; i++)
        {
            pageList[i].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        pageList[pageNumber].GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    public void OnClickExit()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        Utility.ObjectVisibility(targetPanel, false);
    }

    public void OnClickForward()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (pageNumber < 18)
        {
            pageNumber++;
        }
        ShowPage();
    }

    public void OnClickBackward()
    {
        gameManager.PlaySound(SoundFilePath.ButtonTab);
        if (pageNumber > 0)
        {
            pageNumber--;
        }
        ShowPage();
    }
}
