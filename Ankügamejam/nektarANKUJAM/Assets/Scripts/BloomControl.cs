using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloomControl : MonoBehaviour
{
    public Volume volume;
    private Bloom bloom;
    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;
    public float speed = 1f;

    private bool increasing = true;
    private float currentIntensity;

    void Start()
    {
        if (volume.profile.TryGet(out bloom))
        {
            currentIntensity = bloom.intensity.value;
        }
        else
        {
            Debug.LogError("Bloom effect not found in Volume Profile.");
        }
    }

    void Update()
    {
        if (bloom != null)
        {
            if (increasing)
            {
                currentIntensity += speed * Time.deltaTime;
                if (currentIntensity >= maxIntensity)
                {
                    currentIntensity = maxIntensity;
                    increasing = false;
                }
            }
            else
            {
                currentIntensity -= speed * Time.deltaTime;
                if (currentIntensity <= minIntensity)
                {
                    currentIntensity = minIntensity;
                    increasing = true;
                }
            }

            bloom.intensity.value = currentIntensity;
        }
    }
}