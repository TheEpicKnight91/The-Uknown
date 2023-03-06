using UnityEngine;
using System.Collections;

public class weaponswitch : MonoBehaviour {

    public GameObject weapon01;
    public GameObject weapon02;
    public Animator armanimations;
    public Animator m4a1animation;
    public Animator m9animation;
    
    void Start () {
        weapon02.SetActive(true);
        weapon01.SetActive(false);
	}
	
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }
	}

    public void SwitchWeapon()
    {
        if (weapon01.activeSelf)
        {
            armanimations.Play("arm grabbing m4A1");
            m4a1animation.Play("Gun Draw");
            weapon01.SetActive(false);
            weapon02.SetActive(true);
        }
        else if (weapon02.activeSelf)
        {
            armanimations.Play("arm grabbing M9");
            m9animation.Play("M9 draw");
            weapon01.SetActive(true);
            weapon02.SetActive(false);
        }
    }
}
