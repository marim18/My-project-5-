using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    public Animator animator;

    int isWalkingHash;
    int isRunningHash;
    int jumpHash;
    int swordAttackHash;
    public bool isWalking = false;
    public bool isRunning = false;
    float inputaxisy;
    public float inputaxisx;



    public float walkSpeed = 1.5f;
    public float runSpeed = 4f;


    void Start()
    {
        Debug.Log("Animation State Controller started successfully.");
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("No Animator component found on the character!");
        }

        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
        jumpHash = Animator.StringToHash("Jump");
        swordAttackHash = Animator.StringToHash("SwordAttack");

    }

    void Update()
    {
        Debug.Log("Update method called in Animation State Controller.");
        isWalking = animator.GetBool(isWalkingHash);
        isRunning = animator.GetBool(isRunningHash);

        inputaxisy = Input.GetAxis("Vertical");
        inputaxisx = Input.GetAxis("Horizontal");
        bool keyboardinput = inputaxisy != 0 || inputaxisx != 0;

        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
        bool swordPressed = Input.GetKeyDown(KeyCode.F);


        // Walking animation
        if (!isWalking && keyboardinput && !runPressed)
        {
            animator.SetBool(isWalkingHash, true);
            Debug.Log("Walking animation triggered.");
        }

        if (isWalking && !keyboardinput)
        {
            animator.SetBool(isWalkingHash, false);
        }

        // Running animation
        if (!isRunning && keyboardinput && runPressed)
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && (!keyboardinput || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }


        // Jump animation
        if (jumpPressed)
        {
            animator.SetTrigger(jumpHash);

            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        }

        // Sword animation
        if (swordPressed)
        {
            animator.SetTrigger(swordAttackHash);
        }



        // Actual character movement
        if (keyboardinput)
        {
            float currentSpeed = runPressed ? runSpeed : walkSpeed;


            Vector3 movement = new Vector3(-inputaxisx, 0, -inputaxisy).normalized * currentSpeed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
            transform.position += movement;

        }


    }

}