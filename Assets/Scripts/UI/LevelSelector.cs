using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    [Header("LevelSelector")]
    public string prefixToLvl;
    public int[] levelStars;
    public GameObject levelSelectorGrid;
    public GameObject buttonGOPrefab;
    private TextMeshProUGUI buttonTextMeshPro;


    private void Update()
    {

    }
    public void DestroyButtons()
    {
        foreach (Transform child in levelSelectorGrid.transform)
        {
            Destroy(child.gameObject);
        }

    }
    public void CreateButtons(int buttonsAmount, int levelsCompleted)
    {
        for (int i = 0; i < buttonsAmount; i++)
        {
            int level = i + 1;
            GameObject currentGOButton = Instantiate(buttonGOPrefab);
            StarsControl starsControl = currentGOButton.GetComponent<StarsControl>();
            starsControl.DrawStars(levelStars[i]);
            currentGOButton.transform.SetParent(levelSelectorGrid.transform, false);

            Button buttonPrefab = currentGOButton.GetComponent<Button>();
            buttonTextMeshPro = currentGOButton.GetComponentInChildren<TextMeshProUGUI>();

            buttonPrefab.onClick.AddListener(() => LoadLevel(level));
            buttonTextMeshPro.text = prefixToLvl + level;
            if (level > levelsCompleted + 1)
            {
                buttonPrefab.interactable = false;
            }

        }

    }



    void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }

}

