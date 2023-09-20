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
    SC_FPSController playerControl;
    private bool hasTalked;
    private Rigidbody rb;
    private bool isTalking = false;
    private EnemyScript enemyScript;
    public Dialogue dialogueScript;
    private Animator animator;
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
        if (pressToTalk != null)
        {
            pressToTalk.enabled = false;
        }
        enemyScript = GetComponent<EnemyScript>();
        playerControl = FindAnyObjectByType<SC_FPSController>();
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
        //  Debug.Log(distance);
        if (distance <= maxSeeDistance)
        {
            Debug.Log("distance check");
            PresstoTalk();
            enemyBehaviour.ReviveEnemy();
            if (!enemyBehaviour._isDead())
            {
                Debug.Log("is dead?");
                enemyBehaviour.EnemyAudioText();
                if (Input.GetMouseButtonUp(1) && !isTyping)
                {
                    NextLine();
                    Debug.Log("next line");
                }
                if (!hasTalked)
                {
                    hasTalked = true;
                    isTalking = true;
                    Debug.Log("is talking?");
                }
            }
            //if (enemyBehaviour._isHealed())
            //{
            //    isTalking = true;
            //    hasTalked = true;
            //    Debug.Log("npc talk after heal");
            //}
        }
        else
        { if (pressToTalk != null) { pressToTalk.enabled = false; } }
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
        if (currentLines.SequenceEqual(OriginalLines()))
        {
            if (dialogueIndex >= OriginalLines().Length)
            {
                yield return new WaitForSeconds(1f);
                ActiveObject(false);
                _isTalking = false;
                playerControl.triggerNpc = false;
                if (!enemyBehaviour._isDead())
                {
                    enemyScript.UpdateDestination();
                }

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
            //dialogueScript.ButtonOnOff(true);
        }
        if (currentLines.SequenceEqual(OriginalLines()))
        {
            StartCoroutine(EndDialouge());
            if (dialogueScript != null)
            {
                dialogueScript.ButtonOnOff(false);
            }
        }
        Debug.Log("toggle button visibilty");
    }
    public void ifButtonPressed()
    {
        if (dialogueScript._buttonNumber == 0)
        {
            currentLines = GetLinesForChoice1();
            dialogueIndex = 0;
            StartCoroutine(TypeLine());
        }
        else if (dialogueScript._buttonNumber == 1)
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
            // animator.speed = 0;
        }
        else if (!isTalking && !enemyBehaviour._isDead())
        {
            //    //enemyScript.UpdateDestination();
            //    Debug.Log("Updates the movement if not dead or talk");
            // animator.speed = 1f;
        }
    }
    void PresstoTalk()
    {
        if (!hasTalked)
        {
            if (pressToTalk != null)
            {
                pressToTalk.enabled = true;
            }
        }
        if (enemyBehaviour._isDead())
        {
            if (!enemyBehaviour._isHealed())
            {
                if (pressToTalk != null)
                {
                    pressToTalk.text = "Press H to reverse overdose";
                }
            }
        }
        else { if (pressToTalk != null) { pressToTalk.text = "Press F to talk"; } }
    }
}
