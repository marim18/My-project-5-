using UnityEngine;

public class Soundcontroller : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] private AudioClip music1;
    [SerializeField] private AudioClip music2;
    [SerializeField] private AudioClip music3;
    public int passcounter = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            passcounter++;
            Debug.Log("Player entered sound trigger, changing music! Passcounter is now " + passcounter);
            if (passcounter == 1)
            {
                audioSource.clip = music1;
                audioSource.Play();
            }
            else if (passcounter == 2)
            {
                audioSource.clip = music2;
                audioSource.Play();
            }
            else if (passcounter == 3)
            {
                audioSource.clip = music3;
                audioSource.Play();
            }
        }
        // if triggered swap into new enivroment music

    }
}
