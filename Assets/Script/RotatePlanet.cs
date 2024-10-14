using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    void Update()
    {
        // 행성을 지속적으로 회전시키는 코드
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
