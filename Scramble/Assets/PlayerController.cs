using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Animator anim;
	int ud = 0;
	int lr = 0;
	public float movespeed;
	bool move = true;

	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		lr = (int)Input.GetAxisRaw ("Horizontal");
		ud = (int)Input.GetAxisRaw ("Vertical");		
		if (Input.GetKeyDown ("m") && move) {
			move = false;
		}
		if (Input.GetKeyDown ("m") && !move) {
			move = true;
		}
		if (move) {
			transform.Translate (movespeed * lr * Time.deltaTime * Time.deltaTime, movespeed * ud * Time.deltaTime * Time.deltaTime, 0);
		}
	}
}
