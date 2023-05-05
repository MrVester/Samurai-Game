using UnityEngine;
using Application = UnityEngine.Device.Application;

public class PlayerInputController : MonoBehaviour
{
    [HideInInspector] public float HorizontalInput;
    [HideInInspector] public float VerticalInput;
    [HideInInspector] public bool Jump;
    [HideInInspector] public bool Attack;
    [HideInInspector] public bool InputChanged;


    private CharacterController characterController;
    private PlayerWeaponController playerWeaponController;
    public VariableJoystick variableJoystick;
    public AttackButton attackButton;

    private void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Platform" + Application.platform + " is not supported. Only Android is supported.");
        }
        else
        {
            Debug.Log("Platform" + Application.platform + " is supported.");
        }

        characterController = GetComponentInChildren<CharacterController>();
        playerWeaponController = GetComponentInChildren<PlayerWeaponController>();

        CharacterEvents.current.onAttack += playerWeaponController.Attack;
    }

    private void Update()
    {
        var horizontalInput = variableJoystick.Horizontal;
        var verticalInput = variableJoystick.Vertical;
        var jump = variableJoystick.Vertical > 0.5f;
        var attack = attackButton.Status;

        InputChanged = (horizontalInput != HorizontalInput || jump != Jump || attack != Attack || verticalInput != VerticalInput);

        HorizontalInput = horizontalInput;
        VerticalInput = verticalInput;
        Jump = jump;
        Attack = attack;

        characterController.SetHorizontal(HorizontalInput);
        characterController.SetVertical(VerticalInput);
        characterController.SetJump(Jump);


    }
}