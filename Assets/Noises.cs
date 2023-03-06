using UnityEngine;
using System.Collections;

public class Noises : MonoBehaviour
{
    public GameObject Music;
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Music.GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Music.GetComponent<AudioSource>().Stop();
        }
    }
}
