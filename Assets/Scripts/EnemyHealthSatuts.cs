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
    private float timeFollower;
    [SerializeField]
    public float greenMax, greenMin,redMax,redMin,orangeMin,orangeMax,yellowMin,yellowMax;
    private int transformCount;
    public int _transformCount()
    {
        return transformCount;
    }


    void Start()
    {
        timeFollower = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        ColorChanges();
        Debug.Log(transformCount);
    }
    void ColorChanges()
    {
        if (Time.time >= timeFollower + 1)
        {
            
            timeFollower = Time.time;
            green.fillAmount -= Random.Range(greenMin, greenMax);
            if (green.fillAmount <= 0)
            {
                yellow.fillAmount -= Random.Range(yellowMin, yellowMax);
                green.fillAmount = 0;
                transformCount= 1;
            }
            if (yellow.fillAmount <= 0)
            {
                orange.fillAmount -= Random.Range(orangeMin, orangeMax);
                yellow.fillAmount = 0;
                transformCount= 2;
            }
            if (orange.fillAmount <= 0)
            {
                red.fillAmount -= Random.Range(redMin, redMax);
                orange.fillAmount = 0;
                transformCount= 3;
            }
            if (red.fillAmount <= 0)
            {
                red.fillAmount = 0;
            }
        }

    }
}
