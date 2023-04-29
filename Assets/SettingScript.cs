using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    public GameController GC;
    public GameObject panelSetting;
    public Button buttonPlus, buttonMinus, buttonV;

    [Header ("Text")]
    public Text textPersonnel;
    public Text textGood, textEvil, tMeril, tPercival, tMorgana, tOberon, tMordred;

    private int pers = 5;
    private int vers = 0;
    private Color blue = new Color32(147, 147, 207, 255);
    private Color blue_t = new Color32(147, 147, 207, 50);
    private Color red = new Color32(207, 114, 114, 255);
    private Color red_t = new Color32(207, 114, 114, 50);

    private void Update()
    {
        buttonMinus.interactable = (pers > 5);
        buttonPlus.interactable = (pers < 10);
        buttonV.interactable = (6 <= pers && pers <= 8 || pers == 10);

        textPersonnel.text = "檣錳 : " + pers;
        PersonnelSetting(pers, vers);
    }

    public void ButtonPlus()
    {
        pers += 1;
        vers = 0;
    }

    public void ButtonMinus()
    {
        pers -= 1;
        vers = 0;
    }

    public void ButtonV()
    {
        vers += 1;
        if (vers > 3)
            vers = 0;
    }

    public void ButtonGameStart()
    {
        panelSetting.SetActive(false);
        GC.GetIdentity(pers, vers);
    }

    private void PersonnelSetting(int p, int v)
    {
        if (p == 5)
        {
            textGood.text = "摹 : " + 3;
            textEvil.text = "學 : " + 2;

            tPercival.color = blue_t;
            tMorgana.color = red_t;
            tOberon.color = red_t;
            tMordred.color = red_t;
        }
        else if (p == 6)
        {
            textGood.text = "摹 : " + 4;
            textEvil.text = "學 : " + 2;

            tPercival.color = blue;
            tMorgana.color = (v % 2 == 0) ? red : red_t;
            tOberon.color = red_t;
            tMordred.color = (v % 2 == 0) ? red_t : red;
        }
        else if (p == 7)
        {
            textGood.text = "摹 : " + 4;
            textEvil.text = "學 : " + 3;

            tPercival.color = (v == 3)? blue_t : blue;
            tMorgana.color = (v == 3) ? red_t : red;
            tOberon.color = (v == 1)? red : red_t;
            tMordred.color = (v == 2) ? red : red_t;
        }
        else if (p == 8)
        {
            textGood.text = "摹 : " + 5;
            textEvil.text = "學 : " + 3;

            tPercival.color = (v == 3) ? blue_t : blue;
            tMorgana.color = (v == 3) ? red_t : red;
            tOberon.color = (v == 1) ? red : red_t;
            tMordred.color = (v == 2) ? red : red_t;
        }
        else if (p == 9)
        {
            textGood.text = "摹 : " + 6;
            textEvil.text = "學 : " + 3;

            tPercival.color = blue;
            tMorgana.color = red;
            tOberon.color = red_t;
            tMordred.color = red;
        }
        else
        {
            textGood.text = "摹 : " + 6;
            textEvil.text = "學 : " + 4;

            tPercival.color = blue;
            tMorgana.color = red;
            tOberon.color = (v % 2 == 0) ? red : red_t;
            tMordred.color = red;
        }
    }
}
