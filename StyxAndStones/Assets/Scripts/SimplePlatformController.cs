using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour {

	[HideInInspector] public bool facing_right = true;
	[HideInInspector] public bool jump = false;

	public static float move_force = 365f;
	public static float max_speed = 5f;
	[SerializeField] public static float jump_force = 2000f;
	public Transform ground_check;
	public GameObject background;
	public AudioSource jumpSFX;

	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast (transform.position,
		                               ground_check.position,
		                               1 << LayerMask.NameToLayer ("Ground"));
		if (Input.GetButtonDown("Jump") && grounded) {
			jump = true;
		}
	}

	void FixedUpdate() {
		float height = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (height));
		 
		if ((height * rb2d.velocity.x) < max_speed) {
			rb2d.AddForce(Vector2.right * height * move_force);
		}

		if (Mathf.Abs(rb2d.velocity.x) > max_speed) {
			rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * max_speed, rb2d.velocity.y);
		}

		if (height > 0 && !facing_right) {
			Flip ();
		} else if (height < 0 && facing_right) {
			Flip ();
		}

		if (jump) {
			anim.SetTrigger("Jump");
			jumpSFX.Play ();
			rb2d.AddForce(new Vector2(0f, jump_force));
			jump = false;
		}

	}
	
	void Flip() {
		facing_right = !facing_right;

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;

		Vector3 bgscale = background.transform.localScale;
		bgscale.x *= -1;
		background.transform.localScale = bgscale;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}	

	public static void stopMoving () {
		max_speed = 0f;
		move_force = 0f;
		jump_force = 0f;
	}
}
