using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followVRHeadRotation : MonoBehaviour {

	public Transform vrPlayerObject;
	public float cameraOffsetXZ;
	public float cameraOffsetY;
	public float bodyTurnAngle = 20f;

	private Animator myAnim;
	private Vector3 vrRot, myRot;
	private Transform vrCamera;
	private float x, z;


	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
		vrCamera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		vrRot = vrCamera.rotation.eulerAngles;
		myRot = transform.rotation.eulerAngles;

		if (Mathf.DeltaAngle(vrRot.y, myRot.y) > bodyTurnAngle) {
			if (!gameObject.GetComponent<iTween> ()) {
				//Debug.Log("Turn LEFT");
				//myAnim.SetTrigger ("TurnLeft");
				iTween.RotateTo (gameObject, new Vector3 (myRot.x, vrRot.y, myRot.z), 0.75f);
			}
		} else if (Mathf.DeltaAngle(vrRot.y, myRot.y) < -bodyTurnAngle) {
			if (!gameObject.GetComponent<iTween> ()) {
				//Debug.Log("Turn RIGHT");
				//myAnim.SetTrigger ("TurnRight");
				iTween.RotateTo (gameObject, new Vector3 (myRot.x, vrRot.y, myRot.z), 0.75f);
			}
		}
	}

	void LateUpdate() {
		x = cameraOffsetXZ * Mathf.Sin (vrCamera.rotation.eulerAngles.y * Mathf.Deg2Rad);
		z = cameraOffsetXZ * Mathf.Cos (vrCamera.rotation.eulerAngles.y * Mathf.Deg2Rad);
		vrPlayerObject.position = transform.position + new Vector3 (x, cameraOffsetY, z);
	}

}