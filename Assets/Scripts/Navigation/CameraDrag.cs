using UnityEngine;

public class CameraDrag : MonoBehaviour
{
	public float dragSpeed = 2;
	private Vector3 dragOrigin;

	private int yMinLimit = -10;
	private int yMaxLimit = 100;

	private int xMinLimit = -10;
	private int xMaxLimit = 100;

	void LateUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{
			dragOrigin = Input.mousePosition;
			return;
		}

		if (!Input.GetMouseButton(0)) return;

		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
		Vector3 move = new Vector3(-pos.x * dragSpeed, (-pos.y) * dragSpeed,0);
		//if((transform. > xMinLimit && pos.x*dragSpeed<xMaxLimit) && (pos.y*dragSpeed > yMinLimit && pos.y*dragSpeed<yMaxLimit)){
		//Debug.Log(transform.position);
		//Debug.Log(move);

		var worldMove = Camera.main.ViewportToWorldPoint(move);
		var newX = transform.position.x + worldMove.x;
		var newY = transform.position.y + worldMove.y;

		//if((newX > xMinLimit && newX<xMaxLimit) && (newY > yMinLimit && newY<yMaxLimit)){
		transform.Translate(move, Space.World);
		//}
	}


}