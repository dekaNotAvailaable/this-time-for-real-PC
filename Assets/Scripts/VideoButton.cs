using UnityEngine;
using UnityEngine.Video;

public class VideoButton : MonoBehaviour
{
    // Start is called before the first frame update
    public string videoPath;
    private Video videoScript;
    void Start()
    {
        videoScript = FindAnyObjectByType<Video>();
    }

    // Update is called once per frame
    void Update()
    {
        //  ButtonOnClick(videoPath);
    }
    public void ButtonOnClick(string text)
    {
        Debug.Log("button pressed video url" + videoPath);
        videoPath = text;
        videoScript.player.source = VideoSource.Url;
        videoScript.player.url = Application.streamingAssetsPath + text;
    }
}
