using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {

	[SerializeField] private float _minDistance = 1.0f;
    [SerializeField] private float _maxDistance = 4.0f;
    [SerializeField] private float _smooth = 10.0f;

	private Vector3 _dollyDirAdjusted;
	private float _distance;

    Vector3 dollyDir;

    // Use this for initialization
    void Awake () {
		dollyDir = transform.localPosition.normalized;
		_distance = transform.localPosition.magnitude;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 desiredCameraPos = transform.parent.TransformPoint (dollyDir * _maxDistance);
		RaycastHit hit;

		if (Physics.Linecast (transform.parent.position, desiredCameraPos, out hit)) {
			_distance = Mathf.Clamp ((hit.distance * 0.87f), _minDistance, _maxDistance);
				} else {
					_distance = _maxDistance;
				}
				transform.localPosition = Vector3.Lerp (transform.localPosition, dollyDir * _distance, Time.deltaTime * _smooth);
	}
}
