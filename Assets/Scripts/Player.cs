using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 12.5f;

    public CharacterController myController;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //imagine making simple code CRINGE
        Vector3 movment = x * transform.right + z * transform.forward;
        movment = movment * speed * Time.deltaTime;

        myController.Move(movment);

    }




}
