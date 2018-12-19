using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerPlayer : MonoBehaviour {

    AudioSource source;
    public AudioClip Jump, Hit, Die, Woosh, Boom, Pickup;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayHit()
    {
        source.PlayOneShot(Hit);
    }

    public void PlayJump()
    {
        source.PlayOneShot(Jump);
    }

    public void PlayDie()
    {
        source.PlayOneShot(Die);
    }

    public void PlayWoosh()
    {
        source.PlayOneShot(Woosh);
    }

    public void PlayBoom()
    {
        source.PlayOneShot(Boom);
    }

    public void PlayPickup()
    {
        source.PlayOneShot(Pickup);
    }
}
