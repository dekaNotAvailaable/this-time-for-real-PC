using System.IO;
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
        //if (player.url == Path.Combine(Application.streamingAssetsPath, "Assets/StreamingAssets/Comic_Panel_1_REVISED_FIX.mp4"))
        //{
        ButtonWithActiveOrNot(true, 0, true);
        ButtonWithActiveOrNot(true, 1, true);
        //}
        //else
        if (player.url == Path.Combine(Application.streamingAssetsPath, "Comic_Panel_2_REVISED_FIX.mp4"))
        {
            ButtonWithActiveOrNot(false, 0, false);
            ButtonWithActiveOrNot(false, 1, false);
            ButtonWithActiveOrNot(false, 3, false);
            ButtonWithActiveOrNot(true, 4, true);

        }
        else if (player.url == Path.Combine(Application.streamingAssetsPath, "Yes_Choice_Footage_REVISED.mp4"))
        {
            ButtonWithActiveOrNot(false, 0, false);
            ButtonWithActiveOrNot(false, 1, false);
            ButtonWithActiveOrNot(true, 2, true);

        }
        else if (player.url == Path.Combine(Application.streamingAssetsPath, "Comic_Panel_1_Yes_Disabled.mp4"))
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
