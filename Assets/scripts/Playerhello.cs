using UnityEngine;

public class Playerhello : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        string osition = player.transform.position.ToString();
        Debug.Log("Hello, Player! Position: " + osition);
        //Instantiate(player, player.transform.position, player.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
