using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class EnemyDialouge : MonoBehaviour
{
    private string[] currentLines;
    private int dialogueIndex;
    private bool isTyping;
    public string[] firstLines;
    public string[] choiceFirst;
    public string[] choiceSecond;
    public float textSpeed;
    private bool hasDialougeStarted;
    public GameObject dialougeBox;
    private EnemyBehaviour enemyBehaviour;
    public float maxSeeDistance = 3f;
    public TextMeshProUGUI pressToTalk;
    public TextMeshProUGUI dialougeText;
    private bool hasTalked;
    private Rigidbody rb;
    private bool isTalking = false;
    private EnemyScript enemyScript;
    public Dialogue dialogueTxt;
    public bool _isTalking
    {
        get { return isTalking; }
        set { isTalking = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        ActiveObject(false);
        currentLines = OriginalLines();
        enemyBehaviour = GetComponent<EnemyBehaviour>();
        rb = FindAnyObjectByType<Rigidbody>();
        pressToTalk.enabled = false;
        enemyScript = GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        ToggleButtonsVisibility();
        StopDuringTalk();
        InteractiveDistance();
    }
    public void InteractiveDistance()
    {
        float distance = Vector3.Distance(transform.position, rb.position);
        // Debug.Log(distance);
        if (distance <= maxSeeDistance)
        {
            pressToTalk.enabled = true;
            enemyBehaviour.ReviveEnemy();
            enemyBehaviour.EnemyAudioText();
            if (Input.GetMouseButtonDown(1) && !isTyping)
            {
                NextLine();
            }
            if (!hasTalked)
            {
                hasTalked = true;
                isTalking = true;
            }
        }
        else
        { pressToTalk.enabled = false; }
    }
    public string[] OriginalLines()
    {
        return firstLines;
    }
    public string[] GetLinesForChoice1()
    {
        return choiceFirst;
    }
    public string[] GetLinesForChoice2()
    {
        return choiceSecond;
    }
    void StartDialogue()
    {
        dialogueIndex = 0;
        hasDialougeStarted = true;
        StartCoroutine(TypeLine());
        Debug.Log("StartDialuige");
    }
    public void NextLine()
    {
        if (dialogueIndex <= currentLines.Length)
        {
            StartCoroutine(TypeLine());
        }
    }
    IEnumerator TypeLine()
    {
        if (dialogueIndex < currentLines.Length)
        {
            dialougeText.text = string.Empty;
            foreach (char c in currentLines[dialogueIndex].ToCharArray())
            {
                dialougeText.text += c;
                yield return new WaitForSeconds(textSpeed);
                isTyping = true;
            }
            dialogueIndex++;
            isTyping = false;
        }
    }
    IEnumerator EndDialouge()
    {
        if (currentLines.SequenceEqual(GetLinesForChoice1()))
        {
            if (dialogueIndex >= GetLinesForChoice1().Length)
            {
                yield return new WaitForSeconds(1f);
                ActiveObject(false);
                _isTalking = false;
                enemyScript.UpdateDestination();
            }
        }
        else if (currentLines.SequenceEqual(GetLinesForChoice2()))
        {
            if (dialogueIndex >= GetLinesForChoice2().Length)
            {
                yield return new WaitForSeconds(1f);
                ActiveObject(false);
                _isTalking = false;
                enemyScript.UpdateDestination();
            }
        }
    }
    public void ActiveObject(bool activate)
    {
        dialougeBox.gameObject.SetActive(activate);
        if (activate == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (!hasDialougeStarted)
            {
                StartDialogue();
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void ToggleButtonsVisibility()
    {
        if (dialogueIndex >= OriginalLines().Length)
        {
            dialogueTxt.ButtonOnOff(true);
        }
        if (currentLines.SequenceEqual(GetLinesForChoice1()) || currentLines.SequenceEqual(GetLinesForChoice2()))
        {
            StartCoroutine(EndDialouge());
            dialogueTxt.ButtonOnOff(false);
        }
        Debug.Log("toggle button visibilty");
    }
    public void ifButtonPressed()
    {
        if (dialogueTxt._buttonNumber == 0)
        {
            currentLines = GetLinesForChoice1();
            dialogueIndex = 0;
            StartCoroutine(TypeLine());
        }
        else if (dialogueTxt._buttonNumber == 1)
        {
            currentLines = GetLinesForChoice2();
            dialogueIndex = 0;
            StartCoroutine(TypeLine());
        }
    }
    void StopDuringTalk()
    {
        if (isTalking)
        {
            enemyScript.MovementControl(transform.position);
            ActiveObject(true);
        }
        //else if (!isTalking && !isDead)
        //{
        //    //enemyScript.UpdateDestination();
        //    Debug.Log("Updates the movement if not dead or talk");
        //}
    }
}
