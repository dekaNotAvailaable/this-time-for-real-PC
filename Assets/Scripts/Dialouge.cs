using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class Dialogue : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public string[] lines1;
    public string[] lines2;
    public float textSpeed;
    private int index;
    private bool choiceToglle;
    public Button button1;
    public Button button2;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        ToggleChoice();
        if (Input.GetMouseButtonDown(1))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void ToggleChoice()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            choiceToglle = true;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            choiceToglle = false;
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
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
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerPress.Equals(button1))
        {
            Debug.Log("button 1 released");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerPress.Equals(button1))
        {
            Debug.Log("button1 being pressed");
        }
    }
}