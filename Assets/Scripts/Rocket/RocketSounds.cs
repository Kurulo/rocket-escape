using UnityEngine;

public class RocketSounds : MonoBehaviour {
    public AudioClip boostRocketSound;
    
    private AudioSource _audioSource;
    
    void Start() {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayBoostSound() {
        if (!_audioSource.isPlaying) {
            _audioSource.PlayOneShot(boostRocketSound);
        } 
    }
    
    public void StopBoostPaying() {
        _audioSource.Stop();
    }
}
