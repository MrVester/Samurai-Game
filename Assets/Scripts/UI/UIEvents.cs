using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public static UIEvents current;
    void Awake()
    {
        current = this;
    }

    public event Action onGameStop;
    public void GameStop()
    {
        if(onGameStop != null)
            onGameStop();
    }
    public event Action onGameStart;
    public void GameStart()
    {
        if (onGameStart != null)
            onGameStart();
    }
    public event Action onPlayStart;
    public void PlayStart()
    {
        if (onPlayStart != null)
            onPlayStart();
    }
}
