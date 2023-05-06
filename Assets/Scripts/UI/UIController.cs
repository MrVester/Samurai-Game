using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.U2D.Path.GUIFramework;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private GameObject Controls;
    [SerializeField]
    private GameObject DeadScreen;
    [SerializeField]
    private TMP_Text returnText;
    [SerializeField]
    private Image returnImage;


    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
        Controls.SetActive(true);
        DeadScreen.SetActive(false);
        UIEvents.current.onGameStop += StopGame;
        UIEvents.current.onGameStart += StartGame;
        CharacterEvents.current.onDeath += Dead;
        returnImage.fillAmount = 0f;
        returnImage.type = Image.Type.Filled;
        returnImage.fillMethod = Image.FillMethod.Radial360;
        returnImage.fillOrigin = 2;
        returnText.text = "";
    }

    private void Dead()
    {
        Menu.SetActive(false);
        Controls.GetComponent<Canvas>().enabled = false;
        StartCoroutine(DeathScreenCoroutine());
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        Controls.GetComponent<Canvas>().enabled = false;
        Menu.SetActive(true);


    }
    private void StartGame()
    {
        Menu.SetActive(false);
        returnImage.gameObject.SetActive(true);
        StartCoroutine(ResumeGame());

    }

    IEnumerator ResumeGame()
    {
        float timeToResume = Time.unscaledTime + 3;
        returnImage.fillAmount = 1f;
        while (Time.unscaledTime <= timeToResume)
        {
            returnImage.fillAmount -= 1.0f / 3 * Time.unscaledDeltaTime;
            returnText.text = ((int)(timeToResume - Time.unscaledTime) + 1).ToString();

            yield return null;
        }
        returnImage.fillAmount = 1.0f;
        returnImage.gameObject.SetActive(false);
        Controls.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 1;
        UIEvents.current.PlayStart();
    }
    IEnumerator DeathScreenCoroutine()
    {
        float deathTimer = Time.unscaledTime + 3;
        while (Time.unscaledTime <= deathTimer)
        {

            if (Time.timeScale > 0.1f)
            {
                Time.timeScale -= 1.0f / 3 * Time.unscaledDeltaTime; ;
            }
            else
            {
                break;
            }
            yield return null;
        }

        DeadScreen.SetActive(true);

        Time.timeScale = 1;

    }
}

