using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioPlay;

    public void Start()
    {
        audioPlay = GetComponent<AudioSource>();
    }
    public void DiceRollAudio() { 
    audioPlay.Play();
    }

    public void PauseAudio()
    {
        GameManager.gameManager.sound = false;
        audioPlay.gameObject.SetActive(false);
        GameManager.gameManager.audioPlay.gameObject.SetActive(false);
    }
    public void PlayAudio()
    {
        GameManager.gameManager.sound = true ;
        audioPlay.gameObject.SetActive(true);
        GameManager.gameManager.audioPlay.gameObject.SetActive(true);
    }
}
