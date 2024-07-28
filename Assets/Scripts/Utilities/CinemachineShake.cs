using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingIntensity;
    private float startingFrequency;

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time, float frequency)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        if (cinemachineBasicMultiChannelPerlin != null)
        {
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
            cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frequency;
            startingIntensity = intensity;
            startingFrequency = frequency;
            shakeTimer = time;
            shakeTimerTotal = time;
        }
        else
        {
            Debug.LogWarning("CinemachineBasicMultiChannelPerlin component not found!");
        }
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            if (cinemachineBasicMultiChannelPerlin != null)
            {
                // Gradually decrease the intensity and frequency
                float shakeProgress = 1 - (shakeTimer / shakeTimerTotal);
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, shakeProgress);
                cinemachineBasicMultiChannelPerlin.m_FrequencyGain = Mathf.Lerp(startingFrequency, 0f, shakeProgress);

                if (shakeTimer <= 0f)
                {
                    // Timer over
                    cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
                    cinemachineBasicMultiChannelPerlin.m_FrequencyGain = 0f;
                }
            }
        }
    }
}
