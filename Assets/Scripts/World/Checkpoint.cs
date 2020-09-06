using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class Checkpoint : MonoBehaviour
{
    bool actived = false;
    [SerializeField] ParticleSystem particles = default;
    [SerializeField] AudioSource checkpointRecieved = default;
    private void OnTriggerEnter(Collider other)
    {
        if (actived) return;
        if (other.GetComponent<CheckpointManager>() != null)
        {
            other.GetComponent<CheckpointManager>().lastCheckpoint = this.transform;
            checkpointRecieved.Play();
            actived = true;
        }
    }

    private void Update()
    {
        if (!actived) return;
        if (particles.isPlaying) return;

        particles.Play();
    }
}
