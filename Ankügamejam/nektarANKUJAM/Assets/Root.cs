using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && transform.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
        {
            Debug.Log("Root Hurt Player");
        }
    }
}
