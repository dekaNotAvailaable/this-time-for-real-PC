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
        if (player.url == "Assets/videos/Comic_Panel_1.mp4")
        {
            ButtonWithActiveOrNot(true, 0, true);
            ButtonWithActiveOrNot(true, 1, true);
        }
        else if (player.url == "Assets/videos/Comic_Scene_2_with_Button.mp4")
        {
            ButtonWithActiveOrNot(false, 0, false);
            ButtonWithActiveOrNot(false, 1, false);
            ButtonWithActiveOrNot(false, 3, false);
            ButtonWithActiveOrNot(true, 4, true);

        }
        else if (player.url == "Assets/videos/Fail_Answer_CORRECT_RESOLUTION.mp4")
        {
            ButtonWithActiveOrNot(false, 0, false);
            ButtonWithActiveOrNot(false, 1, false);
            ButtonWithActiveOrNot(true, 2, true);

        }
        else if (player.url == "Assets/videos/Comic_Scene_1_Yes_Removed (1).mp4")
        {
            ButtonWithActiveOrNot(false, 2, false);
            ButtonWithActiveOrNot(true, 3, true);
        }
    }
    void ButtonWithActiveOrNot(bool isPaused, int i, bool value)
    {
        isPaused = isPaused ? player.isPaused : player.isPlaying;
        if (isPaused)
        {
            comicButton[i].gameObject.SetActive(value);
        }
    }
}
