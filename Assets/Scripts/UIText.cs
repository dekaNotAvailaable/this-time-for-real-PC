using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    TextMeshProUGUI tmpro;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        tmpro.text = string.Format("Revived:{0}", gm._Score());
    }
}
