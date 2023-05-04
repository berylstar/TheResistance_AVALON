using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoteScript : MonoBehaviour
{
    public GameController GC;
    public ExpeditionScript ES;
    public GameObject panelExpedition, panelVote;
    public Text textNickname;
    public Button buttonNext;

    private int index = 0;
    private int textIndex = 0;
    private int iFail = 0;

    public void VoteReset()
    {
        index = 0;
        textIndex = 0;
        iFail = 0;
        TextNicknameSet();
    }

    public void ButtonSuccess()
    {
        buttonNext.interactable = true;
    }

    public void ButtonFail()
    {
        iFail += 1;
        buttonNext.interactable = true;
    }

    public void ButtonNext()
    {
        index += 1;
        TextNicknameSet();

        if (index == GC.needs[GC.iRound])
        {
            panelExpedition.SetActive(true);
            panelVote.SetActive(false);
            ES.NextExpedition(iFail);
        }
    }

    private void TextNicknameSet()
    {
        for (int i = textIndex; i < GC.total; i++)
        {
            if(ES.toggles[i].isOn)
            {
                textNickname.text = GC.nicknames[i];
                textIndex = i+1;
                return;
            }
        }
    }
}
