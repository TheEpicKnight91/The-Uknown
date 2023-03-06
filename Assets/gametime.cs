using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gametime : MonoBehaviour {

    public Text TimeSurvived;
    public TimerStartMap timerscript;

	void Start () {
        timerscript = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerStartMap>();
        TimeSurvived.text = timerscript.thetime;
	}
	
	void Update ()
    {
		
	}
}
