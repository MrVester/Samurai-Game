using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadSceneButton : MonoBehaviour
{
    Button _RestartButton;
    void Start()
    {
        _RestartButton = GetComponent<Button>();
        _RestartButton.onClick.AddListener(() => MenuButtonRelease());
    }

    private void MenuButtonRelease()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        
    }
}
