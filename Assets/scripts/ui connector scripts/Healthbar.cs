using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{ 
    [SerializeField] public GameObject owner;
    [SerializeField] public UnityEngine.UI.Slider healthbarobject;
    private Healthbar healthbar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      //  getobjectwtihtag getobjectwthtag = new getobjectwithtag(healthbar);
        
            if (healthbarobject == null)        {
                Debug.LogError("Healthbar GameObject reference is missing!");
            }
        
       
        if (owner == null)
        {
            Debug.LogError("Healthbar owner reference is missing!");
            return;
        }
        healthbar.maxHealth = owner.GetComponent<Bossmovementscriptfinal>().maxHealth;
        healthbar.value = maxHealth;
    }


    void Update()
    {
        owner = GameObject.FindWithTag("Boss");
        if (owner == null)
        {
            Debug.LogError("Healthbar owner reference is missing!");
            return;
        }
        
       healthbarobject.value = Mathf.Clamp(owner.currentHealth, 0, owner.maxHealth);
       healthbarobject.maxValue = owner.maxHealth;
    


    }
}
