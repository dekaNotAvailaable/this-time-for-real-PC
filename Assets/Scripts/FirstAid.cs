using UnityEngine;

public class FirstAid : MonoBehaviour
{
    public GameObject aidsearch;
    public GameObject tutorialaidkit;
    public GameObject aidKit;
    bool text = false;
    bool flopping = false;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        tutorialaidkit.SetActive(false);
        aidsearch.SetActive(false);
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text == true)
        {
            aidsearch.SetActive(true);
        }
        else
        {
            aidsearch.SetActive(false);
        }
        if (text == true && Input.GetKeyUp("e"))
        {
            tutorialaidkit.SetActive(true);
            Debug.Log("flopping");
            flopping = !flopping;
        }
        if (flopping == true && Input.GetKeyUp("e"))
        {
            tutorialaidkit.SetActive(false);
            //saidsearch.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AidKit"))
        {
            text = true;
        }
        else
        {
            text = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AidKit"))
        {
            text = false;
            gm._naxolin += 2;
            gm.ObjectiveChanger(true);
            Destroy(aidKit);
        }
    }
}
