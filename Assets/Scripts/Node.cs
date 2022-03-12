using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;

    [Header("Don't touch")]
    public GameObject turrent;
    public TurrentBlueprint turrentBlueprint;
    public bool isUpgraded = false;

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

            if (turrent != null)
            {
                buildManager.SelectNode(this);
                return;
            }

            if (!buildManager.CanBuild)
                return;

            //build a turrent
            //buildManager.BuildTurretOn(this);

            BuildTurret(buildManager.GetTurrentToBuild());
        }
    }

    void BuildTurret (TurrentBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            return;
        }
        PlayerStats.Money -= blueprint.cost;
        //GameObject turrentToBuild = BuildManager.instance.GetTurrentToBuild();
        GameObject _turrent = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turrent = _turrent;

        turrentBlueprint = blueprint;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turrentBlueprint.upgradeCost)
        {
            return;
        }
        PlayerStats.Money -= turrentBlueprint.upgradeCost;

        //destroy old turrent
        Destroy(turrent);

        //build new turrent
        //GameObject turrentToBuild = BuildManager.instance.GetTurrentToBuild();
        GameObject _turrent = (GameObject)Instantiate(turrentBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turrent = _turrent;

        isUpgraded = true;
    }


    private void OnMouseEnter()
    {
        if (cameraController.cringe == 2)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            if (!buildManager.CanBuild)
                return;
            if (buildManager.HasMoney)
            {
                rend.material.color = hoverColor;

            }
            else
            {
                rend.material.color = Color.red;

            }
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
