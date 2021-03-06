using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public AudioSource Audio_Coin_Player;

    public float speed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public SpriteRenderer characterImage;
    public Sprite[] avatars;
    private float XLimit = 27f;
    private float YLimit = 13f;

    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
        characterImage = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
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
            if (transform.position.y > YLimit)
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
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Audio_Coin_Player.Play();
        }
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