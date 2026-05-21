using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueSystem;

    public DialogueObject introDialogue;
    public DialogueObject pickupDialogue;
    public DialogueObject bossDialogue;
    public GameObject Princess;
    public GameObject Player;
    public GameObject Boss;
    public int interactiondistance = 3;

void Start()
    {
        Princess = GameObject.FindGameObjectWithTag("Princess");
        Player = GameObject.FindGameObjectWithTag("Player");
        Boss = GameObject.FindGameObjectWithTag("Boss");
         if(Princess || Player || Boss == null){
            Debug.Log("Could not find people");
        } 
           
    }
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.E))
        {
            interaction();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            dialogueSystem.gameObject.SetActive(true);
            dialogueSystem.StartDialogue(pickupDialogue.dialogue);
        }

        
    }
       
        void interaction()

        {  float distance = Vector3.Distance(Princess.transform.position , Player.transform.position);

             if (distance > interactiondistance)
            {
            dialogueSystem.gameObject.SetActive(true);
            dialogueSystem.StartDialogue(introDialogue.dialogue);
            }
        
        }
    public void dialogueforboss()
    {
          dialogueSystem.gameObject.SetActive(true);
            dialogueSystem.StartDialogue(bossDialogue.dialogue);
    }
    public void dialogueforwin()
    {
           dialogueSystem.gameObject.SetActive(true);
            dialogueSystem.StartDialogue(introDialogue.dialogue);
    }
       
    
       
      

    }
    
