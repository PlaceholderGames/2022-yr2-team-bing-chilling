using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurrentBlueprint standartTurret;
    public TurrentBlueprint missileLauncher;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurrent()
    {
        Debug.Log("CRINGE turrent 1 bought");
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectMissileTurrent()
    {
        Debug.Log("CRINGE turrent 1 bought");
        buildManager.SelectTurretToBuild(missileLauncher);

    }
    //
    // public void PurchaseStandartTurrent()
    // {
    //     Debug.Log("CRINGE turrent 1 bought");
    // }
}
