using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

    public Light flashlight;

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.F) && flashlight.enabled == false)
        {
            flashlight.enabled = true;
        }

        else if (Input.GetKeyDown(KeyCode.F) && flashlight.enabled == true)
        {
            flashlight.enabled = false;
        }
        }
	}