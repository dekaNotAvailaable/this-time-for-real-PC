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
    private float zDegree;
    public GameObject lastForm;
    private bool hasRotated;
    private EnemyScript enemyScript;
    private bool isDead;
    private bool hasPlayed = false;
    private bool isHealed;
    public bool _isHealed()
    {
        return isHealed;
    }
    GameManager gm;
    private Rigidbody rb;
    public float maxHearDistance = 10f;
    public AudioSource dialogueAudio;
    public bool _isDead()
    {
        return isDead;
    }
    void Start()
    {
        rb = FindAnyObjectByType<Rigidbody>();
        timeFollower = Time.time;
        hasRotated = false;
        gm = FindAnyObjectByType<GameManager>();
        enemyScript = FindAnyObjectByType<EnemyScript>();
    }
    // Update is called once per frame
    void Update()
    {
        ColorChanges();
        EnemyTransform();
        ReviveEnemy();
    }

    void ColorChanges()
    {
        Debug.Log(transformCount);
        if (Time.time >= timeFollower + 1 && !isDead)
        {
            timeFollower = Time.time;
            green.fillAmount -= UnityEngine.Random.Range(greenMin, greenMax);
            if (green.fillAmount <= 0)
            {
                yellow.fillAmount -= UnityEngine.Random.Range(yellowMin, yellowMax);
                green.fillAmount = 0;
                transformCount = 1;
            }
            if (yellow.fillAmount <= 0)
            {
                orange.fillAmount -= UnityEngine.Random.Range(orangeMin, orangeMax);
                yellow.fillAmount = 0;
                transformCount = 2;
            }
            if (orange.fillAmount <= 0)
            {
                red.fillAmount -= UnityEngine.Random.Range(redMin, redMax);
                orange.fillAmount = 0;

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
    public void ReviveEnemy()
    {
        float distance = Vector3.Distance(transform.position, rb.position);
        if (distance <= 3)
        {
            if (Input.GetKeyUp(KeyCode.H) && transformCount == 3)
            {
                if (gm._naxolin >= 1)
                {
                    transformCount -= 2;
                    // Mathf.Clamp(transformCount, 0, 3);
                    gm.ScoreModifier(1);
                    isHealed = true;
                    gm._naxolin--;
                    gm.ObjectiveChanger(true);
                }
            }
        }
    }
    private void EnemyDie()
    {
        transformCount = 3;
        lastForm.transform.rotation = Quaternion.Euler(0, 0, zDegree);
        if (isDead)
        {
            // enemyScript.MovementControl(transform.position);
            if (enemyScript != null)
            {
                enemyScript.enabled = false;
                Debug.Log("die");
            }
        }
    }
    void EnemyTransform()
    {
        if (transformCount == 1)
        {
            // MaterialIndexReset();
            //  capsuleRenderer.material = newMaterial[materialIndex + 1];
            //isDead = false;
        }
        else if (transformCount == 2)
        {
            // MaterialIndexReset();
            //  capsuleRenderer.material = newMaterial[materialIndex + 1];
        }
    }
    public void EnemyAudioText()
    {
        float distance = Vector3.Distance(transform.position, rb.position);
        float volume = 1f - (distance / maxHearDistance);
        volume = Mathf.Clamp01(volume);
        dialogueAudio.volume = volume;
        if (!hasPlayed)
        {
            if (!dialogueAudio.isPlaying)
            {
                dialogueAudio.Play();
                hasPlayed = true;
            }
        }
    }

}
