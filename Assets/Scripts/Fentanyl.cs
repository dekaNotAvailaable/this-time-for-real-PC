using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fentanyl : MonoBehaviour
{
    public float HP = 5;

    public void TakeDamage(float damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}