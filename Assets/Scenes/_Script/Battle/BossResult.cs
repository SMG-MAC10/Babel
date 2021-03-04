using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


public class BossResult : MonoBehaviour
{
    // Start is called before the first frame update
    int maxItem;

    int selectedItem;
    Text t;
    itemButton[] buttons;
    Button b;
    BattleManager BM;

    void Start()
    {
        selectedItem = 0;
        buttons = new itemButton[7];
        BM = GameObject.Find("BattleManager").GetComponent<BattleManager>();

        switch (PlayerPrefs.GetInt(PrefsEntity.CurrentFloor)/20) {
            case 4:
                maxItem = 3;
                break;
            case 3:
                maxItem = 4;
                break;
            case 2:
                maxItem = 5;
                break;
            case 1:
                maxItem = 6;
                break;
            case 0:
                maxItem = 8;
                break;
        }
        for (int i= 0; i< 7; i++) {
            GameObject tmp = this.transform.GetChild(i).gameObject;
            buttons[i] = new itemButton(tmp.transform.GetChild(1).GetComponent<Button>(), tmp.transform.GetChild(2).GetComponent<Button>(), tmp.transform.GetChild(0).GetComponent<Text>());
            buttons[i].setText();
        }

        t = this.transform.GetChild(7).GetComponent<Text>();
        b = this.transform.GetChild(8).GetComponent<Button>();
        t.text = maxItem + "개를 선택할 수 있음";

        b.onClick.AddListener(delegate() { onButton(); });
        buttons[0].up.onClick.AddListener(delegate () { buttons[0].num++; buttons[0].setText(); selectedItem++; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });
        buttons[0].down.onClick.AddListener(delegate () { buttons[0].num--; buttons[0].setText(); selectedItem--; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });

        buttons[1].up.onClick.AddListener(delegate () { buttons[1].num++; buttons[1].setText(); selectedItem++; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });
        buttons[1].down.onClick.AddListener(delegate () { buttons[1].num--; buttons[1].setText(); selectedItem--; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });

        buttons[2].up.onClick.AddListener(delegate () { buttons[2].num++; buttons[2].setText(); selectedItem++; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });
        buttons[2].down.onClick.AddListener(delegate () { buttons[2].num--; buttons[2].setText(); selectedItem--; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });

        buttons[3].up.onClick.AddListener(delegate () { buttons[3].num++; buttons[3].setText(); selectedItem++; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });
        buttons[3].down.onClick.AddListener(delegate () { buttons[3].num--; buttons[3].setText(); selectedItem--; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });

        buttons[4].up.onClick.AddListener(delegate () { buttons[4].num++; buttons[4].setText(); selectedItem++; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });
        buttons[4].down.onClick.AddListener(delegate () { buttons[4].num--; buttons[4].setText(); selectedItem--; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });

        buttons[5].up.onClick.AddListener(delegate () { buttons[5].num++; buttons[5].setText(); selectedItem++; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });
        buttons[5].down.onClick.AddListener(delegate () { buttons[5].num--; buttons[5].setText(); selectedItem--; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });

        buttons[6].up.onClick.AddListener(delegate () { buttons[6].num++; buttons[6].setText(); selectedItem++; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });
        buttons[6].down.onClick.AddListener(delegate () { buttons[6].num--; buttons[6].setText(); selectedItem--; t.text = maxItem - selectedItem + "개를 선택할 수 있음"; });
    }

    void onButton()
    {
        int i = 0;
        //장비
        for (i = 0; i < buttons[0].num; i++) {
            GameManager.GetInstatnce().AddEquipment(EquipManager.GetRandomEquip());
        }

        //분해
        for (i = 0; i < buttons[1].num; i++)
        {
            PlayerPrefs.SetInt(PrefsEntity.DecomposeScroll, PlayerPrefs.GetInt(PrefsEntity.DecomposeScroll) + 5);
        }

        //강화
        for (i = 0; i < buttons[2].num; i++)
        {
            PlayerPrefs.SetInt(PrefsEntity.EquipmentUpgradeScroll, PlayerPrefs.GetInt(PrefsEntity.EquipmentUpgradeScroll) + 3);
        }

        //스킬
        for (i = 0; i < buttons[3].num; i++)
        {
            PlayerPrefs.SetInt(PrefsEntity.SkillUpgradeScroll, PlayerPrefs.GetInt(PrefsEntity.SkillUpgradeScroll) + 5);
        }

        //능력치
        int[] k = new int[4];
        for (i = 0; i < buttons[4].num; i++)
        {
            float r = Random.value;
            if ( r <= 0.25f ) {
                k[0]++;
            } 
            else if ( r <= 0.5f )
            {
                k[1]++;
            } 
            else if ( r <= 0.75f )
            {
                k[2]++;
            }
            else
            {
                k[3]++;
            }
        }
        PlayerPrefs.SetInt(PrefsEntity.StatusUpgradeScrollOne, PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollOne) + k[0]);
        PlayerPrefs.SetInt(PrefsEntity.StatusUpgradeScrollThree, PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollThree) + k[1]);
        PlayerPrefs.SetInt(PrefsEntity.StatusUpgradeScrollFive, PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollFive) + k[2]);
        PlayerPrefs.SetInt(PrefsEntity.StatusUpgradeScrollChaos, PlayerPrefs.GetInt(PrefsEntity.StatusUpgradeScrollChaos) + k[3]);

        //체력
        foreach (BattleChar bc in BM.myBC)
        {
            bc.SetHP(bc.getHP() * (1 + 0.2f * buttons[5].num));
            bc.setMP(bc.getMP() * (1 + 0.2f * buttons[5].num));
        }


        for (i = 0; i < buttons[6].num; i++)
        {
            float r = Random.value;
            if (r <= 0.2f)
            {
                GameManager.GetInstatnce().AddCharacter(DataChar.getArcher());
            }
            else if (r <= 0.4f)
            {
                GameManager.GetInstatnce().AddCharacter(DataChar.getKnight());
            }
            else if (r <= 0.6f)
            {
                GameManager.GetInstatnce().AddCharacter(DataChar.getMage());
            }
            else if (r <= 0.8f)
            {
                GameManager.GetInstatnce().AddCharacter(DataChar.getPriest());
            }
            else
            {
                GameManager.GetInstatnce().AddCharacter(DataChar.getThief());
            }
        }

        GameManager.GetInstatnce().Save();
        LoadingManager.LoadScene("Field");

    }

    // Update is called once per frame
    void Update()
    {

        foreach (itemButton i in buttons)
        {
            i.up.interactable = true;
            i.down.interactable = true;

            if(selectedItem >= maxItem)  i.up.interactable = false;
            if(i.num <= 0) i.down.interactable = false;
        }

    }
}

class itemButton{
    public Button up;
    public Button down;
    Text t;
    public int num;
    public itemButton(Button up, Button down, Text t) {
        num = 0;
        this.up = up;
        this.down = down;
        this.t = t;

    }

    public void setText() {
        t.text = num.ToString();
    }
}
