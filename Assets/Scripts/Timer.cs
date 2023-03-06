using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

    public Text counterText;
    public float seconds, minutes, hours;
    public GameObject Brute;
    public GameObject Whisp;
    public GameObject Blinker;
    public GameObject Tank;
    public GameObject Player;

    void Start () {
        counterText = GetComponent<Text>() as Text;
	}
	
	void Update () {
            minutes = (int)(Time.deltaTime / 60f);
            seconds = (int)(Time.deltaTime % 60f);
            hours = (int)(Time.deltaTime / 3600) % 24;
            counterText.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
            /*if (counterText.text == hours.ToString("00") + ":" + minutes.ToString("05") + ":" + seconds.ToString("00"))
            {
                Brute.transform.position = Player.transform.position;
                Brute.transform.position += Vector3.right;
                Whisp.transform.position = Player.transform.position;
                Whisp.transform.position += Vector3.right;
                Blinker.transform.position = Player.transform.position;
                Blinker.transform.position += Vector3.right;
                Tank.transform.position = Player.transform.position;
                Tank.transform.position += Vector3.right;
            }*/
	}
}
