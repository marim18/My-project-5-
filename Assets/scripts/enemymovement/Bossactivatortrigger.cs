using UnityEngine;

public class Bossactivatortrigger : MonoBehaviour
{
    public Bossmovementscriptfinal boss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      //Boss = GameObject.FindObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider collision)
    {
        
        Debug.Log("mother i collided" + collision.tag);
        if ( collision.CompareTag("Player"))
        {
            
            boss.ActivateBoss();
           
        }
    }
    
}
