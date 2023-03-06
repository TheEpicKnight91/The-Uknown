using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMain : MonoBehaviour {

    public GameObject timerscript;


    void Start()
    {
        timerscript = GameObject.FindGameObjectWithTag("Timer");
    }

    public void LoadScene(){
        SceneManager.LoadScene("Main Menu");
        Destroy(timerscript);
    }
}
