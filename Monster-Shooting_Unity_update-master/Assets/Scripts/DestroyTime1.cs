using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime1 : MonoBehaviour
{
    public int destroytimer = 5;

    private void Awake()
    {
        Destroy(gameObject, destroytimer);
    }
}
