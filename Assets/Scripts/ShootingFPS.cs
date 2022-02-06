using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//this is what the original creators said before Krzysztof will try to do antagonise me again for re-using code

        /// Thanks for downloading my projectile gun script! :D
        /// Feel free to use it in any project you like!
        /// 
        /// The code is fully commented but if you still have any questions
        /// don't hesitate to write a yt comment
        /// or use the #coding-problems channel of my discord server
        /// 
        /// Dave

public class ShootingFPS : MonoBehaviour
{

    //bullet s
    public GameObject redBullet;
    public GameObject blueBullet;

    int whichColour;

    //bullet force
    public float shootForce, upwardForce;

    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //Recoil
    public Rigidbody playerRb;
    public float recoilForce;

    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //bug fixing :D
    public bool allowInvoke = true;

    private void Awake()
    {
        //make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInputLeftClick();
        MyInputRightClick();

        //Set ammo display, if it exists :D
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }
    private void MyInputLeftClick()
    {
        whichColour = 0;
        //Check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Reloading 
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //Reload automatically when trying to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //Set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }
    private void MyInputRightClick()
    {
        whichColour = 1;
        //Check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse1);
        else shooting = Input.GetKeyDown(KeyCode.Mouse1);

        //Reloading 
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //Reload automatically when trying to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //Set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //Find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //Just a point far away from the player

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

        //Instantiate bullet/projectile
        if(whichColour == 0)
        {
            GameObject currentBulletRed = Instantiate(redBullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
                                                                                                             //Rotate bullet to shoot direction
            currentBulletRed.transform.forward = directionWithSpread.normalized;

            //Add forces to bullet
            currentBulletRed.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
            currentBulletRed.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        }
        else
        {
            GameObject currentBulletBlue = Instantiate(blueBullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
                                                                                                              //Rotate bullet to shoot direction
            currentBulletBlue.transform.forward = directionWithSpread.normalized;

            //Add forces to bullet
            currentBulletBlue.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
            currentBulletBlue.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);
        }
        

        //Instantiate muzzle flash, if you have one
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            //Add recoil to player (should only be called once)
            playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }

        //if more than one bulletsPerTap make sure to repeat shoot function
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        //Allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime); //Invoke ReloadFinished function with your reloadTime as delay
    }
    private void ReloadFinished()
    {
        //Fill magazine
        bulletsLeft = magazineSize;
        reloading = false;
    }

}