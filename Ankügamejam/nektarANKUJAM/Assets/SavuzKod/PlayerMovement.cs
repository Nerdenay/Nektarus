using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;
    private Vector2 movement;
    [SerializeField] Animator animator;
    [SerializeField] GameObject bullet;
    [SerializeField] Camera cam;
    Vector2 mousePos;
    [SerializeField] CameraManager cameraManager;
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(180, 0, 180);
        }
        if (mousePos.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("isWalking", true);
        } else
        {
            animator.SetBool("isWalking", false);
        }
    }


}








