using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpotlightController : MonoBehaviour
{
    public Light2D spotLight;  // Spot Light referans�
    public float minIntensity = 0.75f;
    public float maxIntensity = 1.5f;
    public float cycleDuration = 3f;  // Tam bir art�� ve azalma d�ng�s� s�resi

    void Start()
    {
        if (spotLight == null)
        {
            spotLight = GetComponent<Light2D>();
        }
        StartCoroutine(ChangeIntensity());
    }

    IEnumerator ChangeIntensity()
    {
        while (true)
        {
            // Yo�unlu�u art�r
            float elapsedTime = 0f;
            while (elapsedTime < cycleDuration / 2)
            {
                spotLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, elapsedTime / (cycleDuration / 2));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Yo�unlu�u azalt
            elapsedTime = 0f;
            while (elapsedTime < cycleDuration / 2)
            {
                spotLight.intensity = Mathf.Lerp(maxIntensity, minIntensity, elapsedTime / (cycleDuration / 2));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
