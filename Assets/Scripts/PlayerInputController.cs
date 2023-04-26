using UnityEngine;
using Application = UnityEngine.Device.Application;

public class PlayerInputController : MonoBehaviour
{
    [HideInInspector] public float HorizontalInput;
    [HideInInspector] public bool Jump;
    [HideInInspector] public bool Attack;
    [HideInInspector] public bool InputChanged;
    public float joystickMaxSpeed = 6f;

    private CharacterController characterController;
    // private PlayerWeaponController playerWeaponController; 
    public VariableJoystick variableJoystick;

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
        /*         playerWeaponController = GetComponentInChildren<PlayerWeaponController>();  */
    }

    private void Update()
    {
        /*      
                // PC INPUT
                // Get the current input states.
                var horizontalInput = Input.GetAxisRaw("Horizontal");
                var jump = Input.GetButtonDown("Jump");
                var jumpHold = Input.GetButton("Jump");
                var attack = Input.GetButtonDown("Fire1"); */


        var horizontalInput = variableJoystick.Horizontal;
        var jump = variableJoystick.Vertical > 0.5f;
        //var attack = variableJoystick.Horizontal > 0.5f;

        InputChanged = (horizontalInput != HorizontalInput || jump != Jump  /* || attack != Attack */);

        HorizontalInput = horizontalInput;
        Jump = jump;
        //Attack = attack;

        characterController.SetMoveDir(HorizontalInput * joystickMaxSpeed);
        characterController.SetJump(Jump);
        /*         // Set inputs on Player Controllers.

                if (attack)
                {
                    playerWeaponController.Attack();
                } */
    }
}