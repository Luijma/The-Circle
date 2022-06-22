using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;

    private float XLimit = 13.5f;
    private float YLimit = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Forcing character to stay withing screen limits
        if (transform.position.x < -XLimit)
        {
            transform.position = new Vector2(-XLimit, transform.position.y);
        }
        if (transform.position.x > XLimit)
        {
            transform.position = new Vector2(XLimit, transform.position.y);
        }
        if (transform.position.y < -YLimit)
        {
            transform.position = new Vector2(transform.position.x, -YLimit);
        }
        if (transform.position.y > YLimit + 1)
        {
            transform.position = new Vector2(transform.position.x, YLimit);
        }
        //Handle Input in Update
        //Get Horizontal and Vertical movement based on user input
        movement.x = Input.GetAxisRaw("Horizontal"); //shifts between 1(right) and -1(left) on host input
        movement.y = Input.GetAxisRaw("Vertical");

        //Adjust parameters to movements based on player input
        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude); //Length of movement vector for bette performance

    }

    void FixedUpdate()
    {
        //Handle Solid Movemente in FixedUpdate
        //Moves Rigidbody to new position and collides with anything
        //that gets in its way
        //MovePosition parameters:
        // -Position of player accessed by .position
        // -Movement based on user input
        // -Speed of movement
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}