using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turrent;
    private Renderer rend;
    private Color startColor;


    CameraController cameraController;

    private void Awake()
    {
        cameraController = GameObject.Find("ManagingScripts").GetComponent<CameraController>();
    }

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

    }


    private void OnMouseDown()
    {
        if (cameraController.cringe == 2)
        {


            if (turrent != null)
            {
                Debug.Log("I hate this so much");
                return;
            }


                //build a turrent
                GameObject turrentToBuild = BuildManager.instance.GetTurrentToBuild();
            turrent = (GameObject)Instantiate(turrentToBuild, transform.position + positionOffset, transform.rotation);
        }
    }

    private void OnMouseEnter()
    {
        if (cameraController.cringe == 2)
        { 
            rend.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        if (cameraController.cringe == 2)
        { 
            rend.material.color = startColor;
        }
    }



}
