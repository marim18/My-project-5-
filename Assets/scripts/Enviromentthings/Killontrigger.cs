using UnityEngine;

public class Killontrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with killontrigger, killing player!" + collision.gameObject.name);
            collision.gameObject.GetComponent<Playerhello>().Die();
        }
    }
}
