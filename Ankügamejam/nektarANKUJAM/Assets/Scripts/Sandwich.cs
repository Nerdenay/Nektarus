using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandwich : MonoBehaviour
{
    [SerializeField] GameObject sandwichLoverNPC;
    [SerializeField] NPCMng npcMng;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
