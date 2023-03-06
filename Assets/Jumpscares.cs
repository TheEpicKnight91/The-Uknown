using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jumpscares : MonoBehaviour
{
    GameObject[] JumpscaresArray = new GameObject[5];
    public GameObject Jumpscare0;
    public GameObject Jumpscare1;
    public GameObject Jumpscare2; // Sets images to include in the array and turn off or on.
    public GameObject Jumpscare3;
    public GameObject Jumpscare4;
    public GameObject JumpscareSound;
    public GameObject JumpscareSelect;
    private float StartTime = 0f;
    public GameObject Brute;
    public GameObject Whisp;
    public GameObject Blinker;
    public GameObject Tank;
    public GameObject Boss;
    public GameObject Player;
    public float JStartTime = 0f;
    public float ScareTime = 0f;
    public GameObject FpsController;

    void Start()
    {
        JumpscaresArray[0] = Jumpscare0;
        JumpscaresArray[1] = Jumpscare1;
        JumpscaresArray[2] = Jumpscare2; // Setting array lists equal to the game-objects.
        JumpscaresArray[3] = Jumpscare3;
        JumpscaresArray[4] = Jumpscare4;
        //JumpscareSound.GetComponent<AudioSource>().Play();
    }

    public void Update()
    {
        JStartTime += Time.deltaTime;
        if (JStartTime >= 120)
        {
            ScareController();
            FpsController.GetComponent<AudioSource>().Play();
            JumpscareSelect.SetActive(true);
            ScareTime += Time.deltaTime;
            if (ScareTime < 2f)
            {
                JumpscareSelect.SetActive(true);
                ScareController(); // Works perfectly except that it's not grabbing a random one. It's just taking the first image.
            }
            if (ScareTime >= 1)
            {
                JumpscareSelect.SetActive(false);
                JStartTime = 0;
                ScareTime = 0;
            }

            //JStartTime = 0;
        }
        else if (JStartTime < 5)
        {
            JumpscareSelect.SetActive(false);
        }
    }

    public void ScareController()
    {
        GameObject RandomlySelectedJumpscare = JumpscaresArray[Random.Range(0, 5)];
        if (Vector3.Distance(this.transform.position, Player.transform.position) >= 20)
        {
            JumpscareSelect.GetComponent<Image>().sprite = RandomlySelectedJumpscare.GetComponent<Image>().sprite;
            JumpscareSelect.SetActive(true);
            
        }
    }
    }