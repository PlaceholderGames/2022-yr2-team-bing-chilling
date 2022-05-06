using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip playerDeathSound, playerFireSound, turretFireSound, smallEnemyDeathSound, laserFireSound, bigEnemyDeathSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerFireSound = Resources.Load<AudioClip>("pewPistol");
        turretFireSound = Resources.Load<AudioClip>("pewTurret");
        laserFireSound = Resources.Load<AudioClip>("laserTurret");
        smallEnemyDeathSound = Resources.Load<AudioClip>("deathSmallEnemy");
        bigEnemyDeathSound = Resources.Load<AudioClip>("deathBigEnemy");
        playerDeathSound = Resources.Load<AudioClip>("deathPlayer");


        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
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
            case "deathSmallEnemy":
                audioSrc.PlayOneShot(smallEnemyDeathSound);
                break;
            case "deathBigEnemy":
                audioSrc.PlayOneShot(bigEnemyDeathSound);
                break;
            case "deathPlayer":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
        }
    }
}