using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Reference Code is from Brackeys
//https://www.youtube.com/watch?v=BLfNP4Sc_iA
//That is the youtube video
//In Description he said
//All content by Brackeys is 100% free. We believe that education should be available for everyone. Any support is truly appreciated so we can keep on making the content free of charge.

public class Player : MonoBehaviour
{

    public float speed = 12.5f;

    public CharacterController myController;

    GameOver gameOver;




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
