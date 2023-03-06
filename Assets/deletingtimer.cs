using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deletingtimer : MonoBehaviour {

    public GameObject timerscript;

	// Use this for initialization
	void Start () {
        timerscript = GameObject.FindGameObjectWithTag("Timer");
    }
    public void onsceneLoad()
    {
        Destroy(timerscript);
    }
}
