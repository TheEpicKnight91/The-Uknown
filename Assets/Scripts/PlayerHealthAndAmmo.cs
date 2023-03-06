using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealthAndAmmo : MonoBehaviour
{
    public float Maximum_Health = 100f;
    public float Current_Health = 100f;
    public Transform Player;
    public Slider Bar_Fill;
    public GameObject Firepit;
    public GameObject Blood1;
    public GameObject Blood2;
    public GameObject Blood3;
    public GameObject Blood4;
    public GameObject Arms;

    void Start()
    {
        
    }

    public void HealthLoss(int DamageTaken)
    {
        Arms.GetComponent<AudioSource>().Play();
        Current_Health += DamageTaken;
        Bar_Fill.value = Current_Health;
/*        if (GetComponent<PlayerHealthAndAmmo>().Current_Health < 100)
        {
            Blood1.SetActive(true);
        }

        if (GetComponent<PlayerHealthAndAmmo>().Current_Health <= 75)
        {
            Blood2.SetActive(true);
        }

        if (GetComponent<PlayerHealthAndAmmo>().Current_Health <= 50)
        {
            Blood3.SetActive(true);
        }

        if (GetComponent<PlayerHealthAndAmmo>().Current_Health <= 25)
        {
            Blood4.SetActive(true);
        } */

        if (GetComponent<PlayerHealthAndAmmo>().Current_Health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Sub Scene");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Update()
    {
        if (Vector3.Distance(Firepit.transform.position, this.transform.position) <= 3)
        {
            int DamageTaken = -1;
            HealthLoss(DamageTaken);
        }

        if (this.transform.GetComponent<PlayerHealthAndAmmo>().Current_Health < 100)
        {
            Blood1.SetActive(true);
        }
        if (this.transform.GetComponent<PlayerHealthAndAmmo>().Current_Health == 100)
        {
            Blood1.SetActive(false);
        }
        if (this.transform.GetComponent<PlayerHealthAndAmmo>().Current_Health <= 75)
        {
            Blood2.SetActive(true);
        }
        if (this.transform.GetComponent<PlayerHealthAndAmmo>().Current_Health > 75)
        {
            Blood2.SetActive(false);
        }
        if (this.transform.GetComponent<PlayerHealthAndAmmo>().Current_Health <= 50)
        {
            Blood3.SetActive(true);
        }
        if (this.transform.GetComponent<PlayerHealthAndAmmo>().Current_Health > 50)
        {
            Blood3.SetActive(false);
        }
        if (this.transform.GetComponent<PlayerHealthAndAmmo>().Current_Health <= 25)
        {
            Blood4.SetActive(true);
        }
        if (this.transform.GetComponent<PlayerHealthAndAmmo>().Current_Health > 25)
        {
            Blood4.SetActive(false);
        }
    }
}