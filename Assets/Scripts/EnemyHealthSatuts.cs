using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSatuts : MonoBehaviour
{
    public Image red;
    public Image green;
    public Image yellow;
    public Image orange;
    private int randomTimeTillColorChange = Random.Range(5, 10);
    private float timeFollower;


    void Start()
    {
        timeFollower = Time.time;


    }

    // Update is called once per frame
    void Update()
    {
        ColorChanges();

    }
    void ColorChanges()
    {
        if (Time.time >= timeFollower + 1)
        {
            timeFollower = Time.time;
            randomTimeTillColorChange--;
            green.fillAmount -= Random.Range(0.02f, 0.1f);
            if (green.fillAmount <= 0)
            {
                yellow.fillAmount -= Random.Range(0.03f, 0.4f);
            }
            if (yellow.fillAmount <= 0)
            {
                orange.fillAmount -= Random.Range(0.06f, 0.6f);
            }
            if (orange.fillAmount <= 0)
            {
                red.fillAmount -= Random.Range(0.09f, 0.65f);
            }
        }

    }
}
