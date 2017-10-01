using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Animator anim;
	int ud = 0;
	int lr = 0;
	[SerializeField] private float movespeed;
	bool move = true;
    
    [SerializeField] private string axisUD;
    [SerializeField] private string axisLR;
    [SerializeField] private LayerMask layerMask;

	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		lr = (int)Input.GetAxisRaw (axisLR);
		ud = (int)Input.GetAxisRaw (axisUD);
		if (Input.GetKeyDown ("m") && move) {
			move = false;
		}
		if (Input.GetKeyDown ("m") && !move) {
			move = true;
		}
		if (move) {
            Vector3 test = new Vector3(movespeed * lr * Time.deltaTime * Time.deltaTime, movespeed * ud * Time.deltaTime * Time.deltaTime, 0);
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, test.normalized, test.magnitude, layerMask);
            foreach(RaycastHit2D r in hits)
            {
                if(r.collider.gameObject.tag == "wall");
                {
                    move = false;
                    break;
                }
            }
            if(move)
            {
                transform.Translate(test);
            }
		}
	}
}
