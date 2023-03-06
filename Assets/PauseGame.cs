using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    public Transform pausebackground;
    public Transform pausemenu;
    public Transform controls;
    public Transform player;
    public GameObject guncamera;
    public bool cursorlock = true;
    public GameObject GlockIcon;
    public GameObject M4A1Icon;
    public GameObject question;

    void Update () {
		if (Input.GetKeyDown(KeyCode.Z))
        {
            Pause();
        }
	}
    public void quit()
    {
        Application.Quit();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Pause()
    {
        if (pausebackground.gameObject.activeInHierarchy == false && pausemenu.gameObject.activeInHierarchy == false)
        {
            cursorlock = false;
            pausebackground.gameObject.SetActive(true);
            pausemenu.gameObject.SetActive(true);
            Time.timeScale = 0;
            player.GetComponent<FirstPersonController>().enabled = false;
            guncamera.SetActive(false);
            GlockIcon.SetActive(false);
            M4A1Icon.SetActive(false);
            question.SetActive(true);
        }
        else
        {
            cursorlock = true;
            pausebackground.gameObject.SetActive(false);
            pausemenu.gameObject.SetActive(false);
            controls.gameObject.SetActive(false);
            Time.timeScale = 1;
            player.GetComponent<FirstPersonController>().enabled = true;
            guncamera.SetActive(true);
            GlockIcon.SetActive(true);
            M4A1Icon.SetActive(true);
            question.SetActive(false);
        }
        if (cursorlock == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (cursorlock == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void start()
    {
        cursorlock = true;
        pausebackground.gameObject.SetActive(false);
        pausemenu.gameObject.SetActive(false);
        controls.gameObject.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<FirstPersonController>().enabled = true;
        guncamera.SetActive(true);
    }
}
