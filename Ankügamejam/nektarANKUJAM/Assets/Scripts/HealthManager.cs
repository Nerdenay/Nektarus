using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] PlayerScript player;

    private void Start()
    {
        healthBar.value = player.GetHealth();
    }
    private void Update()
    {
        healthBar.value = player.GetHealth();
    }
}
