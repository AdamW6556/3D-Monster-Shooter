using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doorslidingscript : MonoBehaviour
{

    Animator anim;

    AudioSource doorAS;

    public AudioClip openAC;

    public AudioClip closeAC;

    public bool isOpen;

    public bool isClose;

    [SerializeField]
    Text doorText;
    string doorstring;
    public enum LockType{White, Dark, Gold, Grey}
    public LockType locktype;


    void Start()
    {
        doorText.enabled = false;
        doorAS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }

    public void OpenDoors()
    {
        isOpen = true;
        
        anim.SetTrigger("Open");
        doorAS.PlayOneShot(openAC);
        doorText.enabled = false;
    }

    public void CloseDoors()
    {
        isOpen = false;
        anim.SetTrigger("Close");
        doorAS.PlayOneShot(closeAC);

    }

    void UpdateDoorUI()
    {
        doorText.enabled = true;
        doorText.text = doorstring.ToString();
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            if(!isClose && !isOpen)
            {
                doorstring = "OPEN DOORS ('E' CLICK)!";
               //UpdateDoorUI();
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    OpenDoors();
                    //doorstring = "";
                    doorText.enabled = false;
                    
                }
                  
            }
            else if(isOpen)
            {
                //doorstring = "CLOSE DOORS!";
               // UpdateDoorUI();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    CloseDoors();
                }

            }
            else if(isClose && !isOpen)
            {
                //doorstring = "DOORS ARE LOCKED!";
                //UpdateDoorUI();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    //isClose = false;
                    CheckTypeoflock();
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            doorText.enabled = false;
        }
    }

    void CheckTypeoflock()
    {
        switch (locktype)
        {

            case LockType.White:
                if(MainScript.hasWhiteKey)
                {
                    isClose = false;
                    OpenDoors();
                }
                break;
            case LockType.Dark:
                if (MainScript.hasDarkKey)
                {
                    isClose = false;
                    OpenDoors();
                }
                break;
            case LockType.Gold:
                if (MainScript.hasGoldKey)
                {
                    isClose = false;
                    OpenDoors();
                }
                break;
            case LockType.Grey:
                if (MainScript.hasGreyKey)
                {
                    isClose = false;
                    OpenDoors();
                }
                break;
            default:
                break;
        }

    }

}
