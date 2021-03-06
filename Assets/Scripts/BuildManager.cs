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

    private TurrentBlueprint turrentToBuild;
    private Node selectedNode;

    public NodeUi nodeUI;

    public bool CanBuild { get { return turrentToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turrentToBuild.cost; } }



    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turrentToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurrentBlueprint turrent)
    {
        turrentToBuild = turrent;
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurrentBlueprint GetTurrentToBuild()
    {
        return turrentToBuild;
    }


}
//Follow the dead in the dark of damnation
//Pious in head and a demon at heart
//Sworn to the night, an evangelist nation born
//Under the sign of the dark
//Gather the wild form the horde of the brave men
//Brothers allied fight the storm of this curse
//Banners up high as we rise like a legion sworn
//All for the light we inverse
//Combat ahead and the night calls for heroes
//Ready for fire command
//Revel in red come and wake up to bring no remorse
//Stand up as force
//Rise over the dead bring us ahead
//Incense and iron
//Fight all of the night
//Banners up high to the top of the land
//Right into the red all you can get
//Incense and iron
//Stand follow the fight doing the right
//As we come to defend
//Hollow the damned in the art of salvation
//Fallen and banned and the angels die first
//Servant in life and elated in eden cursed
//Slaves in the light from beyond
//Bury the night in imperial hunger
//Do or die in this fortress of fear
//Cannot deny all the wonders are sacred burst
//Under the weight of this world
//Remedy sent and the sky falls in treason
//Torn by the liar's intend
//Devil in head come and break out
//And raise up the sword
//Stand up as horde
//Rise over the dead bring us ahead
//Incense and iron
//Fight all of the night
//Banners up high to the top of the land
//Right into the red all you can get
//Incense and iron
//Stand follow the fight doing the right
//As we come to defend
//When we all stand together
//Rise over the dead bring us ahead
//Incense and iron
//Fight all of the night
//Banners up high to the top of the land
//Right into the red all you can get
//Incense and iron
//Stand follow the fight doing the right
//As we come to defend
//When we will last forever