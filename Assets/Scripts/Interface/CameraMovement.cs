using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float KeyboardScrollSpeed = 1.0f;
	public float MouseScrollSpeed = 1.0f;

	Camera parentCamera;

	// Use this for initialization
	void Start () {
		parentCamera = this.gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 translateVector = new Vector3(0, 0, 0);
		translateVector.x = Input.GetAxis("Horizontal") * KeyboardScrollSpeed * Time.deltaTime;
		translateVector.y = Input.GetAxis("Vertical") * KeyboardScrollSpeed * Time.deltaTime;

		parentCamera.transform.Translate(translateVector);
	}
}
