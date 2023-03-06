using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyHealth : MonoBehaviour
{
    public float Maximum_Health = 100f;
    public float Current_Health = 0f;
    public int Wave = 0;
    public int BossWave = 0;
    public Transform Player;
    public Animator anim;
    public Slider Bar_Fill;
    public bool AllowMovement;
    private bool EnemyFlee;
    public GameObject Brute;
    public GameObject Whisp;
    public GameObject Blinker;
    public GameObject Tank;
    public GameObject Boss;
    private float FinalTime;
    public bool HealthRegen;
    public NavMeshPath Path;
    public NavMeshPath PlayerPath;
    public ParticleSystem Blood;
    public Slider MonsterHealth;
    public Animator MonsterAnim;
    public bool GotShot;
    public Slider WhispHealth;
    public Slider BlinkerHealth;
    public Slider TankHealth;
    public Slider BruteHealth;
    public Slider BossHealth;
    private List<GameObject> MonsterList;
    public GameObject Monster2;
    public float DeathTime = 0f;
    public GameObject BossPicture;

    void Start()
    {
        AllowMovement = true;
        Current_Health = Maximum_Health;
    }

    public void EnemyHealthLoss()
    {
        print("1");
        Blood.Simulate(5);
        Current_Health -= 25f; // Sets what the script will substract from the health.
        float Calculate_Health = Current_Health / Maximum_Health;
        SetEnemyHealth(Calculate_Health);
        print("Current enemy health is: " + Current_Health);
    }

    public void SetEnemyHealth(float Final_Health)
    {
        print("2");
        Bar_Fill.value = Current_Health;
    }

    public void Update()
    {
        if (Boss.activeSelf == true && this.transform.GetComponent<EnemyHealth>().Current_Health <= 0)
        {
            BossWave += 1;
            transform.GetComponent<EnemyHealth>().Maximum_Health += 100;
            MonsterHealth.GetComponent<Slider>().maxValue += 100;
            transform.GetComponent<EnemyHealth>().Current_Health = transform.GetComponent<EnemyHealth>().Maximum_Health; // Everytime the monster dies, we are adding 300 to their health.
            MonsterHealth.GetComponent<Slider>().value = transform.GetComponent<EnemyHealth>().Maximum_Health;
            Boss.SetActive(true);
            if (this.transform.GetComponent<EnemyHealth>().BossWave == 3)
            {
                SceneManager.LoadScene("Victory Screen");
                Destroy(Player);
                Cursor.lockState = CursorLockMode.None;
            }
        }
        if (this.transform.GetComponent<EnemyHealth>().Current_Health <= 0 && this.transform.GetComponent<EnemyHealth>().Wave < 3 && transform.tag == "Blinker")
        {
            transform.GetComponent<EnemyHealth>().Maximum_Health += 5;
            MonsterHealth.GetComponent<Slider>().maxValue += 5;
            transform.GetComponent<EnemyHealth>().Current_Health = transform.GetComponent<EnemyHealth>().Maximum_Health; // Everytime the monster dies, we are adding 300 to their health.
            MonsterHealth.GetComponent<Slider>().value = transform.GetComponent<EnemyHealth>().Maximum_Health;
            Vector3 position = new Vector3(Random.Range(170f, 4f), 1.0f, Random.Range(170f, 6f));
            Monster2.transform.position = position;
            //this.transform.GetComponent<CapsuleCollider>().enabled = false;
            Wave += 1;
            //DeathTime += Time.deltaTime;
            /*if (DeathTime >= 3)
            {
                this.transform.GetComponent<CapsuleCollider>().enabled = true;
            }*/
        }
            if (this.transform.GetComponent<EnemyHealth>().Current_Health <= 0 && this.transform.GetComponent<EnemyHealth>().Wave == 3 && transform.tag == "Blinker")
        {
            print("2.5");
            Monster2.SetActive(false);
            Monster2.GetComponent<EnemyHealth>().enabled = false;
            Boss.SetActive(true);
        }
        if (Current_Health <= 0)
        {
            if (Boss.GetComponent<EnemyHealth>().Current_Health <= 0)
            {
                this.transform.GetComponent<CapsuleCollider>().enabled = false;
            }
            print("3");
            AllowMovement = false;
            transform.GetComponent<NavMeshAgent>().isStopped = true;
            anim.Play("Dead");
            this.transform.GetComponent<CapsuleCollider>().enabled = false;
            DeathTime += Time.deltaTime;
            if (DeathTime >= 3)// && AllowMovement == false)
            {
                print("4");
                this.transform.GetComponent<CapsuleCollider>().enabled = true;
                Vector3 position = new Vector3(Random.Range(170f, 4f), 1.0f, Random.Range(170f, 6f));
                Monster2.transform.position = position;
                if (position.y > 1.0f)
                {
                    print("5");
                    position.y = 1.0f; // This is trying to correct the monsters getting higher in the air when they respawn.
                }
                print("6");
                DeathTime = 0f;
                transform.GetComponent<EnemyHealth>().Maximum_Health += 100;
                MonsterHealth.GetComponent<Slider>().maxValue += 100;
                transform.GetComponent<EnemyHealth>().Current_Health = transform.GetComponent<EnemyHealth>().Maximum_Health; // Everytime the monster dies, we are adding 300 to their health.
                MonsterHealth.GetComponent<Slider>().value = transform.GetComponent<EnemyHealth>().Maximum_Health;
                Wave += 1;
                anim.Play("Walk");
                AllowMovement = true;
            }
            print("7");
            Blood.Simulate(0);
        }
        if (this.transform.GetComponent<EnemyHealth>().Wave == 3 && this.transform.GetComponent<CapsuleCollider>().enabled == false)
        {
            print("8");
                Monster2.SetActive(false);
                Monster2.GetComponent<EnemyHealth>().enabled = false;
        }
        if (Monster2.activeInHierarchy == false && Wave < 3)
        {
            print("9");
            Wave += 1;
        }
        if (Wave == 3 && Current_Health < Maximum_Health && Current_Health > 0)// || this.transform.GetComponent<EnemyHealth>().BossWave == 3 && this.transform.GetComponent<EnemyHealth>().Current_Health < this.transform.GetComponent<EnemyHealth>().Maximum_Health)
        {
            print("10");
            transform.GetComponent<EnemyHealth>().Current_Health += 0.15f;
            MonsterHealth.GetComponent<Slider>().value = Current_Health;
        }

        if (Blinker.activeInHierarchy == false && Brute.activeInHierarchy == false && Whisp.activeInHierarchy == false && Tank.activeInHierarchy == false && Wave == 3)// && GetComponent<EnemyHealth>().Boss.GetComponent<EnemyHealth>().Wave == 3)
        {
            Boss.SetActive(true);
            print("11");
            GetComponent<PlayerControl>().BossWave += 1;
            if (Current_Health < Maximum_Health && Wave == 3 || BossWave == 3)
            {
                print("12");
                BossHealth.value += 0.05f;
            }
            print("13");
        }
    }

    public void HealthLoss(out int DamageTaken2)
    {
        print("15");
        DamageTaken2 = -10;
            Current_Health += DamageTaken2;
            Bar_Fill.value = Current_Health;
    }
}