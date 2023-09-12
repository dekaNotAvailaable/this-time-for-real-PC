using TMPro;
using UnityEngine;

public class UI :MonoBehaviour
    {
    TextMeshProUGUI tmpro;
    // Start is called before the first frame update
    void Start()
        {
        tmpro = GetComponent<TextMeshProUGUI>();
        }

    // Update is called once per frame
    void Update()
        {
        tmpro. text = "toyota";
        }
    }
