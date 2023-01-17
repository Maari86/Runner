
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float movementDistance;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdgel;

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdgel = transform.position.x + movementDistance;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

            }
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdgel)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

}
