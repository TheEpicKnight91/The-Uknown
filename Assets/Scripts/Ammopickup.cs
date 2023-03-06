using UnityEngine;
using System.Collections;

public class Ammopickup : MonoBehaviour {

    public GameObject AmmoBox1;

	void Update () {
        Vector3 position = new Vector3(Random.Range(170f, 4f), 1.5f, Random.Range(170f, 6f));
        Instantiate(AmmoBox1).transform.position = position;
    }
}