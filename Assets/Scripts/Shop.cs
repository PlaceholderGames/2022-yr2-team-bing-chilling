using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurrentBlueprint standartTurret;
    public TurrentBlueprint missileLauncher;
    public TurrentBlueprint laserTurret;


    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurrent()
    {
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectMissileTurrent()
    {
        buildManager.SelectTurretToBuild(missileLauncher);

    }
    public void SelectLaserTurrent()
    {
        buildManager.SelectTurretToBuild(laserTurret);
    }
    //
    // public void PurchaseStandartTurrent()
    // {
    //     Debug.Log("CRINGE turrent 1 bought");
    // }
}
