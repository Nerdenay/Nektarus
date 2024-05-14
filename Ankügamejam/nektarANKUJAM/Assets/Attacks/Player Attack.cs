using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Animator anim;

    [SerializeField] private float meelespeed;

    [SerializeField] private float damage;

    float timeUntilMeele;

    private void Update()

    {

        if (timeUntilMeele <= 0)

        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                timeUntilMeele = meelespeed;

            }
            else
            {
                timeUntilMeele -= Time.deltaTime;

            }
        }



    }

    private  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //  other.GetComponent<Enemy>().TakeDamage(damage);  bu hasar alma fln

            Debug.Log("Enemy hit");

        }



     }





}
