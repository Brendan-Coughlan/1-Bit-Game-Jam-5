using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireController : MonoBehaviour
{
    [SerializeField] private float fuel;
    [SerializeField] private float maxFuel;
    [SerializeField] private float fuelConsumeRate;

    private void Start()
    {
        fuel = maxFuel;
        StartCoroutine(ConsumeFuel());
    }

    IEnumerator ConsumeFuel()
    {
        while (true)
        {
            yield return new WaitForSeconds(fuelConsumeRate);
            if(fuel >= 0)
            {
                fuel--;
            }
        }
    }

    public void AddToFuel(int woodCount)
    {
        fuel += woodCount * 10f;
        if(fuel > maxFuel)
        {
            fuel = maxFuel;
        }
    }
}
