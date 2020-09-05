using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{


	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	void Awake()
	{
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
			s.source.priority = s.priority;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}
    private void Update()
    {
        /*if(PlayerHealth.playerDead == true)
        {
			Stop("Music");
		}*/
    }

    private void Start()
    {

		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			Play("Music");
		}
		if(SceneManager.GetActiveScene().buildIndex == 1 && this.gameObject.CompareTag("GameController"))
        {
			Play("Music");
			Play("Ambience");
		}
		if (SceneManager.GetActiveScene().buildIndex == 1 && this.gameObject.CompareTag("Player"))
		{
			Play("CharacterSounds");
		}
	}

    public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.Stop();
	}

	public void Pause(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.Pause();
	}

	public void UnPause(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.UnPause();
	}
}
