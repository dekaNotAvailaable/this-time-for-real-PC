using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class EnemyTransform : MonoBehaviour
{
    public MeshRenderer renderOne;
    public MeshRenderer renderTwo;
    private bool transform;
    EnemyHealthSatuts enemyHP;
    // Start is called before the first frame update
    void Start()
    {
        renderOne.enabled = true;
        renderTwo.enabled = false;
        enemyHP= FindObjectOfType<EnemyHealthSatuts>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            transform = !transform;
        }
        renderOne.enabled = !transform;
        renderTwo.enabled = transform;
        if (enemyHP._transformCount() == 1)
        {
            renderOne.enabled = false;
            renderTwo.enabled = true;
        }

    }

}
