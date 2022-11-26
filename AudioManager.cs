using System;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;
    public int adsCount;
    void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
           s.source.loop = s.loop;

        }
    }
    public void PlaySound(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
       s.source.Play();
    }

}
