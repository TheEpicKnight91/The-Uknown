using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class WhispProximity : MonoBehaviour
{
    public Transform Player;
    public SkinnedMeshRenderer Invisibility;

    void Start()
    {
        Vector3 Position = new Vector3(Random.Range(170f, 4f), 1.5f, Random.Range(170f, 6f));
        this.transform.position = Position;
    }

    void Update()
    {
        if (Vector3.Distance(Player.position, this.transform.position) > 15 && GetComponent<WhispProximity>())
        {
            Invisibility.GetComponent<SkinnedMeshRenderer>().enabled = false;
            transform.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;
            transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = Player.position;
        }

        else if (Vector3.Distance(Player.position, this.transform.position) < 15)
        {
            //transform.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
            Invisibility.GetComponent<SkinnedMeshRenderer>().enabled = true;
            transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = Player.position;
            //AudioSource audio = GetComponent<AudioSource>();
            //audio.Play();
        }
        if (Vector3.Distance(Player.position, this.transform.position) <= 4)
        {
            transform.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
        if (this.transform.GetComponent<EnemyHealth>().Current_Health <= 0)
        {
            Invisibility.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
    }
}