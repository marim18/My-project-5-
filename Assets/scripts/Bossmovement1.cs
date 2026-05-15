using UnityEngine;

public class Bossmovement1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   float Cooldown = 5f;
    public GameObject FireBall;
    float cooldownTimer = 0f;
    public float health = 100f;
    public float damage = 10f;
    public float speed = 5f;
     float range = 10f;
     GameObject player;
     Vector3 targetlocation;
     Vector3 direction;
     Rigidbody rigidbody;
      public Animator animator;
GameObject Boss;
    void Start()
    {
        if (FireBall == null)
        {
            Debug.LogError("FireBall prefab is not assigned in the inspector!");
        }
        if (GetComponent<Animator>() == null)
        {
            Debug.LogError("No Animator component found on the boss!");
        }
        Boss = GameObject.FindGameObjectWithTag("Boss");
        animator = gameObject.GetComponent<Animator>();
       
        cooldownTimer = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
            targetlocation = player.GetComponent<Transform>().position;
            rigidbody = GetComponent<Rigidbody>();

        if (health <= 0)
        {
            Debug.Log("Boss is dead!");

           // Destroy(gameObject);
        }
        else
        {
            //keep playing idle animation; 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        getplayerlocation();
        attack();
        move();
    }

    void attack()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer < Cooldown)
        {
            // do nothing
        }
        else  
        {
            if (Vector3.Distance(transform.position, player.transform.position) < range)
            {
                int randomAttack = Random.Range(0, 2); // Randomly choose between 0 and 1
                if (randomAttack == 0)
                {
                    // Perform headbutt attack
                    GetComponent<Animator>().Play("hit"); // Play headbutt animation
                    Debug.Log("Player in range, performing headbutt attack!");
                }
                else
                {
                    // Perform fireball attack
                    GetComponent<Animator>().Play("hit2"); // punch animation
                    Debug.Log("Player in range, performing punch attack!");
                }
                // attack player
                GetComponent<Animator>().Play("hit"); //thats the headbutt
                Debug.Log("Player in range, attacking!");
            }
            else
            {
             
                 GameObject projectile = Instantiate(FireBall, Boss.GetComponent<Transform>().position, Quaternion.identity);
            cooldownTimer = 0f; // Reset cooldown timer
            GetComponent<Animator>().Play("Rage"); // Play attack animation
            }
        }
           
    }
    void move()
    {
       
        if (Vector3.Distance(transform.position, player.transform.position) < range)
        {
            // Move towards player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            direction = targetlocation - transform.position;
             rigidbody.AddForce(direction.normalized * speed);
             GetComponent<Animator>().Play("Walk"); // Play walk animation
        
        }
        else
        {
            GetComponent<Animator>().Play("IdleAction"); // Play idle animation
             rigidbody.linearVelocity = Vector3.zero; // Stop movement
        }
    }
     void getplayerlocation()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        targetlocation = player.GetComponent<Transform>().position;
    }


    

   
}
