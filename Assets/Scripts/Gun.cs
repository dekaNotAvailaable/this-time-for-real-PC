using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    bool ready = true;
    bool loaded = true;
    int rounds = 12;
    float rate = 1 / 2f;
    float last;
    float loadspeed = 3f;
    float Loading;
    bool loader;
    public Text Ammo;

    void Update()
    {

        Ammo.text = rounds.ToString();
        firespeed();
        if (ready == true && loaded == true && Input.GetMouseButton(0))
        {

            rounds -= 1;
            ready = false;
            Debug.Log("fired");
        }
        if (Input.GetKey("r"))
        {
            loader = true;
            loaded = false;
        }
        Debug.Log("loading =" + Loading);
        if (loader == true)
        {
            Loading += Time.deltaTime;
        }
        if (Loading >= loadspeed)
        {
            rounds = 12;
            loaded = true;
            Debug.Log("reloaded");
            Debug.Log("rounds =" + rounds);
            loader = false;
            Loading = 0;
        }
        if (rounds <= 0)
        {
            loaded = false;
        }
    }

    void firespeed()
    {
        if (Time.time > rate + last)
        {
            ready = true;
            last = Time.time;
        }
    }
}
