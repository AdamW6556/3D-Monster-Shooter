using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItems : MonoBehaviour
{

    //Winscene winscene;
    public GameObject Endscrn;
    Ray ray;

    RaycastHit hit;

    [SerializeField]
    float pickdistance = 0.5f;

    

    public Text keytextpickwhite;
    public Text keytextpickdark;
    public Text keytextpickgold;
    public Text keytextpickgrey;

    Camera maincamera;

    public Text textpick;


    Weapon weaponScript;

    public LayerMask layer;

    string infopick;

    [Header("Audio")]
    public AudioClip pickaudioammosound;
    public AudioClip pickaudiohealthsound;
    public AudioClip winsound;
    public AudioClip pickkeysound;
    AudioSource picksound;
    string itemtag;

    private void Start()
    {
        picksound = GetComponent<AudioSource>();
        maincamera = Camera.main;
        weaponScript = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        ray = maincamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit, pickdistance, layer))
        {
            textpick.enabled = true;
            textpick.text = hit.transform.name.ToString();
            itemtag = hit.transform.tag;
            CheckItemTag();
            /*
            if (hit.transform.tag == "AmmoPack")
            {
                infopick = "AMMO PACK (PICK 'E')";
                textpick.text = infopick;
                Pickkey();
            }
            else if (hit.transform.tag == "HealthPack")
            {

                if (PlayerHealth.singleton.CurrentHealth < PlayerHealth.singleton.MaximumHealth)
                {
                    Pickhealth();
                    infopick = "HEALTH PACK (PICK 'E')";
                    textpick.text = infopick;
                }
                else
                {
                    infopick = "HEALTH FULL!";
                    textpick.text = infopick;

                }

            }
            else if (hit.transform.tag == "Wingame")
            {
                infopick = "CLICK 'M' TO FINAL \n ESCAPE FROM DUNGEON!";
                textpick.text = infopick;
                Finalescape();

            }
            else if (hit.transform.tag == "OpDoors")
            {
                infopick = "OPEN DOORS! ('E')";
                textpick.text = infopick;
            }
            */
        }       
        else
        {
            textpick.enabled = false;
        }

    }

    void Pickkey()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(hit.transform.gameObject);
             // weaponScript.currentcarriedAmmo = weaponScript.maxcarriedAmmo;
            weaponScript.currentcarriedAmmo += 15;
            picksound.PlayOneShot(pickaudioammosound);
            textpick.enabled = false;
            weaponScript.AmmoUI();
        }
    }

    void Finalescape()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            picksound.PlayOneShot(winsound);
            Endscrn.gameObject.SetActive(true);
            Time.timeScale = 0f;
            keytextpickdark.enabled = false;
            keytextpickgold.enabled = false;
            keytextpickgrey.enabled = false;
            keytextpickwhite.enabled = false;
            //winscene.Winscreen();
        }
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(2);
        // SceneManager.LoadScene("GameoverScene");
        //Cursor.visible = true;
        //winscene.Winscreen();
        //SceneManager.LoadScene(SceneManager.SetActiveScene("GameoverScene"));
    }

    void Pickhealth()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(hit.transform.gameObject);
            picksound.PlayOneShot(pickaudiohealthsound);
            textpick.enabled = false;
            

            HealthPick healthpickscript = hit.transform.GetComponent<HealthPick>();

            float healthbox = healthpickscript.healthbox;

            if (PlayerHealth.singleton.CurrentHealth + healthbox > PlayerHealth.singleton.MaximumHealth)
            {
                PlayerHealth.singleton.CurrentHealth = PlayerHealth.singleton.MaximumHealth;
                PlayerHealth.singleton.UpdateHealthUI();
            }
            else
            { 
                PlayerHealth.singleton.Addhealth(healthbox);
            }
        }
    }

    void PickUpKey()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            picksound.PlayOneShot(pickkeysound);
            Destroy(hit.transform.gameObject);


        }
    }

    void CheckItemTag()
    {
        switch (itemtag)
        {
            case "AmmoPack":
                if (hit.transform.tag == "AmmoPack")
                {
                    infopick = "AMMO PACK (PICK 'E')";
                    textpick.text = infopick;
                    Pickkey();
                }
                break;
            case "HealthPack":
                if (hit.transform.tag == "HealthPack")
                {

                    if (PlayerHealth.singleton.CurrentHealth < PlayerHealth.singleton.MaximumHealth)
                    {
                        Pickhealth();
                        infopick = "HEALTH PACK (PICK 'E')";
                        textpick.text = infopick;
                    }
                    else
                    {
                        infopick = "HEALTH FULL!";
                        textpick.text = infopick;

                    }

                }
                break;
            case "Wingame":
                if (hit.transform.tag == "Wingame")
                {
                    infopick = "CLICK 'M' TO FINAL \n ESCAPE FROM DUNGEON!";
                    textpick.text = infopick;
                    Finalescape();
                }
                break;
            case "OpDoors":
                if (hit.transform.tag == "OpDoors")
                {
                    infopick = "OPEN DOORS! (PICK 'E')";
                    textpick.text = infopick;
                }
                break;
            case "WhiteKeyDoors":
                if (hit.transform.tag == "WhiteKeyDoors")
                {
                    infopick = "WHITE KEY REQUIRED TO OPEN THIS DOOR! (PICK 'E')";
                    textpick.text = infopick;
                }
                break;
            case "DarkKeyDoors":
                if (hit.transform.tag == "DarkKeyDoors")
                {
                    infopick = "DARK KEY REQUIRED TO OPEN THIS DOOR! (PICK 'E')";
                    textpick.text = infopick;
                }
                break;
            case "GoldKeyDoors":
                if (hit.transform.tag == "GoldKeyDoors")
                {
                    infopick = "GOLD KEY REQUIRED TO OPEN THIS DOOR! (PICK 'E')";
                    textpick.text = infopick;
                }
                break;
            case "GreyKeyDoors":
                if (hit.transform.tag == "GreyKeyDoors")
                {
                    infopick = "GREY KEY REQUIRED TO OPEN THIS DOOR! (PICK 'E')";
                    textpick.text = infopick;
                }
                break;
            case "Keys":
                PickUpKey();
                break;
            default:
                break;
        }

    }
    
}
