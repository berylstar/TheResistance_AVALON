using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 10 : 기사
// 11 : 멀린
// 12 : 퍼시벌
// 20 : 하수인
// 21 : 모르가나
// 22 : 오베론
// 23 : 모드레드

public class GameController : MonoBehaviour
{
    [Header ("Identity")]
    public int total = 0;
    public int isGood = 0;
    public bool isMerlin = false;
    public bool isPercival = false;
    public int isEvil = 0;
    public bool isMorgana = false;
    public bool isOberon = false;
    public bool isMordred = false;

    [Header ("Game System")]
    public string[] players = { "", "", "", "", "", "", "", "", "", "" };
    public string[] nicknames = { "", "", "", "", "", "", "", "", "", "" };
    public int[] needs = { 0, 0, 0, 0, 0 };

    public int iCaptin = 0;
    public int iRound = 0;
    public int iBreakdown = 0;

    private void IdentityShuffle()
    {
        int[] idx = new int[total];

        for (int i = 0; i < idx.Length; i++)
        {
            idx[i] = i;
        }

        for (int i = 0; i < idx.Length; i++)
        {
            int temp = idx[i];
            int randomIndex = Random.Range(0, idx.Length);
            idx[i] = idx[randomIndex];
            idx[randomIndex] = temp;
        }

        players[idx[0]] = "멀린";

        if (isPercival)
            players[idx[1]] = "퍼시벌";
        if (isMorgana)
            players[idx[2]] = "모르가나";
        if (isOberon)
            players[idx[3]] = "오베론";
        if (isMordred)
            players[idx[4]] = "모드레드";

        int cnt = 0;

        for (int i = 0; i < idx.Length; i++)
        {
            if (players[idx[i]] == "" && cnt < isGood)
            {
                players[idx[i]] = "기사";
                cnt += 1;
            }
            else if (players[idx[i]] == "")
                players[idx[i]] = "하수인";
        }
    }

    public void GetIdentity(int pers, int ver)
    {
        isMerlin = true;
        total = pers;

        if (pers == 5)
        {
            isGood = 2;
            isEvil = 2;
        }
        else if (pers == 6)
        {
            isGood = 2;
            isPercival = true;
            isEvil = 1;
            isMorgana = (ver % 2 == 0) ? true : false;
            isMordred = (ver % 2 == 0) ? false : true;
        }
        else if (pers == 7)
        {
            isGood = (ver == 3) ? 3 : 2;
            isPercival = (ver == 3) ? false : true;

            if (ver == 0)
                isEvil = 2;
            else if (ver == 1 || ver == 2)
                isEvil = 1;
            else
                isEvil = 3;

            isMorgana = (ver == 3) ? false : true;
            isOberon = (ver == 1) ? true : false;
            isMordred = (ver == 2) ? true : false;
        }
        else if (pers == 8)
        {
            isGood = (ver == 3) ? 4 : 3;
            isPercival = (ver == 3) ? false : true;

            if (ver == 0)
                isEvil = 2;
            else if (ver == 1 || ver == 2)
                isEvil = 1;
            else
                isEvil = 3;

            isMorgana = (ver == 3) ? false : true;
            isOberon = (ver == 1) ? true : false;
            isMordred = (ver == 2) ? true : false;
        }
        else if (pers == 9)
        {
            isGood = 4;
            isPercival = true;
            isEvil = 1;
            isMorgana = true;
            isOberon = false;
            isMordred = true;
        }
        else
        {
            isGood = 4;
            isPercival = true;
            isEvil = (ver % 2 == 0) ? 1 : 2;
            isMorgana = true;
            isOberon = (ver % 2 == 0) ? true : false;
            isMordred = true;
        }

        IdentityShuffle();
        ExpeditionNeed();
    }

    public void ExpeditionNeed()
    {
        if (total == 5)
        {
            needs[0] = 2;
            needs[1] = 3;
            needs[2] = 2;
            needs[3] = 3;
            needs[4] = 3;
        }
        else if (total == 6)
        {
            needs[0] = 2;
            needs[1] = 3;
            needs[2] = 4;
            needs[3] = 3;
            needs[4] = 4;
        }
        else if (total == 7)
        {
            needs[0] = 2;
            needs[1] = 3;
            needs[2] = 3;
            needs[3] = 4;
            needs[4] = 4;
        }
        else if (total == 8 || total == 9 || total == 10)
        {
            needs[0] = 3;
            needs[1] = 4;
            needs[2] = 4;
            needs[3] = 5;
            needs[4] = 5;
        }
    }
}
