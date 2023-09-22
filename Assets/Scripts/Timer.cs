using TMPro;
using UnityEngine;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float duration = 300f;
    private float elapsedTime;
    SceneChange sceneChanger;
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = duration;
        UpdateTimerText();
        sceneChanger = FindAnyObjectByType<SceneChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            Debug.Log("Timer has reached 0:00");
            sceneChanger.SceneChanger("High Score");
            elapsedTime = 0f;
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}
