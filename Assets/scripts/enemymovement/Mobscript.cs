using UnityEngine;
using UnityEngine.UI;

public class Mobscript : MonoBehaviour
{
    [SerializeField] private float speed = 1f; // Speed of the mob
    [SerializeField] private Transform target; // Target to follow
    [SerializeField] private float stoppingDistance = 1f; // Distance at which the mob stops moving towards the target
    [SerializeField] private float retreatDistance = 0.5f; // Distance at which the mob starts retreating from the target
    [SerializeField] private float retreatSpeed = 3f; // Speed at which the mob retreats from the target
    [SerializeField] private float attackRange = 1f; // Range at which the mob can attack the target
    [SerializeField] private float attackCooldown = 2f; // Cooldown time between attacks
    [SerializeField] private int damage = 10; // Damage dealt to the target when attacking
    [SerializeField] private float health = 100f; // Health of the mob
    [SerializeField] private float maxhealth = 100f; // Maximum health of the mob

    [SerializeField] private float agroRange = 10f; // Range at which the mob will aggro the player
    // Reference to the player object
    [SerializeField] private AudioClip mobSound; // Reference to the mob's sound script
    [SerializeField] private AudioClip agroSound; // Reference to the mob's aggro sound script
    [SerializeField] private Animator anim; 
    
    [SerializeField] private UnityEngine.UI.Slider mobHealth; // Reference to the Animator component
    [SerializeField] private GameObject Weapon;
    // Force applied to the target when attacking
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (mobHealth != null)
        {
            mobHealth.maxValue = maxhealth; // Set the maximum value of the health slider
            mobHealth.value = health; // Set the current value of the health slider
        }
        Weapon.GetComponent<Collider>().enabled = false; // Disable the weapon's collider at the start
        anim = GetComponent<Animator>(); // Get the Animator component attached to the mob
        printmyparameters(); // Print the parameters of the Animator component to the console for debugging
         // Set the idle animation to true at the start
         
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position; // Get the current position of the mob
        Vector3 targetPosition = target.position; 
        if (Vector3.Distance(position, targetPosition) > stoppingDistance && 
        Vector3.Distance(position, targetPosition) <= agroRange)
        {
            // Move towards the target
            Vector3 direction = (targetPosition - position).normalized; // Calculate the direction towards the target
            transform.position += direction * speed * Time.deltaTime; 
            transform.rotation = Quaternion.LookRotation(direction); // Rotate the mob to face the target
            anim.SetBool("Walk", true); // Set the walking animation to true
        }
        else if (Vector3.Distance(position, targetPosition) == stoppingDistance)
        {
            anim.SetBool("Walk", false); // Set the walking animation to false
            attackCooldown -= Time.deltaTime; // Decrease the attack cooldown timer
            if (attackCooldown <= 0f)
            {
                  
                attack(); // Attack the target
                attackCooldown = 2f; // Reset the attack cooldown timer
            }
            // Mo walking animation to true
        }
        else
        {
            anim.SetTrigger("Idle"); // Set the idle animation trigger at the start of each update
        }
    }
    void printmyparameters()
    {
        foreach (var parameter in anim.parameters)
        {
            Debug.Log("Parameter Name: " + parameter.name + ", Type: " + parameter.type);
        }
    }
    void attack()
    { Weapon.GetComponent<Collider>().enabled = true;
        
        Debug.Log("Mob is attacking the target!");
        int randomattack = Random.Range(0, 1); 
        if (randomattack == 0)
        {   AudioSource.PlayClipAtPoint(mobSound, transform.position);
            anim.SetTrigger("attack1"); 
           // Enable the hitbox collider to detect collisions with the player
        }
        else 
        { AudioSource.PlayClipAtPoint(mobSound, transform.position);
            anim.SetTrigger("attack2");
        }
    
     
       
    
    }
   public void takedamage(int damage)
    {
        AudioSource.PlayClipAtPoint(agroSound, transform.position);
        anim.SetTrigger("TakeDamage"); // Trigger the damage animation
        health -= damage; // Decrease the mob's health by the damage taken
        Debug.Log("Mob took " + damage + " damage. Current health: " + health); 
         mobHealth.value = Mathf.Clamp(health, 0, maxhealth); // Update the health slider value
    
        if (health <= 0f)
        {
            anim.SetTrigger("death");
            Destroy(gameObject); // Call the Die method if health drops to 0 or below
        }
    }
}
