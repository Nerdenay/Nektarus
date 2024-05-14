using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private Texture[] textures;
    private int animationStep;
    [SerializeField] private float fps = 30f;
    private float fpsCounter;

    private Transform bossTransform;
    private Transform target;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (bossTransform != null && target != null)
        {
            lineRenderer.SetPosition(0, bossTransform.position); // Bossun pozisyonunu güncelle
            lineRenderer.SetPosition(1, target.position); // Hedefin pozisyonunu güncelle
        }

        fpsCounter += Time.deltaTime;
        if (fpsCounter >= 1f / fps)
        {
            animationStep++;
            if (animationStep == textures.Length)
            {
                animationStep = 0;
            }

            lineRenderer.material.SetTexture("_MainTex", textures[animationStep]);

            fpsCounter = 0f;
        }
    }

    public void AssignTarget(Transform boss, Transform newTarget)
    {
        lineRenderer.positionCount = 2;
        bossTransform = boss;
        target = newTarget;
        lineRenderer.SetPosition(0, bossTransform.position); // Baþlangýçta bossun pozisyonunu ayarla
        lineRenderer.SetPosition(1, target.position); // Baþlangýçta hedefin pozisyonunu ayarla
    }
}
