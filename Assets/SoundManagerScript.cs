using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip playerHitSound, playerFireSound, turretFireSound, cannonFireSound, enemyDeathSound, laserFireSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerFireSound = Resources.Load<AudioClip>("pewPistol");
        turretFireSound = Resources.Load<AudioClip>("pewTurret");
        laserFireSound = Resources.Load<AudioClip>("laserTurret");

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
                audioSrc.PlayOneShot(playerFireSound);
                break;
            case "pewTurret":
                audioSrc.PlayOneShot(turretFireSound);
                break;
            case "laserTurret":
                audioSrc.PlayOneShot(laserFireSound);
                break;
        }
    }
}
