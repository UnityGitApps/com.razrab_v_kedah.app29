using UnityEngine;

public class RotateBtn : MonoBehaviour
{
    [SerializeField] int direction;
    private void OnMouseEnter()
    {
        if (!GamePlay.current)
        {
            return;
        }

        GamePlay.current.AddTorque(direction * 45, ForceMode2D.Force);
    }
}
