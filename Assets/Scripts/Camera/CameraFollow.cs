using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float zoomLerpSpeed = 2f;

    private Camera cam;
    private float zoomSpeed;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        Move();
        Zoom();
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;

        // Lock the Z position to a specific value
        newPosition.z = -10;  // Assuming your camera's Z position is -10

        transform.position = newPosition;
    }

    private Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
            return targets[0].position;

        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

    private void Zoom()
    {
        float distance = GetGreatestDistance();

        // Invert the minZoom and maxZoom values for the desired zoom effect
        float newZoom = Mathf.Lerp(minZoom, maxZoom, distance / 10f);

        // Use lerp to smoothly adjust the camera's orthographic size
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, newZoom, ref zoomSpeed, zoomLerpSpeed);
    }

    private float GetGreatestDistance()
    {
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    public void FillTransList(Transform trs)
    {
        targets.Add(trs);
    }
}
