using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangerEnemyMoveAndShoot : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float stoppingDistance;
    [SerializeField] GameObject coal;
    [SerializeField] Transform firePoint;
    [SerializeField] int fireSpeed;
    [SerializeField] float moveTreshold;

    Transform player;
    float distance;

    private bool canShoot;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        canShoot = true;
    }

    private void Update()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);
        if (Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(player.position.x, 0)) > stoppingDistance && distance <= moveTreshold)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(player.position.x, 0)) <= stoppingDistance && Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(player.position.x, 0)) >= stoppingDistance / 2 && distance <= moveTreshold)
        {
            if (Vector2.Distance(new Vector2(0, transform.position.y), new Vector2(0, player.position.y)) > .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, player.position.y), speed * Time.deltaTime);
            }
            else
            {
                transform.position = this.transform.position;
                if (canShoot == true) StartCoroutine(Shoot());
            }
        }
        else if (Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(player.position.x, 0)) < stoppingDistance / 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            if (canShoot == true) StartCoroutine(Shoot());
        }
        if (player.transform.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (player.transform.position.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(1);

        // Player'ýn pozisyonuna doðru yön hesapla
        Vector2 direction = (player.position - firePoint.position).normalized;

        GameObject col = Instantiate(coal, firePoint.position, Quaternion.identity);
        col.GetComponent<Rigidbody2D>().AddForce(direction * fireSpeed, ForceMode2D.Impulse);

        canShoot = true;
    }
}
