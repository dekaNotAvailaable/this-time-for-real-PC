using System;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Button[] buttons;
    public GameObject parent;
    EnemyDialouge enemyDialouge;
    EnemyScript enemyScript;
    public int _buttonNumber;

    // Start is called before the first frame update
    void Start()
    {
        enemyDialouge = FindAnyObjectByType<EnemyDialouge>();
        enemyScript = FindAnyObjectByType<EnemyScript>();
        // StartDialogue();
        for (int i = 0; i < buttons.Length; i++)
        {
            int mysteryCopy = i;
            // TODO: during C++ labs, revisit this (capture lists...)
            // or google: stackoverflow: C# lambda capture a copy instead of reference
            buttons[i].onClick.AddListener(() => { Button1Clicked(mysteryCopy, enemyDialouge.ifButtonPressed); });
        }
        ButtonOnOff(false);
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
