using UnityEngine;

class TreeObject: Plant {

  public TreeObject(Tile t): base(t, (Plant.Breed)Random.Range(0, 2)) {
    offset.y = getAsset().GetComponent<Renderer>().bounds.size.y / 4;
  }

  override public GameObject getAsset() {
    if (grown > 0.3) {
      asset = Useful.findAsset("Tree" + ((int)breed + 1));
    } else {
      asset = Useful.findAsset("trunk");
    }
    return asset;
  }
}
