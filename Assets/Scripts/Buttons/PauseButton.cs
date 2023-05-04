using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    Button _pauseButton;
    bool _buttonState;
    void Start()
    {
        _pauseButton = GetComponent<Button>();
        _pauseButton.onClick.AddListener(() => PauseButtonRelease());
        UIEvents.current.onPlayStart += ButtonEnable;
        UIEvents.current.onGameStop += ButtonDisable;
    }

    private void ButtonDisable()
    {

        _buttonState = _pauseButton.interactable;
        _pauseButton.interactable = false;
    }

    private void ButtonEnable()
    {
        _pauseButton.interactable = _buttonState;
    }

    private void PauseButtonRelease()
    {
        UIEvents.current.GameStop();
    }

}
