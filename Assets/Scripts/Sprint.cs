using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Sprint : MonoBehaviour {
    float Stamina = 5;
    float MaxStamina = 5;
    private bool IsRunning;
    public Slider SprintBar;
    private float RunSpeed = 3f;
    private float Subtraction = 1f;
    public GameObject PauseScreen;
    public GameObject PauseBackround;
    public Animator armtorchanimation;
    public Animator torchanimations;

	void Start ()
    {
        SprintBar.enabled = false;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.D))
       {
            armtorchanimation.Play("arm torch walking");
           torchanimations.Play("torch walking");
        }
        if (PauseScreen.activeSelf)
        {
            SprintBar.value += 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SprintBar.enabled = true;
            IsRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            float m_WalkSpeed = 2;
            IsRunning = false;
            SprintBar.value += 2 * Time.deltaTime;
            GetComponent<FirstPersonController>().m_RunSpeed = m_WalkSpeed;
        }
        if (IsRunning)
        {
            SprintBar.enabled = true;
            SprintBar.value -= 1.5f * Time.deltaTime;
        }
        if (SprintBar.value <= 0)
        {
            GetComponent<FirstPersonController>().m_RunSpeed = 2;
        }
        else if (Stamina < MaxStamina)
        {
            SprintBar.value += 2 * Time.deltaTime;
        }
        if (IsRunning == false && PauseScreen.activeInHierarchy == false && PauseBackround.activeInHierarchy == false)
        {
            SprintBar.value += 0.04f;
        }
        if (SprintBar.value > 0)
        {
            GetComponent<FirstPersonController>().m_RunSpeed = 5;
        }
    }
	}

