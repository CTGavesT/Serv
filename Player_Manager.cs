using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Manager : MonoBehaviour
{
    public static int playerHealthMax = 100;
    public static int playerHealthCurrent;

    public bool isDead = false;

   // public GameObject UI_Healthbar;
    public GameObject UI_DamagedImage;

    float timer = 0;

    public Color damagedColor = Color.red;
    public float flashSpeed = 2f;

    public bool damageef = false;

    public AudioClip[] damagedSounds = new AudioClip[2];

    private void Awake()
    {
        playerHealthCurrent = playerHealthMax;
        damageef = false;
    }

    void Update()
    {
        if (damageef) DamageEffect();
    }

    public void GetDamaged(int damage)
    {
        playerHealthCurrent -= damage;

        if (playerHealthCurrent < 0) playerHealthCurrent = 0;

        float value = (playerHealthCurrent * 100) / playerHealthMax;

      //  UI_Healthbar.GetComponent<Slider>().value = (int)value;

        damageef = true;
        timer = 0f;
        UI_DamagedImage.SetActive(true);
        int rnd = Random.Range(0, damagedSounds.Length);
       // UI_DamagedImage.GetComponent<AudioSource>().clip = damagedSounds[rnd];
        //UI_DamagedImage.GetComponent<AudioSource>().Play();

        if (playerHealthCurrent == 0 && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
        }

    }

    public void GetHealed(int heal)
    {
        playerHealthCurrent += heal;

        if (playerHealthCurrent > playerHealthMax) playerHealthCurrent = playerHealthMax;

       // UI_Healthbar.GetComponent<Slider>().value = playerHealthCurrent;
    }

    void DamageEffect()
    {
        timer += Time.deltaTime * flashSpeed;
        
        Color c = new Color(damagedColor.r, damagedColor.g, damagedColor.b, 0f);

        if (timer < 1f)
        {
            UI_DamagedImage.GetComponent<Image>().color = Color.Lerp(damagedColor, c, timer);
        }
        else
        {
            UI_DamagedImage.SetActive(false);
            damageef = false;
        }

    }

}
