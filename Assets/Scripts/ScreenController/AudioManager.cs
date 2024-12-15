using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Untuk System.Array

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds; // Pastikan Anda punya kelas Sound
    public AudioSource musicSource;

    private void Awake() // Tambahkan kurung kurawal
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name); // Perbaiki "array" menjadi "Array"

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void ToggleMusic(){
        musicSource.mute = !musicSource.mute;
    }
    public void MusicVolume(float volume){
        musicSource.volume = volume; 
    }
}

