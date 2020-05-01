using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float reloadTime = 1;
    public int damage = 5;
    public float speed = 5;
    public float liveTime = 1;

    private void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
