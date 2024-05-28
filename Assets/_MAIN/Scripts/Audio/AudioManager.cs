using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip bandaSonora;

    public AudioClip pop;

    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
        _audioSource.clip = bandaSonora;
        _audioSource.loop = true;
        //_audioSource.play( );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
