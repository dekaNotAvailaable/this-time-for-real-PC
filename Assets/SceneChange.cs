using UnityEngine;
using UnityEngine. SceneManagement;

public class SceneChange :MonoBehaviour
    {
    // Start is called before the first frame update
    //  public string level;
    void Start()
        {

        }

    // Update is called once per frame
    void Update()
        {
        if(Input. GetKeyUp(KeyCode. R))
            {
            SceneManager. LoadScene("first scene");
            Debug. Log("scene change");
            }
        }
    }
