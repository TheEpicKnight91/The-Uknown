using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JSelection : MonoBehaviour {
    public Toggle Checkbox;
    public GameObject Player;

    void Start()
    {
        Checkbox.isOn = true;
    }

    void Update()
    {
        if (Checkbox.isOn == false)
        {
            Player.GetComponent<Jumpscares>().enabled = false;
        }
        else
        {
            Player.GetComponent<Jumpscares>().enabled = true;
        }
    }
}
