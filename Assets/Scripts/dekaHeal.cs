using UnityEngine;

public class dekaHeal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NpcTrigger;
    private EnemyBehaviour enemyBehaviour;
    void Start()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
        NpcTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyBehaviour._isHealed())
        {
            NpcTrigger.SetActive(true);
            Debug.Log("healed dk");
        }
    }
}
