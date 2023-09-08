using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource dialouge;
    public float maxHearDistance = 10f;
    public Rigidbody rb;

    void Update()
    {
        float distance = Vector3.Distance(rb.position, transform.position);
        float volume = 1f - (distance / maxHearDistance);
        volume = Mathf.Clamp01(volume);
        dialouge.volume = volume;
        if (Input.GetKeyUp(KeyCode.E))
        {
            dialouge.Play();
        }
    }
}
