using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    public PickUpSpawn AmmoBox;
    public HealthPickUpSpawn HealthPack;
    public PlayerHealthAndAmmo pack;
    public float largehealthadd = 50f;
    public float smallhealthadd = 25f;
    public int largeammoboxM4A1 = 50;
    public int smallammoboxM4A1 = 25;
    public int largeammoboxM9 = 26;
    public int smallammoboxM9 = 13;
    public Shoot shoot;
    public int Wave = 0;
    public int BossWave = 0;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 Position = new Vector3(Random.Range(170f, 4f), 1.5f, Random.Range(170f, 6f));
        this.transform.position = Position;
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.gameObject.CompareTag("Small Ammo Pick Up"))
            {
                //destroys the pick up gameobject and starts the respawn function
                Destroy(other.gameObject);
                //shoot.CurrentM4A1Ammo = shoot.CurrentM4A1Ammo + smallammoboxM4A1;
                //shoot.CurrentM9Ammo = shoot.CurrentM9Ammo + smallammoboxM9;
                StartCoroutine(SpawnSmallAmmo());
                shoot.M4A1Clips = shoot.M4A1Clips + 1;
                shoot.M4A1_Ammo.value = 25;
                shoot.M9Clips = shoot.M9Clips + 1;
                shoot.M9_Ammo.value = 13;
                shoot.CurrentM9Ammo = 13;
                shoot.CurrentM4A1Ammo = 25;
            } else if (other.gameObject.CompareTag("Large Ammo Pick Up"))
            {
                Destroy(other.gameObject);
                //shoot.CurrentM4A1Ammo = shoot.CurrentM4A1Ammo + largeammoboxM4A1;
                //shoot.CurrentM9Ammo = shoot.CurrentM9Ammo + largeammoboxM9;
                shoot.M4A1Clips = shoot.M4A1Clips + 2;
                shoot.M4A1_Ammo.value = 25;
                shoot.M9Clips = shoot.M9Clips + 2;
                shoot.M9_Ammo.value = 13;
                shoot.CurrentM9Ammo = 13;
                shoot.CurrentM4A1Ammo = 25;
                StartCoroutine(SpawnLargeAmmo());

            } else if (other.gameObject.CompareTag("Large Health Pack Pick Up") && pack.Current_Health <= 50f)
            {
                Destroy(other.gameObject);
                StartCoroutine(SpawnLargeHealthPack());
                pack.Current_Health = pack.Current_Health + 50f;
                //pack.Current_Health = pack.Current_Health + largehealthadd;
                //pack.Bar_Fill.value = pack.Bar_Fill.value + largehealthadd;
            }
            else if (other.gameObject.CompareTag("Small Health Pack Pick Up") && pack.Current_Health <= 75f)
            {
                Destroy(other.gameObject);
                StartCoroutine(SpawnSmallHealthPack());
                pack.Current_Health = pack.Current_Health + 25f;
                //pack.Current_Health = pack.Current_Health + smallhealthadd;
                //pack.Bar_Fill.value = pack.Bar_Fill.value + smallhealthadd;
            }
        }
        catch
        {

        }
        // weaponswitch meWeapons = new weaponswitch();
        //meWeapons.switchWeaponPlease();
        rb.position = new Vector3(0, 0, 0);
    }

    //respawn function
       IEnumerator SpawnSmallAmmo()
    {
        //tells us that its working on respawn in the console log
        // waits 20 seconds until it executes the next line of code
            yield return new WaitForSeconds(60);
        // spawns a new ammo pickup randomly in the map.
           AmmoBox.RespawnSmallAmmo();
        }
    IEnumerator SpawnLargeAmmo()
    {
        yield return new WaitForSeconds(120);
        AmmoBox.RespawnLargeAmmo();
    }
    IEnumerator SpawnLargeHealthPack()
    {
        yield return new WaitForSeconds(120);
        HealthPack.RespawnLargeHealth();
    }
    IEnumerator SpawnSmallHealthPack()
    {
        yield return new WaitForSeconds(60);
        HealthPack.RespawnSmallHealth();
    }
    /*void Update()
    {
        if (Wave == 3 && BossWave == 3)
        {
            SceneManager.LoadScene("Victory Screen");
        }
    }*/
}