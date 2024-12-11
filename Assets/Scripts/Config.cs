using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Config : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;
    public void stablishFullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void changeVolume(float volumeValue)
    {
        audioMixer.SetFloat("VolumeValue", volumeValue);
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
