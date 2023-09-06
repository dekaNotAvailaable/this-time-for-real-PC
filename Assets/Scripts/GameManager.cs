using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int PlayerHealth = 100;
    private int PlayerStamina = 100;
    public int _PlayerStamina()
    {
        return PlayerStamina;
    }
    public int _PlayerHealth()
    {
        return PlayerHealth;
    }
    void StaminaModifier(int Amount)
    {
        PlayerStamina += Amount;
    }
    void HealthModifier(int Amount)
    {
        PlayerHealth += Amount;
    }
}
