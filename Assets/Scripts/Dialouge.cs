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
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int mysteryCopy = i;
            // TODO: during C++ labs, revisit this (capture lists...)
            // or google: stackoverflow: C# lambda capture a copy instead of reference
            buttons[i].onClick.AddListener(() => { Button1Clicked(mysteryCopy); });
        }
        StartDialogue();
    }

    void Button1Clicked(int buttonNumber)
    {
        Debug.Log("Button clicked: " + buttonNumber);
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