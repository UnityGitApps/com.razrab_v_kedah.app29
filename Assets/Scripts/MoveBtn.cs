using UnityEngine;

public class MoveBtn : MonoBehaviour
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

        var lastVelocity = GamePlay.current.velocity;
        GamePlay.current.velocity = new Vector2(lastVelocity.x + direction * 3 * Time.deltaTime, lastVelocity.y);
    }
}
