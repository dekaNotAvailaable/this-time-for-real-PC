using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    TextMeshProUGUI tmpro;
    public TextMeshProUGUI objective;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
        gm = FindAnyObjectByType<GameManager>();
        objective.color = Color.white;
        tmpro.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        objective.text = string.Format("Current Objective:{0}",);
        tmpro.text = string.Format("Revived:{0}", gm._Score());
    }
}
