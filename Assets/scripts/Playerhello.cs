using UnityEngine;
using UnityEngine.UI;

public class Playerhello : MonoBehaviour
{
    public int maxhealth = 100;
    public int playerdamage = 10;
    public int currenthealth;
    public Slider healthbarobject;
    public GameObject player;
    [SerializeField]
    private AudioClip AttackSound;
    [SerializeField]
    private AudioClip damagesound;
    [SerializeField]
    private AudioClip walksound;
    public bool playerwalksoundplayed = false;
   
    [SerializeField]
    private AudioClip panting;
    [SerializeField] private AudioClip Grunt;
    [SerializeField] private AudioClip Jumpsfx;
    [SerializeField] private AudioClip Landingsfx;
    [SerializeField] private AudioClip SwordAttackSfx;
    [SerializeField] private AudioClip PlayerDieSfx;

     void Awake()
    {
        currenthealth = maxhealth;
    }

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        healthbarobject.maxValue = maxhealth;
        healthbarobject.value = currenthealth;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("No player GameObject assigned! Please assign the player GameObject in the inspector.");
        }
        else
        {
            string position = player.transform.position.ToString();
            Debug.Log("Hello, Player! Position: " + position);
            //Instantiate(player, player.transform.position, player.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void takedamage  (int damage)
    {
        Debug.Log("Player is taking damage: " + damage + " current health: " + currenthealth);
        int randomnoise = Random.Range(0, 3);
        if (randomnoise == 0)        {
             AudioSource.PlayClipAtPoint(Grunt, transform.position);
        }
        else if (randomnoise == 1)
        {
              AudioSource.PlayClipAtPoint(panting, transform.position);  
              }
        AudioSource.PlayClipAtPoint(damagesound, transform.position);
        currenthealth -= damage;
        Debug.Log("Player took " + damage + " damage. Current health: " + currenthealth);
        healthbarobject.value = Mathf.Clamp(currenthealth, 0, maxhealth);
        if (currenthealth <= 0)
        {
            Die();
        }
    }
    public void dodamage (int damage , GameObject enemy)
    {
        Debug.Log("Player is doing damage: " + damage + " current health: " + currenthealth);
        int randomnoise = Random.Range(0, 3);
        if (randomnoise == 0)
        {
             AudioSource.PlayClipAtPoint(Grunt, transform.position);
        }
        else if (randomnoise == 1)
        {
              AudioSource.PlayClipAtPoint(AttackSound, transform.position);  
              }
        AudioSource.PlayClipAtPoint(SwordAttackSfx, transform.position);
        Debug.Log("Player dealt " + damage + " damage to the enemy.");
        enemy.GetComponent<Bossmovementscriptfinal>().takedamage(damage);
        // Add logic to apply damage to the enemy here
    }
    public void Die()
    {
        AudioSource.PlayClipAtPoint(PlayerDieSfx, transform.position);
        Debug.Log("Player has died.");
        
        // Add death logic here (e.g., respawn, game over screen, etc.)
    }
    void onCollisionEnter(Collision collision)
    {
        Debug.Log("Player collided with " + collision.gameObject.name + ", taking damage!");
        if (collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("Player collided with boss, taking damage!");
            dodamage(playerdamage, collision.gameObject);
        
        }
    }
    
}
