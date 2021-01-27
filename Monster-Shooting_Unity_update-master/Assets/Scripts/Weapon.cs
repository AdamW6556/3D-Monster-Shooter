using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{

    public GameObject Endscrn;
    [SerializeField]
    Transform shootMark;

    RaycastHit hit;

    [SerializeField]
    public int currentAmmo = 12;
    public int maxAmmo = 12;
    public int currentcarriedAmmo = 35;
    public int maxcarriedAmmo = 35;
    bool isReloading;

    [SerializeField]
    float rateOfFire;
    float nextFire = 0;

    [SerializeField]
    float weaponRange;

    [SerializeField]
    float damageZombie = 10f;

    [SerializeField]
    float headshootDamage = 100f;

    public ParticleSystem shootefect;

    public ParticleSystem Bulletvoice;

    AudioSource gunshootv1;

    public AudioClip gunvoice;
    public AudioClip emptyfire;
    public AudioClip reloadvoice;

    //blood effect from enemy

    public GameObject bloodfromEnemy;

    public Text CurrentAmmoText;
    public Text BackpackAmmoText;

    public GameObject dscreen;

   // public bool canShoot = true;

    [Header(" Layers Affected")]
    public LayerMask layer;
    //Animator animator;
    void Start()
    {
        shootefect.Stop();
        Bulletvoice.Stop();
        gunshootv1 = GetComponent<AudioSource>();
        //animator = GetComponent<Animator>();
        AmmoUI();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && currentAmmo > 0)
        {

         
            if(!Endscrn.activeSelf )
            {
                Shoot();
            }
           // else if(!dscreen.activeSelf)
           // {
          //      Shoot();
          //  }
                
            
            
        }
        else if (Input.GetButton("Fire1") && currentAmmo <= 0)
        {

            if (!Endscrn.activeSelf )
            {
                DryFire();
            }
          //  else if (!dscreen.activeSelf)
          //  {
          //      DryFire();
          //  }

        }
        else if (Input.GetKeyDown(KeyCode.Q) && currentAmmo <= maxAmmo)
        {


            if (!Endscrn.activeSelf )
            {
                Reload();
            }
            //else if (!dscreen.activeSelf)
           // {
           //     Reload();
           // }
        }
    }

    void DryFire()
    {

        

        if (Time.time > nextFire)
        {
            nextFire = 0f;
            nextFire = Time.time + rateOfFire;
            //animator.SetTrigger("Shoot");

            //currentAmmo--;

            // gunshootv1.PlayOneShot(gunvoice);

            // StartCoroutine(ShootEffects());


            //int layerMask = LayerMask.GetMask("Enemy");
            // ShootRay();
            // Debug.Log("Play dry fire sound");
           
            if(!dscreen.activeSelf)
            {
                gunshootv1.PlayOneShot(emptyfire);
            }
               
            
        }
    }

    void Shoot()
    {
        
        
            if (Time.time > nextFire)
            {
                //if(dscreen)
                nextFire = 0f;
                nextFire = Time.time + rateOfFire;
                //animator.SetTrigger("Shoot");

                currentAmmo--;

                
            if(!dscreen.activeSelf)
            {
                gunshootv1.PlayOneShot(gunvoice);
            }
                

                
                

                StartCoroutine(ShootEffects());
                //int layerMask = LayerMask.GetMask("Enemy");
                ShootRay();

                AmmoUI();



            }
        

        
    }

    //
    void ShootRay()
    {
        if (Physics.Raycast(shootMark.position, shootMark.forward, out hit, weaponRange, layer))
        {

            if (hit.transform.tag == "Enemy")
            {

                ZombieHealth zombiehealth = hit.transform.GetComponent<ZombieHealth>();
                zombiehealth.HealthAmount(damageZombie);

                Instantiate(bloodfromEnemy, hit.point, transform.rotation);
                //Debug.Log("Hit Enemy");
                //Debug.DrawLine(shootMark.position, hit.point);
                //Debug.Log(hit.transform.tag);
            }
           /* else if (hit.transform.tag == "Head")
            {

                ZombieHealth zombiehealth = hit.transform.GetComponent<ZombieHealth>();
                zombiehealth.HealthAmount(headshootDamage);

                Instantiate(bloodfromEnemy, hit.point, transform.rotation);
               //hit.transform.gameObject.SetActive(false);
                Debug.Log("headshoot");
            }*/
            else
            {

                //Debug.Log("Hit something else");
                Debug.Log(hit.transform.name);
                //Debug.DrawLine(shootMark.position, hit.point);
                // Debug.Log(hit.transform.tag);
            }
        }
    }
    //

    void Reload()
    {
        if (currentcarriedAmmo <= 0) return;
        StartCoroutine(ReloadTime(1f));
       
            gunshootv1.PlayOneShot(reloadvoice);
        
    }

    IEnumerator ReloadTime(float time)
    {
        while(time>0f)
        {
            isReloading = true;
            time -= Time.deltaTime;
            yield return null;
        }

        if(time<=0f)
        {
            isReloading = false;
            int ammoneeded = maxAmmo - currentAmmo;
            int AmmoCalculate = (currentcarriedAmmo >= ammoneeded) ? ammoneeded : currentcarriedAmmo;

            currentcarriedAmmo -= AmmoCalculate;
            currentAmmo += AmmoCalculate;

            AmmoUI();
        }
    }
    IEnumerator ShootEffects()
    {
        Bulletvoice.Play();
        shootefect.Play();

        yield return new WaitForEndOfFrame();

        shootefect.Stop();
        Bulletvoice.Stop();
    }

    public void AmmoUI()
    {
        CurrentAmmoText.text = currentAmmo.ToString();
        BackpackAmmoText.text = currentcarriedAmmo.ToString();
    }




}
