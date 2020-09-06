using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject text = default;
    void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<CheckpointManager>() != null)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioManager>().Stop("Music");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioManager>().Play("EndGame");
            text.SetActive(true);
        }
    }

    public void Start()
    {
        text.SetActive(false);
    }
}
