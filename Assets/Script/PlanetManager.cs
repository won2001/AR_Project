using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    [SerializeField] GameObject[] planets;

    public void HidePlanet()
    {
        foreach (GameObject planet in planets)
        {
            planet.SetActive(false);
        }
    }

    public void ShowPlanet(int planetIndex)
    {
        HidePlanet();
        planets[planetIndex].SetActive(true);
    }
}
