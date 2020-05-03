using System.Collections;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Bullet bullet;
    public AudioSource shootSound;
    public GameObject shootStartPosition;

    private PlayerAnimationController animController;
    private bool isMakeShoot = true;

    private void Start()
    {
        animController = GetComponentInChildren<PlayerAnimationController>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && isMakeShoot)
        {
            StartCoroutine(WaitPreload());
            isMakeShoot = false;
        }
    }

    private IEnumerator WaitPreload()
    {
        animController.StartShootAnimation();
        yield return new WaitForSeconds(0.25f);
        InstantiateBullet();
        StartCoroutine(WaitReload());
        yield return new WaitForSeconds(0.75f);
        animController.StartIdleAnimation();
    }

    private IEnumerator WaitReload()
    {
        yield return new WaitForSeconds(bullet.reloadTime);
        isMakeShoot = true;
    }

    private void InstantiateBullet()
    {
        shootSound.Play();
        Destroy(Instantiate(bullet.gameObject, shootStartPosition.transform.position, shootStartPosition.transform.rotation), bullet.liveTime);
    }
}
