//WASD to orbit, left Ctrl/Alt to zoom
using UnityEngine;

[AddComponentMenu("Camera-Control/Keyboard Orbit")]

public class KeyboardOrbit : MonoBehaviour {
    public Transform target;
    //public float distance = -20.0f;
    public float zoomSpd = 2.0f;
	private float maxZoomIn = 5.0f;
	private float maxZoomOut = 20.0f;

    public float xSpeed = 0.5f;
    public float ySpeed = 0.5f;

    public int yMinLimit = -100;
    public int yMaxLimit = 200;

	public int xMinLimit = -100;
	public int xMaxLimit = 200;

    private float x = 16.0f;
    private float y = 16.0f;
	private float z = -20f;

	private float moveSpeed = 0.025f;

    public void Start () {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;

		transform.position = new Vector3 (x, y, z);
		Camera.main.orthographicSize = maxZoomOut;

    }

    public void LateUpdate () {
        if (target) {

			var horizontal = Input.GetAxis ("Horizontal");
			var vertical = Input.GetAxis ("Vertical");

			if (x + horizontal * xSpeed * 0.02f < xMaxLimit && x + horizontal * xSpeed * 0.02f > xMinLimit) {
				x += horizontal * xSpeed * 0.02f;

			}

			if (y + vertical * ySpeed * 0.02f < yMaxLimit && y + vertical * ySpeed * 0.02f > yMinLimit) {
				y += vertical * ySpeed * 0.02f;

			}


			zoom();

			if (horizontal == 0 && vertical == 0) {
				transform.position = transform.position;
				x = transform.position.x;
				y = transform.position.y;
			} else {
				transform.position = Vector3.Lerp (transform.position, new Vector3(x,y,z), moveSpeed);
			}

        }
    }

	private void zoom()
	{
		Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
		if (Camera.main.orthographicSize < maxZoomIn) 
		{
			Camera.main.orthographicSize = maxZoomIn;
		} else if (Camera.main.orthographicSize > maxZoomOut) 
		{
			Camera.main.orthographicSize = maxZoomOut;
		}

		if (Camera.main.orthographicSize > 10) {
			moveSpeed = 0.5f;
		} else if (Camera.main.orthographicSize < 10) {
			moveSpeed = 0.005f;

		}

	}
}
