using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    private float shakeIntensity = 5f;
    private float shakeTime = .2f;
    private float timer;
    private CinemachineBasicMultiChannelPerlin cbmcp;

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin cbmcp = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = shakeIntensity;
        timer = shakeTime;
    }
    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin cbmcp = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = 0;
        timer = 0;
    }

    private void Start()
    {
        StopShake();
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                StopShake();
            }
        }
    }
}
