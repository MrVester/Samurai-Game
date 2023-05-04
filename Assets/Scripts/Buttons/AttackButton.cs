using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class AttackButton : MonoBehaviour
{
    public UnityEvent OnPressed;
    private Button _attackButton;
    private Weapon _weapon;
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
        _weapon = GameObject.FindWithTag("Player").GetComponent<PlayerWeaponController>().Weapon;
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
        OnPressed.Invoke();
        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        float attackTimer = Time.time + _weapon.AttackInterval;
        _attackButtonImage.fillAmount = 0f;
        while (Time.time <= attackTimer)
        {
            _attackButtonImage.fillAmount += 1.0f / _weapon.AttackInterval * Time.deltaTime;


            yield return null;
        }
        _attackButtonImage.fillAmount = 1.0f;
        Status = false;
        _attackButton.interactable = true;

    }
}
