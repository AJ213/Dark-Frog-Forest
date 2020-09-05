﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class SceneChanger : MonoBehaviour
{
    private int indexToLoad = 0;
    [SerializeField]AudioMixer mixer = default;
    private void Start()
    {
        StartCoroutine(FadeMixerGroup.StartFade(mixer, "Main", 0.2f, 1f));
    }
    public void FadeToScene(int levelIndex)
    {
        indexToLoad = levelIndex;
        StartCoroutine(FadeMixerGroup.StartFade(mixer, "Main", 0.99f, 0f));
        GetComponent<Animator>().SetTrigger("FadeOut");
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                
                FadeToScene(0);
            }
        }
    }

    public void LoadScene()
    {
        if (indexToLoad == -1)
        {
            Application.Quit();
            return;
        }
        
        SceneManager.LoadScene(indexToLoad);
    }
}
