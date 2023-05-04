using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpeditionScript : MonoBehaviour
{
    public GameController GC;
    public Image[] circles;
    public GameObject[] rounds;
    public Text[] textNeeds;
    public Text textBreakdown, textCaptin, textTwoFail;
    public Button buttonBreakdown, buttonVote;

    private Color colorFail = new Color32(255, 0, 0, 100);
    private Color colorSuccess = new Color32(0, 0, 255, 100);
    private Color colorBreakdown = new Color32(210, 196, 142, 255);

    [Header("Scroll View")]
    public GameObject[] ps;
    public Text[] textNicknames;
    public Toggle[] toggles;

    private void Awake()    // 처음에 한 번
    {
        for (int i = 0; i < GC.total; i++)
        {
            textNicknames[i].text = GC.nicknames[i];
            ps[i].SetActive(true);
        }

        for (int i = 0; i < 5; i++)
        {
            textNeeds[i].text = GC.needs[i].ToString();
        }

        rounds[0].SetActive(true);

        if (GC.total >= 7)
            textTwoFail.gameObject.SetActive(true);

        GC.iCaptin = Random.Range(0, GC.total);
        textCaptin.text = "원정대장: " + GC.nicknames[GC.iCaptin];
    }

    private void Update()
    {
        buttonVote.interactable = CheckExpeditionNeed();
    }

    public bool CheckExpeditionNeed()
    {
        int k = 0;

        for (int i = 0; i < GC.total; i++)
        {
            if (toggles[i].isOn)
                k += 1;
        }

        if (GC.needs[GC.iRound] == k)
            return true;
        else
            return false;
    }

    public void BreakdownPlus()
    {
        GC.iBreakdown += 1;
        textBreakdown.text = GC.iBreakdown.ToString();

        if (GC.iBreakdown == 4)
        {
            buttonBreakdown.image.color = colorFail;
        }
        else if (GC.iBreakdown > 4)
        {
            // 악의 진영 승리
            GC.EvilWin();
        }

        ChangeCaptin();
    }

    public void BreakDownReset()
    {
        GC.iBreakdown = 0;
        textBreakdown.text = 0.ToString();
        buttonBreakdown.image.color = colorBreakdown;
    }

    public void NextExpedition(int iFail)
    {
        if (!CheckSuccess(iFail))
            GC.failCount += 1;

        if (GC.CheckGameOver())
        {
            // 게임 오버 처리
        }
        else
        {
            for (int i = 0; i < GC.total; i++)
            {
                toggles[i].isOn = false;
            }

            textNeeds[GC.iRound].text = (GC.needs[GC.iRound] - iFail) + "/" + iFail;
            circles[GC.iRound].color = CheckSuccess(iFail) ? colorSuccess : colorFail;
            rounds[GC.iRound].SetActive(false);
            ChangeCaptin();
            BreakDownReset();

            GC.iRound += 1;

            rounds[GC.iRound].SetActive(true);
        }
    }

    private bool CheckSuccess(int iFail)
    {
        if (iFail > 0)
        {
            if (GC.iRound == 3 && GC.total >= 7)
                return (iFail == 1);
            else
                return false;
        }

        return true;
    }

    public void ChangeCaptin()
    {
        GC.iCaptin += 1;

        if (GC.iCaptin == GC.total)
            GC.iCaptin = 0;

        textCaptin.text = "원정대장: " + GC.nicknames[GC.iCaptin];
    }
}
