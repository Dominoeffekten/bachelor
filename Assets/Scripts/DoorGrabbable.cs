using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//open door
// https://www.youtube.com/watch?v=3cJ_uq1m-dg&vl=fr


//lyd
// https://answers.unity.com/questions/459651/play-sound-when-opening-door.html

//grabble the door
public class DoorGrabbable : OVRGrabbable {
    public Transform handler;

	
	//tager firkanten i døren, og sætter den på sin rette plads igen, så den ikke svæver i luften
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity){ //linearVelocity is X and Y directions angularVelocity is Angular velocity in degrees per second.

		base.GrabEnd(Vector3.zero, Vector3.zero);
		transform.position = handler.transform.position;
		transform.rotation = handler.transform.rotation;

		//undgår at døren går tilbage igen
		Rigidbody rbhandler = handler.GetComponent<Rigidbody>(); //physics simulation
		rbhandler.velocity = Vector3.zero; //The velocity vector of the rigidbody. It represents the rate of change of Rigidbody position.
		rbhandler.angularVelocity = Vector3.zero; // The angular velocity vector of the rigidbody measured in radians per second.
	}


	private void Update(){
		if (Vector3.Distance(handler.position, transform.position) > 0.4f){
			grabbedBy.ForceRelease(this);
		}
	}
}
