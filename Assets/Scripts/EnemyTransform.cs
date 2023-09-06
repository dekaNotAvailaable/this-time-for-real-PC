using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class EnemyTransform : MonoBehaviour
{
    public MeshRenderer renderOne;
    public MeshRenderer renderTwo;
    private bool transform;
    // Start is called before the first frame update
    void Start()
    {
        renderOne = GetComponent<MeshRenderer>();
        renderTwo = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            transform = !transform;
        }
        if (transform)
        {
            renderOne.enabled = false;
            renderTwo.enabled = true;
        }
        else
        {
            renderOne.enabled = true;
            renderTwo.enabled = false;
        }

    }

}
