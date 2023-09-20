using UnityEngine;

public class DealerNpc : MonoBehaviour
{
    // public TextMeshProUGUI dealer;
    public Rigidbody rb;
    public SceneChange sceneChanger;
    // Start is called before the first frame update
    void Start()
    {
        //dealer = GetComponent<TextMeshProUGUI>();
        if (rb == null)
        {
            rb = FindAnyObjectByType<Rigidbody>();
        }
        ///  dealer.color = Color.white;
        //  dealer.text = "Press E to catch";
        //  sceneChanger = FindAnyObjectByType<SceneChange>();
    }

    // Update is called once per frame
    void Update()
    {
        //float distance = Vector3.Distance(transform.position, rb.position);
        //Debug.Log(distance);
        //if (distance <= 1.4f)
        //{
        //    // dealer.enabled = true;

        //    sceneChanger.SceneChanger("comic dealer");

        //    Debug.Log("scene change");
        //}
    }
}
