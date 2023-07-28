using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    public AudioMixerGroup mix;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = mix;

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Music");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return;
        }

        s.source.Play();
    }

    public bool CheckPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return false;
        }

        return s.source.isPlaying;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return;
        }

        s.source.Stop();
    }

    public void FadeOut(string musicname)
    {
        Sound s = Array.Find(sounds, sound => sound.name == musicname);

        IEnumerator FadeO()
        {
            AudioSource fadingmusic = s.source;

            /*while (fadingmusic.volume > 0)
            {
                fadingmusic.volume -= 0.00001f;
                yield return null;
                fadingmusic.Stop(); //fade out is not working as intended
            }*/

            do
            {
                fadingmusic.volume -= 0.0001f;
                yield return null;
                fadingmusic.Stop();
            } while (fadingmusic.volume > 0);


        }

        StartCoroutine(FadeO());
    }

    public void FadeIn(string musicname)
    {
        Sound s = Array.Find(sounds, sound => sound.name == musicname);

        IEnumerator FadeI()
        {
            s.source.Play();
            float volume = 0f;

            do
            {
                s.source.volume = volume;
                volume += 0.0001f;
                yield return null;
            } while (s.source.volume <= s.volume);

        }

        StartCoroutine(FadeI());
    }

    /*private Sound sound;
    public void Play(string name)
    {
        StopAllCoroutines();
        if (sound != null) StartCoroutine(EndSound());

        sound = Array.Find(sounds, s => s.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Music " + name + " not found.");
            return;
        }
        StartCoroutine(StartSound());
    }

    private IEnumerator EndSound()
    {
        AudioSource oldSound = sound.source;
        while (oldSound.volume > 0)
        {
            oldSound.volume -= 0.01f;
            yield return null;
        }
        oldSound.Stop();
    }

    private IEnumerator StartSound()
    {
        sound.source.Play();
        float volume = 0f;
        do
        {
            sound.source.volume = volume;
            volume += 0.01f;
            yield return null;
        } while (sound.source.volume <= sound.volume);
    }
    */
}
