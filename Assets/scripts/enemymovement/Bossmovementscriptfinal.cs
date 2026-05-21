using System.Threading.Tasks;
using UnityEngine;

//i gave up and pasted my buggy code into chatgpt. The result was a mess, then i changed it considerably and simplified it.
public class Bossmovementscriptfinal : MonoBehaviour
{


    public GameObject FireBall;
int tempcheckythingy = 0;
    private float currentHealth = 100f;
    public float maxHealth = 100f;
    public float damage = 10f;
    public float speed = 5f;

    public float meleeRange = 3f;
    public float projectileRange = 10f;
    public float cooldown = 3f;

    public float cooldownTimer = 0f;
    

   [SerializeField] private GameObject player;
    private Rigidbody rb;
    public Animator animatorboss;
    [SerializeField] private AudioClip meleeAttackSound;
    [SerializeField] private AudioClip projectileAttackSound;  
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip ragesound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip gruntSound;
    public bool walksoundplayed = false;
   [SerializeField] private UnityEngine.UI.Slider healthbarobject;
    Collider collidern;
    public bool bossisactive = false;
   public DialogueTrigger bossdialgouguetrigger;
 

    void Start()
    {  
        
        currentHealth = maxHealth;
        healthbarobject.maxValue = maxHealth;
        healthbarobject.value = currentHealth;
        animatorboss = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        collidern = GetComponent<Collider>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody component found on the boss!");
        }
        animatorboss.SetFloat("Walk", 0);
       animatorboss.SetBool("sleep", true);
       

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

        
      
        if (player == null)
           Debug.LogError("Player reference is missing!");

        if (currentHealth <= 0)
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
           
         WalkTowardsPlayer();
        }
      
    }
    

    void  MeleeAttack()
    {
        Debug.Log("Boss is performing a melee attack!");

        int randomAttack = Random.Range(0, 2);
        int randomnoise = Random.Range(0, 2);

        if (randomAttack == 0)
        {
            AudioSource.PlayClipAtPoint(meleeAttackSound, transform.position);
            if (randomnoise == 0)
            {
                AudioSource.PlayClipAtPoint(gruntSound, transform.position);
            }
            
           animatorboss.SetTrigger("Hit");
            Debug.Log("Boss used headbutt!");
            
          
             // Wait for the hit animation to play
        // Replace with actual animation duration
        }
        else
        {
             if (randomnoise == 0)
            {
                AudioSource.PlayClipAtPoint(gruntSound, transform.position);
            }
            
            AudioSource.PlayClipAtPoint(meleeAttackSound, transform.position);
            animatorboss.SetTrigger("Hit2");
            Debug.Log("Boss used punch!");
            // Wait for the punch animation to play
         
           // Replace with actual animation duration
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
        // Replace with actual projectile duration
    }

   void WalkTowardsPlayer()
    {
        
        
        Vector3 targetPosition = player.transform.position;
        targetPosition.y = transform.position.y;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime);
            
        if (!walksoundplayed)
        {
            AudioSource.PlayClipAtPoint(walkSound, transform.position);
            walksoundplayed = true;
        }
        // Replace with actual look rotation duration
        transform.LookAt(targetPosition);
        animatorboss.SetFloat("Walk", 1);

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
        walksoundplayed = false;
    }

    void Die()
    {
        StopWalking();
        animatorboss.SetTrigger("Die");
        Debug.Log("Boss is dead!");
        AudioSource.PlayClipAtPoint(dieSound, transform.position);
        
        bossdialgouguetrigger.dialogueforwin();
        
        
    }
   void OnCollisionEnter(Collision collision)
    { Debug.Log("Boss collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            
              if (cooldownTimer >= cooldown)
            {
                Debug.Log("Boss collided with player, dealing damage!");

               MeleeAttack();
            }
        }
    }
    public void Bosstakedamage(int damageamount)
    {
        
        currentHealth -= damageamount;
        Debug.Log("Boss took " + damageamount + " damage! Current health: " + currentHealth);
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
        healthbarobject.value = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Boss health bar updated: " + healthbarobject.value + "/" + maxHealth +"bossbar is; " + healthbarobject);
        Debug.Log("Slider object: " + healthbarobject.name);

          if (currentHealth <= 0)
        {
            Die();
        }
    }
    void onTriggerEnter(Collider collision)
    {
        if (animatorboss.GetCurrentAnimatorStateInfo(0).IsName("Sleep") && collision.CompareTag("Startbosstrigger"))
        {
            if(bossdialgouguetrigger == null)
            {
                Debug.Log("dialogue where");
            }
            else
            {
                bossdialgouguetrigger.dialogueforboss();
            }
            
            animatorboss.SetBool("sleep", false);
            animatorboss.SetTrigger("EndSleep");
            animatorboss.SetTrigger("enrage");
            AudioSource.PlayClipAtPoint(ragesound, transform.position);
            
        }
    }
}

