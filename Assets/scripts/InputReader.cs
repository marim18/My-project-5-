using Unity.VisualScripting;
using UnityEngine;
/*
public class InputReader : MonoBehaviour
{

    public Vector3 moveinput { get; private set; }
    public Vector3 lookinput { get; private set; }
    public bool attackpressed { get; private set; }

    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
    }
    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;
        controls.Player.Look.performed += OnLook;
        controls.Player.Look.canceled += OnLook;
        controls.Player.Attack.performed += OnAttack;
        controls.Player.Attack.canceled += OnAttack;
    }
    private void Ondisable()
    {
        controls.Player.Disable();
        controls.Player.Move.performed -= OnMove;
        controls.Player.Move.canceled -= OnMove;
        controls.Player.Look.performed -= OnLook;
        controls.Player.Look.canceled -= OnLook;
        controls.Player.Attack.performed -= OnAttack;
        controls.Player.Attack.canceled -= OnAttack;    
    }
    public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        moveinput = context.ReadValue<Vector3>();
    }
    public void OnLook(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        lookinput = context.ReadValue<Vector3>();
    }   
    public void OnAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        attackpressed = context.ReadValueAsButton();
    }
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }
}/
*/
