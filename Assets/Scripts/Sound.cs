 using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

    public float DelayTime = 8;
    private float counter = 0;
    private AudioSource m_AudioSource;
    [SerializeField]
    private AudioClip m_ShootSound;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void PlayShootSound()
    {
        m_AudioSource.clip = m_ShootSound;
        m_AudioSource.Play();


    }

    void Update()
    {

            if (Input.GetKey(KeyCode.Mouse0) && counter > DelayTime)
            {
                PlayShootSound();
            counter = 0;
            }
        counter += Time.deltaTime;
        }
    }