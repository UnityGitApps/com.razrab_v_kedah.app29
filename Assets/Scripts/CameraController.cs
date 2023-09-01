using UnityEngine;
using System.Collections.Generic;
using System;

public class CameraController : MonoBehaviour
{
    private float lastDistance;

    private Vector3 target;
    private EdgeCollider2D border;

    public static Action<float> OnDistanceChanged { get; set; }

    private void Awake()
    {
        border = GameObject.Find("border").GetComponent<EdgeCollider2D>();
    }

    private void Start()
    {
        target = transform.position;
        target.z = -10;

        InvokeRepeating(nameof(CheckUpperBlock), 0.0f, 1.0f);
    }

    private void OnDestroy()
    {
        CancelInvoke(nameof(CheckUpperBlock));
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 3.0f * Time.deltaTime);
    }

    private void CheckUpperBlock()
    {
        var figures = FindObjectsOfType<Figure>();

        float y = 0;
        foreach(Figure f in figures)
        {
            if(f.IsDynamic)
            {
                continue;
            }

            var _distance = Mathf.Abs(-4.8f - f.transform.position.y);
            if (f.transform.position.y > -4.8 && _distance > lastDistance)
            {
                lastDistance = _distance;
                OnDistanceChanged?.Invoke(lastDistance);
            }

            if(f.transform.position.y > y)
            {
                y = f.transform.position.y;
            }
        }

        target = new Vector3(0, y, -10);

        var cameraTransform = Camera.main.transform;

        var upperLeft = new Vector2(-2.23f, cameraTransform.position.y + 10);
        var downLeft = new Vector2(-2.23f, -2.8f);

        var downRight = new Vector2(2.84f, -2.8f);
        var upperRight = new Vector2(2.84f, cameraTransform.position.y + 10);

        border.SetPoints(new List<Vector2>
        {
            upperLeft, downLeft, downRight, upperRight
        });
    }
}
