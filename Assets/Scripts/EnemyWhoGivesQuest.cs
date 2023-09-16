using UnityEngine;

public class EnemyWhoGivesQuest : MonoBehaviour
{
    EnemyBehaviour enemyBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyBehaviour.InteractiveDistance();
    }
}
