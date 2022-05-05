using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip playerHitSound, fireSound, enemyDeathSound, laserFireSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        fireSound = Resources.Load<AudioClip>("pewPistol");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "pewPistol":
                audioSrc.PlayOneShot(fireSound);
                break;
        }
    }
}
