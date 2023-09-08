using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashLight : MonoBehaviour
{
    // Start is called before the first frame update
    public PartyLight flashLight;
    private bool onOffSwitch;
    void Start()
    {
        flashLight = GetComponent<PartyLight>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.V))
        {
            onOffSwitch = !onOffSwitch;
        }
        flashLight.enabled = onOffSwitch ? true : false;
    }
}
