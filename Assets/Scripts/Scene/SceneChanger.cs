using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class SceneChanger : MonoBehaviour
{
    private int indexToLoad = 0;
    [SerializeField]AudioMixer mixer = default;

    private void Awake()
    {
        StartCoroutine(FadeMixerGroup.StartFade(mixer, "Main", 0.2f, 1f));
    }
    public void FadeToScene(int levelIndex)
    {
        indexToLoad = levelIndex;
        StartCoroutine(FadeMixerGroup.StartFade(mixer, "Main", 0.99f, 0f));
        GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public void LoadScene()
    {
        if(indexToLoad == -1)
        {
            Application.Quit();
            return;
        }
        SceneManager.LoadScene(indexToLoad);
    }
}
