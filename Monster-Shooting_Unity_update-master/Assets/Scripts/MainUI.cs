using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUI : MonoBehaviour
{
    public static MainUI instance;

    [SerializeField]
    TextMeshProUGUI numofkills;

    [HideInInspector]
    public int killsnumber;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Updatenumofkills()
    {
        numofkills.text = killsnumber.ToString();
    }
}
