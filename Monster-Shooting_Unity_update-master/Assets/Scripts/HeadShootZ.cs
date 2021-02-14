using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShootZ : MonoBehaviour
{

  //  public GameObject head;
    public GameObject blood;
    private void OnDisable()
    {
      //  head.SetActive(false);
        blood.SetActive(true);
    }
}
