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
        if (player.isPaused)
        {
            for (int i = 0; i < comicButton.Length; i++)
            {
                comicButton[i].gameObject.SetActive(true);
            }
        }
    }

}
