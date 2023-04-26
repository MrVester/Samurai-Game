using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    public Button attackButton;
    public bool Status = false;
    void Start()
    {
        attackButton = GetComponent<Button>();
    }

}
