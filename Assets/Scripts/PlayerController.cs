using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
	public int jumpForce;
	private bool canJump = true;
	private int numberOfPickUps;

	private float movementX;
	private float movementY;

	private Rigidbody rb;
	private int count;
	private GameObject[] Pickups;

	// At the start of the game..
	void Start()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		SetCountText();

		Pickups = GameObject.FindGameObjectsWithTag("PickUp");

		numberOfPickUps = GameObject.FindGameObjectsWithTag("PickUp").Length;

		// Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winTextObject.SetActive(false);
	}
    void FixedUpdate()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

		rb.AddForce(movement * speed);
		if (Input.GetKey("space") && canJump)
		{
			rb.AddForce(new Vector3(0, 1 * jumpForce, 0));
			canJump = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText();
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.CompareTag("Ground"))
		{
			canJump = true;
		}
		if(collision.gameObject.CompareTag("OffGame"))
		{
			Restart();
		}
	}

    void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;
	}

	public void Restart()
    {
		count = 0;
		SetCountText();
		Transform tr = GetComponent<Transform>();
		tr.position = new Vector3(0, 1, 0);
		rb.velocity = new Vector3(0, 0, 0);
		//NOTA quitar fuerza a la bola para que no se mueva al hacer spawn
		foreach (GameObject go in Pickups)
		{
			go.SetActive(true);
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		

		if (count >= numberOfPickUps)
		{
			// Set the text value of your 'winText'
			winTextObject.SetActive(true);
		}
        else
        {
			winTextObject.SetActive(false);
		}
	}
}