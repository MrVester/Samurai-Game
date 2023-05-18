using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.PackageManager;

public class MainMenuControl : MonoBehaviour
{
    private LevelSelector levelSelector;
    [Header("LevelSelector")]
    public GameObject levelSelectorTab;
    public int levelsAmount;
    public int levelsCompleted;

    public bool isGenerateButtons = false;
    public Button backButtonFromLevelSelector;
    [Header("Settings")]
    public GameObject settingsTab;
    public Button backButtonFromSettings;
    [Header("MainMenu")]
    public GameObject mainMenuTab;
    public Button playButton;
    public Button levelSelectionButton;
    public Button settingsButton;
    public Button quitButton;

    void Start()
    {
        JSONSave.Start(JSONSaveConfig.GetConfig());
        
        levelSelector = GetComponent<LevelSelector>();
        
        FirstTimeCheck();

        //If it is nor working, replace listeners from button after loading main menu, then add new listener to button
        //���� �� ����� ��������, �� ������� ��������� � ������ ��� ����������� � ������� ���� � ��������� ����� ��������
        playButton.onClick.AddListener(() => PlayButtonEvent(levelsCompleted + 1));
        levelSelectionButton.onClick.AddListener(() => LevelSelectionButtonEvent());
        settingsButton.onClick.AddListener(() => SettingsButtonEvent());
        quitButton.onClick.AddListener(() => Application.Quit());

        backButtonFromLevelSelector.onClick.AddListener(() => BackButtonFromLevelSelectorEvent());
        backButtonFromSettings.onClick.AddListener(() => BackButtonFromSettingsEvent());
        
    }


    void Update()
    {
        if (isGenerateButtons)
        {
            levelSelector.DestroyButtons();
            levelSelector.CreateButtons(levelsAmount, levelsCompleted);
            isGenerateButtons = false;
        }
    }

    private void BackButtonFromSettingsEvent()
    {
        settingsTab.SetActive(false);
        mainMenuTab.SetActive(true);
    }
    private void SettingsButtonEvent()
    {
        settingsTab.SetActive(true);
        mainMenuTab.SetActive(false);
    }
    private void BackButtonFromLevelSelectorEvent()
    {

        levelSelectorTab.SetActive(false);
        levelSelector.DestroyButtons();
        mainMenuTab.SetActive(true);
    }

    private void LevelSelectionButtonEvent()
    {
        levelSelector.CreateButtons(levelsAmount, levelsCompleted);
        levelSelectorTab.SetActive(true);
        mainMenuTab.SetActive(false);
    }



    private void PlayButtonEvent(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }


    private T GetChildComponentByName<T>(string name) where T : Component
    {
        foreach (T component in GetComponentsInChildren<T>(true))
        {
            if (component.gameObject.name == name)
            {
                return component;
            }
        }
        return null;
    }

    /// <summary>
    /// Check if it is the first time the game is run
    /// </summary>
    public void FirstTimeCheck()
    {
        if (!JSONSave.HasKeyForBool("isFirstTime"))
        {
            JSONSave.SetBool("isFirstTime", false);
            // init initial values
            JSONSave.SetInt("levelsAmount", levelsAmount);
            for (int i = 0; i < levelsAmount; i++)
            {
                JSONSave.SetInt("level" + (i + 1) + "Stars", 0);
            }
            JSONSave.SetInt("levelsCompleted", 0);
            JSONSave.SetInt("currentLevel", 1);
        }
        // load values
        levelsAmount = JSONSave.GetInt("levelsAmount");
        levelsCompleted = JSONSave.GetInt("levelsCompleted");
        for (int i = 0; i < levelsAmount; i++)
        {
            levelSelector.SetLevelStars(JSONSave.GetInt("level" + (i + 1) + "Stars"));
        }
    }
}
