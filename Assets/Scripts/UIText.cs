using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    TextMeshProUGUI tmpro;
    public TextMeshProUGUI objective;
    public TextMeshProUGUI naxolinCount;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
        gm = FindAnyObjectByType<GameManager>();
        objective.color = Color.white;
        tmpro.color = Color.white;
        naxolinCount.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        objective.text = string.Format(gm.Objective()); ;
        tmpro.text = string.Format(gm._Score().ToString());
        naxolinCount.text = string.Format(gm._naxolin.ToString());
    }
}
