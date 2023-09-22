using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gmInstance { get; private set; }

    // Add your GameManager variables and methods here

    private void Awake()
    {
        // Ensure there's only one instance of GameManager
        if (gmInstance == null)
        {
            gmInstance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keep GameManager between scenes
        }
        else
        {
            // If another instance exists, destroy this one
            Destroy(gameObject);
        }
    }
    private int PlayerHealth = 100;
    private int PlayerStamina = 100;
    private int Score;
    private int objectiveIndex = 0;
    private int lastObjectiveIndex;
    public string[] objectives;
    private int naxolin;
    public int _Naxolin()
    {
        return naxolin;
    }
    public int _naxolin
    {
        get { return naxolin; }
        set { naxolin = value; }
    }
    [HideInInspector]
    public string currentObjective;
    private Rigidbody rb;
    private bool isChanged;
    public AudioSource BGM;
    private int lastScore;
    public TextMeshProUGUI highScoreText;
    private void Start()
    {
        currentObjective = objectives[objectiveIndex];
        lastObjectiveIndex = objectiveIndex;
        rb = FindAnyObjectByType<Rigidbody>();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Mansion1.1")
        {
            if (BGM != null)
            {
                BGM.Play();
                BGM.loop = true;
                BGM.volume = 0.5f;
            }
        }
        else if (sceneName == "Mansionv1.2")
        {
            objectiveIndex = 0;
            naxolin = 20;
            if (BGM != null)
            {
                BGM.Play();
                BGM.loop = true;
                BGM.volume = 0.5f;
            }
        }
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
                currentObjective = objectives[objectiveIndex];
                Value = false;
            }
        }
    }
    public string Objective()
    {
        return currentObjective;
    }
    void NaxolinObtain()
    {
        //float distance = Vector3.Distance(rb.position - aidKidDetectionRange);

    }
}
