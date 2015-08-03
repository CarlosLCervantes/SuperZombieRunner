using UnityEngine;
using System.Collections;

public class PlayerAnimatorManager : MonoBehaviour {

	private Animator animator;
	private InputState inputState;

	void Awake() {
		animator = GetComponent<Animator> ();
		inputState = GetComponent<InputState> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var running = true;

		string msg = inputState.absVelX + " / " + inputState.absVelY + " / " + inputState.standingThreshold;
		Debug.Log (msg);
		if (inputState.absVelX > 0 && inputState.absVelY < inputState.standingThreshold) {
			running = false;
		}

		animator.SetBool ("Running", running);
	
	}
}
