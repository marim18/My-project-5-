using UnityEngine;

public class swordscript : MonoBehaviour
{

    public int Swordpieceid; 
    Rigidbody rigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { if (GetComponent<Rigidbody>() == null)
        {
            Debug.LogError("No Rigidbody component found on the sword piece!");
        }
        else
        {
            rigidbody = GetComponent<Rigidbody>();
        }
        if (Swordpieceid == 0)
        {
            Debug.Log("Sword piece ID is not set! Please assign a unique ID to this sword piece.");
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player picked up sword piece with ID: " + Swordpieceid);
            // Add logic here to give the player the sword piece and update any relevant UI or game state
        }
    }
}
