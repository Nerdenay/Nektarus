using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMng : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject objectToFound;
    [SerializeField] GameObject border;
    CameraManager cameraManager;
    bool isFound = false;

    private void Start()
    {
        cameraManager = border.GetComponent<CameraManager>();
    }

    public void SetIsFound(bool value)
    {
        isFound = value;
    }


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox") &&  !isFound)
        {
            GiveMission();
        } else if (collision.gameObject.CompareTag("Hitbox") && isFound)
        {
            GiveGateStone();
        }
    }

    void GiveGateStone()
    {
        cameraManager.stoneCount++;
    }

    void GiveMission()
    {
        objectToFound.SetActive(true);
    }
}
