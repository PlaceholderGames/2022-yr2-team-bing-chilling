using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Dan you've fucked up something");
            return;
        }
        instance = this;
    }

    public GameObject standartTurrentPrefab;

    private void Start()
    {
        //this will need to be changed later on
        turrentToBuild = standartTurrentPrefab;
    }


    private GameObject turrentToBuild;

    public GameObject GetTurrentToBuild()
    {
        return turrentToBuild;
    }
}
