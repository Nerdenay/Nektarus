using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ElectricBoss : MonoBehaviour
{
    public List<IceTower> allTowers;
    [SerializeField] private List<LineController> allLines;
    [SerializeField] private LineController linePrefab;

    public enum BossState
    {
        Walking,
        DashingAndAttacking,
        Dying
    }
    public GameObject tornadoPlace;
    public BossState currentState;
    public float speed;
    private Animator bossAnim;
    public float bossHealth;
    private Vector2 randomSpot;
    private bool changePosition = true;
    private bool canDash = true;
    public GameObject bossDead;
    public bool playerSeen;
    private GameObject player;
    public float detectionRange = 10f;
    private bool isChangeAttackCoroutineRunning = false;

    public static bool tornadoAttackHappening;
    [SerializeField] AudioSource bossDamageSound;
    [SerializeField] GameObject afterDeadStone;
    [SerializeField] Slider healthBar;
    public GameObject deadBoss;

    void Start()
    {
        currentState = BossState.Walking;
        speed = 2;
        playerSeen = false;
        player = GameObject.FindGameObjectWithTag("Player");

        healthBar.maxValue = bossHealth;

        bossAnim = GetComponent<Animator>();
        allLines = new List<LineController>();

        for (int i = 0; i < allTowers.Count; i++)
        {
            LineController newLine = Instantiate(linePrefab);
            newLine.transform.SetParent(allTowers[i].transform); // LineController'ý ilgili tower'ýn child'ý yap
            allLines.Add(newLine);
            newLine.AssignTarget(transform, allTowers[i].transform); // Bossun transformunu ve kulenin transformunu geç
            allTowers[i].GetComponent<RangerEnemyMoveAndShoot>().enabled = false;
        }
    }

    void Update()
    {
        //DetectPlayer();

        if (playerSeen)
        {
            HandleBossBehavior();

            if (!isChangeAttackCoroutineRunning)
            {
                StartCoroutine(ChangeAttack());
            }
        }

        
    }

    /*private void DetectPlayer()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= detectionRange)
            {
                playerSeen = true;
            }
            else
            {
                playerSeen = false;
            }
        }
    }*/

    private void UpdateHealthBar()
    {
        healthBar.value = bossHealth;
    }

    private void HandleBossBehavior()
    {
        switch (currentState)
        {
            case BossState.Walking:
                HandleWalking();
                break;
            case BossState.DashingAndAttacking:
                HandleDashingAndAttacking();
                break;
            case BossState.Dying:
                HandleDying();
                break;
        }
    }

    private void HandleWalking()
    {
        if (speed > 0)
        {
            if (changePosition)
            {
                StartCoroutine(SetRandomSpotToWalk());
            }
            MoveBoss();
        }

        if (bossHealth <= 0)
        {
            currentState = BossState.Dying;
        }
    }

    private void HandleDashingAndAttacking()
    {
        if (canDash)
        {
            StartCoroutine(DashAndAttackPlayer());
        }

        if (bossHealth <= 0)
        {
            currentState = BossState.Dying;
        }
    }

    private void HandleDying()
    {
        HandleBossDeath();
    }

    private void MoveBoss()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + randomSpot.x, transform.position.y + randomSpot.y), speed * Time.deltaTime);
    }

    private void HandleBossDeath()
    {
        Instantiate(deadBoss, transform.position, Quaternion.identity);
        afterDeadStone.SetActive(true);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(GetHurt());
        }
    }

    IEnumerator GetHurt()
    {
        if (bossAnim != null)
        {
            bossAnim.SetBool("isHurt", true);
        }
        bossDamageSound.Play();
        bossHealth -= 5;
        yield return new WaitForSeconds(0.5f);
        if (bossAnim != null)
        {
            bossAnim.SetBool("isHurt", false);
            bossAnim.SetBool("isWalking", true);
        }
        bossDamageSound.Stop();
        UpdateHealthBar();
    }

    IEnumerator ChangeAttack()
    {
        isChangeAttackCoroutineRunning = true;

        while (true)
        {
            yield return new WaitForSeconds(4f);
            currentState = (Random.Range(0, 2) == 0) ? BossState.Walking : BossState.DashingAndAttacking;
        }
    }

    IEnumerator SetRandomSpotToWalk()
    {
        changePosition = false;
        randomSpot = new Vector2(Random.Range(-5, 6), Random.Range(-5, 6));
        yield return new WaitForSeconds(1f);
        changePosition = true;
    }

    IEnumerator DashAndAttackPlayer()
    {
        canDash = false;
        Vector2 dashPosition = (Vector2)player.transform.position + new Vector2(0, 3f); // Player'ýn 5 birim üstü
        float dashTime = 0.2f;
        float elapsedTime = 0f;

        while (elapsedTime < dashTime)
        {
            transform.position = Vector2.Lerp(transform.position, dashPosition, (elapsedTime / dashTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Burada saldýrý iþlemi gerçekleþecek
        if (bossAnim != null)
        {
            bossAnim.SetBool("isWalking", true); // Saldýrý animasyonunu tetikle
            
        }

        yield return StartCoroutine(PerformAttack()); // Saldýrý coroutine'ini baþlat
        tornadoAttackHappening = false;
        canDash = true;
        currentState = BossState.Walking;
    }

    IEnumerator PerformAttack()
    {
        tornadoAttackHappening = true;
        // Burada saldýrý iþlemi gerçekleþecek
        if (bossAnim != null)
        {
            bossAnim.SetTrigger("Attack");
        }
        yield return new WaitForSeconds(1f);

    }
}
