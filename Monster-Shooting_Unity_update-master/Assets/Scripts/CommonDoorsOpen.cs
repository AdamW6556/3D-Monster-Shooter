using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonDoorsOpen : MonoBehaviour
{
    Animator anim;

    AudioSource doorAS;

    public AudioClip openAC;


    public bool isOpen;

    public bool isClose;

    [SerializeField]
    Text doorText;
    string doorstring;
   


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
    

    }

    void UpdateDoorUI()
    {
        doorText.enabled = true;
        doorText.text = doorstring.ToString();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isClose && !isOpen)
            {
                doorstring = "OPEN DOORS ('E' CLICK)!";
                

                if (Input.GetKeyDown(KeyCode.E))
                {
                    OpenDoors();
                    
                    doorText.enabled = false;

                }

            }
            else if (isOpen)
            {
               

                if (Input.GetKeyDown(KeyCode.E))
                {
                    CloseDoors();
                }

            }
           

        }
    }

   

}
