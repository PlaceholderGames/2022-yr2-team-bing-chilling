using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turrent;
    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    CameraController cameraController;

    private void Awake()
    {
        cameraController = GameObject.Find("ManagingScripts").GetComponent<CameraController>();
    }

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;

    }


    private void OnMouseDown()
    {
        if (cameraController.cringe == 2)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            if (buildManager.GetTurrentToBuild() == null)
                return;

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
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            if (buildManager.GetTurrentToBuild() == null)
                return;
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
