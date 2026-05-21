using UnityEngine;

public class Hitboxscript : MonoBehaviour
{
   [SerializeField] private GameObject limb;
   [SerializeField] public bool isboss = true;
   [SerializeField] public bool isenemy = false;
    private Collider hitboxcollider;
    public int damage = 10; // Adjust the damage value as needed
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        hitboxcollider = GetComponent<Collider>();
        hitboxcollider.enabled = false; 
        if (hitboxcollider == null){
            Debug.LogError("Collider component not found on the hitbox object." + gameObject.name);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
   public void hitboxenabled()
    {
        limb.GetComponent<Collider>().enabled = true;
    }

     void OnTriggerEnter(Collider collision)
    { 
        if (collision.CompareTag("Player") && isboss || collision.CompareTag("Player") && isenemy)
        {
            Debug.Log("specific hitbox collided with player, dealing damage!" + collision.gameObject.name + " and damage is " + damage);
            collision.gameObject.GetComponent<Playerhello>().Playertakedamage((int)damage);
        }
        else if (collision.CompareTag("Boss") && !isboss)
        {
            Debug.Log("specific hitbox collided with boss, dealing damage!" + collision.gameObject.name + " and damage is " + damage);
            collision.gameObject.GetComponent<Bossmovementscriptfinal>().Bosstakedamage((int)damage);
        }
        else if (collision.CompareTag("Enemy") && !isenemy)
        {
            Debug.Log("specific hitbox collided with enemy, dealing damage!" + collision.gameObject.name + " and damage is " + damage);
            collision.gameObject.GetComponent<Mobscript>().takedamage((int)damage);
        }
        
        
    }
}
