using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Transform lastCheckpoint = default;
    [SerializeField] Transform startingCheckpoint = default;
    public void LoadCheckpoint()
    { 
        this.transform.position = lastCheckpoint.position + Vector3.up;
        Player.player.GetComponent<PlayerHealth>().Revive();
        
    }
}
