using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DashButton : MonoBehaviour
{

    public UnityEvent OnPressed;
    Button _dashButton;
    Image _dashButtonImage;

    void Start()
    {
        _dashButton = GetComponent<Button>();
        _dashButton.onClick.AddListener(() => DashButtonRelease());
        _dashButtonImage = GetComponent<Image>();
        _dashButtonImage.fillAmount = 1f;
        _dashButtonImage.type = Image.Type.Filled;
        _dashButtonImage.fillMethod = Image.FillMethod.Radial360;
        _dashButtonImage.fillOrigin = 2;

    }



    void DashButtonRelease()
    {
        _dashButton.interactable = false;
        OnPressed.Invoke();
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
