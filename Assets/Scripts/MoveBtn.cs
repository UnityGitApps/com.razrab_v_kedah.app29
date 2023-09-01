using UnityEngine;

public class MoveBtn : MonoBehaviour
{
    [SerializeField] int direction;
    private void OnMouseEnter()
    {
        if(!GamePlay.current)
        {
            return;
        }

        GamePlay.current.AddForce(new Vector2(30 * direction, 0), ForceMode2D.Force);
    }
}
