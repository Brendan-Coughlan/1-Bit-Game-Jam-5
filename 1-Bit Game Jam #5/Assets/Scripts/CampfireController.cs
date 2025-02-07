using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CampfireController : MonoBehaviour
{
    [SerializeField] private float fuelRemaining;
    [SerializeField] private float maxFuel;
    [SerializeField] private float fuelConsumeRate;
    private Light2D campfireLight;

    private void Awake()
    {
        campfireLight = GetComponentInChildren<Light2D>();
    }

    private void Start()
    {
        fuelRemaining = maxFuel;
        StartCoroutine(ConsumeFuel());
    }

    private void Update()
    {
        campfireLight.pointLightInnerRadius = fuelRemaining * 0.01f;
        campfireLight.pointLightOuterRadius = fuelRemaining * 0.08f;
    }

    IEnumerator ConsumeFuel()
    {
        while (true)
        {
            yield return new WaitForSeconds(fuelConsumeRate);
            if(fuelRemaining >= 0)
            {
                fuelRemaining--;
            }
        }
    }

    public void AddToFuel(int woodCount)
    {
        fuelRemaining += woodCount * 10f;
        if(fuelRemaining > maxFuel)
        {
            fuelRemaining = maxFuel;
        }
    }
}
