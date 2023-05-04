using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    Button _pauseButton;
    void Start()
    {
        _pauseButton = GetComponent<Button>();
        _pauseButton.onClick.AddListener(() => PauseButtonRelease());
        UIEvents.current.onPlayStart += ButtonEnable;
        UIEvents.current.onGameStop += ButtonDisable;
    }

    private void ButtonDisable()
    {
        _pauseButton.interactable = false;
    }

    private void ButtonEnable()
    {
        _pauseButton.interactable = true;
    }

    private void PauseButtonRelease()
    {
        UIEvents.current.GameStop();
    }

}
