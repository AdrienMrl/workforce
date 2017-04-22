using UnityEngine;

class FloorObject: GridObject {

  override public GameObject getAsset() {
    int random = Random.Range(1, 3);
    asset = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/prefabs/Grass" + random + ".prefab", typeof(GameObject)) as GameObject;
    Debug.Log("Assets/prefabs/Grass" + random + ".prefab");
    return asset;
  }

  public FloorObject(Tile root): base(root, Type.floor) {
  }
}
