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

    public int yMinLimit = 0;
    public int yMaxLimit = 100;

	public int xMinLimit = 0;
	public int xMaxLimit = 100;

    private float x = 16.0f;
    private float y = 16.0f;
	private float z = -20f;

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
				transform.position = Vector3.Lerp (transform.position, new Vector3(x,y,z), 0.025f);
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
	}
}
