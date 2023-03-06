using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingover : MonoBehaviour {

    public GameObject timerscript;

	// Use this for initialization
	void Start () {
        timerscript = GameObject.FindGameObjectWithTag("Timer");
    }

    public void deletetimer()
    {
        Destroy(timerscript);
    }
}
