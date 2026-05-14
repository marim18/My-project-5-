using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;

    int isWalkingHash;
    int isRunningHash;
    int jumpHash;
    int swordAttackHash;

    public float walkSpeed = 1.5f;
    public float runSpeed = 4f;

    void Start()
    {
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
        jumpHash = Animator.StringToHash("Jump");
        swordAttackHash = Animator.StringToHash("SwordAttack");
    }

    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
        bool swordPressed = Input.GetKeyDown(KeyCode.F);

        // Walking animation
        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        // Running animation
        if (!isRunning && forwardPressed && runPressed)
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }

        // Jump animation
        if (jumpPressed)
        {
            animator.SetTrigger(jumpHash);
        }

        // Sword animation
        if (swordPressed)
        {
            animator.SetTrigger(swordAttackHash);
        }

        // Actual character movement
        if (forwardPressed)
        {
            float currentSpeed = runPressed ? runSpeed : walkSpeed;

            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
    }
}