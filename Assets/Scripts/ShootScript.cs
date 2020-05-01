using System;
using System.Collections;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Bullet bullet;
    public GameObject shootStartPosition;
    private bool isMakeShoot = true;
    void Update()
    {
        if (Input.GetButton("Fire1") && isMakeShoot)
        {
            InstantiateBullet();
            StartCoroutine(WaitReload());
            isMakeShoot = false;
        }
    }

    private IEnumerator WaitReload()
    {
        yield return new WaitForSeconds(bullet.reloadTime);
        isMakeShoot = true;
    }

    private void InstantiateBullet()
    {
        Destroy(Instantiate(bullet.gameObject, shootStartPosition.transform.position, shootStartPosition.transform.rotation), bullet.liveTime);
    }
}
