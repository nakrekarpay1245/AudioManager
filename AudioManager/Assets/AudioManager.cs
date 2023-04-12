using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField]
    private int maximumSoundCount = 10;
    [SerializeField]
    private float masterVolume = 1f;

    [SerializeField]
    private List<AudioSource> audioSources = new List<AudioSource>();
    [SerializeField]
    private List<Sound> soundList = new List<Sound>();

    private void Awake()
    {
        // AudioSource componentlerini oluþtur
        for (int i = 0; i < maximumSoundCount; i++)
        {
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            audioSources.Add(newSource);
        }
    }

    public void PlaySound(string clipName, float volume = 1f, bool loop = false)
    {
        // Aktif olan AudioSource componentini bul
        AudioSource activeSource = null;
        for (int i = 0; i < audioSources.Count; i++)
        {
            if (!audioSources[i].isPlaying)
            {
                activeSource = audioSources[i];
                break;
            }
        }

        if (activeSource == null)
        {
            Debug.LogWarning("Maksimum ses sayýsýna ulaþýldý");
            return;
        }

        for (int i = 0; i < soundList.Count; i++)
        {
            if(clipName == soundList[i].Name)
            {
                activeSource.clip = soundList[i].Clip;
                activeSource.volume = masterVolume * soundList[i].Volume;
                activeSource.loop = soundList[i].Loop;
                activeSource.Play();
            }
        }
    }

    public void StopAllSounds()
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            audioSources[i].Stop();
        }
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        for (int i = 0; i < audioSources.Count; i++)
        {
            audioSources[i].volume = audioSources[i].volume * volume;
        }
    }

    public void ToggleMute()
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            audioSources[i].mute = !audioSources[i].mute;
        }
    }
}
