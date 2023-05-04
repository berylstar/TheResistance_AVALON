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

    private int voteIndex = 0;
    private int textIndex = 0;
    private int nowVoter = 0;
    private int iFail = 0;

    public void VoteReset()
    {
        voteIndex = 0;
        textIndex = 0;
        nowVoter = 0;
        iFail = 0;
        TextNicknameSetting();
    }

    public void ButtonSuccess()
    {
        buttonNext.interactable = true;
    }

    public void ButtonFail()
    {
        //if (GC.players[nowVoter] == "하수인" || GC.players[nowVoter] == "모르가나" || GC.players[nowVoter] == "오베론" || GC.players[nowVoter] == "모드레드")
        if(GC.IsEvil(nowVoter))
            iFail += 1;

        buttonNext.interactable = true;
    }

    public void ButtonNext()
    {
        voteIndex += 1;
        TextNicknameSetting();
        buttonNext.interactable = false;

        if (voteIndex == GC.needs[GC.iRound])
        {
            panelExpedition.SetActive(true);
            panelVote.SetActive(false);
            ES.NextExpedition(iFail);
        }
    }

    private void TextNicknameSetting()
    {
        for (int i = textIndex; i < GC.total; i++)
        {
            if(ES.toggles[i].isOn)
            {
                textNickname.text = GC.nicknames[i];
                nowVoter = i;
                textIndex = i+1;
                return;
            }
        }
    }
}
