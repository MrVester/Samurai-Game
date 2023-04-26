using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DashButton : MonoBehaviour
{

    public UnityEvent OnPressed;
    public float dashCoolDown = 2f;
    Button _dashButton = null;
    Image _dashButtonImage = null;

    void Start()
    {
        _dashButton = GetComponent<Button>();
        _dashButton.onClick.AddListener(() => DashButtonRelease());
        _dashButtonImage = GetComponent<Image>();
        _dashButtonImage.fillAmount = 1f;
    }



    void DashButtonRelease()
    {
        _dashButton.interactable = false;
        OnPressed.Invoke();
        StartCoroutine(DashCoroutine());
        

    }
    IEnumerator DashCoroutine()
    {
        float startTime = Time.time;
        float dashTimer = Time.time + dashCoolDown;
        _dashButtonImage.fillAmount = 0f;
        while (Time.time <= dashTimer)
        {
            _dashButtonImage.fillAmount += 1.0f / dashCoolDown * Time.deltaTime;


            yield return null;
        }
        _dashButtonImage.fillAmount = 1.0f;
        _dashButton.interactable = true;

    }


}
