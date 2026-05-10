using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SondManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundEffect
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume;

    }

    [SerializeField] private SoundEffect[] soundEffects;
    [ SerializeField] private int maxAudioSources = 5;

    private List<AudioSource> audioSources = new List<AudioSource>();
    private Dictionary<string, AudioClip> soundEffectDict = new Dictionary<string, AudioClip>();
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
        for (int i = 0; i < maxAudioSources; i++)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSources.Add(audioSource);
        }
        foreach (SoundEffect sound in soundEffects)
        {
            if (sound.clip != null)
            {
                soundEffectDict[sound.name] = sound.clip;
            }
        }
    }  
    private AudioSource GetAvailableAudioSource()
    {
        foreach (AudioSource source in audioSources)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }
        return audioSources.Count > 0 ? audioSources[0] : null; 
    }
     public void PlaySound(string name)
    {
        if (!soundEffectDict.TryGetValue(name, out AudioClip clip))
        {
            Debug.Log("pas trouvé" + name);
            return;
        }

        AudioSource audioSource = GetAvailableAudioSource();
        if (audioSource != null)
        {
            float volume = 1f;
            foreach (SoundEffect sound in soundEffects)
            {
                if (sound.name == name)
                {
                    volume = sound.volume;
                    break;
                }
            }
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.Play();
        }
    }
}
