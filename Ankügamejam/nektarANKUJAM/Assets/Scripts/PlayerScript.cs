using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] HealthManager healthManager;
    [SerializeField] AudioSource hurtSound;
    int health;

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            hurtSound.Play();
        }
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
