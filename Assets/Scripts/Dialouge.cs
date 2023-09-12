using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
        if (Input.GetKeyUp(KeyCode.T))
        {
            choiceToggle = !choiceToggle;
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
        if (dialogueIndex >= currentLines.Length - 1)
        {
            StartCoroutine(TypeLine());
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerPress.Equals(button1.gameObject))
        {
            Debug.Log("button 1 is pressed");
        }
        else if (eventData.pointerPress.Equals(button2.gameObject))
        {
            Debug.Log("button 2 is pressed");
        }
    }


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
        };
    }
}
