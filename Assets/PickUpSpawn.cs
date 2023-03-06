using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawn : MonoBehaviour {

    public GameObject SmallAmmo;

    public GameObject LargeAmmo;

	void Start () {

        for (int s = 0; s < 3; s++)
        {

            Vector3 position = new Vector3(Random.Range(170f, 4f), 1.5f, Random.Range(170f, 6f));
            Instantiate(SmallAmmo).transform.position = position;
        }
        for (int l = 0; l < 2; l++)
        {
            Vector3 position = new Vector3(Random.Range(170f, 4f), 1.5f, Random.Range(170f, 6f));
            Instantiate(LargeAmmo).transform.position = position;
        }

    }
	
	void Update () {
		
	}

    public void RespawnSmallAmmo()
    {
        for (int s = 2; s < 3; s++)
        {
            Vector3 position = new Vector3(Random.Range(170f, 4f), 1.5f, Random.Range(170f, 6f));
            Instantiate(SmallAmmo).transform.position = position;
        }
    }
    public void RespawnLargeAmmo()
    {

        for (int l = 1; l < 2; l++)
        {
            Vector3 position = new Vector3(Random.Range(170f, 4f), 1.5f, Random.Range(170f, 6f));
            Instantiate(LargeAmmo).transform.position = position;
        }

    }
}
