using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grabbingtimerscript : MonoBehaviour {

    public Text timesurvived;
    public TimerStartMap timerscript;

	// Use this for initialization
	void Start () {
        timerscript = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerStartMap>(); 
	}
	
	// Update is called once per frame
	void Update () {
        timesurvived.text = timerscript.thetime;
	}
}
