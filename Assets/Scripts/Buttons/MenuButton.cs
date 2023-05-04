
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class MenuButton : MonoBehaviour
{
    Button _menuButton;
    void Start()
    {
        _menuButton = GetComponent<Button>();
        _menuButton.onClick.AddListener(() => MenuButtonRelease());
    }

    private void MenuButtonRelease()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
