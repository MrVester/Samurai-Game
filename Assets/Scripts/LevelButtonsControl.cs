using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButtonsControl : MonoBehaviour
{
    public GameObject GridLayout;
    public GameObject buttonGOPrefab;

    public int buttonsAmount;
    public bool GenerateButtons = false;

    private TextMeshProUGUI buttonTextMeshPro;


    private void Start()
    {

        CreateButtons();
    }
    private void Update()
    {
        if (GenerateButtons)
        {
            foreach (Transform child in GridLayout.transform)
            {
                Destroy(child.gameObject);
            }
            CreateButtons();
        }
    }
    void CreateButtons()
    {
        for (int i = 0; i < buttonsAmount; i++)
        {
            int level = i + 1;
            GameObject currentGOButton = Instantiate(buttonGOPrefab);

            currentGOButton.transform.SetParent(GridLayout.transform, false);

            Button buttonPrefab = currentGOButton.GetComponent<Button>();
            buttonTextMeshPro = currentGOButton.GetComponentInChildren<TextMeshProUGUI>();

            buttonPrefab.onClick.AddListener(() => LoadLevel(level));
            buttonTextMeshPro.text = "Level" + (level);



        }
        GenerateButtons = false;
    }
    void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }

}

