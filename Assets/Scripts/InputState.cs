using UnityEngine;
using System.Collections;

public class InputState : MonoBehaviour {

	public bool actionButton;
	public float absVelX = 0f;
	public float absVelY = 0f;
	public bool standing;
	public int standingThreshold = 1;

	private Rigidbody2D body2d;


	void Awake() {
		body2d = GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void Update () {
		//TODO: Make Space only
		actionButton = Input.anyKeyDown;
	}

	void FixedUpdate() {
		absVelX = System.Math.Abs (body2d.velocity.x);
		absVelY = System.Math.Abs (body2d.velocity.y);

		standing = absVelY <= standingThreshold;
	}
}
