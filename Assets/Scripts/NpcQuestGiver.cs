using UnityEngine;

public class NpcQuestGiver : MonoBehaviour
{
    private EnemyScript enemyScript;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        enemyScript = GetComponent<EnemyScript>();
        rb = FindAnyObjectByType<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {

    //    }
    //}
}
