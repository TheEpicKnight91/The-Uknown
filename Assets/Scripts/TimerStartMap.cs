using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerStartMap : MonoBehaviour
{
    public float seconds, minutes, mil;
    public float startTime = 0;
    private float time;
    public string thetime;
    public PlayerHealthAndAmmo player;
    public bool timerrun;

    void Awake()
    {
      DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {

        startTime = Time.time;
        timerrun = true;

    }

    void Update()
    {
        float t = Time.time - startTime;
        if (player.Current_Health == 0)
        {
            timerrun = false;
        }

            if (timerrun == true)
            {
                int min = ((int)t / 60);
                int sec = ((int)t % 60);
                int fraction = ((int)(t * 100) % 100);
                thetime = string.Format("{00:00}:{1:00}:{2:00}", min, sec, fraction);
            }
    }
}
