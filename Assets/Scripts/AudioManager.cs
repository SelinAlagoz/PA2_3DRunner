using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic;  // Çalınacak müzik dosyası
    private AudioSource audioSource;   // AudioSource bileşeni

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();  // AudioSource bileşenini al

        // Müziği ayarla ve çalmaya başla
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;  // Müziği sürekli tekrarla
        audioSource.Play();
    }
}