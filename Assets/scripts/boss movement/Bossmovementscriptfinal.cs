using System.Threading.Tasks;
using UnityEngine;

//i gave up and pasted my buggy code into chatgpt. The result was a mess, then i changed it considerably and simplified it.
public class Bossmovementscriptfinal : MonoBehaviour
{


    public GameObject FireBall;
int tempcheckythingy = 0;
    public float health = 100f;
    public float damage = 10f;
    public float speed = 5f;

    public float meleeRange = 3f;
    public float projectileRange = 10f;
    public float cooldown = 3f;

    private float cooldownTimer = 0f;

    private GameObject player;
    private Rigidbody rb;
    public Animator animatorboss;
    

    void Start()
    { animatorboss = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody component found on the boss!");
        }
        animatorboss.SetFloat("Walk", 1);
       // animator.SetTrigger("IdleAction");
       

        player = GameObject.FindGameObjectWithTag("Player");

        if (FireBall == null){
            Debug.LogError("FireBall prefab is not assigned!");}

        if (animatorboss == null){
            Debug.LogError("No Animator component found!");
        }

        if (player == null){
            Debug.LogError("No player found with tag Player!");
           
        } 
    }

    void Update()
    {
        tempcheckythingy++;
        Debug.Log("Boss Update called. TempCheck: " + tempcheckythingy);
        if (player == null)
           Debug.LogError("Player reference is missing!");

        if (health <= 0)
        {
            Die();
           
        }

        cooldownTimer += Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= meleeRange && cooldownTimer >= cooldown)
        {
            StopWalking();

            MeleeAttack();
            cooldownTimer = 0f;
        }
        else if (distance <= meleeRange)
        {
            StopWalking();
        }
        else
        {
            Debug.Log("Boss is out of melee range, walking towards player.");
            animatorboss.SetTrigger("IdleAction");
            WalkTowardsPlayer();
        }
      
    }

    void MeleeAttack()
    {
        Debug.Log("Boss is performing a melee attack!");

        int randomAttack = Random.Range(0, 2);

        if (randomAttack == 0)
        {
            animatorboss.SetTrigger("Hit");
            Debug.Log("Boss used headbutt!");
             // Wait for the hit animation to play
        }
        else
        {
            animatorboss.SetTrigger("Hit2");
            Debug.Log("Boss used punch!");
            // Wait for the punch animation to play
        }
    }



    void LaunchProjectile()
    {
        if (FireBall == null)
            Debug.LogError("FireBall prefab is not assigned!");

        Instantiate(
            FireBall,
            transform.position + transform.forward,
            Quaternion.identity
        );
    }

    void WalkTowardsPlayer()
    {
        tempcheckythingy++;
        Debug.Log("Boss is walking towards the player." + " TempCheck: " + tempcheckythingy);
        animatorboss.SetFloat("Walk", 1);

        Vector3 targetPosition = player.transform.position;
        targetPosition.y = transform.position.y;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        transform.LookAt(targetPosition);
        Debug.Log("Boss is looking at the player." + targetPosition);
    }

    void StopWalking()
    {
        Debug.Log("Boss stopped walking.");
        animatorboss.SetFloat("Walk", 0);
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
        animatorboss.SetTrigger("Die");
        Debug.Log("Boss is dead!");
    }
    void triggerOnCollide(Collision collision)
    { Debug.Log("Boss collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            
            animatorboss.SetTrigger("Hit");
           // Wait for the hit animation to play
            animatorboss.SetTrigger("Hit2");
            Debug.Log("Boss collided with player, dealing damage!");
            // Here you would typically call a method on the player's health script to apply damage
            // e.g., collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}

