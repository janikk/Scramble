using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float stepTime;
    [SerializeField] private float straightChance;
    [SerializeField] private float stepSize;
    [SerializeField] private int maxHealth;
    [SerializeField] private AudioClip stepSound;
    
    private float toStep;
    private int health;
    private Vector3 lastPos;
    private Vector3 nextPos;
    private AudioSource source;
    
	// Use this for initialization
	void Start()
    {
		toStep = stepTime;
	}
	
	void Awake()
    {
        source = GetComponent<AudioSource>();
        source.clip = stepSound;
    }
	
	// Update is called once per frame
	void Update()
    {
        transform.position = Vector3.Lerp(nextPos, lastPos, toStep/stepTime);
		toStep -= Time.deltaTime;
        if(toStep <= 0)
        {
            toStep = stepTime;
            step();
        }
	}
	
	public void damage()
    {
        --health;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
	
	void step()
    {
        source.Play();
        Vector2 vLeft = new Vector2(transform.position.x - transform.right.x, transform.position.y - transform.right.y);
        Vector2 vUp = new Vector2(transform.position.x + transform.up.x, transform.position.y + transform.up.y);
        Vector2 vRight = new Vector2(transform.position.x + transform.right.x, transform.position.y + transform.right.y);
        
        RaycastHit2D[] cLeft = Physics2D.CircleCastAll(vLeft, stepSize/2, Vector2.up);
        RaycastHit2D[] cForward = Physics2D.CircleCastAll(vUp, stepSize/2, Vector2.up);
        RaycastHit2D[] cRight = Physics2D.CircleCastAll(vRight, stepSize/2, Vector2.up);
        
        bool left = true;
        bool forward = true;
        bool right = true;
        
        foreach(RaycastHit2D r in cLeft)
        {
            if(r.collider.gameObject.tag == "wall")
            {
                left = true;
                break;
            }
        }
        
        foreach(RaycastHit2D r in cForward)
        {
            if(r.collider.gameObject.tag == "wall")
            {
                forward = true;
                break;
            }
        }
        
        foreach(RaycastHit2D r in cRight)
        {
            if(r.collider.gameObject.tag == "wall")
            {
                right = true;
                break;
            }
        }
        
        float rand = Random.Range(0.0f, 1.0f);
        
        if(rand * 2 > straightChance + 1)
        {
            if(left)
            {
                transform.Rotate(Vector3.forward * 90);
            }
            else if(right)
            {
                transform.Rotate(Vector3.forward * -90);
            }
            else if(!forward)
            {
                transform.Rotate(Vector3.forward * 180);
            }
        }
        
        else if(rand > straightChance)
        {
            if(right)
            {
                transform.Rotate(Vector3.forward * -90);
            }
            else if(left)
            {
                transform.Rotate(Vector3.forward * 90);
            }
            else if(!forward)
            {
                transform.Rotate(Vector3.forward * 180);
            }
        }
        else if(!forward)
        {
            transform.Rotate(Vector3.forward * 180);
        }
        lastPos = nextPos;
        nextPos += transform.up * stepSize;
    }
}
