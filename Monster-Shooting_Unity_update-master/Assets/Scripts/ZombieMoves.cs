using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMoves : MonoBehaviour
{

    //AudioSource ZombieVoice;

    //[SerializeField]
   // AudioClip zombievoice;

    NavMeshAgent nav;
    Transform target;
    Animator animation;

    [SerializeField]
    float CatchDistance = 2f;

    [SerializeField]
    float turn_speed = 5f;

    public bool isMonsterDead = false;


    public float DamageAmount = 35f;

    [SerializeField]

    float AttackTimes = 2f;

    public bool CanAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        animation = GetComponent<Animator>();
        //ZombieVoice = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance between enemy and player
        float distance = Vector3.Distance(transform.position, target.position);

         if(distance < CatchDistance && CanAttack && !PlayerHealth.singleton.IsDeadPlayer)
         {
             AttackPlayer();
            
         }
         else if(distance > CatchDistance && !isMonsterDead)
         {
             CatchPlayer();
          

        }
        else if (PlayerHealth.singleton.IsDeadPlayer)
        {
            StopMonster();
        }
        // else if(CanAttack && !PlayerHealth.singleton.IsDeadPlayer)
        // {
        //     AttackPlayer();
        // }


        /*
        if (!isMonsterDead && !PlayerHealth.singleton.IsDeadPlayer)
        {
            if (distance < CatchDistance && CanAttack)
            {
                AttackPlayer();
            }
            else if (distance > CatchDistance)
            {
                CatchPlayer();

            }
        }
        else
        {
            StopMonster();
        }
        */
    }

    public void ZombieDeathAnimation()
    {
        isMonsterDead = true;
        animation.SetTrigger("isDead");
    }

    void CatchPlayer()
    {
        nav.updateRotation = true;
        nav.updatePosition = true;
        nav.SetDestination(target.position);
        animation.SetBool("isWalking", true);
        animation.SetBool("isAttacking", false);
    }

    void AttackPlayer()
    {
        nav.updateRotation = false; 
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turn_speed * Time.deltaTime);
        nav.updatePosition = false;
        animation.SetBool("isWalking", false);
        animation.SetBool("isAttacking", true);
        StartCoroutine(AttackbyMonster());
        
    }

    IEnumerator AttackbyMonster()
    {
        CanAttack = false;
        yield return new WaitForSeconds(0.5f);

        if (!isMonsterDead) //
        {
            PlayerHealth.singleton.DamagePlayer(DamageAmount);  //
        }  //
        
        yield return new WaitForSeconds(AttackTimes);
        CanAttack = true;
    }

    void StopMonster()
    {
        CanAttack = false;
        animation.SetBool("isWalking", false);
        animation.SetBool("isAttacking", false);
    }
}
