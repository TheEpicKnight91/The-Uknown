using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamScript : MonoBehaviour {
    public GameObject Player;
    public GameObject Sam;
	void Start ()
    {
        
    }
	
	void Update ()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) <= 6)
        {
            Sam.SetActive(false);
        }
        else
        {
            Sam.SetActive(true);
        }
    }
}
