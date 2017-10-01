using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {

	//Animator anim;
	int ud = 0;
	int lr = 0;
	[SerializeField] private float movespeed;
	bool move = true;
    
    private AudioSource source;
    
    [SerializeField] private string axisUD;
    [SerializeField] private string axisLR;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private AudioClip stopSound;
    [SerializeField] private AudioClip moveSound;

	// Use this for initialization
	void Awake () {
		//anim = GetComponent<Animator> ();
        source = GetComponent<AudioSource>();
	}
	
	
	// Update is called once per frame
	void Update () {
		lr = (int)Input.GetAxisRaw (axisLR);
		ud = (int)Input.GetAxisRaw (axisUD);
		float boxSize = 0.5f;
		if (lr != 0 || ud != 0) {
			move = true;
		}
		else
        {
            move = false;
        }
		if (lr != 0 && ud != 0) {
			boxSize *= Mathf.Sqrt (2.0f);
		}
		if (move) {
			Vector3 test = new Vector3(movespeed * lr * Time.deltaTime * Time.deltaTime, movespeed * ud * Time.deltaTime * Time.deltaTime, 0);
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position + test.normalized * boxSize, test.normalized, test.magnitude, layerMask);
            foreach(RaycastHit2D r in hits)
            {
                if(r.collider.gameObject.tag == "wall")
                {
                    move = false;
                    if(!(source.clip == stopSound && source.isPlaying))
                    {
                        source.clip = stopSound;
                        source.Play();
                    }
                    break;
                }
            }
            if(move)
            {
                if(!(source.clip == moveSound && source.isPlaying))
                {
                    source.clip = moveSound;
                    source.Play();
                }
                transform.Translate(test);
            }
		}
		else
        {
            source.Pause();
        }
	}
}
