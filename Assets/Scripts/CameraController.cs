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
    public GameObject ShopPanel;
    public GameObject money;

    public int cringe = 1;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(cringe == 1)
            {
                //TOWER DEFENSE
                TowerCam.SetActive(true);
                fpsCam.SetActive(false);
                ShopPanel.SetActive(true);
                money.SetActive(true);

                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;

                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;

                crosshair.SetActive(false);
                waveText.SetActive(true);
                cringe = 2;
            }
            else if(cringe == 2)
            {
                //FPS
                fpsCam.SetActive(true);
                TowerCam.SetActive(false);
                ShopPanel.SetActive(false);
                money.SetActive(false);

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                crosshair.SetActive(true);
                waveText.SetActive(false);
                cringe = 1;

            }

        }
    }
}
