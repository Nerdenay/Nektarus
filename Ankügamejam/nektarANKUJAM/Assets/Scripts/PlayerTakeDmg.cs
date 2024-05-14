using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDmg : MonoBehaviour
{
    BoxCollider2D playerCollider;

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerCollider != null)
        {

        }
    }
}
