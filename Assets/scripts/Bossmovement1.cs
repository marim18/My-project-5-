using UnityEngine;

public class Bossmovement1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   float Cooldown = 5f;
    public GameObject FireBall;
    float cooldownTimer = 0f;
    public float health = 100f;
    public float damage = 10f;
    public float speed = 5f;
     float range = 10f;
     GameObject player;
     Vector3 targetlocation;
     Vector3 direction;
     Rigidbody rigidbody;
     [SerializeField] private AnimatorControllerParameterType _type;
     [SerializeField] private string _name;
      [SerializeField] private Animator _animator;
      [SerializeField] private float _value;
    void Start()
    {
        cooldownTimer = 0f;
        player = GameObject.FindGameObjectWithTag("TestPlayer");
            targetlocation = player.GetComponent<Transform>().position;
            rigidbody = GetComponent<Rigidbody>();

        if (health <= 0)
        {
            Debug.Log("Boss is dead!");

           // Destroy(gameObject);
        }
        else
        {
            //keep playing idle animation; 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        getplayerlocation();
        attack();
        move();
    }

    void attack()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer < Cooldown)
        {
            // do nothing
        }
        else  
        {
            if (Vector3.Distance(transform.position, player.transform.position) < range)
            {
            
                // attack player
                Debug.Log("Player in range, attacking!");
            }
            else
            {
                 GameObject projectile = Instantiate(FireBall, transform.position, Quaternion.identity);
            cooldownTimer = 0f; // Reset cooldown timer
            }
        }
           
    }
    void move()
    {
        _name = "Die";
        InvokeTrigger();
        if (Vector3.Distance(transform.position, player.transform.position) < range)
        {
            // Move towards player
            direction = targetlocation - transform.position;
            rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(direction.normalized * speed);
        }
        else
        {
            // Keep course
        }
    }
     void getplayerlocation()
    {
        player = GameObject.FindGameObjectWithTag("TestPlayer");
        targetlocation = player.GetComponent<Transform>().position;
    }

     void InvokeTrigger()
    {
        switch (_type)
        {
            case AnimatorControllerParameterType.Trigger:
                _animator.SetTrigger(_name);
                break;

            case AnimatorControllerParameterType.Float:
                _animator.SetFloat(_name, _value);
                break;
        }
    }

   
}
