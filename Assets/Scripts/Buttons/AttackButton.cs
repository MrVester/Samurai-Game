using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class AttackButton : MonoBehaviour
{
    public UnityEvent OnPressed;
    private Button _attackButton;
    public bool Status = false;
    Image _attackButtonImage;
    bool _buttonState;

    void Start()
    {
        _attackButton = GetComponent<Button>();
        _attackButton.onClick.AddListener(() => AttackButtonRelease());
        _attackButtonImage = GetComponent<Image>();
        _attackButtonImage.fillAmount = 1f;
        _attackButtonImage.type = Image.Type.Filled;
        _attackButtonImage.fillMethod = Image.FillMethod.Radial360;
        _attackButtonImage.fillOrigin = 2;
        // get current weapon attack interval

        UIEvents.current.onPlayStart += ButtonEnable;
        UIEvents.current.onGameStop += ButtonDisable;
    }

    private void ButtonDisable()
    {
        _buttonState = _attackButton.interactable;
        _attackButton.interactable = false;
    }

    private void ButtonEnable()
    {
        _attackButton.interactable = _buttonState;
    }

    void AttackButtonRelease()
    {
        _attackButton.interactable = false;
        Status = true;
        CharacterEvents.current.Attack();
        StartCoroutine(AttackCoroutine());

    }

    IEnumerator AttackCoroutine()
    {
        float attackTimer = Time.time + CharacterParameters.AttackCoolDown;
        _attackButtonImage.fillAmount = 0f;

        while (Time.time <= attackTimer)
        {
            _attackButtonImage.fillAmount += 1.0f / CharacterParameters.AttackCoolDown * Time.deltaTime;


            yield return null;
        }
        _attackButtonImage.fillAmount = 1.0f;
        Status = false;
        _attackButton.interactable = true;

    }
}
