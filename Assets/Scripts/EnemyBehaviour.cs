using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public Image red;
    public Image green;
    public Image yellow;
    public Image orange;
    private float timeFollower;
    [SerializeField]
    public float greenMax, greenMin, redMax, redMin, orangeMin, orangeMax, yellowMin, yellowMax;
    private int transformCount;
    public MeshRenderer renderOne;
    public MeshRenderer renderTwo;
    public MeshRenderer renderThree;
    private float zDegree;
    public GameObject lastForm;
    private bool hasRotated;
    public EnemyScript enemyScript;
    private bool isDead;
    GameManager gm;
    public bool _isDead()
    {
        return isDead;
    }
    void Start()
    {
        timeFollower = Time.time;
        renderOne.enabled = true;
        renderTwo.enabled = false;
        renderThree.enabled = false;
        hasRotated = false;
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ColorChanges();
        EnemyTransform();
        Debug.Log(transformCount);
        TemporaryFunction();
    }
    void ColorChanges()
    {
        if (Time.time >= timeFollower + 1 && !isDead)
        {
            timeFollower = Time.time;
            green.fillAmount -= Random.Range(greenMin, greenMax);
            if (green.fillAmount <= 0)
            {
                yellow.fillAmount -= Random.Range(yellowMin, yellowMax);
                green.fillAmount = 0;
                transformCount = 1;
            }
            if (yellow.fillAmount <= 0)
            {
                orange.fillAmount -= Random.Range(orangeMin, orangeMax);
                yellow.fillAmount = 0;
                transformCount = 2;
            }
            if (orange.fillAmount <= 0)
            {
                red.fillAmount -= Random.Range(redMin, redMax);
                orange.fillAmount = 0;
                //transformCount = 3;
            }
            if (red.fillAmount <= 0 && !hasRotated)
            {
                isDead = true;
                red.fillAmount = 1;
                hasRotated = true;
                zDegree = 90;
                EnemyDie();
            }
        }
    }
    void TemporaryFunction()
    {
        if (Input.GetKeyUp(KeyCode.F) && transformCount == 3)
        {
            transformCount -= 2;
            // Mathf.Clamp(transformCount, 0, 3);
            gm.ScoreModifier(1);
        }
    }
    private void EnemyDie()
    {
        transformCount = 3;
        lastForm.transform.rotation = Quaternion.Euler(0, 0, zDegree);
        enemyScript.MovementControl(transform.position);
    }
    void EnemyTransform()
    {
        if (transformCount == 1)
        {
            renderOne.enabled = false;
            renderTwo.enabled = true;
            renderThree.enabled = false;
            //isDead = false;
        }
        else if (transformCount == 2)
        {
            renderTwo.enabled = false;
            renderThree.enabled = true;
        }
    }
}
