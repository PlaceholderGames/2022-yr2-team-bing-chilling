using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUi : MonoBehaviour
{
    private Node target;

    public void SetTarget(Node _target)
    {
        this.target = _target;

        transform.position = target.GetBuildPosition();
    }
}
