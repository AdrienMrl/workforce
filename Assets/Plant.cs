using UnityEngine;
using System.Collections;
using uPromise;
using System.Threading;

class Plant: GridObject {

  public float initialGrow = 0.1f;
  public float grown;
  public float chopTime = 4f;

  public Plant(Tile root): base(root, Type.floor) {
    zOffset = 1.9f;
    grown = initialGrow;
  }

  public Promise chop() {
    Debug.Log("chop!");
    return Useful.wait(chopTime).Then(x => chopped());
  }

  public void chopped() {
    grown = initialGrow;
    Debug.Log("plat chopped");
  }
}
