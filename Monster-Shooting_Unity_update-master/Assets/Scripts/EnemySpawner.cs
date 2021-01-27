using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombies;

    public Transform[] SpawnPoints;

    BoxCollider trigger;

    private void Start()
    {
        trigger = GetComponent<BoxCollider>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            SpawnZombies();
            trigger.enabled = false;
        }
    }

    void SpawnZombies()
    {

        foreach(var x in SpawnPoints)
        {
            Instantiate(zombies, x.position, x.rotation);
        }


    }


}
