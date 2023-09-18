using System;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Button[] buttons;
    public GameObject parent;
    EnemyBehaviour enemyBehaviour;
    EnemyScript enemyScript;
    public int _buttonNumber;

    // Start is called before the first frame update
    void Start()
    {
        enemyBehaviour = FindAnyObjectByType<EnemyBehaviour>();
        enemyScript = FindAnyObjectByType<EnemyScript>();
        // StartDialogue();
        for (int i = 0; i < buttons.Length; i++)
        {
            int mysteryCopy = i;
            // TODO: during C++ labs, revisit this (capture lists...)
            // or google: stackoverflow: C# lambda capture a copy instead of reference
            buttons[i].onClick.AddListener(() => { Button1Clicked(mysteryCopy, enemyBehaviour.ifButtonPressed); });
        }
        ButtonOnOff(false);
    }
    // Update is called once per frame
    void Update()
    {

        //  Debug.Log(string.Format("text :{0}, dialouge inex :{1}", currentLines, dialogueIndex));
        //Debug.Log(string.Format(":{0}, :{1}", textComponent.text, currentLines[dialogueIndex]));
        //Debug.Log(enemyBehaviour._isTalking);
    }
    public void ButtonOnOff(bool value)
    {
        foreach (Button btn in buttons)
        {
            btn.gameObject.SetActive(value);
        }
    }
    public void Button1Clicked(int buttonNumber, Action function)
    {
        _buttonNumber = buttonNumber;
        if (buttonNumber == 0)
        {
            function();
        }
        else if (buttonNumber == 1)
        {
            function();
        }
    }

}
