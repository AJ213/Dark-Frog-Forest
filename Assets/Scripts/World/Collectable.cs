using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectable : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
       
        if (other.GetComponent<CheckpointManager>() != null)
        {
            Player.player.GetComponent<AudioManager>().Play("Fly");
            Destroy(this.gameObject);
        }
    }
}
