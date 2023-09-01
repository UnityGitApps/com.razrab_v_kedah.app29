using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void LateUpdate()
    {
        
    }

    private void CheckUpperBlock()
    {
        var figures = FindObjectsOfType<Figure>();
        float y = 0;
        foreach(Figure f in figures)
        {
            if(f.transform.position.y > y)
            {

            }
        }
    }
}
