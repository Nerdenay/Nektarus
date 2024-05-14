using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indikator : MonoBehaviour
{
    public GameObject projecktile;
    public float waitTime;
    public GameObject splash;

    private void Start()
    {
        StartCoroutine(MakeBullet());
    }

    IEnumerator MakeBullet()
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(projecktile, transform.position, Quaternion.identity);
        Instantiate(splash, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
