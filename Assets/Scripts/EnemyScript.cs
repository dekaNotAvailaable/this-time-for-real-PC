using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScript : MonoBehaviour
{
    NavMeshAgent agent;
    int wayPointIndex;
    public Transform[] wayPoitns;
    Vector3 target;
    public AudioSource dialouge;
    public float maxHearDistance = 10f;
    public float maxSeeDistance = 3f;
    public Rigidbody rb;
    public TextMeshProUGUI textTalk;
    private bool isTalking = false;
    public bool _isTalking
    {
        get { return _isTalking; }
        set { isTalking = value; }
    }
    private bool wasTalking = false;
    private EnemyBehaviour enemyBehaviour;
    public Dialogue dialogue;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        textTalk.enabled = false;
        isTalking = false;
        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }

    void Update()
    {
        if (enemyBehaviour._isDead() == false)
        {
            UpdateDestination(); // ----------> this is not ideal. Will fix. getting called every frame making the array so big.
        }
        wasTalking = isTalking;
        if (Vector3.Distance(transform.position, target) < 1)
        {
            ResetWayPointIndex();
        }
        if (isTalking)
        {
            MovementControl(transform.position);
        }
        //else if (!isTalking && wasTalking)
        //{
        //    StartCoroutine(ExecuteUpdateDestination());
        //}
        EnemyAudioText();
    }

    public void MovementControl(Vector3 vector3)
    {
        agent.SetDestination(vector3);
    }
    void UpdateDestination()
    {
        // if (isTalking == false)
        //{
        target = wayPoitns[wayPointIndex].position;
        MovementControl(target);
        //  }
    }
    void ResetWayPointIndex()
    {
        wayPointIndex++;
        if (wayPointIndex == wayPoitns.Length)
        {
            wayPointIndex = 0;
        }
    }
    void EnemyAudioText()
    {
        float distance = Vector3.Distance(rb.position, transform.position);
        float volume = 1f - (distance / maxHearDistance);
        volume = Mathf.Clamp01(volume);
        dialouge.volume = volume;
        if (Input.GetKeyUp(KeyCode.E))
        {
            dialouge.Play();
            isTalking = true;
            dialogue.ActiveObject(true);
        }
        if (!dialouge.isPlaying)
        {
            //isTalking = false;
        }
        if (distance <= maxSeeDistance)
        {
            textTalk.enabled = true;

        }
        else
        { textTalk.enabled = false; }
    }
    IEnumerable ExecuteUpdateDestination() // --------------> my idea to fix the issue. 
    {
        yield return new WaitForSeconds(1);
        UpdateDestination();
    }
}
