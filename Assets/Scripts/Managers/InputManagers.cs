using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagers : MonoBehaviour
{
    PlayerInputs playerInputs;
    [SerializeField] Vector2 movement;
    [SerializeField] bool canJump;
    [SerializeField] bool hasPressedDash;
    [SerializeField] bool hasPressedDown;
    bool isDoingAction = false;
    public static InputManagers instance;
    public Vector2 Movement { get { return movement; } }
    public bool CanJump { get { return canJump; } private set { canJump = value; } }
    public bool HasPressedDash { get { return hasPressedDash ; } set { hasPressedDash = value; } }
    public bool HasPressedDown { get { return hasPressedDown; } set { hasPressedDown = value; } }
    [SerializeField] public int Presses { get; private set; }
    public bool IsDoingAction { get {  return isDoingAction; }  set {  isDoingAction = value; } }
   

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void OnEnable()
    {
        if (playerInputs == null)
        {
            playerInputs = new PlayerInputs();
            playerInputs.InputMap.Movement.performed += i => movement = i.ReadValue<Vector2>();
            playerInputs.InputMap.Jump.performed += i => canJump = true;
            playerInputs.InputMap.MouseClick.performed += i => Presses++;
            
           
            




        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInputs.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputs.InputMap.Dash.IsPressed())
        {
            hasPressedDash = true;
        }
        else
        {
            hasPressedDash = false;
        }

    }
    public IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(0.5f);
        canJump = false;
    }
    public void RestPress()
    {
        Presses = 0;
    }
   
}
   
