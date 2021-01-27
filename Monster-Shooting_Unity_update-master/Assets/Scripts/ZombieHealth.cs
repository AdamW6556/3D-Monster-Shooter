using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float zombieHealth = 100f;
    ZombieMoves zombieAI;

    public bool isZombiedead;
    public Collider[] zombiecollider;

    AudioSource ZombieDeads;

    [SerializeField]
    AudioClip zombiedeads;

    private void Start()
    {
        zombieAI = GetComponent<ZombieMoves>();
        ZombieDeads = GetComponentInParent<AudioSource>();
    }

    public void HealthAmount(float lesshealth)
    {
        if(!isZombiedead)
        {
            zombieHealth -= lesshealth;

            if (zombieHealth <= 0)
            {
                ZombieDead();
            }
        }
       
    }

    public void ZombieDead()
    {

        isZombiedead = true;
        zombieAI.ZombieDeathAnimation();

        ZombieDeads.PlayOneShot(zombiedeads);

        foreach(var collider in zombiecollider)
        {
            collider.enabled = false;
        }
        zombieHealth = 0f;

        MainUI.instance.killsnumber++;
        MainUI.instance.Updatenumofkills();
        Destroy(gameObject, 1);


    }
}
