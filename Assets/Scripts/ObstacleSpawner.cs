using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // assign in Inspector
    public float spawnInterval = 2f;
    public float speed = 5f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        var obs = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        var rb = obs.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity = Vector2.left * speed;
        obs.AddComponent<BoxCollider2D>();
    }
}
