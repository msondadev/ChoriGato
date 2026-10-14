using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Transform puntoA;
    public Transform puntoB;

    private Vector3 destino;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        destino = puntoB.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (destino.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, destino, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino) < 0.1f)
        {
            destino = destino == puntoA.position ? puntoB.position : puntoA.position;
        }
    }
}
