using TMPro;
using UnityEngine;

public class DistanceText : MonoBehaviour
{
    private float distance;
    private float targetDistance;

    private TextMeshPro distanceText;

    private void Awake()
    {
        distanceText = GetComponent<TextMeshPro>();
        CameraController.OnDistanceChanged += CameraController_OnDistanceChanged;
    }

    private void OnDestroy()
    {
        CameraController.OnDistanceChanged -= CameraController_OnDistanceChanged;
    }

    private void Update()
    {
        distance = Mathf.MoveTowards(distance, targetDistance, 1.5f * Time.deltaTime);
        distanceText.text = $"{distance:N2}m";
    }

    private void CameraController_OnDistanceChanged(float newDistance)
    {
        targetDistance = newDistance;
    }
}
