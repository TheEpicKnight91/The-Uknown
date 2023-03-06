using UnityEngine;
using System.Collections;
using Image=UnityEngine.UI.Image;

public class HealthPointsScript : MonoBehaviour {
    Image HealthBar;
    float tmpHealth=1;
	// Use this for initialization
	void Start () {
        HealthBar=GameObject.Find("mainCamera").transform.Find("Canvas").Find("Health Bar").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        HealthBar.fillAmount = tmpHealth;
	}
    public void ChangeHealth()
    {
        tmpHealth = Random.Range(0f, 1f);
    }
}
