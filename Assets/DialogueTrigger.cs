using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueSystem;

    public DialogueObject introDialogue;
    public DialogueObject pickupDialogue;
    public DialogueObject bossDialogue;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            dialogueSystem.gameObject.SetActive(true);
            dialogueSystem.StartDialogue(introDialogue.dialogue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            dialogueSystem.gameObject.SetActive(true);
            dialogueSystem.StartDialogue(pickupDialogue.dialogue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            dialogueSystem.gameObject.SetActive(true);
            dialogueSystem.StartDialogue(bossDialogue.dialogue);
        }
    }
}