using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle1 : MonoBehaviour
{
    public int bossLevels;
    public GameObject indikator, bigIndikator, smallBullet, bigBullet;
    public int bossHealth;
    private bool changeLevel, canShoot, canShootMultipale, canShootBig, rootOnFire;
    private Transform player;
    [SerializeField] SpriteRenderer[] roots;
    private Animator bossAnim;
    public bool playerSeen;
    public GameObject afterDeadPill;
    public GameObject deadBoss;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossAnim = GetComponent<Animator>();
        bossLevels = 0;
        canShoot = true;
        changeLevel = true;
        canShootMultipale = true;
        canShootBig = true;
        rootOnFire = true;
    }

    private void Update()
    {
        if(playerSeen == true)
        {
            if (changeLevel == true)
            {
                StartCoroutine(ChangeAttack());
            }
            if (bossLevels == 0)
            {
                if (canShoot == true)
                {
                    StartCoroutine(Shoot1Projectile());
                }
            }
            else if (bossLevels == 1)
            {
                if (canShootBig == true)
                {
                    StartCoroutine(ShootBigProjectile());
                }
            }
            else if (bossLevels == 2)
            {
                if (canShootMultipale == true)
                {
                    StartCoroutine(ShootMultiple());
                }
            }
            else if (bossLevels == 3)
            {
                if (rootOnFire == true)
                {
                    StartCoroutine(SetRootOnFire());
                }
            }
            if (bossHealth <= 0)
            {
                Instantiate(deadBoss, transform.position, Quaternion.identity);
                afterDeadPill.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(GetHurt(5));
            Destroy(collision.gameObject);
        }
    }

    IEnumerator ChangeAttack()
    {
        changeLevel = false;
        yield return new WaitForSeconds(10f);
        bossLevels = Random.Range(0, 4);
        changeLevel = true;
    }

    IEnumerator Shoot1Projectile()
    {
        canShoot = false;
        bossAnim.SetBool("NormalSpit", true);
        yield return new WaitForSeconds(.5f);
        GameObject smallBall = Instantiate(smallBullet, transform.position, Quaternion.identity) as GameObject;
        smallBall.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.6f);
        Instantiate(indikator, new Vector2(Random.Range(player.position.x - 5, player.position.x + 5), Random.Range(player.position.y - 5, player.position.y + 5)), Quaternion.identity);
        bossAnim.SetBool("NormalSpit", false);
        yield return new WaitForSeconds(.2f);
        canShoot = true;
    }

    IEnumerator ShootBigProjectile()
    {
        canShootBig = false;
        yield return new WaitForSeconds(0.8f);
        Instantiate(bigIndikator, new Vector2(Random.Range(player.position.x - 5, player.position.x + 5), Random.Range(player.position.y - 5, player.position.y + 5)), Quaternion.identity);
        canShootBig = true;
        bossLevels = 0;
    }

    IEnumerator ShootMultiple()
    {
        canShootMultipale = false;
        bossAnim.SetBool("Speed", true);
        GameObject smallBall = Instantiate(smallBullet, transform.position, Quaternion.identity) as GameObject;
        smallBall.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.6f);
        Instantiate(indikator, new Vector2(Random.Range(player.position.x - 5, player.position.x + 5), Random.Range(player.position.y - 5, player.position.y + 5)), Quaternion.identity);
        yield return new WaitForSeconds(.2f);
        GameObject smallBall1 = Instantiate(smallBullet, transform.position, Quaternion.identity) as GameObject;
        smallBall1.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.6f);
        Instantiate(indikator, new Vector2(Random.Range(player.position.x - 5, player.position.x + 5), Random.Range(player.position.y - 5, player.position.y + 5)), Quaternion.identity);
        yield return new WaitForSeconds(.2f);
        GameObject smallBall2 = Instantiate(smallBullet, transform.position, Quaternion.identity) as GameObject;
        smallBall2.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.6f);
        Instantiate(indikator, new Vector2(Random.Range(player.position.x - 5, player.position.x + 5), Random.Range(player.position.y - 5, player.position.y + 5)), Quaternion.identity);
        yield return new WaitForSeconds(.2f);
        GameObject smallBall7 = Instantiate(smallBullet, transform.position, Quaternion.identity) as GameObject;
        smallBall7.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.6f);
        Instantiate(indikator, new Vector2(Random.Range(player.position.x - 5, player.position.x + 5), Random.Range(player.position.y - 5, player.position.y + 5)), Quaternion.identity);
        yield return new WaitForSeconds(.2f);
        GameObject smallBall3 = Instantiate(smallBullet, transform.position, Quaternion.identity) as GameObject;
        smallBall3.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.6f);
        Instantiate(indikator, new Vector2(Random.Range(player.position.x - 5, player.position.x + 5), Random.Range(player.position.y - 5, player.position.y + 5)), Quaternion.identity);
        yield return new WaitForSeconds(.2f);
        GameObject smallBall4 = Instantiate(smallBullet, transform.position, Quaternion.identity) as GameObject;
        smallBall4.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.6f);
        Instantiate(indikator, new Vector2(Random.Range(player.position.x - 5, player.position.x + 5), Random.Range(player.position.y - 5, player.position.y + 5)), Quaternion.identity);
        yield return new WaitForSeconds(.2f);
        GameObject smallBall5 = Instantiate(smallBullet, transform.position, Quaternion.identity) as GameObject;
        smallBall5.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.6f);
        Instantiate(indikator, new Vector2(Random.Range(player.position.x - 5, player.position.x + 5), Random.Range(player.position.y - 5, player.position.y + 5)), Quaternion.identity);
        yield return new WaitForSeconds(.2f);
        GameObject smallBall6 = Instantiate(smallBullet, transform.position, Quaternion.identity) as GameObject;
        smallBall6.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.6f);
        Instantiate(indikator, new Vector2(Random.Range(player.position.x - 5, player.position.x + 5), Random.Range(player.position.y - 5, player.position.y + 5)), Quaternion.identity);
        yield return new WaitForSeconds(.2f);
        bossAnim.SetBool("Speed", false);
        canShootMultipale = true;
        bossLevels = 0;
    }

    IEnumerator SetRootOnFire()
    {
        rootOnFire = false;
        int a = Random.Range(0, roots.Length);
        roots[a].color = Color.yellow;
        yield return new WaitForSeconds(1);
        roots[a].color = Color.red;
        yield return new WaitForSeconds(3);
        roots[a].color = Color.white;
        rootOnFire = true;
        bossLevels = 0;
    }
    IEnumerator GetHurt(int damage)
    {
        bossAnim.SetBool("Hurt", true);
        bossHealth -= damage;
        yield return new WaitForSeconds(.3f);
        bossAnim.SetBool("Hurt", false);
    }
}
