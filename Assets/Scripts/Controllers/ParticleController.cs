using UnityEngine;

public class ParticleController : MonoBehaviour {
    public ParticleSystem successParticle;
    public ParticleSystem smashParticle;
    public ParticleSystem leftBoostParticle;
    public ParticleSystem rightBoostParticle;
    public ParticleSystem boostParticle;
    
    public void PlaySmash() {
        smashParticle.Play();
    }
    
    public void StopSmash() {
        smashParticle.Stop();
    }
    
    public void PlaySuccess() {
        successParticle.Play();
    }
    
    public void StopSuccess() {
        successParticle.Stop();
    }
    
    public void PlayLeftBoost() {
        if(!leftBoostParticle.isPlaying)
            leftBoostParticle.Play();
    }
    
    public void StopLeftBoost() {
        leftBoostParticle.Stop();
    }
    
    public void PlayRightBoost() {
        if (!rightBoostParticle.isPlaying)
            rightBoostParticle.Play();
    }
    
    public void StopRightBoost() {
        rightBoostParticle.Stop();
    }
    
    public void PlayBoost() {
        if (!boostParticle.isPlaying)
            boostParticle.Play();
    }
    
    public void StopBoost() {
        boostParticle.Stop();
    }
}
