using UnityEngine;

public class Hitboxscript : MonoBehaviour
{
   [SerializeField] private GameObject limb;
   [SerializeField] public bool isboss = true;
    Collider hitboxcollider;
    public int damage = 10; // Adjust the damage value as needed
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitboxcollider = GetComponent<Collider>();
        hitboxcollider.enabled = true; // Disable the hitbox collider at the start
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
        if (collision.CompareTag("Player") && isboss)
        {
            Debug.Log("specific hitbox collided with player, dealing damage!");
            collision.gameObject.GetComponent<Playerhello>().Playertakedamage((int)damage);
        }
        else if (collision.CompareTag("Boss") && !isboss)
        {
            Debug.Log("specific hitbox collided with boss, dealing damage!");
            collision.gameObject.GetComponent<Bossmovementscriptfinal>().Bosstakedamage((int)damage);
        }
        
    }
}
