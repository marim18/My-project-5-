using System.Threading.Tasks;
using UnityEngine;

//i gave up and pasted my buggy code into chatgpt
public class Bosschat : MonoBehaviour
{


    public GameObject FireBall;

    public float health = 100f;
    public float damage = 10f;
    public float speed = 5f;

    public float meleeRange = 3f;
    public float projectileRange = 10f;
    public float cooldown = 3f;

    private float cooldownTimer = 0f;

    private GameObject player;
    private Rigidbody rb;
    private Animator animator;
    

    void Start()
    { animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        animator.SetFloat("Walk", 0);
       // animator.SetTrigger("IdleAction");
       

        player = GameObject.FindGameObjectWithTag("TestPlayer");

        if (FireBall == null){
            Debug.LogError("FireBall prefab is not assigned!");}

        if (animator == null){
            Debug.LogError("No Animator component found!");
        }

        if (player == null){
            Debug.LogError("No player found with tag TestPlayer!");
           
        } 
    }

    async Task Update()
    {
        if (player == null)
            return;

        if (health <= 0)
        {
            Die();
            return;
        }

        cooldownTimer += Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= meleeRange && cooldownTimer >= cooldown)
        {
            StopWalking();
            await MeleeAttack();
            cooldownTimer = 0f;
        }
        else if (distance <= meleeRange)
        {
            StopWalking();
        }
        else
        {
            WalkTowardsPlayer();
        }
      
    }

    async Task MeleeAttack()
    {
        Debug.Log("Boss is performing a melee attack!");

        int randomAttack = Random.Range(0, 2);

        if (randomAttack == 0)
        {
            animator.SetTrigger("Hit");
            Debug.Log("Boss used headbutt!");
            await Task.Delay(500); // Wait for the hit animation to play
        }
        else
        {
            animator.SetTrigger("Hit2");
            Debug.Log("Boss used punch!");
            await Task.Delay(500); // Wait for the punch animation to play
        }
    }



    void LaunchProjectile()
    {
        if (FireBall == null)
            return;

        Instantiate(
            FireBall,
            transform.position + transform.forward,
            Quaternion.identity
        );
    }

    void WalkTowardsPlayer()
    {
        Debug.Log("Boss is walking towards the player.");
        animator.SetFloat("Walk", 1);

        Vector3 targetPosition = player.transform.position;
        targetPosition.y = transform.position.y;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        transform.LookAt(targetPosition);
    }

    void StopWalking()
    {
        Debug.Log("Boss stopped walking.");
        animator.SetFloat("Walk", 0);
      //  animator.SetTrigger("IdleAction");

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            // If this errors, use:
            // rb.velocity = Vector3.zero;
        }
    }

    void Die()
    {
        StopWalking();
        animator.SetTrigger("Die");
        Debug.Log("Boss is dead!");
    }
    async Task OnCollide(Collision collision)
    { Debug.Log("Boss collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("TestPlayer"))
        {
            
            animator.SetTrigger("Hit");
            await Task.Delay(500); // Wait for the hit animation to play
            animator.SetTrigger("Hit2");
            Debug.Log("Boss collided with player, dealing damage!");
            // Here you would typically call a method on the player's health script to apply damage
            // e.g., collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}

