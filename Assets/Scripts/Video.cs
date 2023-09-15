using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    [HideInInspector]
    public VideoPlayer player;
    public Button[] comicButton;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        for (int i = 0; i < comicButton.Length; i++)
        {
            comicButton[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.url == "Assets/videos/Comic_Scene_1_Trimmed.mp4")
        {
            Debug.Log("url of first vid");
            if (player.isPaused)
            {
                ButtonWithActiveOrNot(0, true);
                ButtonWithActiveOrNot(1, true);
                Debug.Log("is paused button appear");
            }
        }
        else if (player.url == "Assets/videos/Fail_Answer_CORRECT_RESOLUTION.mp4")
        {
            ButtonWithActiveOrNot(0, false);
            ButtonWithActiveOrNot(1, false);
            ButtonWithActiveOrNot(2, true);
            Debug.Log("is playing button disappear");
        }
    }
    void ButtonWithActiveOrNot(int i, bool value)
    {
        if (player.isPaused)
        {
            comicButton[i].gameObject.SetActive(value);
        }
    }
}
