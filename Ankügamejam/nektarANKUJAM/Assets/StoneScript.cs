using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    [SerializeField] GameObject border;
    CameraManager cameraManager;
    LandCleaned landCleanedStone;
    private void Start()
    {
        cameraManager = border.GetComponent<CameraManager>();
        landCleanedStone = GameObject.FindAnyObjectByType<LandCleaned>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (landCleanedStone.currentScene == 2)
        //{
            if (collision.gameObject.CompareTag("Hitbox"))
            {
                cameraManager.stoneCount++;
                cameraManager.CheckForStones();
                Destroy(this.gameObject);
            }
        //}
        //else
        //{
            if (collision.gameObject.CompareTag("Player"))
            {
                cameraManager.stoneCount++;
                cameraManager.CheckForStones();
                Destroy(this.gameObject);
            }
        //}

    }
}
