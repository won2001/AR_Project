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
                    infoPanel.SetActive(true); // 정보 창 활성화
                    infoText.text = hit.transform.name + "의 정보"; // 행성 정보 업데이트
                }
            }
        }
    }
}
