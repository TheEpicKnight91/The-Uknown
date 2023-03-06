using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class CarProximity : MonoBehaviour
{
    public GameObject Alarm;
    public GameObject Brute;
    public GameObject Tank;
    public GameObject Blinker;
    public GameObject Whisp;
    Vector3 Position = new Vector3(26, 1.5f, 90);

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Alarm.GetComponent<AudioSource>().Play();
            Brute.transform.position = Position;
            Tank.transform.position = Position;
            Blinker.transform.position = Position;
            Whisp.transform.position = Position;
        }
    }
}