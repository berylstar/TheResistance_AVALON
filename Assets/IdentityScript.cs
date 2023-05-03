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

        if (iden == "�ָ�")
        {
            bool isMordred = false;

            strr = "<���� ����>\n";
            for (int i = 0; i < GC.total; i++)
            {
                if (GC.players[i] == "�ϼ���" || GC.players[i] == "�𸣰���" || GC.players[i] == "������")
                {
                    strr += "\"" + GC.nicknames[i] + "\"\n";
                }

                if (GC.players[i] == "��巹��")
                    isMordred = true;
            }

            if (isMordred)
                strr += "\"???\"\n";
        }
        else if (iden == "�۽ù�")
        {
            strr = "<�ָ� ??>\n";
            for (int i = 0; i < GC.total; i++)
            {
                if (GC.players[i] == "�ָ�" || GC.players[i] == "�𸣰���")
                {
                    strr += "\"" + GC.nicknames[i] + "\"\n";
                }
            }
        }
        else if (iden == "���")
        {

        }
        else if (iden == "�𸣰���")
        {
            bool isOberon = false;

            strr = "<���� ����>\n";
            for (int i = 0; i < GC.total; i++)
            {
                if (GC.players[i] == "�ϼ���" || GC.players[i] == "�𸣰���" || GC.players[i] == "��巹��")
                {
                    strr += "\"" + GC.nicknames[i] + "\"\n";
                }
                else if (GC.players[i] == "������")
                {
                    isOberon = true;
                }
            }

            if (isOberon)
            {
                strr += "\"???\"\n";
            }
        }
        else if (iden == "������")
        {
            strr = "<���� ����>\n";
            for (int i = 0; i < GC.total; i++)
            {
                if (GC.players[i] == "�ϼ���" || GC.players[i] == "�𸣰���" || GC.players[i] == "��巹��")
                {
                    strr += "\"???\"\n";
                }
            }

        }
        else if (iden == "��巹��")
        {
            bool isOberon = false;

            strr = "<���� ����>\n";
            for (int i = 0; i < GC.total; i++)
            {
                if (GC.players[i] == "�ϼ���" || GC.players[i] == "�𸣰���" || GC.players[i] == "��巹��")
                {
                    strr += "\"" + GC.nicknames[i] + "\"\n";
                }
                else if (GC.players[i] == "������")
                {
                    isOberon = true;
                }
            }

            if (isOberon)
            {
                strr += "\"???\"";
            }
        }
        else if (iden == "�ϼ���")
        {
            bool isOberon = false;

            strr = "<���� ����>\n";
            for (int i = 0; i < GC.total; i++)
            {
                if (GC.players[i] == "�ϼ���" || GC.players[i] == "�𸣰���" || GC.players[i] == "��巹��")
                {
                    strr += "\"" + GC.nicknames[i] + "\"\n";
                }
                else if (GC.players[i] == "������")
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
