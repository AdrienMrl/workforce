using UnityEngine;

class TreeObject: GridObject {

  override public GameObject getAsset() {
    int random = Random.Range(1, 3);
    asset = Useful.findAsset("Tree" + random);
    return asset;
  }

  public TreeObject(Tile root): base(root, Type.floor) {
    zOffset = 1.9f;
  }
}
