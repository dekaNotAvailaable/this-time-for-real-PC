using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int PlayerHealth = 100;
    private int PlayerStamina = 100;
    private int Score;
    private int objectiveIndex;
    private int lastObjectiveIndex;
    public string[] objectives;
    [HideInInspector]
    public string currentObjective;
    private void Start()
    {
        currentObjective = objectives[objectiveIndex];
        lastObjectiveIndex = objectiveIndex;
    }
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
    public void ObjectiveChanger(bool Value)
    {
        if (Value == true)
        {
            if (objectiveIndex >= lastObjectiveIndex)
            {
                objectiveIndex++;
                lastObjectiveIndex = objectiveIndex;
                Value = false;
            }
        }
    }
    public string Objective()
    {
        return currentObjective;
    }
}
