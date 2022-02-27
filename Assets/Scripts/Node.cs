using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turrent;

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

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (cameraController.cringe == 2)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            if (!buildManager.CanBuild)
                return;

            if (turrent != null)
            {
                Debug.Log("I hate this so much");
                return;
            }


            //build a turrent
            buildManager.BuildTurretOn(this);
        }
    }

    private void OnMouseEnter()
    {
        if (cameraController.cringe == 2)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            if (!buildManager.CanBuild)
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
