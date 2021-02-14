using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDirect : MonoBehaviour
{
    RaycastHit hit;

    public Transform rayshootpoint;
    float raydistance = 3f;
    public LayerMask layer;
    float tick = 1f;


    private void Update()
    {
        tick -= Time.deltaTime;

        if(tick<=0f)
        {
            tick = 1f;
            //Debug.DrawRay(rayshootpoint.position, rayshootpoint.forward, Color.red);

            if(Physics.Raycast(rayshootpoint.position,rayshootpoint.forward,out hit,raydistance,layer))
            {
                Doorslidingscript doortrigger = hit.transform.GetComponent<Doorslidingscript>();

                if(!doortrigger.isOpen && !doortrigger.isClose)
                {
                    doortrigger.OpenDoors();
                }
            }
        }
    }
}
