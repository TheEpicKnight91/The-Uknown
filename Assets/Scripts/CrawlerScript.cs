using UnityEngine;
using System.Collections;

public class CrawlerScript : MonoBehaviour {
    public Transform Player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.position, this.transform.position) <= 400) //How close they have to be to start chasing the player.
        {
            Vector3 direction = Player.position - this.transform.position;
            direction.y = 0; //Makes it so he doesn't lean back when he is close to you.
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);
           // this.transform.rotation.x = -90;
            if (direction.magnitude >= 3)
            {
                this.transform.Translate(0, 0, 0.05f);
            }
        }
    }
}
