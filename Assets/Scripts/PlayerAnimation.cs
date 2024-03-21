using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private AudioSource audio;
    public AudioClip clip1;
    public AudioClip clip2;
    public ParticleSystem particle;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    public void Punch_1()
    {
        anim.SetTrigger("Punch1");
        audio.clip = clip1;
        audio.Play();
    }

    public void Punch_2()
    {
        anim.SetTrigger("Punch2");
        audio.clip = clip2;
        audio.Play();
    }

    public void Punch_3()
    {
        anim.SetTrigger("Punch3");
        audio.clip = clip1;
        audio.Play();
    }

    public void Kick_1()
    {
        anim.SetTrigger("Kick1");
        audio.clip = clip1;
        audio.Play();
    }

    public void Kick_2()
    {
        anim.SetTrigger("Kick2");
        audio.clip = clip2;
        audio.Play();
    }
    public void Kick_3()
    {
        anim.SetTrigger("Kick3");
        audio.clip = clip1;
        audio.Play();
    }
    public void Blocking()
    {
        anim.SetTrigger("Blocking");
    }
}
