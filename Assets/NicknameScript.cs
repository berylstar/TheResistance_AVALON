using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NicknameScript : MonoBehaviour
{
    public GameController GC;
    public InputField[] inputs;
    public Button buttonReady;

    private bool isReady = false;

    private void Start()
    {
        for (int i = 0; i < GC.total; i++)
        {
            inputs[i].interactable = true;
        }
    }

    private void Update()
    {
        isReady = true;

        for (int i = 0; i < GC.total; i++)
        {
            if (inputs[i].text == "")
                isReady = false;
        }

        if (isReady)
            buttonReady.interactable = true;
    }

    public void ButtonReady()
    {
        for (int i = 0; i < GC.total; i++)
        {
            GC.nicknames[i] = inputs[i].text;
        }
    }
}
