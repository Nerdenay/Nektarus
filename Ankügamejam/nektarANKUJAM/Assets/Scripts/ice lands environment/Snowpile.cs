using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowpile : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == player.tag)
        {
            // ACTIVATE PRESSABLE BUTTON
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Give quest!");
            }
        }

    }
}
