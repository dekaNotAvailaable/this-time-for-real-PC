using UnityEngine;

public class Particles :MonoBehaviour
    {
    private ParticleSystem particleSystem;
    private GameManager gm;
    bool particleOnOff;

    void Start()
        {
        particleSystem = GetComponent<ParticleSystem>();
        gm = FindObjectOfType<GameManager>();
        }

    void Update()
        {
        if(Input. GetKeyUp(KeyCode. Mouse0))
            {
            particleOnOff = !particleOnOff;
            Debug. Log(particleOnOff);
            }
        if(particleOnOff)
            {
            particleSystem. gameObject. SetActive(true);

            }
        else
            {
            particleSystem. gameObject. SetActive(false);

            }
        }
    }
