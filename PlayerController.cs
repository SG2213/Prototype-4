using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playSpeed = 10.0f;

    private Rigidbody playRB;
    private GameObject focPoint;

    
    // Start is called before the first frame update
    void Start()
    {
        focPoint = GameObject.Find("FocalPoint");
        playRB = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forInput = Input.GetAxis("Vertical");

        playRB.AddForce(focPoint.transform.forward*playSpeed*forInput);

    }
}