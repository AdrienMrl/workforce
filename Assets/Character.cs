using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uPromise;
using System.Threading;

public class Character: MonoBehaviour {

	public float speed;
	public int cash;
	public Vector2 gridPosition;

	private Vector3 targetOld, targetCurrent;
	private float elapsedSinceLastTurn = 0;
	private float turningTime = 1;
	private Deferred mMoveDeferred;

	public Promise idle() {
		return Useful.wait(1)
			.Then(x => doChop());
	}

	public Promise doChop() {

		print("let's chop");
		TreeObject tree =  Engine.instance().grid.findCloseObject(gridPosition, typeof(TreeObject)) as TreeObject;
		tree.locked++;
		return moveTo(tree.root.position)
			.Then(x => tree.chop())
			.Then(x => {
				print("foobar");
				tree.locked--;
				doChop();
				});
			}

	void Start () {
		targetOld = transform.position;
		targetCurrent = transform.position;
		cash = Random.Range(300, 10000);
		speed = Random.Range(0.4f, 2f);
		idle();
		gridPosition = new Vector2(0, 0);
		Vector3 newpos = transform.position;
		newpos.z -= 2f;
		transform.position = newpos;
	}

	Promise moveTo(Vector2 position) {

		targetOld = targetCurrent;
		targetCurrent = Grid.toWorldPosition(position);
		targetCurrent.z -= 2f;
		elapsedSinceLastTurn = 0;
		mMoveDeferred = new Deferred();
		return mMoveDeferred.Promise;
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
		Vector3 beforeMove = transform.position;
		transform.position = Vector3.MoveTowards(transform.position, trueTarget, step);
		if (transform.position == beforeMove && mMoveDeferred != null) {
			mMoveDeferred.Resolve();
			mMoveDeferred = null;
		}
	}
}
