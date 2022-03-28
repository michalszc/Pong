using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMusic : MonoBehaviour
{
    public Sprite spriteMusicOn;
    public Sprite spriteMusicOff;
    public Image musicImg;

    private AudioSource audioSource;

    public void MusicToggle()
    {
        if (audioSource != null && audioSource.mute)
        {
            musicImg.sprite = spriteMusicOn;
            audioSource.mute = false;
        }
        else
        {
            musicImg.sprite = spriteMusicOff;
            audioSource.mute = true;
        }
    }

    private void Awake()
    {
        audioSource = GameObject.Find("Background Music").GetComponent<AudioSource>();
        if (audioSource != null && audioSource.mute)
        {
            musicImg.sprite = spriteMusicOff;
        }
    }
}
