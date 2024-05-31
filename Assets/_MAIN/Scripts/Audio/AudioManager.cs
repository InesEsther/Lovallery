/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //public AudioClip Pop;
    //public AudioClip fxButton;
    AudioSource _audioSource;
    public GameObject musicObj;

    //public AudioMixerSnapshot defaultSnapshot;
    //public AudioMixerSnapshot tunelSnapshot;
    //public AudioMixerSnapshot submarinoSnapshot;

    AudioSource audioMusic;
    

    public static AudioManager Instance;

    void Awake(){

        if(Instance != null && Instance != this){
            Destroy(this.gameObject);
        }else{
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        audioMusic = musicObj.GetComponent<AudioSource>();
        audioMusic = this.GetComponent<AudioSource>();
        //audioMusic.clip = pop;
        audioMusic.loop = true;
        audioMusic.volume = 0.2f;
        audioMusic.Play();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//metodo para hacer sonar clips de audio
    public void SonarClipUnaVez(AudioClip ac ){
        _audioSource.PlayOneShot(ac);
    }

    /*public void IniciarEfectoTunel(){
        tunelSnapshot.TransitionTo(0.5f);
    }

    public void IniciarEfectoBurbuja(){
        submarinoSnapshot.TransitionTo(1f);
    }

    public void IniciarEfectoDefault(){
        defaultSnapshot.TransitionTo(0.5f);
    }
}*/
