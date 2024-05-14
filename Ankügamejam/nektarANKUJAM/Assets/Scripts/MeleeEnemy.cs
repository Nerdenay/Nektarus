using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    [SerializeField] float moveTreshold;
    [SerializeField] float stopTreshold;
    [SerializeField] float attackInterval;
    [SerializeField] float damageDistance;

    PlayerScript playerScript;
    bool isAttacking;
    float distance;

    private void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < moveTreshold && distance > stopTreshold && !isAttacking)
        {
            Move();
        }
        else if (distance < moveTreshold && distance <= stopTreshold && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackInterval);
        if (distance < damageDistance)
        {
            playerScript.TakeDamage(3);
        }
        isAttacking = false;
    }
    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

}
