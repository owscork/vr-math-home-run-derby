using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    Vector3 worldPosition;

    // Update is called once per frame
    private void Update()
    {
      worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + 2,Input.mousePosition.y, mainCamera.nearClipPlane + 0.3f));
      transform.position = worldPosition;
    }
}
