using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingtimertext : MonoBehaviour {

    public Text timer;
    public TimerStartMap timescript;

	void Start () {
		
	}
	
	void Update () {
        timer.text = timescript.thetime;
	}
}
