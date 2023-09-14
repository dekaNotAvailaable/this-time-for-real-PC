using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    private bool choiceToggle;
    private int dialogueIndex;
    private bool isTyping;
    private string[] currentLines;
    public Button[] buttons;
    public GameObject parent;
    EnemyScript enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        ActiveObject(false);
        enemyScript = FindAnyObjectByType<EnemyScript>();
        // StartDialogue();
        currentLines = OriginalLines();
        for (int i = 0; i < buttons.Length; i++)
        {
            int mysteryCopy = i;
            // TODO: during C++ labs, revisit this (capture lists...)
            // or google: stackoverflow: C# lambda capture a copy instead of reference
            buttons[i].onClick.AddListener(() => { Button1Clicked(mysteryCopy); });
        }
        foreach (Button btn in buttons)
        {
            btn.gameObject.SetActive(false);
        }
    }
    public void ActiveObject(bool activate)
    {
        parent.gameObject.SetActive(activate);
        if (activate == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            StartDialogue();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    void Button1Clicked(int buttonNumber)
    {
        if (buttonNumber == 0)
        {
            Debug.Log("Button clicked: " + buttonNumber);
            currentLines = GetLinesForChoice1();
            dialogueIndex = 0;
            StartCoroutine(TypeLine());
        }
        else if (buttonNumber == 1)
        {
            Debug.Log("Button clicked: " + buttonNumber);
            currentLines = GetLinesForChoice2();
            dialogueIndex = 0;
            StartCoroutine(TypeLine());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isTyping)
        {
            NextLine();
            Debug.Log("after done all text");
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            choiceToggle = !choiceToggle;
        }
        Debug.Log(string.Format("text :{0}, dialouge inex :{1}", currentLines, dialogueIndex));
        //Debug.Log(string.Format(":{0}, :{1}", textComponent.text, currentLines[dialogueIndex]));
        ToggleButtonsVisibility();

    }

    void StartDialogue()
    {
        dialogueIndex = 0;
        choiceToggle = false;

        StartCoroutine(TypeLine());
    }
    IEnumerator EndDialouge()
    {
        if (dialogueIndex >= GetLinesForChoice1().Length || dialogueIndex >= GetLinesForChoice2().Length)
        {
            yield return new WaitForSeconds(1f);
            ActiveObject(false);
            Debug.Log("end starts");
            enemyScript._isTalking = false;
        }
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
                isTyping = true;
            }
            dialogueIndex++;
            isTyping = false;
        }
    }
    void ToggleButtonsVisibility()
    {
        if (dialogueIndex >= OriginalLines().Length)
        {
            Debug.Log("oringal line");
            foreach (Button btn in buttons)
            {
                btn.gameObject.SetActive(true);
            }
        }
        if (currentLines.SequenceEqual(GetLinesForChoice1()) || currentLines.SequenceEqual(GetLinesForChoice2()))
        {
            StartCoroutine(EndDialouge());
            Debug.Log("current line changes");
            foreach (Button btn in buttons)
            {
                btn.gameObject.SetActive(false);
            }
        }
    }

    void NextLine()
    {
        if (dialogueIndex <= currentLines.Length)
        {
            StartCoroutine(TypeLine());

        }
        // else
        // {
        //   gameObject.SetActive(false);
        //}
    }


    public string[] OriginalLines()
    {
        return new string[]
        {
            "original line",
        };
    }
    public string[] GetLinesForChoice1()
    {
        return new string[]
        {
            "Choice 1 Line 1",
            "Choice 1 Line 2",
            "something else ",
        };
    }

    public string[] GetLinesForChoice2()
    {
        return new string[]
        {
            "Choice 2 Line 1",
            "Choice 2 Line 2",
        };
    }
}
