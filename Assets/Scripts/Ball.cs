using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 200.0f;
    private Rigidbody2D _rigidBody;

    public void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    public void Start()
    {
        ResetPosition();
        AddStartingForce();
    }

    public void ResetPosition()
    {
        _rigidBody.position = Vector3.zero;
        _rigidBody.velocity = Vector3.zero;
    }

    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : 
                                        Random.Range(0.5f, 1.0f);
        Vector2 direction = new(x, y);
        _rigidBody.AddForce(direction * speed);
    }
    

    public void AddForce(Vector2 force)
    {
        _rigidBody.AddForce(force);
    }
}
