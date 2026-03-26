using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float delay = 1f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TestPlayer"))
        {
            Invoke("Fall", delay);
        }

    }
    void Fall()
    {

        rb.isKinematic = false;
    }
}
