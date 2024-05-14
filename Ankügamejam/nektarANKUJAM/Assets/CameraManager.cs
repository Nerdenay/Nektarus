using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] BoxCollider2D box;
    [SerializeField] Animator cutSceneAnim;
    [SerializeField] GameObject bossScript;
    public int stoneCount;
    [SerializeField] string bossName;
    [SerializeField] bool up;
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(up == true)
            {
                if(collision.transform.position.y > transform.position.y)
                {
                    box.isTrigger = false;
                    cutSceneAnim.SetBool("Switch", true);
                    StartCoroutine(WaitToSeePlayer());
                }
            }
            else if(up == false)
            {
                if (collision.transform.position.y < transform.position.y)
                {
                    box.isTrigger = false;
                    cutSceneAnim.SetBool("Switch", true);
                    StartCoroutine(WaitToSeePlayer());
                }
            }
        }
    }

    public void CheckForStones()
    {
        if(stoneCount == 3)
        {
            Destroy(transform.GetChild(0).gameObject);
            box.isTrigger = true;
        }
    }

    IEnumerator WaitToSeePlayer()
    {
        yield return new WaitForSeconds(.5f);
        if(bossName == "Fire") bossScript.GetComponent<BossBattle1>().playerSeen = true;
        if(bossName == "Elec")
        {
            bossScript.GetComponent<ElectricBoss>().playerSeen = true;
            foreach (var item in bossScript.GetComponent<ElectricBoss>().allTowers)
            {
                item.GetComponent<RangerEnemyMoveAndShoot>().enabled = true;
            }
        }
        if(bossName == "Yeti") bossScript.GetComponent<Planet1Boss>().playerSeen = true;
    }
}
