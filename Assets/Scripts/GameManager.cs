using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int PlayerHealth = 100;
    private int PlayerStamina = 100;
    private int Score;
    [SerializeField]
    private string[] objectives;
    [HideInInspector]
    public string currentObjective;
    public int _PlayerStamina()
    {
        return PlayerStamina;
    }
    public int _Score()
    {
        return Score;
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
    public void ScoreModifier(int Amount)
    {
        Score += Amount;
    }
    public void Objective(string text)
    {
        if (currentObjective == null)
        {
            currentObjective = text;
        }
    }
}
