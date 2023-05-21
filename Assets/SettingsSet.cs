using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsSet : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetVolume(float volumeui)
    {
        audioMixer.SetFloat("Bvolume", volumeui);
    }
    public void SetqualityInMenu(int Options)
    {
        QualitySettings.SetQualityLevel(Options);
    }
    public void FullScreenMode(bool fillscreen)
    {
        Screen.fullScreen = fillscreen;
    }
}
