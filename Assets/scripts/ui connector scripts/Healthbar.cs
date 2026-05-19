using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{ /*
    [SerializeField] public GameObject owner;
    [SerializeField] public UnityEngine.UI.Slider healthbarobject;
    private Healthbar healthbar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      //  getobjectwtihtag getobjectwthtag = new getobjectwithtag(healthbar);
       gameobject healthbar = getobjectwthtag.getobjectwithtag(healthbar);
        
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

    // Update is called once per frame
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
    


        // Here you would typically update the health bar's visual representation based on the owner's health
        // For example, if the owner has a health component, you could do something like:
        // float healthPercentage = owner.GetComponent<HealthComponent>().currentHealth / owner.GetComponent<HealthComponent>().maxHealth;
        // Update the health bar UI based on healthPercentage
    }Æ*/
}
