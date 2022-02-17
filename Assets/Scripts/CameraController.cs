using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject fpsCam;
    public GameObject TowerCam;

    [Header("Things to turn on/off")]
    public GameObject crosshair;
    public GameObject waveText;

    int cringe = 1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(cringe == 1)
            {
                TowerCam.SetActive(true);
                fpsCam.SetActive(false);

                crosshair.SetActive(false);
                waveText.SetActive(true);
                cringe = 2;
            }
            else if(cringe == 2)
            {
                fpsCam.SetActive(true);
                TowerCam.SetActive(false);

                crosshair.SetActive(true);
                waveText.SetActive(false);
                cringe = 1;

            }

        }
    }
}
