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
        }

    // Update is called once per frame
    void FixedUpdate()
        {
        ColorChanges();
        Debug.Log(transformCount);
        EnemyTransform();
        }
    void ColorChanges()
        {
        if (Time.time >= timeFollower + 1)
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
                transformCount = 3;
                }
            if (red.fillAmount <= 0 && !hasRotated)
                {
                red.fillAmount = 1;
                hasRotated = true;
                zDegree = 90;
                EnemyDie();
                }
            }
        }
    private void EnemyDie()
        {
        isDead = true;
        lastForm.transform.rotation = Quaternion.Euler(0, 0, zDegree);
        enemyScript.StopMovement();
        }
    void EnemyTransform()
        {
        if (transformCount == 1)
            {
            renderOne.enabled = false;
            renderTwo.enabled = true;
            }
        else if (transformCount == 2)
            {
            renderTwo.enabled = false;
            renderThree.enabled = true;
            }
        }
    }
