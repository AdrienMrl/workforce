using UnityEngine;
using System.Collections;
using uPromise;
using System.Threading;

class Plant: GridObject {

  public float initialGrow = 0.1f;
  public float grown;
  public float chopTime = 4f;
  public enum Breed {
    tree,
    fir
  }
  public Breed breed;

  public Plant(Tile root, Breed breed): base(root, GridObject.Type.floor) {
    offset.z = -1.9f;
    grown = 0.8f;
    this.breed = breed;
  }

  public Promise chop() {
    return Useful.wait(chopTime); //.Then(x => chopped());
  }

  public Promise chopped() {
    grown = initialGrow;
    UnityEngine.GameObject.Destroy(gameObject);
    instantiate();
    Deferred d = new Deferred();
    d.Resolve();
    return d.Promise;
  }
}
