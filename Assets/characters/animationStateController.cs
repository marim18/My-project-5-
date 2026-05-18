using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
   public Animator animator;

   int isWalkingHash;
    int isRunningHash;
    int jumpHash;
    int swordAttackHash;
    public bool isWalking =false;
    public bool isRunning = false;
    
   

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

        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
        bool swordPressed = Input.GetKeyDown(KeyCode.F);


        // Walking animation
        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
            Debug.Log("Walking animation triggered.");
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