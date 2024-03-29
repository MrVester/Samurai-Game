using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DashButton : MonoBehaviour
{

    Button _dashButton;
    Image _dashButtonImage;
    bool _buttonState;
    void Start()
    {
        _dashButton = GetComponent<Button>();
        _dashButton.onClick.AddListener(() => DashButtonRelease());
        _dashButtonImage = GetComponent<Image>();
        _dashButtonImage.fillAmount = 1f;
        _dashButtonImage.type = Image.Type.Filled;
        _dashButtonImage.fillMethod = Image.FillMethod.Radial360;
        _dashButtonImage.fillOrigin = 2;
        UIEvents.current.onPlayStart += ButtonEnable;
        UIEvents.current.onGameStop += ButtonDisable;
        CharacterEvents.current.onDeath += ButtonDisable;
    }

    private void ButtonDisable()
    {
        _buttonState = _dashButton.interactable;
        _dashButton.interactable = false;
    }

    private void ButtonEnable()
    {
        _dashButton.interactable = _buttonState;
    }




    void DashButtonRelease()
    {
        _dashButton.interactable = false;
        CharacterEvents.current.Dash();
        StartCoroutine(DashCoroutine());


    }
    IEnumerator DashCoroutine()
    {
        float dashTimer = Time.time + CharacterParameters.DashCoolDown;
        _dashButtonImage.fillAmount = 0f;
        while (Time.time <= dashTimer)
        {
            _dashButtonImage.fillAmount += 1.0f / CharacterParameters.DashCoolDown * Time.deltaTime;


            yield return null;
        }
        _dashButtonImage.fillAmount = 1.0f;
        _dashButton.interactable = true;

    }


}
