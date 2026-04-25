using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool AimLocked { get; private set; }
    public bool DashPressed { get; private set; }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        JumpPressed = Input.GetKeyDown(KeyCode.Y);
        AimLocked = Input.GetKey(KeyCode.T);
        DashPressed = Input.GetKeyDown(KeyCode.LeftShift);
    }

    public void UseJump() => JumpPressed = false;
}