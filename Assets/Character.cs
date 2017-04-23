using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character: MonoBehaviour, IMachine {

	public float speed;
	public int cash;
	public Vector2 gridPosition;

	private Vector3 targetOld, targetCurrent;
	private float elapsedSinceLastTurn = 0;
	private float turningTime = 1;

	StateMachine machine = new StateMachine();

	public IEnumerator idle() {
		yield return new WaitForSeconds(1);
		doChop();
	}

	void doChop() {
		GridObject tree = Engine.instance().grid.findCloseObject(gridPosition, typeof(TreeObject));
		tree.locked++;
		moveTo(tree.root.position);
	}

	void Start () {
		targetOld = transform.position;
		targetCurrent = transform.position;
		cash = Random.Range(300, 10000);
		speed = Random.Range(0.4f, 2f);
		machine.run(this, this);
		gridPosition = new Vector2(0, 0);
		Vector3 newpos = transform.position;
		newpos.z -= 2f;
		transform.position = newpos;
	}

	void moveTo(Vector2 position) {

		targetOld = targetCurrent;
		targetCurrent = Grid.toWorldPosition(position);
		targetCurrent.z -= 2f;
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
