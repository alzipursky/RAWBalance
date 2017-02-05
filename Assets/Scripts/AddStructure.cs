using UnityEngine;
using System.Collections;

public class AddStructure : MonoBehaviour {

	public GameObject settlement;
	private Vector3 target;
	//private Ray ray;
	//private RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = 0;
			var newSettlement = Instantiate(settlement);
			newSettlement.transform.position = target;
		}
	}
}
