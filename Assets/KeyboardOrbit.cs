//WASD to orbit, left Ctrl/Alt to zoom
using UnityEngine;

[AddComponentMenu("Camera-Control/Keyboard Orbit")]

public class KeyboardOrbit : MonoBehaviour {
    public Transform target;
    public float distance = -20.0f;
    public float zoomSpd = 2.0f;

    public float xSpeed = 240.0f;
    public float ySpeed = 123.0f;

    public int yMinLimit = 0;
    public int yMaxLimit = 100;

    private float x = 0.0f;
    private float y = 0.0f;

    public void Start () {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
		//transform.position = new Vector3(50,50,-10);
    }

    public void LateUpdate () {
        if (target) {
            x += Input.GetAxis("Horizontal") * xSpeed * 0.02f;
            y += Input.GetAxis("Vertical") * ySpeed * 0.02f;

	    	distance -= Input.GetAxis("Fire1") *zoomSpd* 0.02f;
            distance += Input.GetAxis("Fire2") *zoomSpd* 0.02f;

            transform.position = new Vector3(x,y,distance);
        }
    }
}
