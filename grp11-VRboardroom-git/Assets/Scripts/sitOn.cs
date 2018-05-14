using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sitOn : MonoBehaviour {

	Animator myAnim;
	public GameObject player;
	//public Transform seatPos;

	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		/*
		if (Vector3.Distance(myPlayer.transform.position, mySeat.transform.position) < 0.5) {

			myAnim.SetTrigger ("Sit");

			myPlayer.transform.rotation = mySeat.transform.rotation;
			myAnim.SetBool ("isSitting", true);
		} else myAnim.SetBool("isSitting", false);
		*/



		if (Vector3.Distance(player.transform.position, this.transform.position) < 2) {

			myAnim.SetTrigger ("isSitting");

			player.transform.rotation = this.transform.rotation;
		}
	}

}
/*
	public void sit() {
		if (Input.GetMouseButtonDown (0)) {
			player.position = seatPos.position;
			player.rotation = seatPos.rotation;

			myAnim.SetTrigger ("Sit");
		}
	}
*/

