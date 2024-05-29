using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip bandaSonora;
    public AudioClip pop;

    private AudioSource _audioSource;

    public static AudioManager Instance { get; private set; }

    // Lista de nombres de escenas donde el sonido debería reproducirse
    private readonly List<string> escenasPermitidas = new List<string> { "Menu", "Escena1" };

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;

            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = bandaSonora;
            _audioSource.loop = true;
            _audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!escenasPermitidas.Contains(scene.name))
        {
            _audioSource.Stop();
        }
        else if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        // Aquí puedes agregar la lógica para el update si es necesario
    }
}
