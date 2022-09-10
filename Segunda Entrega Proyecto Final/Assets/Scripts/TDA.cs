using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDA : MonoBehaviour
{
    public GameObject spawn;
    public List<GameObject> zombies = new List<GameObject>();
    void Start()
    { 
        Invoke("SpawnZombies", 1f);
    }


    void Update()
    {
        
    }

    void SpawnZombies()
    {
        for (int i = 0; i < zombies.Count; i++)
        {
            GameObject newzombie = Instantiate(zombies[i]);
            newzombie.transform.position = new Vector3(Random.Range(720, 700), 17f, Random.Range(410, 403));
        }
    }
}
