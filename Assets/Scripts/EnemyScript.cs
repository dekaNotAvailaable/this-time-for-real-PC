using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScript : MonoBehaviour
{
    NavMeshAgent agent;
    int wayPointIndex;
    public Transform[] wayPoitns;
    Vector3 target;
    private bool wasTalking = false;
    private EnemyBehaviour enemyBehaviour;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        enemyBehaviour = FindAnyObjectByType<EnemyBehaviour>();
    }

    void Update()
    {
        UpdateDestination(); // ----------> this is not ideal. Will fix. getting called every frame making the array so big.
        wasTalking = enemyBehaviour._isTalking;
        if (Vector3.Distance(transform.position, target) < 1)
        {
            ResetWayPointIndex();

        }
        Debug.Log(string.Format("way poiny index : {0} , target: {1}", wayPointIndex, target));
        //else if (!isTalking && wasTalking)
        //{
        //    StartCoroutine(ExecuteUpdateDestination());
        //}
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
    IEnumerator ExecuteUpdateDestination() // --------------> my idea to fix the issue. 
    {
        yield return null;
        UpdateDestination();
    }
}
