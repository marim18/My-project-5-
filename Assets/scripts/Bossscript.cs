using UnityEngine;

public class Bossscript : MonoBehaviour
{
    public Animator animator;
    
    public float health = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   animator = GetComponent<Animator>();

    Debug.Log("Animator Controller: " + animator.runtimeAnimatorController.name);

        foreach (var parameter in animator.parameters)
        {
        Debug.Log("PARAMETER: " + parameter.name + " TYPE: " + parameter.type);
         }
    }
}

    // Update is called once per frame

