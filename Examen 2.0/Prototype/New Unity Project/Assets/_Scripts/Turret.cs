using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public float delay;
    private float myTime;
    public float moveAmount;
    public float speed;
    public bool moveForward = false;
    public bool moveBackward = false;

	
	void Update ()
	{
	    myTime += Time.deltaTime;

        //Makes turret move forward, just before bullet is launched
	    if (myTime >= delay && myTime < delay + 4 && !moveForward)
	    {
	        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - moveAmount), speed);
	        if (transform.position.z <= 25)
	        {
	            moveForward = true;
	        }
	    }

        //after 4 seconds the turret is being returned
	    if (myTime > delay + 4 && !moveBackward)
	    {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + moveAmount), speed);
	        if (transform.position.z >= 28)
	        {
	            moveBackward = true;
	        }
	    }
    }
}
