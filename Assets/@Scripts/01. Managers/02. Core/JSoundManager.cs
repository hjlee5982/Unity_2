using System;
using System.Collections.Generic;
using UnityEngine;

public class JSoundManager
{
    private AudioSource[] _audioSources = new AudioSource[(int)JDefine.ESound.Max];
    private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
    private GameObject _soundRoot = null;

    public void Init()
    {
        if (_soundRoot == null)
        {
            _soundRoot = GameObject.Find("@SoundRoot");

            if (_soundRoot == null)
            {
                _soundRoot = new GameObject { name = "@SoundRoot" };
                UnityEngine.Object.DontDestroyOnLoad(_soundRoot);

                string[] soundTypeNames = System.Enum.GetNames(typeof(JDefine.ESound));
                for (int count = 0; count < soundTypeNames.Length - 1; count++)
                {
                    GameObject go = new GameObject { name = soundTypeNames[count] };
                    _audioSources[count] = go.AddComponent<AudioSource>();
                    go.transform.parent = _soundRoot.transform;
                }

                _audioSources[(int)JDefine.ESound.Bgm].loop = true;
            }
        }
    }

    public void Clear()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.Stop();
        }

        _audioClips.Clear();
    }

    public void Play(JDefine.ESound type)
    {
        AudioSource audioSource = _audioSources[(int)type];
        audioSource.Play();
    }

    public void Play(JDefine.ESound type, string key, float pitch = 1.0f)
    {
        AudioSource audioSource = _audioSources[(int)type];

        if (type == JDefine.ESound.Bgm)
        {
            LoadAudioClip(key, (audioClip) =>
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }

                audioSource.clip = audioClip;
                audioSource.Play();
            });
        }
        else
        {
            LoadAudioClip(key, (audioClip) =>
            {
                audioSource.pitch = pitch;
                audioSource.PlayOneShot(audioClip);
            });
        }
    }

    public void Play(JDefine.ESound type, AudioClip audioClip, float pitch = 1.0f)
    {
        AudioSource audioSource = _audioSources[(int)type];

        if (type == JDefine.ESound.Bgm)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void Stop(JDefine.ESound type)
    {
        AudioSource audioSource = _audioSources[(int)type];
        audioSource.Stop();
    }

    private void LoadAudioClip(string key, Action<AudioClip> callback)
    {
        AudioClip audioClip = null;
        if (_audioClips.TryGetValue(key, out audioClip))
        {
            callback?.Invoke(audioClip);
            return;
        }

        audioClip = JManagers.Resource.Load<AudioClip>(key);

        if (_audioClips.ContainsKey(key) == false)
        {
            _audioClips.Add(key, audioClip);
        }

        callback?.Invoke(audioClip);
    }
}
