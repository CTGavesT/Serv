using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Handgun : MonoBehaviour
{

    public bool gunIsActive;

    public bool isRunning;

    public GameObject player;

    public GameObject crosshairs;

    public Color crosshairsCanShoot;
    public Color crosshairsCannotShoot;

    public GameObject roundLight;
    public GameObject muzzleMesh;

    public Color muzzleColor;
    public float muzzleIntensity = 2f;

    public GameObject gunBulletHole;
    public GameObject bulletImpact;

    public AudioClip[] sounds = new AudioClip[4];
    public AudioClip drawGun;

    private void Update()
    {
        PlayerIsRunning();

        PlayerIsShooting();
    }


    void PlayerIsShooting()
    {

    }


    public void HandgunShot()
    {
        gameObject.GetComponent<Animator>().SetTrigger("GunShot");

        roundLight.SetActive(true);
        muzzleMesh.SetActive(true);
        muzzleMesh.GetComponent<Renderer>().material.color = muzzleColor * muzzleIntensity;

        int rnd = Random.Range(0, sounds.Length);
        GetComponent<AudioSource>().clip = sounds[rnd];
        GetComponent<AudioSource>().Play();

    }

    public void DisableEffects()
    {
        roundLight.SetActive(false);
        muzzleMesh.SetActive(false);
    }

    public void BulletTrail(Vector3 impact, Vector3 normal, Collider parent)
    {
        GameObject trail = Instantiate(bulletImpact, impact, Quaternion.LookRotation(normal));
      //  trail.GetComponent<sfx_bullet_trail>().incomingDirection = (gunBulletHole.transform.position - impact).normalized;
       // trail.GetComponent<sfx_bullet_trail>().impactPosition = impact;
       // trail.GetComponent<sfx_bullet_trail>().surfaceNormal = normal;
       // trail.GetComponent<sfx_bullet_trail>().parent = parent;
        //trail.GetComponent<sfx_bullet_trail>().Spawn();
    }

    void PlayerIsRunning()
    {
        if (Input.GetAxis("Running") > 0.5)
        {
            crosshairs.GetComponent<Image>().color = crosshairsCannotShoot;
            isRunning = true;        }
        else
        {
            crosshairs.GetComponent<Image>().color = crosshairsCanShoot;
            isRunning = false;
        }
        gameObject.GetComponent<Animator>().SetBool("isRunning", isRunning);
    }

    private void OnEnable()
    {
        crosshairs.SetActive(true);
        crosshairs.GetComponent<Image>().color = crosshairsCanShoot;

        GetComponent<AudioSource>().clip = drawGun;
        GetComponent<AudioSource>().Play();

    }

    /*private void OnDisable()
    {
        crosshairs.SetActive(false);
    }*/
}
