using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    bool ready = true;
    bool loaded = true;
    int rounds = 12;
    float rate = 1/2f;
    float last;
    float loadspeed = 3f;
    float Loading;
    bool loader;
    public Text Ammo;
    private void Start()
    {
     
    }

    void Update()
    {
       
        Ammo.text = rounds.ToString();
        firespeed();
        if (ready == true && loaded == true && Input.GetMouseButton(0)) 
      {
       FireRay();
       rounds -= 1;
       ready = false;
       Debug.Log("fired");
       }

    

        if (Input.GetKey("r"))
        {
            loader = true;
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

    void FireRay()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {

            hit.collider.gameObject.GetComponent<Fentanyl>()?.TakeDamage(1);
                
            
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
