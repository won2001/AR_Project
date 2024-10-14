using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfo : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    [SerializeField] Text infoText;

    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
    }
    private Dictionary<string, string> planetDescriptions = new Dictionary<string, string>()
    {
        { "Mercury", "수성은 태양에 가장 가까운 행성입니다." },
        { "Venus", "금성은 태양계에서 두 번째로 가까운 행성입니다." },
        { "Earth", "지구는 생명체가 가장 살기좋은 행성입니다." },
        { "Mars", "화성은 지구와 가장 닮은 붉은 행성입니다." },
        { "Jupiter", "목성은 태양계에서 가장 큰 행성입니다." }
    };
    private void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Planet"))
                {
                    string planetName = hit.transform.name;
                    if (planetDescriptions.ContainsKey(planetName))
                    {
                        infoPanel.SetActive(true);
                        infoText.text = planetName + ": " + planetDescriptions[planetName];
                    }
                }
            }
        }
    }
}
