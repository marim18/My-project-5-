using UnityEngine;

public class animationStateController : MonoBehaviour
{
    public Animator animator;

    int isWalkingHash;
    int isRunningHash;
    int jumpHash;
    int swordAttackHash;

    public bool isWalking;
    public bool isRunning;

    public float walkSpeed = 1.5f;
    public float runSpeed = 4f;

    void Start()
    {
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
        isWalking = animator.GetBool(isWalkingHash);
        isRunning = animator.GetBool(isRunningHash);

        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
        bool swordPressed = Input.GetKeyDown(KeyCode.F);

        float horizontal = 0f;
        float vertical = 0f;

       // Forward / backward
if (Input.GetKey(KeyCode.W))
{
    vertical = 1f;
}
else if (Input.GetKey(KeyCode.S))
{
    vertical = -1f;
}

// Left / right
if (Input.GetKey(KeyCode.D))
{
    horizontal = -1f;
}
else if (Input.GetKey(KeyCode.A))
{
    horizontal = 1f;
}

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        bool isMoving = moveDirection.magnitude > 0;

        // Walking animation
        animator.SetBool(isWalkingHash, isMoving);

        // Running animation
        animator.SetBool(isRunningHash, isMoving && runPressed);

        // Jump animation
        if (jumpPressed)
        {
            animator.SetTrigger(jumpHash);
        }

        // Sword attack animation
        if (swordPressed)
        {
            animator.SetTrigger(swordAttackHash);
        }

        // Actual movement
        if (isMoving)
        {
            float currentSpeed = runPressed ? runSpeed : walkSpeed;

            transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.Self);     }
    }
}