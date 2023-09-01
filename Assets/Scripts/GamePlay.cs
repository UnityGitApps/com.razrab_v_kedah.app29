using System.Collections;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public static Rigidbody2D current;

    private void Start()
    {
        StartCoroutine(nameof(Spawn));
    }

    private void OnDestroy()
    {
        StopCoroutine(nameof(Spawn));
    }

    private IEnumerator Spawn()
    {
        while(!TapToStart.isStarted)
        {
            yield return null;
        }

        while(true)
        {
            current = Figure.Instant();
            yield return null;

            while (current.bodyType == RigidbodyType2D.Dynamic)
            {
                yield return null;
            }
        }
    }
}
