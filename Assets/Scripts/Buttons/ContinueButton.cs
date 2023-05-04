
using UnityEngine;
using UnityEngine.UI;
public class ContinueButton : MonoBehaviour
{
    Button _continueButton;
    void Start()
    {
        _continueButton = GetComponent<Button>();
        _continueButton.onClick.AddListener(() => ContinueButtonRelease());
    }

    private void ContinueButtonRelease()
    {
        UIEvents.current.GameStart();
    }
}
