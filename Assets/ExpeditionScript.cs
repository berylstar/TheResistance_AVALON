using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpeditionScript : MonoBehaviour
{
    public GameController GC;
    public Image[] circles;
    public Text[] textNeeds;
    public Text textCount, textVoteCount, textCaptin;
    public Button buttonVote;

    private int iExp = 0;

    [Header("Scroll View")]
    public GameObject[] ps;
    public Text[] textNicknames;
    public Toggle[] toggles;

    private void Awake()
    {
        for (int i = 0; i < GC.total; i++)
        {
            textNicknames[i].text = GC.nicknames[i];
            ps[i].SetActive(true);
        }
    }

    public void ButtonVote()
    {
        for (int i = 0; i < GC.total; i++)
        {
            if (toggles[i].isOn)
                print(i);
        }
    }
}
