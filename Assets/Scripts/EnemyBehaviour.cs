using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{
    private float redValue = 100f;
    private float greenValue = 100f;
    private float yellowValue = 100f;
    private float orangeValue = 100f;
    private float timeFollower;
    [SerializeField]
    public float greenMax, greenMin, redMax, redMin, orangeMin, orangeMax, yellowMin, yellowMax;
    private int transformCount;
    private float zDegree;
    public GameObject lastForm;
    public GameObject fisrtForm;
    private bool hasRotated;
    private EnemyScript enemyScript;
    private bool isDead;
    private bool hasPlayed = false;
    private bool isHealed;
    NavMeshAgent _navMeshAgent;
    public bool _isHealed()
    {
        return isHealed;
    }
    GameManager gm;
    private Rigidbody rb;
    public float maxHearDistance = 10f;
    public AudioSource dialogueAudio;
    private Animator _animation;
    public bool _isDead()
    {
        return isDead;
    }
    void Start()
    {
        if (lastForm != null)
        {
            lastForm.SetActive(false);
        }
        _navMeshAgent = GetComponent<NavMeshAgent>();
        rb = FindAnyObjectByType<Rigidbody>();
        timeFollower = Time.time;
        hasRotated = false;
        gm = FindAnyObjectByType<GameManager>();
        enemyScript = GetComponent<EnemyScript>();
        _animation = GetComponentInChildren<Animator>();


    }
    // Update is called once per frame
    void Update()
    {
        ColorChanges();
        EnemyTransform();
    }

    void ColorChanges()
    {
        if (Time.time >= timeFollower + 1 && !isDead)
        {
            timeFollower = Time.time;
            greenValue -= UnityEngine.Random.Range(greenMin, greenMax);
            if (greenValue <= 0)
            {
                yellowValue -= UnityEngine.Random.Range(yellowMin, yellowMax);
                greenValue = 0;
                transformCount = 1;
            }
            if (yellowValue <= 0)
            {
                orangeValue -= UnityEngine.Random.Range(orangeMin, orangeMax);
                yellowValue = 0;
                transformCount = 2;
            }
            if (orangeValue <= 0)
            {
                redValue -= UnityEngine.Random.Range(redMin, redMax);
                orangeValue = 0;
            }
            if (redValue <= 0 && !hasRotated)
            {
                isDead = true;
                redValue = 1;
                hasRotated = true;
                zDegree = 90;
                EnemyDie();
            }
        }
    }
    IEnumerator EnemyDespawn()
    {
        if (this != null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "Mansionv1.2")
            {
                yield return new WaitForSeconds(2);
                Destroy(lastForm);
            }
        }
    }
    public void ReviveEnemy()
    {
        float distance = Vector3.Distance(transform.position, rb.position);
        if (distance <= 3)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (gm._naxolin >= 1)
                {
                    transformCount -= 2;
                    gm.ScoreModifier(1);
                    isHealed = true;
                    gm._naxolin--;
                    gm.ObjectiveChanger(true);
                    isDead = false;
                    lastForm.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
        if (isHealed)
        {
            //  StartCoroutine(EnemyDespawn());
        }
    }
    private void EnemyDie()
    {
        transformCount = 3;
        lastForm.transform.rotation = Quaternion.Euler(-zDegree, 0, zDegree);
        if (isDead)
        {
            AnimationStop();
            Debug.Log("dead disable animator");
            if (enemyScript != null)
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
                Debug.Log("die");
            }
        }
    }
    public void AnimationStop()
    {
        if (_animation != null)
        {
            _animation.GetComponentInChildren<Animator>().enabled = false;
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
        else if (transformCount == 3)
        {
            ReviveEnemy();
            lastForm.SetActive(true);
            fisrtForm.SetActive(false);
        }
    }
    public void EnemyAudioText()
    {
        float distance = Vector3.Distance(transform.position, rb.position);
        float volume = 1f - (distance / maxHearDistance);
        volume = Mathf.Clamp01(volume);
        if (dialogueAudio != null)
        {
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

}
