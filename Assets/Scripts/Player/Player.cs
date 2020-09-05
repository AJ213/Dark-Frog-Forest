using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static GameObject player = default;

    void Awake()
    {
        player = this.gameObject;   
    }
}
