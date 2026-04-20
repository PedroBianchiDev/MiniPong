using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private string horizontallWallTag, verticalWallTag, paddleTag;

    [SerializeField]
    private float iniBallSpeed = 7;

    private float ballSpeed;
    private Vector2 direction;

    void Start()
    {
        direction = new Vector2(1, 1);
        ballSpeed = iniBallSpeed;
    }

    void Update()
    {
        transform.Translate(direction * ballSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == verticalWallTag)
        {
            direction = new Vector2(direction.x, -direction.y);

        }

        if (collision.gameObject.tag == horizontallWallTag)
        {
            direction = new Vector2(-direction.x, direction.y);
            AddPoint();
        }

        if (collision.gameObject.tag == paddleTag)
        {
            direction = new Vector2(-direction.x, direction.y);
        }
    }

    private void AddPoint()
    {
        gameManager.AddPointAndVerifyWinner(transform.position.x);
        gameManager.ResetBall();
    }
}
