using System;
using System.Collections;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Shoot shoot;
    public GameObject shootStartPosition;
    private bool isMakeShoot = true;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isMakeShoot)
        {
            InstantiateBullet();
            StartCoroutine(WaitReload());
            isMakeShoot = false;
        }
    }

    private IEnumerator WaitReload()
    {
        yield return new WaitForSeconds(shoot.reloadTime);
        isMakeShoot = true;
    }

    private void InstantiateBullet()
    {
        Destroy(Instantiate(shoot.gameObject, shootStartPosition.transform.position, shootStartPosition.transform.rotation), shoot.liveTime);
    }
}
