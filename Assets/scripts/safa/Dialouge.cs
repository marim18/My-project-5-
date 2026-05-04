using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameComponent; // NEW

    public float textSpeed;

    private DialogueLine[] lines;
    private int index;

    void Start()
    {
        // Do nothing automatically (we trigger externally now)
    }

    public void StartDialogue(DialogueData dialogue)
    {
        if (dialogue == null || dialogue.lines.Length == 0)
            return;

        lines = dialogue.lines;
        index = 0;

        gameObject.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (lines == null || lines.Length == 0) return;

            if (textComponent.text == lines[index].text)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index].text;
            }
        }
    }

    IEnumerator TypeLine()
    {
        textComponent.text = "";
        nameComponent.text = lines[index].speakerName;

        foreach (char c in lines[index].text)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StopAllCoroutines();
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}