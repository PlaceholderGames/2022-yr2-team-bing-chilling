using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUi : MonoBehaviour
{
    public GameObject ui;
    private Node target;

    public Text upgradeCost;

    public void SetTarget(Node _target)
    {
        this.target = _target;

        upgradeCost.text = "$" + target.turrentBlueprint.upgradeCost;

        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
