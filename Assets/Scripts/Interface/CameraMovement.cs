using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform FollowObject;
	Vector2 FollowPos;

	public Vector2 FollowMargin;
	public Vector2 FollowSmoothing;

	public float KeyboardScrollSpeed = 1.0f;
	public float MouseScrollSpeed = 1.0f;

	Camera ParentCamera;

	//Constrains movement of the camera
	public bool BoundsSet = false;
	public Rect CameraBounds;
	public Vector2 HalfCameraSize;

	// Use this for initialization
	void Awake() {
		//Setting up boundry related values in Awake so that other objects can call SetCameraBounds in their Start() functions
		ParentCamera = this.gameObject.GetComponent<Camera>();

		if (ParentCamera != null) {
			//Setup camera size for keeping in bounds
			float height = 2f * ParentCamera.orthographicSize;
			float width = height * ParentCamera.aspect;
			HalfCameraSize = new Vector2(width / 2, height / 2);
		} else {
			Debug.LogError("CameraMovement.Awake: Could not find parent camera");
		}
	}

	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		Vector3 NewPosition = ParentCamera.transform.position;
		NewPosition.x += Input.GetAxis("CameraHorizontal") * KeyboardScrollSpeed * Time.deltaTime;
		NewPosition.y += Input.GetAxis("CameraVertical") * KeyboardScrollSpeed * Time.deltaTime;

		if (FollowObject != null) {
			FollowPos = FollowObject.GetComponent<SpriteRenderer>().bounds.center;

			if (Mathf.Abs(NewPosition.x - FollowPos.x) > FollowMargin.x) {
				NewPosition.x = Mathf.Lerp(NewPosition.x, FollowPos.x, FollowSmoothing.x * Time.deltaTime);
			}
			if (Mathf.Abs(NewPosition.y - FollowPos.y) > FollowMargin.y) {
				NewPosition.y = Mathf.Lerp(NewPosition.y, FollowPos.y, FollowSmoothing.y * Time.deltaTime);
			}
		}

		if (BoundsSet) {
			if (NewPosition.x < CameraBounds.x) { NewPosition.x = CameraBounds.x; }
			if (NewPosition.x > CameraBounds.width) { NewPosition.x = CameraBounds.width; }
			if (NewPosition.y < CameraBounds.y) { NewPosition.y = CameraBounds.y; }
			if (NewPosition.y > CameraBounds.height) { NewPosition.y = CameraBounds.height; }
		}

		ParentCamera.transform.position = NewPosition;		
	}

	public void SetCameraBounds(float SizeX, float SizeY) {
		if (SizeX > 0 && SizeY > 0) {
			CameraBounds = new Rect(HalfCameraSize.x, HalfCameraSize.y, SizeX - HalfCameraSize.x, SizeY - HalfCameraSize.y);
			BoundsSet = true;
		} else {
			Debug.LogError("CameraMovement.SetCameraBounds: cannot set camera size to: " + SizeX.ToString() + ", " + SizeY.ToString());
			BoundsSet = false;
		}
	}
}
