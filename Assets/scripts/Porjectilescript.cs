using UnityEngine;

public class Porjectilescript : MonoBehaviour
{
    public float speed = 10f;
        float objectlifetime = 0f;
        GameObject player;
        Vector3 targetlocation;
        Vector3 direction;
        Rigidbody rigidbody;
        Vector3 Projectilelaunchlocation;
        //GameObject fireball = "Fireball";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 void Start()
    {
    
     
       // Porjectilescript to location;
       GameObject Boss = GameObject.FindGameObjectWithTag("Boss");
        Projectilelaunchlocation = Boss.GetComponent<Transform>().position;
        GameObject player = GameObject.FindGameObjectWithTag("TestPlayer");
        targetlocation = player.GetComponent<Transform>().position;
       direction = targetlocation - Projectilelaunchlocation;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(direction.normalized * speed);
       objectlifetime = 0;
       
        
    }

    // Update is called once per frame
    void Update()
    {

        if (objectlifetime < 5)
        {
            player = GameObject.FindGameObjectWithTag("TestPlayer");
            targetlocation = player.GetComponent<Transform>().position;
           // direction = targetlocation - transform.position;
           direction = targetlocation - Projectilelaunchlocation;
            rigidbody = GetComponent<Rigidbody>();
            GetComponent<Rigidbody>().AddForce(direction.normalized * speed);
        }
        else
        {
            Destroy(gameObject);
        }

        objectlifetime += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TestPlayer")
        {
            // damage player
            Debug.Log("Player hit");
             Destroy(gameObject);
        }
        else 
        {
         Destroy(gameObject);

        }
    }
}

