using System;
using UnityEngine;

public class SoundsController : MonoBehaviour {
    public AudioClip smashClip;
    public AudioClip finishClip;
    
    private AudioSource _audioSource;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlaySmashClip() {
        if (!_audioSource.isPlaying)
            _audioSource.PlayOneShot(smashClip);
    }
    
    public void PlayFinishClip() {
        if (!_audioSource.isPlaying) 
            _audioSource.PlayOneShot(finishClip);
    }
}
