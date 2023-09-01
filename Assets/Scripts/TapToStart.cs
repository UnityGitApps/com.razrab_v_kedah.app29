using UnityEngine;

public class TapToStart : MonoBehaviour
{
    public static bool isStarted;

    private void Awake()
    {
        isStarted = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            Destroy(gameObject);
        }
    }
}
