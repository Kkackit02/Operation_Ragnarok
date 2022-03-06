using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }


    AudioSource myAudio;
    AudioSource BgmAudio;

    public AudioClip AttackFire;
    public AudioClip DoubleAttackFire;
    public AudioClip BulletHit;
    public AudioClip DestroyModule;
    public AudioClip DestroyShip;
    public AudioClip Composite;
    public AudioClip Decomposite;
    public AudioClip TitleBGM; 
    public AudioClip IngameBGM;     
    
    public bool isPlay = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void Play_AttackFireSound()
    {
        myAudio.PlayOneShot(AttackFire);
    }
    public void Play_DoubleAttackFireSound()
    {
        myAudio.PlayOneShot(DoubleAttackFire);
    }
    public void Play_BulletHitSound()
    {
        myAudio.PlayOneShot(BulletHit);
    }
    public void Play_DestroyModuleSound()
    {
        myAudio.PlayOneShot(DestroyModule);
    }
    public void Play_DestroyShipSound()
    {
        myAudio.PlayOneShot(DestroyShip);
    }
    public void Play_CompositeSound()
    {
        myAudio.PlayOneShot(Composite);
    }
    public void Play_DecompositeSound()
    {
        myAudio.PlayOneShot(Decomposite);
    }

}
