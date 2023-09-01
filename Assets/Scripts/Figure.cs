using UnityEngine;

public class Figure : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool IsDynamic
    {
        get => rb.bodyType == RigidbodyType2D.Dynamic;
    }

    private readonly static string[] figures = new string[] { "B", "I", "L", "T", "Z"};
    public static Rigidbody2D Instant()
    {
        var randomFigure = figures[Random.Range(0, figures.Length)];
        var go = Instantiate(Resources.Load<Rigidbody2D>($"figures/{randomFigure}"));

        var bodySprite = Resources.Load<Sprite>($"blocks/{Random.Range(0,6)}");
        foreach(Transform t in go.transform)
        {
            var render = t.GetComponent<SpriteRenderer>();
            render.sprite = bodySprite;
        }

        go.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 5) * 90);
        go.transform.position = new Vector2(-3.12f, Camera.main.transform.position.y + 7);

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
