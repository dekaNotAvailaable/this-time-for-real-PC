using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    //  public string level;
    public string sceneName;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneChanger(sceneName);
        }
    }
    public void SceneChanger(string scenename)
    {
        sceneName = scenename;
        SceneManager.LoadScene(scenename);
        Debug.Log("scene change");
        if (sceneName == "quit")
        {
            Debug.Log("quit");
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
