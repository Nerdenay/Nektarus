using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    public void GetHurt(float dammage)
    {
        health -= dammage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
