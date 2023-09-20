using UnityEngine;

public class FlashLight : MonoBehaviour
{
    // Start is called before the first frame update
    public Light flashLight;
    private bool onOffSwitch;
    void Start()
    {
        flashLight.color = Color.yellow;
        flashLight.intensity = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            onOffSwitch = !onOffSwitch;
        }
        flashLight.enabled = onOffSwitch ? true : false;
    }
}
