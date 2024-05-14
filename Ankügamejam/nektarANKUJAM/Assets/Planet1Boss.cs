using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet1Boss : MonoBehaviour
{
    public int bossLevels;
    public GameObject snowball;
    public int bossHealth;
    private bool changeLevel, canShoot, canScream, canPunch;
    private Transform player;
    private Animator bossAnim;
    [SerializeField] AudioSource bossScream;
    public bool playerSeen;
    [SerializeField] GameObject afterDeadPill;
    public GameObject deadBoss;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossAnim = GetComponent<Animator>();
        bossLevels = 0;
        canShoot = true;
        changeLevel = true;
        canPunch = true;
        canScream = true;
    }

    private void Update()
    {
        if(playerSeen == true)
        {
            if (changeLevel == true)
            {
                StartCoroutine(ChangeAttack());
            }
            if (Vector2.Distance(transform.position, player.position) > 1.5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, 3 * Time.deltaTime);
            }
            if (bossLevels == 0)
            {
                if (canPunch == true && Vector2.Distance(transform.position, player.position) < 3.5f)
                {
                    StartCoroutine(Hit());
                }
            }
            else if (bossLevels == 1)
            {
                if (canShoot == true)
                {
                    StartCoroutine(ShootProjectile());
                }
            }
            else if (bossLevels == 2)
            {
                if (canScream == true)
                {
                    StartCoroutine(Scream());
                }
            }
            if (bossHealth <= 0)
            {
                Instantiate(deadBoss, transform.position, Quaternion.identity);
                afterDeadPill.SetActive(true);
                Destroy(gameObject);
            }
            if (transform.position.x > player.position.x) transform.eulerAngles = new Vector3(0, 0, 0);
            else if (transform.position.x < player.position.x) transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(GetHurt());
            Destroy(collision.gameObject);
        }
    }

    IEnumerator ChangeAttack()
    {
        changeLevel = false;
        yield return new WaitForSeconds(10f);
        bossLevels = Random.Range(0, 3);
        changeLevel = true;
    }

    IEnumerator Scream()
    {
        canScream = false;
        bossAnim.SetBool("Scream", true);
        bossScream.Play();
        yield return new WaitForSeconds(.75f);
        GameObject snowFall = Instantiate(snowball, new Vector2(Random.Range(player.transform.position.x - 2, player.transform.position.x + 2), player.position.y + 3), Quaternion.identity);
        snowFall.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 10, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.75f);
        GameObject snowFall1 = Instantiate(snowball, new Vector2(Random.Range(player.transform.position.x - 2, player.transform.position.x + 2), player.position.y + 3), Quaternion.identity);
        snowFall1.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 10, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.75f);
        GameObject snowFall2 = Instantiate(snowball, new Vector2(Random.Range(player.transform.position.x - 2, player.transform.position.x + 2), player.position.y + 3), Quaternion.identity);
        snowFall2.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 10, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.75f);
        GameObject snowFall3 = Instantiate(snowball, new Vector2(Random.Range(player.transform.position.x - 2, player.transform.position.x + 2), player.position.y + 3), Quaternion.identity);
        snowFall3.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 10, ForceMode2D.Impulse);
        bossAnim.SetBool("Scream", false);
        yield return new WaitForSeconds(1.2f);
        canScream = true;
        bossLevels = 0;
    }

    IEnumerator ShootProjectile()
    {
        canShoot = false;
        bossAnim.SetBool("Throw", true);
        yield return new WaitForSeconds(0.8f);
        GameObject snow = Instantiate(snowball, transform.position, Quaternion.identity) as GameObject;
        if (transform.eulerAngles == new Vector3(0, 0, 0)) snow.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -10, ForceMode2D.Impulse);
        else if (transform.eulerAngles == new Vector3(0, 180, 0)) snow.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10, ForceMode2D.Impulse);
        bossAnim.SetBool("Throw", false);
        canShoot = true;
        bossLevels = 0;
    }

    IEnumerator Hit()
    {
        canPunch = false;
        bossAnim.SetBool("Punch", true);
        yield return new WaitForSeconds(.5f);
        if (Vector2.Distance(transform.position, player.position) < 3) player.GetComponent<PlayerScript>().TakeDamage(2);
        yield return new WaitForSeconds(.5f);
        bossAnim.SetBool("Punch", false);
        yield return new WaitForSeconds(.5f);
        canPunch = true;
        bossLevels = 0;
    }
    IEnumerator GetHurt()
    {
        bossAnim.SetBool("Hurt", true);
        bossHealth--;
        yield return new WaitForSeconds(.35f);
        bossAnim.SetBool("Hurt", false);
    }


}
