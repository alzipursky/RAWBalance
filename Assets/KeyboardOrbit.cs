//WASD to orbit, left Ctrl/Alt to zoom
using UnityEngine;

[AddComponentMenu("Camera-Control/Keyboard Orbit")]

public class KeyboardOrbit : MonoBehaviour {
    public Transform target;
    //public float distance = -20.0f;
    public float zoomSpd = 2.0f;
	private float maxZoomIn = 5.0f;
	private float maxZoomOut = 50.0f;

    public float xSpeed = 1.0f;
    public float ySpeed = 1.0f;

    public int yMinLimit = 0;
    public int yMaxLimit = 100;

    private float x = 50.0f;
    private float y = 50.0f;
	private float z = -20f;

    public void Start () {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    public void LateUpdate () {
        if (target) {
            x += Input.GetAxis("Horizontal") * xSpeed * 0.02f;
            y += Input.GetAxis("Vertical") * ySpeed * 0.02f;

			zoom();
            transform.position = new Vector3(x,y,z);
        }
    }

	private void zoom()
	{
		Camera.main.orthographicSize += Input.GetAxis("Mouse ScrollWheel");
		if (Camera.main.orthographicSize < maxZoomIn) 
		{
			Camera.main.orthographicSize = maxZoomIn;
		} else if (Camera.main.orthographicSize > maxZoomOut) 
		{
			Camera.main.orthographicSize = maxZoomOut;
		}
	}
}
