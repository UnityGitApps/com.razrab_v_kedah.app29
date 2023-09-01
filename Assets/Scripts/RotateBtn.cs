using UnityEngine;

public class RotateBtn : MonoBehaviour
{
    private bool isPressing;
    [SerializeField] int direction;

    private void OnMouseDown()
    {
        isPressing = true;
    }

    private void OnMouseUp()
    {
        isPressing = false;
    }

    private void Update()
    {
        if (!GamePlay.current || !isPressing)
        {
            return;
        }

        var lastVelocity = GamePlay.current.angularVelocity;
        GamePlay.current.angularVelocity = lastVelocity + direction * 200 * Time.deltaTime;
    }
}
