using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject fpsCam;
    public GameObject TowerCam;
    public GameObject crosshair;
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
                cringe = 2;
            }
            else if(cringe == 2)
            {
                fpsCam.SetActive(true);
                TowerCam.SetActive(false);

                crosshair.SetActive(true);
                cringe = 1;

            }

        }
    }
}
