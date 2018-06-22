using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject target;
    public GameObject player;
    public float pushSpeed;
    public float speed;
    public float delay;
    private float time;
    public Vector3 targetDir;
    public Vector3 slowDir;
    public bool pushDone = false;
    public bool isLooking = false;
    public bool gravEnabled = false;

    public Vector3 thisPos;
    public Vector3 prevPos;

    public float dir;
    public float gravEnableTarget;

	void Start () {
		
	}
	
	void Update () {
        time += Time.deltaTime;
        dir = GetComponent<Rigidbody>().velocity.magnitude;
        if (time>delay)
        {
            //gives initial speed to bullet
            if (!pushDone)
            {
                targetDir = target.transform.position - transform.position;
                targetDir = targetDir.normalized;
                GetComponent<Rigidbody>().AddForce(targetDir*speed);
                pushDone = true;
            }
        }

        //slows bullet if player is looking at it
	    if (isLooking && !gravEnabled)
	    {
	        slowDir = target.transform.position - transform.position;
	        slowDir = slowDir.normalized;
            GetComponent<Rigidbody>().AddForce(-slowDir*pushSpeed);
	    }

        transform.rotation = Quaternion.LookRotation(-GetComponent<Rigidbody>().velocity);

        //This gets activated when bullet is below a certain speed
        if (dir <= gravEnableTarget && pushDone == true && time >= delay + 2 && gravEnabled == false)
        {
            GetComponent<Rigidbody>().useGravity = true;
            gravEnabled = true;
            GetComponent<Bullet>().enabled = false;
        }
	    dir = GetComponent<Rigidbody>().velocity.magnitude;
	}

    public void Looking()
    {
        isLooking = true;
    }

    public void NotLooking()
    {
        isLooking = false;
    }
}
