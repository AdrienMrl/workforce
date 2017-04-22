using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public float speed = 3;

	private Vector3 targetOld, targetCurrent;
	private float elapsedSinceLastTurn = 0;
	private float turningTime = 1;

	void Start () {
		targetOld = transform.position;
		targetCurrent = transform.position;
		InvokeRepeating("zéroblabla", 1, 2);
	}

	void zéroblabla() {
		int x = Random.Range(0, 30);
		int y = Random.Range(0, 30);
		moveTo(x, y);
	}

	void moveTo(int x, int y) {

		targetOld = targetCurrent;
		targetCurrent = Grid.toWorldPosition(x, y);
		targetCurrent.z -= 1.5f;
		elapsedSinceLastTurn = 0;
	}

	Vector3 smoothErp(Vector3 old, Vector3 current, float t) {
		float nx = Mathf.SmoothStep(old.x, current.x, t);
		float ny = Mathf.SmoothStep(old.y, current.y, t);
		float nz = Mathf.SmoothStep(old.z, current.z, t);
		return new Vector3(nx, ny, nz);
	}

	void Update () {
		elapsedSinceLastTurn += Time.deltaTime;
		float step = speed * Time.deltaTime;
		Vector3 trueTarget = smoothErp(targetOld, targetCurrent, elapsedSinceLastTurn / turningTime);
		transform.position = Vector3.MoveTowards(transform.position, trueTarget, step);
	}
}
