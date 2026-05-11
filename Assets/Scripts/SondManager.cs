using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SondManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundEffect
    {
        public string _name;
        public AudioClip _clip;
        [Range(0f, 1f)]
        public float _volume;

    }

    [SerializeField] private SoundEffect[] _soundEffects;
    [ SerializeField] private int _maxAudioSources = 5;

    private List<AudioSource> _audioSources = new List<AudioSource>();
    private Dictionary<string, AudioClip> _soundEffectDict = new Dictionary<string, AudioClip>();
    public static SondManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        for (int i = 0; i < _maxAudioSources; i++)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            _audioSources.Add(audioSource);
        }
        foreach (SoundEffect sound in _soundEffects)
        {
            if (sound._clip != null)
            {
                _soundEffectDict[sound._name] = sound._clip;
            }
        }
    }  
    private AudioSource GetAvailableAudioSource()
    {
        foreach (AudioSource source in _audioSources)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }
        return _audioSources.Count > 0 ? _audioSources[0] : null; 
    }
     public void PlaySound(string name)
    {
        if (!_soundEffectDict.TryGetValue(name, out AudioClip clip))
        {
            Debug.Log("pas trouvé" + name);
            return;
        }

        AudioSource audioSource = GetAvailableAudioSource();
        if (audioSource != null)
        {
            float volume = 1f;
            foreach (SoundEffect sound in _soundEffects)
            {
                if (sound._name == name)
                {
                    volume = sound._volume;
                    break;
                }
            }
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.Play();
        }
    }
}
