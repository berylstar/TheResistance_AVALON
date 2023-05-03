using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdentityScript : MonoBehaviour
{
    public GameController GC;
    public GameObject panelIdentity;
    public Text textNickname, textExtra;
    public Button buttonIdentity, buttonNext;

    private bool isClick = false;
    private bool isChecked = false;
    private int idx = 0;

    private void Update()
    {
        if (isClick)
        {
            textNickname.text = GC.players[idx];
            ExtraInfo(GC.players[idx]);
        }
        else
        {
            textNickname.text = GC.nicknames[idx];
            textExtra.gameObject.SetActive(false);
        }

        buttonNext.interactable = isChecked;
    }

    public void PointerDown()
    {
        isClick = true;
    }

    public void PointerUp()
    {
        isClick = false;
        isChecked = true;
    }

    public void ButtonNext()
    {
        idx += 1;

        if (idx == GC.total)
            panelIdentity.SetActive(false);
    }

    public void ExtraInfo(string iden)
    {
        string strr = "";

        if (iden == "멀린")
        {
            bool isMordred = false;

            strr = "<악의 진영>\n";
            for (int i = 0; i < GC.total; i++)
            {
                if (GC.players[i] == "하수인" || GC.players[i] == "모르가나" || GC.players[i] == "오베론")
                {
                    strr += "\"" + GC.nicknames[i] + "\"\n";
                }

                if (GC.players[i] == "모드레드")
                    isMordred = true;
            }

            if (isMordred)
                strr += "\"???\"\n";
        }
        else if (iden == "퍼시벌")
        {
            strr = "<멀린 ??>\n";
            for (int i = 0; i < GC.total; i++)
            {
                if (GC.players[i] == "멀린" || GC.players[i] == "모르가나")
                {
                    strr += "\"" + GC.nicknames[i] + "\"\n";
                }
            }
        }
        else if (iden == "기사")
        {

        }
        else if (iden == "모르가나")
        {
            bool isOberon = false;

            strr = "<악의 진영>\n";
            for (int i = 0; i < GC.total; i++)
            {
                if (GC.players[i] == "하수인" || GC.players[i] == "모르가나" || GC.players[i] == "모드레드")
                {
                    strr += "\"" + GC.nicknames[i] + "\"\n";
                }
                else if (GC.players[i] == "오베론")
                {
                    isOberon = true;
                }
            }

            if (isOberon)
            {
                strr += "\"???\"\n";
            }
        }
        else if (iden == "오베론")
        {
            strr = "<악의 진영>\n";
            for (int i = 0; i < GC.total; i++)
            {
                if (GC.players[i] == "하수인" || GC.players[i] == "모르가나" || GC.players[i] == "모드레드")
                {
                    strr += "\"???\"\n";
                }
            }

        }
        else if (iden == "모드레드")
        {
            bool isOberon = false;

            strr = "<악의 진영>\n";
            for (int i = 0; i < GC.total; i++)
            {
                if (GC.players[i] == "하수인" || GC.players[i] == "모르가나" || GC.players[i] == "모드레드")
                {
                    strr += "\"" + GC.nicknames[i] + "\"\n";
                }
                else if (GC.players[i] == "오베론")
                {
                    isOberon = true;
                }
            }

            if (isOberon)
            {
                strr += "\"???\"";
            }
        }
        else if (iden == "하수인")
        {
            bool isOberon = false;

            strr = "<악의 진영>\n";
            for (int i = 0; i < GC.total; i++)
            {
                if (GC.players[i] == "하수인" || GC.players[i] == "모르가나" || GC.players[i] == "모드레드")
                {
                    strr += "\"" + GC.nicknames[i] + "\"\n";
                }
                else if (GC.players[i] == "오베론")
                {
                    isOberon = true;
                }
            }

            if (isOberon)
            {
                strr += "\"???\"";
            }
        }
        else
        {

        }

        textExtra.gameObject.SetActive(true);
        textExtra.text = strr;
    }
}
