using UnityEngine;

class FloorObject: GridObject {

  override public GameObject getAsset() {
    int random = Random.Range(1, 3);
    asset = Useful.findAsset("Grass" + random);
    return asset;
  }

  public FloorObject(Tile root): base(root, Type.floor) {
    zOffset = 0;
  }
}
