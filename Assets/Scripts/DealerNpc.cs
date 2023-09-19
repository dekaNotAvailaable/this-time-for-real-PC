using TMPro;
using UnityEngine;

public class DealerNpc : MonoBehaviour
{
    public TextMeshProUGUI dealer;
    Rigidbody rb;
    public SceneChange sceneChanger;
    // Start is called before the first frame update
    void Start()
    {
        //dealer = GetComponent<TextMeshProUGUI>();
        rb = FindAnyObjectByType<Rigidbody>();
        dealer.color = Color.white;
        dealer.text = "Press E to catch";
        //  sceneChanger = FindAnyObjectByType<SceneChange>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, rb.position);
        if (distance <= 3)
        {
            // dealer.enabled = true;
            if (Input.GetKeyUp(KeyCode.E))
            {
                sceneChanger.SceneChanger("Comic Scene");
            }
            Debug.Log("scene change");
        }
    }
}
