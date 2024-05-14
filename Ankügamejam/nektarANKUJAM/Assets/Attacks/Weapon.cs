using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireforce = 20f;
    public float angle;
    private Rigidbody2D rb;
    [SerializeField] Camera cam;
    Vector2 mousePos;
    [SerializeField] Transform anchorPos;
    private bool canShoot;
    [SerializeField] AudioSource gunSound;
    [SerializeField] CameraShake shake1, shake2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canShoot = true;
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - (Vector2)anchorPos.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 180;

        // Silahýn rotasyonunu güncelle
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if(transform.position.x < mousePos.x)
        {
            transform.localEulerAngles = new Vector3(0, 0, 180 - transform.localEulerAngles.z);

        }

        // Silahýn pozisyonunu anchorPos'a sabitle
        transform.position = anchorPos.position;

        // Ateþ etme tuþu kontrolü (Örneðin, sol fare tuþu)
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        canShoot = false;
        gunSound.Play();
        shake1.ShakeCamera();
        shake2.ShakeCamera();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Vector2 fireDirection = (mousePos - (Vector2)firePoint.position).normalized;
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * -fireforce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
}
