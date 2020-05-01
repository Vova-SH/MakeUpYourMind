using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float reloadTime = 1;
    public int damage = 5;
    public float speed = 5;
    public float liveTime = 1;

    private Rigidbody rb;
    private Vector3 direction;

    private void Awake()
    {
        direction = new Vector3(0, 0, speed);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.TransformVector(direction) * Time.fixedDeltaTime + transform.position);
        //transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter: " + other.name);
        var bot = other.gameObject.GetComponentInParent<BotMovement>();
        if (other.gameObject.isStatic)
        {
            Destroy(gameObject);
        } else if (bot != null)
        {
            bot.SetDamage(damage);
            Destroy(gameObject);
        }
    }
}
