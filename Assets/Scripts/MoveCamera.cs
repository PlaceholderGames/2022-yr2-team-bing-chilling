using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Transform player;
    //okay i want to apologize to krzysztof as this is also simple code
    void Update()
    {
        transform.position = player.transform.position;
    }
}
