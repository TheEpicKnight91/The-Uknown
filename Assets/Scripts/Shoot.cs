using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    private float M4A1fireRate = 0.6f; // Makes a wait time for when they can fire next.
    private float M9fireRate = 0.6f;
    private float M4A1nextFire;
    private float M9nextFire;
    private RaycastHit hit;
    private float range = 3000;
    public Light Muzzle_Flash;
    public ParticleSystem Explosion;
    public bool IsEmmiting;
    public int DamageDealt = 25; // Health taken when he is shot.
    public GameObject MuzzleBall; // Make sure to have the "f" so it doesn't go like 25.64853925 as the hit value.
    public Slider M9_Ammo;
    public Slider M4A1_Ammo;
    public float Maximum_Health = 100f;
    public float Current_Health = 100f;
    private int DamageTaken2;
    public int CurrentM4A1Ammo = 25;
    public int CurrentM9Ammo = 13;
    private int FinalM4A1Ammo;
    private int FinalM9Ammo;
    public GameObject Blinker;
    public GameObject Boss;
    public GameObject M4A1;
    public GameObject M9;
    //public GameObject M4A1Bullet;
    //public GameObject M9Bullet;
    public int M4A1Clips = 3;
    public int M9Clips = 2;
    public bool M4A1CanShoot;
    public bool M9CanShoot;
    public float yFloat = -40.0f;
    public float xFloat = 3.0f;
    public float zFloat = -1.0f;
    public float yFloat2 = 0f;
    public float xFloat2 = 1.0f;
    public float zFloat2 = -0.2f;
    public Animator M4A1animations;
    public Animator M9animations;
    public Camera GunCamera;
    public Animator armanimations;
    public Animator armtorchanimations;
    public Animator torch;
    public bool aim = false;
    public GameObject Cursor;
    public Camera first;
    public GameObject torch1;
    public Sprint sprint;
    public GameObject Arms;
    public weaponswitch ws;
    public GameObject armtorch1;

    void Start()
    {
        M4A1CanShoot = true;
        M9CanShoot = true;
        Muzzle_Flash.enabled = false;
        Explosion.Simulate(0);
        MuzzleBall.SetActive(false);
    }
    void Update()
    {
        //Debug.DrawRay(transform.position, transform.rotation.ToEuler(), Color.blue);
        if (M4A1Clips == 0 && CurrentM4A1Ammo == 0 && M9Clips == 0 && CurrentM9Ammo == 0)
        {
            Arms.SetActive(false);
            M4A1.SetActive(false);
            M9.SetActive(false);
        }

        if (CurrentM4A1Ammo <= 0 && M4A1Clips <= 0)
        {
            M4A1.SetActive(false);
            if (CurrentM9Ammo > 0 || M9Clips > 0)
            {
                M9.SetActive(true);
            }
        }

        if (CurrentM9Ammo <= 0 && M9Clips <= 0)
        {
            if (CurrentM4A1Ammo > 0 || M4A1Clips > 0)
            {
                M4A1.SetActive(true);
            }
            M9.SetActive(false);
        }

        CheckForInput();

        // READ ME
        // I commented this out for debugging. Not sure if this works as intended. You may have to change some things in the if statement
        // READ ME
        /*if (CurrentM4A1Ammo >= 0 && CurrentM9Ammo >= 0 && M4A1Clips < 0 && M9Clips < 0)
        {
            M9.SetActive(false);
            M4A1.SetActive(false);
            Muzzle_Flash.enabled = false;
            Explosion.Simulate(0);
            MuzzleBall.SetActive(false);
        }*/
    }
    public void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && aim == false && M4A1.activeSelf == true)
        {
            aim = true;
            sprint.enabled = false;
            //this.transform.GetComponent<Sprint>().enabled = false;
            M4A1animations.Play("gun down sights");
            ws.enabled = false;
            armanimations.Play("M4A1 aim down arm");
            armtorchanimations.Play("arm torch idle");
            armtorch1.SetActive(false);
            torch.Play("torch idle");
            first.fieldOfView = 30;
            torch1.SetActive(false);
            Cursor.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && aim == true && M4A1.activeSelf == true)
        {
            aim = false;
            sprint.enabled = true;
            ws.enabled = true;
           // this.transform.GetComponent<Sprint>().enabled = false;
            M4A1animations.Play("gun down sights not");
            armanimations.Play("M4A1 aim down arm unaim");
            armtorchanimations.Play("arm torch walking");
            armtorch1.SetActive(true);
            torch.Play("torch walking");
            first.fieldOfView = 60;
            torch1.SetActive(true);
            Cursor.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && aim == false && M9.activeSelf == true)
        {
            aim = true;
            sprint.enabled = false;
            ws.enabled = false;
          //  this.transform.GetComponent<Sprint>().enabled = false;
            M9animations.Play("M9 aim down sight");
            armanimations.Play("M9 aim down sight arm");
            armtorchanimations.Play("arm torch idle");
            armtorch1.SetActive(false);
            torch.Play("torch idle");
            first.fieldOfView = 30;
            torch1.SetActive(false);
            Cursor.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && aim == true && M9.activeSelf == true)
        {
            aim = false;
            sprint.enabled = true; 
            ws.enabled = true;
            //this.transform.GetComponent<Sprint>().enabled = false;
            M9animations.Play("M9 not aim down sight");
            armanimations.Play("M9 aim down arm unaim");
            armtorchanimations.Play("arm torch walking");
            armtorch1.SetActive(true);
            torch.Play("torch walking");
            first.fieldOfView = 60;
            torch1.SetActive(true);
            Cursor.SetActive(true);
        }

        if (Input.GetButton("Fire1"))
        {
            if (M9.activeSelf && aim == false)
                {
                if (Time.time > M9nextFire)
                {
                    armanimations.Play("arm M9 Shooting");
                    M9animations.Play("M9 shoot");
                    /*Instantiate(M9Bullet).transform.position = M9.transform.position + new Vector3(xFloat, yFloat, zFloat); // Sets where the bullet will spawn relative to the transoform that the script is attached to.
                    M9Bullet.transform.position = transform.position + new Vector3(xFloat, yFloat, zFloat);
                    M9Bullet.transform.rotation = transform.rotation * Quaternion.Euler(180, 180, 90);
                    M9Bullet.SetActive(true);*/
                    Debug.DrawRay(transform.TransformPoint(0, 0, 2), transform.forward, Color.blue, 5); //Makes the raycast ray.
                    if (Physics.Raycast(transform.TransformPoint(0, 0, 2), transform.forward, out hit, range) && /*M4A1Clips > 0 && */M9Clips > 0 && /*CurrentM4A1Ammo > 0 &&*/ CurrentM9Ammo > 0)
                    {
                        if (hit.transform.tag == "Enemy")
                        {
                            Debug.Log(hit.transform.name); //We are grabbing from a seperate script on this line.
                                                           //"EnemyHealth" is another script that we are pulling the values from.
                            hit.collider.gameObject.GetComponent<EnemyHealth>().EnemyHealthLoss();
                        }

                        if (hit.transform.tag == "Blinker")
                        {
                            BlinkerTeleport();
                            hit.collider.gameObject.GetComponent<EnemyHealth>().EnemyHealthLoss();
                        }

                        if (hit.transform.tag == "Boss")
                        {
                            hit.collider.gameObject.GetComponent<EnemyHealth>().EnemyHealthLoss();
                        }

                        else
                        {                                   //Prints the transform name in a gray bar at
                            Debug.Log(hit.transform.name);  //the bottom of your screen that your raycast hits. 
                        }
                    }
                    Muzzle_Flash.enabled = true;
                    Explosion.Simulate(5);
                    MuzzleBall.SetActive(true);
                    CurrentM9Ammo -= 1;
                    FinalM9Ammo = CurrentM9Ammo;
                    M9_Ammo.value = CurrentM9Ammo;

                    M9nextFire = Time.time + M9fireRate;

                    if (CurrentM9Ammo <= 0 && M9Clips >= 0)
                    {
                        M9CanShoot = false;
                        M9animations.Play("M9 reload");
                        armanimations.Play("arm M9 reload");
                        M9Clips -= 1;
                        print("M9 clips: " + M9Clips);
                        M9_Ammo.value = CurrentM9Ammo;
                        Muzzle_Flash.enabled = false;
                        Explosion.Simulate(0);
                        MuzzleBall.SetActive(false);
                        CurrentM9Ammo = 13;
                        M9_Ammo.value = CurrentM9Ammo;
                    }
                    else if (Time.time > M9nextFire && M9.activeSelf && Input.GetButton("Fire1") && M9Clips == 2)
                    {
                        CurrentM9Ammo -= 1;
                        M9_Ammo.value = CurrentM9Ammo;
                    }
                    else if (Time.time > M9nextFire && M9.activeSelf && Input.GetButton("Fire1") && M9Clips == 1)
                    {
                        CurrentM9Ammo -= 1;
                        M9_Ammo.value = CurrentM9Ammo;
                    }
                    else if (CurrentM9Ammo <= 0 && M9Clips <= 1)
                    {
                        M9Clips = 0;
                        M9_Ammo.value = 0;
                        M9animations.Play("Gun Idle");
                        M9CanShoot = false;
                        Muzzle_Flash.enabled = false;
                        Explosion.Simulate(0);
                        MuzzleBall.SetActive(false);
                        M4A1.SetActive(true);
                        M9.SetActive(false);
                    }

                    if (M9Clips <= 0)
                    {
                        M9CanShoot = false;
                        CurrentM9Ammo = 0;
                        M9_Ammo.value = 0;
                    }
                }

                else
                {
                    Muzzle_Flash.enabled = false;
                    Explosion.Simulate(0);
                    MuzzleBall.SetActive(false);
                }
            }
            else if (M9.activeSelf && aim == true)
            {
                aimshootM9();
            }

            else if (M4A1.activeSelf && aim == false)
            {
                if (Time.time > M4A1nextFire)
                {
                    armanimations.Play("arm M4A1 shooting");
                    M4A1animations.Play("Gun Shot");
                    /*Instantiate(M4A1Bullet).transform.position = M4A1.transform.position + new Vector3(xFloat2, yFloat2, zFloat2); // Sets where the bullet will spawn relative to the transoform that the script is attached to.
                    M4A1Bullet.transform.position = transform.position + new Vector3(xFloat2, yFloat2, zFloat2);
                    M4A1Bullet.transform.rotation = transform.rotation * Quaternion.Euler(90, -180, 0);
                    M4A1Bullet.SetActive(true);*/
                    Debug.DrawRay(transform.TransformPoint(0, 0, 2), transform.forward, Color.blue, 5); //Makes the raycast ray.
                    if (Physics.Raycast(transform.TransformPoint(0, 0, 2), transform.forward, out hit, range) && M4A1Clips > 0 /*&& M9Clips > 0*/ && CurrentM4A1Ammo > 0/* && CurrentM9Ammo > 0*/)// && CurrentM4A1Ammo > 0 && CurrentM9Ammo > 0) //This may cause a problem later.
                    {
                        if (hit.transform.tag == "Enemy")
                        {
                            Debug.Log(hit.transform.name); //We are grabbing from a seperate script on this line.
                                                           //"Health" is another script that we are pulling the values from.
                            hit.collider.gameObject.GetComponent<EnemyHealth>().EnemyHealthLoss();
                        }

                        if (hit.transform.tag == "Blinker")
                        {
                            BlinkerTeleport();
                            hit.collider.gameObject.GetComponent<EnemyHealth>().EnemyHealthLoss();
                        }

                        if (hit.transform.tag == "Boss")
                        {
                            hit.collider.gameObject.GetComponent<EnemyHealth>().EnemyHealthLoss();
                        }

                        else
                        {                                   //Prints the transform name in a gray bar at
                            Debug.Log(hit.transform.name);  //the bottom of your scrren that your raycast hits. 
                        }
                    }
                    Muzzle_Flash.enabled = true;
                    Explosion.Simulate(5);
                    MuzzleBall.SetActive(true);
                    CurrentM4A1Ammo -= 1;

                    FinalM4A1Ammo = CurrentM4A1Ammo;
                    M4A1_Ammo.value = CurrentM4A1Ammo;

                    M4A1nextFire = Time.time + M4A1fireRate;
                    if (CurrentM4A1Ammo <= 0 && M4A1Clips > 0)
                    {
                        M4A1CanShoot = false;
                        M4A1Clips -= 1;
                        armanimations.Play("arm M4A1 reloading");
                        M4A1animations.Play("Gun Reload");
                        print("M4A1 clips: " + M4A1Clips);
                        M4A1_Ammo.value = CurrentM4A1Ammo;
                        Muzzle_Flash.enabled = false;
                        Explosion.Simulate(0);
                        MuzzleBall.SetActive(false);
                        CurrentM4A1Ammo = 25;
                        M4A1_Ammo.value = CurrentM4A1Ammo;

                        if (Time.time > M4A1nextFire && M4A1.activeSelf && Input.GetButton("Fire1") && M4A1Clips == 3)
                        {
                            CurrentM4A1Ammo -= 1;
                            M4A1_Ammo.value = CurrentM4A1Ammo;
                        }
                        else if (Time.time > M4A1nextFire && M4A1.activeSelf && Input.GetButton("Fire1") && M4A1Clips == 2)
                        {
                            CurrentM4A1Ammo -= 1;
                            M4A1_Ammo.value = CurrentM4A1Ammo;
                        }
                        else if (Time.time > M4A1nextFire && M4A1.activeSelf && Input.GetButton("Fire1") && M4A1Clips == 1)
                        {
                            CurrentM4A1Ammo -= 1;
                            M4A1_Ammo.value = CurrentM4A1Ammo;
                        }
                    }

                    if (CurrentM4A1Ammo <= 0 && M4A1Clips == 0)
                    {
                        M4A1Clips = 0;
                        M4A1_Ammo.value = 0;
                        M4A1CanShoot = false;
                        M4A1.SetActive(false);
                        M9.SetActive(true);
                        Muzzle_Flash.enabled = false;
                        Explosion.Simulate(0);
                        MuzzleBall.SetActive(false);
                        M4A1animations.Play("Gun Idle");
                    }
                }
                else
                {
                    Muzzle_Flash.enabled = false;
                    Explosion.Simulate(0);
                    MuzzleBall.SetActive(false);
                }
            }
            else if (M4A1.activeSelf && aim == true)
            {
                aimShoot();
            }
        }
    }

    void BlinkerTeleport()
    {
        Vector3 position = new Vector3(Random.Range(475f, 10f), 1.5f, Random.Range(490f, 5f));
        Blinker.transform.position = position;
    }
    void aimShoot()
    {
        if (Time.time > M4A1nextFire)
        {
            M4A1animations.Play("aim down sight shoot");
            /*Instantiate(M4A1Bullet).transform.position = M4A1.transform.position + new Vector3(xFloat2, yFloat2, zFloat2); // Sets where the bullet will spawn relative to the transoform that the script is attached to.
            M4A1Bullet.transform.position = transform.position + new Vector3(xFloat, yFloat, zFloat);
            M4A1Bullet.transform.rotation = transform.rotation * Quaternion.Euler(90, -180, 0);
            M4A1Bullet.SetActive(true);*/
            if (Physics.Raycast(transform.TransformPoint(0, 0, 2), transform.forward, out hit, range) && M4A1Clips > 0 && M9Clips > 0)// && CurrentM4A1Ammo > 0 && CurrentM9Ammo > 0) //This may cause a problem later.
            {
                if (hit.transform.tag == "Enemy")
                {
                    Debug.Log(hit.transform.name); //We are grabbing from a seperate script on this line.
                                                   //"Health" is another script that we are pulling the values from.
                    hit.collider.gameObject.GetComponent<EnemyHealth>().EnemyHealthLoss();
                }

                if (hit.transform.tag == "Blinker")
                {
                    BlinkerTeleport();
                    hit.collider.gameObject.GetComponent<EnemyHealth>().EnemyHealthLoss();
                }

                if (hit.transform.tag == "Boss")
                {
                    hit.collider.gameObject.GetComponent<EnemyHealth>().EnemyHealthLoss();
                }

                else
                {                                   //Prints the transform name in a gray bar at
                    Debug.Log(hit.transform.name);  //the bottom of your scrren that your raycast hits. 
                }
            }
            Muzzle_Flash.enabled = true;
            Explosion.Simulate(5);
            MuzzleBall.SetActive(true);
            CurrentM4A1Ammo -= 1;

            FinalM4A1Ammo = CurrentM4A1Ammo;
            M4A1_Ammo.value = CurrentM4A1Ammo;

            M4A1nextFire = Time.time + M4A1fireRate;

            if (CurrentM4A1Ammo <= 0 && M4A1Clips > 0)
            {
                M4A1CanShoot = false;
                M4A1Clips -= 1;
                armanimations.Play("arm M4A1 reloading");
                M4A1animations.Play("Gun Reload");
                print("M4A1 clips: " + M4A1Clips);
                M4A1_Ammo.value = CurrentM4A1Ammo;
                Muzzle_Flash.enabled = false;
                Explosion.Simulate(0);
                MuzzleBall.SetActive(false);
                CurrentM4A1Ammo = 25;
                M4A1_Ammo.value = CurrentM4A1Ammo;

                if (Time.time > M4A1nextFire && M4A1.activeSelf && Input.GetButton("Fire1") && M4A1Clips == 3)
                {
                    CurrentM4A1Ammo -= 1;
                    M4A1_Ammo.value = CurrentM4A1Ammo;
                }
                else if (Time.time > M4A1nextFire && M4A1.activeSelf && Input.GetButton("Fire1") && M4A1Clips == 2)
                {
                    CurrentM4A1Ammo -= 1;
                    M4A1_Ammo.value = CurrentM4A1Ammo;
                }
                else if (Time.time > M4A1nextFire && M4A1.activeSelf && Input.GetButton("Fire1") && M4A1Clips == 1)
                {
                    CurrentM4A1Ammo -= 1;
                    M4A1_Ammo.value = CurrentM4A1Ammo;
                }
            }

            if (CurrentM4A1Ammo <= 0 && M4A1Clips <= 1)
            {
                M4A1_Ammo.enabled = false;
                M4A1Clips = 0;
                M4A1_Ammo.value = 0;
                M4A1CanShoot = false;
                M4A1.SetActive(false);
                M9.SetActive(true);
                Muzzle_Flash.enabled = false;
                Explosion.Simulate(0);
                MuzzleBall.SetActive(false);
                M4A1animations.Play("Gun Idle");
            }
        }
        else
        {
            Muzzle_Flash.enabled = false;
            Explosion.Simulate(0);
            MuzzleBall.SetActive(false);
        }
    }
    void aimshootM9()
    {
        if (Time.time > M9nextFire)
        {
            M9animations.Play("M9 aim down sight shoot");
            /*Instantiate(M9Bullet).transform.position = M9.transform.position + new Vector3(xFloat, yFloat, zFloat); // Sets where the bullet will spawn relative to the transoform that the script is attached to.
            M9Bullet.transform.position = transform.position + new Vector3(xFloat, yFloat, zFloat);
            M9Bullet.transform.rotation = transform.rotation * Quaternion.Euler(180, 180, 90);
            M9Bullet.SetActive(true);*/
            //GunCamera.transform.Rotate(0, 30, 0);
            Debug.DrawRay(transform.TransformPoint(0, 0, 2), transform.forward, Color.blue, 5); //Makes the raycast ray.
            if (Physics.Raycast(transform.TransformPoint(0, 0, 2), transform.forward, out hit, range)/* && M4A1Clips > 0 */&& M9Clips > 0)
            {
                if (hit.transform.tag == "Enemy")
                {
                    Debug.Log(hit.transform.name); //We are grabbing from a seperate script on this line.
                                                   //"EnemyHealth" is another script that we are pulling the values from.
                    hit.collider.gameObject.GetComponent<EnemyHealth>().EnemyHealthLoss();
                }

                if (hit.transform.tag == "Blinker")
                {
                    BlinkerTeleport();
                    hit.collider.gameObject.GetComponent<EnemyHealth>().EnemyHealthLoss();
                }

                if (hit.transform.tag == "Boss")
                {
                    hit.collider.gameObject.GetComponent<EnemyHealth>().EnemyHealthLoss();
                }

                else
                {                                   //Prints the transform name in a gray bar at
                    Debug.Log(hit.transform.name);  //the bottom of your screen that your raycast hits. 
                }
            }
            Muzzle_Flash.enabled = true;
            Explosion.Simulate(5);
            MuzzleBall.SetActive(true);
            CurrentM9Ammo -= 1;

            FinalM9Ammo = CurrentM9Ammo;
            M9_Ammo.value = CurrentM9Ammo;

            M9nextFire = Time.time + M9fireRate;

            if (CurrentM9Ammo <= 0 && M9Clips > 0)
            {
                M9CanShoot = false;
                M9animations.Play("M9 reload");
                armanimations.Play("arm M9 reload");
                M9Clips -= 1;
                print("M9 clips: " + M9Clips);
                M9_Ammo.value = CurrentM9Ammo;
                Muzzle_Flash.enabled = false;
                Explosion.Simulate(0);
                MuzzleBall.SetActive(false);
                CurrentM9Ammo = 13;
                M9_Ammo.value = CurrentM9Ammo;
            }
            else if (Time.time > M9nextFire && M9.activeSelf && Input.GetButton("Fire1") && M9Clips == 2)
            {
                CurrentM9Ammo -= 1;
                M9_Ammo.value = CurrentM9Ammo;
            }
            else if (Time.time > M9nextFire && M9.activeSelf && Input.GetButton("Fire1") && M9Clips == 1)
            {
                CurrentM9Ammo -= 1;
                M9_Ammo.value = CurrentM9Ammo;
            }
            else if (CurrentM9Ammo <= 0 && M9Clips <= 1)
            {
                M9_Ammo.enabled = false;
                M9Clips = 0;
                M9_Ammo.value = 0;
                M9animations.Play("Gun Idle");
                M9CanShoot = false;
                Muzzle_Flash.enabled = false;
                Explosion.Simulate(0);
                MuzzleBall.SetActive(false);
                M4A1.SetActive(true);
                M9.SetActive(false);
            }

            if (M9Clips <= 0)
            {
                M9CanShoot = false;
                CurrentM9Ammo = 0;
            }
        }

        else
        {
            Muzzle_Flash.enabled = false;
            Explosion.Simulate(0);
            MuzzleBall.SetActive(false);
        }
    }
}