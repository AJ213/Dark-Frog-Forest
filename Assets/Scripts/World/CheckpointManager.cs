using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CheckpointManager : MonoBehaviour
{
    public Transform lastCheckpoint = default;
    [SerializeField] Transform startingCheckpoint = default;
    public void LoadCheckpoint()
    { 
        if(lastCheckpoint == null)
        {
            lastCheckpoint = startingCheckpoint;
        }

        this.transform.position = lastCheckpoint.position + Vector3.up;
        Player.player.GetComponent<PlayerHealth>().Revive();
    }
}
