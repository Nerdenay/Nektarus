using System.Collections;
using UnityEngine;

public class TornadoPlace : MonoBehaviour
{
    private bool isDamaging = false; // Hasar verme iþleminin devam edip etmediðini kontrol eder

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ElectricBoss.tornadoAttackHappening && !isDamaging)
            {
                StartCoroutine(DamagePlayer(collision.gameObject));
            }
        }
    }

    IEnumerator DamagePlayer(GameObject player)
    {
        isDamaging = true; // Hasar verme iþlemi baþladý

        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Player takes damage from tornado!");
            // Burada oyuncuya hasar verme iþlemini ekleyebilirsin
            player.GetComponent<PlayerScript>().TakeDamage(1);
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f); // 0.5 saniye bekle
        isDamaging = false; // Hasar verme iþlemi bitti, tekrar baþlayabilir
    }
}
