using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //This is a reminder that the AI-Script is still attached to the Player, keep in mind it's a seperate component!

    public float playSpeed = 10.0f;
    private float powerStrength = 5.0f;
    public bool hasMultiplier = false;

    private Rigidbody playRB;
    private GameObject focPoint;
    public GameObject multiplier;
    public GameObject powerIndicator;

    // Start is called before the first frame update
    void Start()
    {
        focPoint = GameObject.Find("FocalPoint");
        multiplier = GameObject.Find("MultiplierPowerup");
        powerIndicator = GameObject.Find("PowerIndicator");
        playRB = GameObject.Find("Player").GetComponent<Rigidbody>();

        powerIndicator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float forInput = Input.GetAxis("Vertical");

        playRB.AddForce(focPoint.transform.forward*playSpeed*forInput);

        powerIndicator.transform.position = transform.position + new Vector3(0f,-0.5f, 0);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasMultiplier = true;
            powerIndicator.gameObject.SetActive(true);
            Debug.Log("You have THE POWER!!");
            StartCoroutine("PowerupCountdown");
            GameObject.Destroy(multiplier);
           
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Rigidbody enemyRB = other.gameObject.GetComponent<Rigidbody>();
        Vector3 awayPlayer = (other.gameObject.transform.position - transform.position).normalized;
        

        if(hasMultiplier == true && other.gameObject.CompareTag("Enemy"))
        {
            enemyRB.AddForce(powerStrength*awayPlayer);
            powerIndicator.gameObject.SetActive(false);
            Debug.Log("Wow! You hit the enemy with THE POWER!!");
            hasMultiplier = false;
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(5);
        powerIndicator.gameObject.SetActive(false);
        Debug.Log("THE POWER has left you..");
        hasMultiplier = false;
    }
}