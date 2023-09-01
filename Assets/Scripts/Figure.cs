using UnityEngine;

public class Figure : MonoBehaviour
{
    private Rigidbody2D rb;
    private readonly static string[] figures = new string[] { "B", "I", "L", "T", "Z"};
    public static Rigidbody2D Instant()
    {
        var randomFigure = figures[Random.Range(0, figures.Length)];
        var go = Instantiate(Resources.Load<Rigidbody2D>($"figures/{randomFigure}"));
        go.velocity = Vector2.down;
        return go;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(rb.bodyType == RigidbodyType2D.Static)
        {
            return;
        }

        if(rb.velocity.magnitude <= 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
