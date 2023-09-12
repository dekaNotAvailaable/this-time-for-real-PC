using UnityEngine;

public class PartyLight :MonoBehaviour
    {
    // Start is called before the first frame update
    Light partyLight;
    private float timeFollower;
    private int red, green, blue;
    void Start()
        {
        timeFollower = Time. time;
        partyLight = GetComponent<Light>();
        }

    // Update is called once per frame
    void Update()
        {
        if(Time. time >= timeFollower + 0.1f)
            {
            red = Random. Range(0,255);
            green = Random. Range(0,255);
            blue = Random. Range(0,255);
            timeFollower = Time. time;
            partyLight. color = new Color(red / 255f,green / 255f,blue / 255f);
            }
        }
    }
