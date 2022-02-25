using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandartTurrent()
    {
        Debug.Log("CRINGE turrent 1 bought");
        buildManager.SetTurrentToBuild(buildManager.standartTurrentPrefab);
    }
    public void PurchaseMissileTurrent()
    {
        Debug.Log("CRINGE turrent 1 bought");
        buildManager.SetTurrentToBuild(buildManager.MissileTurrentPrefab);

    }
    //
    // public void PurchaseStandartTurrent()
    // {
    //     Debug.Log("CRINGE turrent 1 bought");
    // }
}
