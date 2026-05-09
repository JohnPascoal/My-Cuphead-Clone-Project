using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool AimLocked { get; private set; }
    public bool DashPressed { get; private set; }
    public bool ShootPressed { get; private set; }
    public bool ShootTrigger { get; private set; }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) JumpPressed = true;
    }

    public void OnAimLock(InputAction.CallbackContext context)
    {
        AimLocked = context.ReadValueAsButton();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed) DashPressed = true;
        if (context.canceled) DashPressed = false;
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        ShootPressed = context.ReadValueAsButton();
        if (context.performed) ShootTrigger = true;
    }

    public void UseJump() => JumpPressed = false;
    public void UseShoot() => ShootTrigger = false;
}