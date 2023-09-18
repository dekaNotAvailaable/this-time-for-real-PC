using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScript : MonoBehaviour
{
    NavMeshAgent agent;
    int wayPointIndex;
    public Transform[] wayPoitns;
    Vector3 target;
    //private bool wasTalking = false;
    private EnemyDialouge enemyDialouge;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        enemyDialouge = FindAnyObjectByType<EnemyDialouge>();
    }

    void Update()
    {
        //   wasTalking = enemyDialouge._isTalking;
        if (Vector3.Distance(transform.position, target) < 1)
        {
            ResetWayPointIndex();
            UpdateDestination(); // ----------> this is not ideal. Will fix. getting called every frame making the array so big. 
        }
        // Debug.Log(string.Format("way poiny index : {0} , target: {1}", wayPointIndex, target));
        //else if (!isTalking && wasTalking)
        //{
        //    StartCoroutine(ExecuteUpdateDestination());
        //}
    }
    public void MovementControl(Vector3 vector3)
    {
        agent.SetDestination(vector3);
    }
    public void UpdateDestination()
    {
        // if (isTalking == false)
        //{
        target = wayPoitns[wayPointIndex].position;
        MovementControl(target);
        Debug.Log("updating destination");
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
    IEnumerator ExecuteUpdateDestination() // --------------> my idea to fix the issue. 
    {
        yield return null;
        UpdateDestination();
    }
}
