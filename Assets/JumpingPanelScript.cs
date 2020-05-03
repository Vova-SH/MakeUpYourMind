using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpingPanelScript : MonoBehaviour
{
    public int jump = 20;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerScript>();
        if(player != null)
        {
            player.SetJump(jump);
    }
    }
}
