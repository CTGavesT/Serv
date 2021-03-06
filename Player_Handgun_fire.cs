using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Handgun_fire : MonoBehaviour
{
    public int shotDamage = 25;

    public float shotFrequency = 0.5f;
    public float shotRange = 100f;

    public float shotForce = 50f;

    public float effectsDuration = 0.1f;

    public GameObject rayCaster;

    float timerShot = 0f;

    bool effects = false;

    Ray fireRay;
    RaycastHit fireHitInfo;

    private void Update()
    {
        timerShot += Time.deltaTime;

        if (!GetComponent<Player_Handgun>().isRunning) Fire();

        if (timerShot >= effectsDuration && effects)
        {
            effects = false;
            GetComponent<Player_Handgun>().DisableEffects();
        }

    }

    void Fire()
    {

        if (Input.GetButton("Fire1") && timerShot >= shotFrequency)
        {
            GetComponent<Player_Handgun>().HandgunShot();

            effects = true;
            timerShot = 0f;

            fireRay.origin = rayCaster.transform.position;
            fireRay.direction = rayCaster.transform.forward;

            if (Physics.Raycast(fireRay, out fireHitInfo, shotRange))
            {
                if (fireHitInfo.collider.CompareTag("Enemy"))
                {
                  //  fireHitInfo.collider.GetComponent<Enemy_Manager>().GetDamaged(shotDamage);
                }

                if (fireHitInfo.collider.GetComponent<Rigidbody>() != null)
                {
                    fireHitInfo.collider.GetComponent<Rigidbody>().AddForceAtPosition(rayCaster.transform.forward.normalized * shotForce, fireHitInfo.point);

                    //Debug.DrawLine(rayCaster.transform.position, fireHitInfo.point, Color.green, 2f);
                    //Debug.DrawLine(fireHitInfo.normal + fireHitInfo.point, fireHitInfo.point, Color.blue, 2f);
                }

                GetComponent<Player_Handgun>().BulletTrail(fireHitInfo.point, fireHitInfo.normal, fireHitInfo.collider);
            }
        }
    }


    

}
