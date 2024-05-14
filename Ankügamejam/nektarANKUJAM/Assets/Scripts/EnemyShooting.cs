using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    bool ableToShoot;
    [SerializeField] Transform bulletPos;
    [SerializeField] GameObject bullet;
    // Update is called once per frame
    private void Start()
    {
        ableToShoot = true;
    }
    void Update()
    {
        if (ableToShoot)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        ableToShoot = false;
        yield return new WaitForSeconds(1);
        fire();
        ableToShoot = true;
    }

    void fire()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
