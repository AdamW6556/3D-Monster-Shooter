using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysScript : MonoBehaviour
{

    public Text keytextpickwhite;
    public Text keytextpickdark;
    public Text keytextpickgold;
    public Text keytextpickgrey;

    public enum KeyType 
   {
    
        White, Dark, Gold, Grey
   }

    public KeyType keytype;

    private void OnDestroy()
    {
        switch (keytype)
        {
            case KeyType.White:                                         
                MainScript.hasWhiteKey = true;
                EnKeytextwhite();
                break;
            case KeyType.Dark:
               EnKeytextdark();
                MainScript.hasDarkKey = true;                
                break;
            case KeyType.Gold:                                           
                MainScript.hasGoldKey = true;
                EnKeytextgold();
                break;
            case KeyType.Grey:
                MainScript.hasGreyKey = true;
                EnKeytextgrey();
                break;
            default:
                break;
        }


            
    }


    private void EnKeytextwhite()
    {
        if (keytextpickwhite != null)
        { 
            keytextpickwhite.enabled = true; 
        }
      
    }

    private void EnKeytextdark()
    {
        if (keytextpickdark != null)
        {
            keytextpickdark.enabled = true;
        }

    }

    private void EnKeytextgold()
    {
        if (keytextpickgold != null)
        {
            keytextpickgold.enabled = true;
        }

    }
    private void EnKeytextgrey()
    {
        if (keytextpickgrey != null)
        {
            keytextpickgrey.enabled = true;
        }

    }
}
