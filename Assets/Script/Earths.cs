using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Earths : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float zoomSpeed;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                float rotationX = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
                float rotationY = touch.deltaPosition.y * rotationSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, -rotationX, Space.World);
                transform.Rotate(Vector3.right, rotationY, Space.World);
            }
        }
        if (Input.touchCount == 2)
        {
            Touch zoomTouch = Input.GetTouch(0);
            Touch zoomTouch1 = Input.GetTouch(1);

            Vector2 zoomTouchPos = zoomTouch.position - zoomTouch.deltaPosition;
            Vector2 zommTouch1Pos = zoomTouch1.position - zoomTouch1.deltaPosition;

            float prevTouchDeltaMag = (zoomTouchPos - zommTouch1Pos).magnitude;
            float touchDeltaMag = (zoomTouch.position - zoomTouch1.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            float newScale = transform.localScale.x - deltaMagnitudeDiff * zoomSpeed;
            newScale = Mathf.Clamp(newScale, 0.5f, 2f);
            transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }
}
