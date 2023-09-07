using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    //public CapsuleCollider player;
    private int enemyHealth = 100;
    NavMeshAgent agent;
    int wayPointIndex;
    public Transform[] wayPoitns;
    Vector3 target;
    void Start()
    {
        // player = GetComponent<CapsuleCollider>();   
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            ResetWayPointIndex();
            UpdateDestination();
        }
    }
    public void TakeDamage(int Amount)
    {
        enemyHealth += Amount;
    }
    void UpdateDestination()
    {
        target = wayPoitns[wayPointIndex].position;
        agent.SetDestination(target);
    }
    void ResetWayPointIndex()
    {
        wayPointIndex++;
        if (wayPointIndex == wayPoitns.Length)
        {
            wayPointIndex = 0;
        }
    }
}
