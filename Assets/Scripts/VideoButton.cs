using UnityEngine;

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
    //public void ButtonOnClick(string text)
    //{
    //    videoPath = text;
    //    videoScript.player.source = VideoSource.Url;
    //    videoScript.player.url = text;
    //}
}
