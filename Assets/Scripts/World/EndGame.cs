using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<CheckpointManager>() != null)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioManager>().Stop("Music");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioManager>().Play("EndGame");
            
        }
    }
}
