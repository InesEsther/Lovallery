using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip MenuEscena1;
    public AudioClip[] Escena3;
    public AudioClip Degas1;
    public AudioClip[] Escena1;
    public AudioClip[] Escena2;
    public AudioClip Cassatt1;
    public AudioClip[] Cassatt2;
    public AudioClip[] Degas2;

    private AudioSource _audioSource;

    private Dictionary<string, AudioClip[]> Sounds = new Dictionary<string, AudioClip[]>();

    public static AudioManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();

        SceneManager.sceneLoaded += OnSceneLoaded;

        // Añadir los clips de audio a las escenas en el diccionario
        Sounds.Add("Menu", new AudioClip[] { MenuEscena1 });
        Sounds.Add("Escena1", new AudioClip[] { MenuEscena1 });
        Sounds.Add("Escena2", Escena2);
        Sounds.Add("Escena3", new AudioClip[] { Degas1 });
        Sounds.Add("Degas1", new AudioClip[] { Degas1 });
        //Sounds.Add("Degas2", new AudioClip [] { Degas2 });
        Sounds.Add("Cassatt1", new AudioClip [] { Cassatt1 });
        //Sounds.Add("Cassatt2", new AudioClip [] { Cassatt2 });
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;
        if (!Sounds.ContainsKey(sceneName))
        {
            StopSound();
            return;
        }

        AudioClip[] sceneSounds = Sounds[sceneName];
        if (sceneSounds.Length == 0)
        {
            StopSound();
            return;
        }

        AudioClip randomSound = sceneSounds[Random.Range(0, sceneSounds.Length)];
        PlaySound(randomSound);
    }

    private void PlaySound(AudioClip clip)
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = clip;
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }

    private void StopSound()
    {
        _audioSource.Stop();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
