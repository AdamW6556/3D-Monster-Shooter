using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{

    //public GameOverScreen gameoverscreen;

    public GameObject Endscrn;

    public float CurrentHealth;
    public float MaximumHealth = 100f;

    public static PlayerHealth singleton;

    public bool IsDeadPlayer = false;

    public Slider healthSlider;
    public Text healthLevel;

    public DeathScreen deathScreen;
    public Weapon wp;

    [Header("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    float colorSmoothing = 1.5f;
    bool isDamaged = false;
    //public static FirstPersonController fpc;

    AudioSource PlayerHurt;

    [SerializeField]
    AudioClip playerhurt;

    private void Awake()
    {
        singleton = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        CurrentHealth = MaximumHealth;
        healthSlider.value = MaximumHealth;
        UpdateHealthUI();

        PlayerHurt = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }


        if (isDamaged)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, colorSmoothing * Time.deltaTime);
        }

        if (!IsDeadPlayer)
        {
            isDamaged = false;
        }


    }

   
    public void DamagePlayer(float damage)
    {

        if (CurrentHealth > 0)
        {
            if (damage >= CurrentHealth)
            {
               
                isDamaged = true;
                DeadPlayer();
            }
            else
            {
                
                isDamaged = true;
                CurrentHealth -= damage;

                if(!Endscrn.activeSelf)
                {
                    PlayerHurt.PlayOneShot(playerhurt);
                }
                
            }

            UpdateHealthUI();
        }

    }

    public void UpdateHealthUI()
    {
        healthLevel.text = CurrentHealth.ToString();
        healthSlider.value = CurrentHealth;
    }


    void DeadPlayer()
    {

       
        CurrentHealth = 0;
        IsDeadPlayer = true;
        healthSlider.value = 0;

        if (!Endscrn.activeSelf)
        {
            PlayerHurt.PlayOneShot(playerhurt);
        }
        Debug.Log("Player is dead");
        UpdateHealthUI();


        // gameObject.SetActive(false);

        //wp.canShoot = false;

        deathScreen.GameOverscreen();
        
        // GameOver();

        // SceneManager.LoadScene("GameoverScene");

        // StartCoroutine(Wait(1.0F));

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


        // SceneManager.LoadScene(0);


        //isDamaged = true;
        //SceneManager.SetActiveScene("GameoverScene");
        //StartCoroutine(Wait2(3.0F));
    }

   

    public void Addhealth(float healthamount)
    {
        CurrentHealth += healthamount;
        UpdateHealthUI();
    }

    IEnumerator Wait(float waitseconds)
    {
        yield return new WaitForSeconds(waitseconds);
        // SceneManager.LoadScene("GameoverScene");
        //Cursor.visible = true;
        SceneManager.LoadScene(2);
        //SceneManager.LoadScene(SceneManager.SetActiveScene("GameoverScene"));
    }

   // public void GameOver()
   // {
   //     gameoverscreen.BacktoMenu();
  //  }
    //IEnumerator Wait2(float waitseconds)
   // {
    //    yield return new WaitForSeconds(waitseconds);
    //    SceneManager.LoadScene("Test_Map");
        
   // }
}
