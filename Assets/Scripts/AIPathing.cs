using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AIPathing : MonoBehaviour {
    public Transform Player;
    public Animator anim;
    public AudioClip Attack;
    public GameObject Monster;
    public Vector3 Direction;
    public int EnemyAttackDamage = 10;
    private int DamageTaken;
    private bool EnemyFlee;
    public SkinnedMeshRenderer Boss;
    private GameObject UpdateG;
    public ParticleSystem Particles;
    public GameObject Monster2;
    public GameObject ChaseObject;

    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("DamagePlayer", 0, 1);
        Vector3 Position = new Vector3(Random.Range(170f, 4f), 1.5f, Random.Range(170f, 6f));
        this.transform.position = Position;
        Boss.GetComponent<SkinnedMeshRenderer>().enabled = false;
    }

    void DamagePlayer()
    {
        if (Vector3.Distance(Player.position, this.transform.position) <= 4 && GetComponent<EnemyHealth>().Current_Health != 0)
        {
            Player.GetComponent<PlayerHealthAndAmmo>().HealthLoss(-10);
        }
    }
	
	void Update ()
    {
            if (Vector3.Distance(Player.position, transform.position) > 4 && Vector3.Distance(Player.position, transform.position) < 25 && GetComponent<EnemyHealth>().AllowMovement)
        {
            ChaseObject.SetActive(true);
            transform.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;
            transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = Player.position;
            anim.Play("Walk");
            GetComponent<AIPathing>().GetComponent<NavMeshAgent>().enabled = true;
            if (transform.tag == "Boss")
            {
                transform.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;
                transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = Player.position;
                Boss.GetComponent<SkinnedMeshRenderer>().enabled = false;
                anim.Play("Walk");
            }

            if (GetComponent<EnemyHealth>().GotShot == true)
            {
                transform.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
                GetComponent<EnemyHealth>().MonsterAnim.Play("Shot");
            }
        }

        if (Vector3.Distance(Player.position, transform.position) >= 20)
        {
            if (transform.GetComponent<NavMeshAgent>().enabled)
            {
                transform.GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<AIPathing>().GetComponent<NavMeshAgent>().enabled = false;
            }
            ChaseObject.SetActive(false);
            transform.LookAt(Player);
        }

        else if (Vector3.Distance(Player.position, transform.position) <= 4 && GetComponent<EnemyHealth>().AllowMovement)
         {
            Boss.GetComponent<SkinnedMeshRenderer>().enabled = true;
            transform.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
            anim.Play("Attack");
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
         }

        else
        {
            UpdateG.SetActive(false);
            if (UpdateG.activeSelf == false)
            {
                transform.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
                anim.Play("Dead");
                Particles.Simulate(0);
                this.GetComponent<AIPathing>().enabled = false;
                float StartTime = 0f;
                StartTime += Time.deltaTime;
                if (StartTime >= 6)
                {
                    Vector3 position = new Vector3(Random.Range(170f, 4f), 1.0f, Random.Range(170f, 6f));
                    Monster.SetActive(false);
                    Instantiate(Monster2).transform.position = position;
                    StartTime = 0f;
                }

            }
        }
    }
}