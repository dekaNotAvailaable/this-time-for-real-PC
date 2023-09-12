using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour, IPointerDownHandler
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    private bool choiceToggle;
    private int dialogueIndex;

    public Button button1;
    public Button button2;

    private string[] currentLines;

    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        dialogueIndex = 0;
        choiceToggle = false;
        currentLines = choiceToggle ? GetLinesForChoice1() : GetLinesForChoice2();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if (dialogueIndex < currentLines.Length)
        {
            textComponent.text = string.Empty;
            foreach (char c in currentLines[dialogueIndex].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            dialogueIndex++;
        }
        else
        {

            choiceToggle = !choiceToggle;
            dialogueIndex = 0;
            currentLines = choiceToggle ? GetLinesForChoice1() : GetLinesForChoice2();
            StartCoroutine(TypeLine());
        }
    }

    void NextLine()
    {
        if (dialogueIndex >= currentLines.Length-1)
        {
            StartCoroutine(TypeLine());
        }
    }

    // Implement these methods to handle button clicks
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerPress.Equals(button1.gameObject))
        {
            // Handle button 1 click
        }
        else if (eventData.pointerPress.Equals(button2.gameObject))
        {
            // Handle button 2 click
        }
    }

    // Replace these methods with your actual dialogue lines for choice 1 and choice 2
    private string[] GetLinesForChoice1()
    {
        return new string[]
        {
            "Choice 1 Line 1",
            "Choice 1 Line 2",
        };
    }

    private string[] GetLinesForChoice2()
    {
        return new string[]
        {
            "Choice 2 Line 1",
            "Choice 2 Line 2",
            // Add more lines for choice 2
        };
    }
}
