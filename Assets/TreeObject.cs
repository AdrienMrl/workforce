using UnityEngine;

class TreeObject: Plant {

  public TreeObject(Tile t): base(t) {
  }

  override public GameObject getAsset() {
    int random = Random.Range(1, 3);
    asset = Useful.findAsset("Tree" + random);
    return asset;
  }
}
