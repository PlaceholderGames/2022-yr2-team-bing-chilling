using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUi : MonoBehaviour
{
    public GameObject ui;
    private Node target;

    public Text upgradeCost;
    public Button upgradeButton;

    public void SetTarget(Node _target)
    {
        this.target = _target;

        upgradeCost.text = "$" + target.turrentBlueprint.upgradeCost;

        if (!target.isUpgraded)
        { 
            transform.position = target.GetBuildPosition();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "MAXED OUT";
            upgradeButton.interactable = false;

        }
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
