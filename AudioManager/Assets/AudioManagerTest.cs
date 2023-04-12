using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerTest : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioManager.Singleton.PlaySound("BloodSFX");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioManager.Singleton.PlaySound("CoinSFX");
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            AudioManager.Singleton.PlaySound("LoseSFX");
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            AudioManager.Singleton.PlaySound("Background");
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            AudioManager.Singleton.PlaySound("ShootSFX");
        }
        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            AudioManager.Singleton.PlaySound("SwordSFX");
        }
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            AudioManager.Singleton.PlaySound("WinSFX");
        }
    }

    public void StopAllSounds()
    {
        AudioManager.Singleton.StopAllSounds();
    }

    public void SetMasterVolume(float value)
    {
        AudioManager.Singleton.SetMasterVolume(value);
    }

    public void ToggleMute()
    {
        AudioManager.Singleton.ToggleMute();
    }
}
