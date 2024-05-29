using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip bandaSonoraMenuEscena1;
    public AudioClip bandaSonoraEscena3Degas1;
    public AudioClip bandaSonoraGeneral;

    private AudioSource _audioSource;

    // Listas de nombres de escenas donde el sonido debería reproducirse
    private readonly List<string> escenasMenuEscena1 = new List<string> { "Menu", "Escena1" };
    private readonly List<string> escenasEscena3Degas1 = new List<string> { "Escena3", "Degas1" };

    public static AudioManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _audioSource = GetComponent<AudioSource>();

            SceneManager.sceneLoaded += OnSceneLoaded;

            // Comprobar la escena actual y reproducir el sonido adecuado
            CheckCurrentScene(SceneManager.GetActiveScene());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckCurrentScene(scene);
    }

    private void CheckCurrentScene(Scene scene)
    {
        if (escenasMenuEscena1.Contains(scene.name))
        {
            PlaySound(bandaSonoraMenuEscena1);
        }
        else if (escenasEscena3Degas1.Contains(scene.name))
        {
            PlaySound(bandaSonoraEscena3Degas1);
        }
        else
        {
            PlaySound(bandaSonoraGeneral);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (_audioSource.clip != clip)
        {
            _audioSource.clip = clip;
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
