using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public CapsuleCollider player;
    private int enemyHealth = 100;
    void Start()
    {
        player = GetComponent<CapsuleCollider>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int Amount)
    {
        enemyHealth += Amount;
    }
}
