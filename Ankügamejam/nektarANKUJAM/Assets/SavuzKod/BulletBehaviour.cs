using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float bulletmoveSpeed = 5f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.AddForce(Vector2.left * bulletmoveSpeed, ForceMode2D.Impulse);
    }

}
