using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool LeftButtonInput { get; private set; }
    public bool RightButtonInput { get; private set; }
    public bool JumpButtonInput { get; private set; }
    public bool AttackButtonInput { get; private set; }

    private LeftButtonInput _leftButtonInput;
    private RightButtonInput _rightButtonInput;
    private JumpButtonInput _jumpButtonInput;

    private void Start()
    {
        _leftButtonInput = FindObjectOfType<LeftButtonInput>();
        _rightButtonInput = FindObjectOfType<RightButtonInput>();
        _jumpButtonInput = FindObjectOfType<JumpButtonInput>();
    }

    private void Update()
    {
#if UNITY_EDITOR
        HorizontalInput();

        JumpInput();

        AttackInput();
#else
        LeftButtonInput = _leftButtonInput.LeftButtonPressed;
        RightButtonInput = _rightButtonInput.RightButtonPressed;
        JumpButtonInput = _jumpButtonInput.JumpButtonPressed;
#endif
    }

    private void HorizontalInput()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            RightButtonInput = true;
            LeftButtonInput = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            RightButtonInput = false;
            LeftButtonInput = true;
        }
        else
        {
            RightButtonInput = false;
            LeftButtonInput = false;
        }
    }
    
    private void JumpInput()
    {
        JumpButtonInput = Input.GetButtonDown("Jump");
    }

    private void AttackInput()
    {
        AttackButtonInput = Input.GetMouseButtonDown(0);
    }
}