using UnityEngine;

public class Useful {

  static public GameObject findAsset(string name) {
    return UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/prefabs/" + name + ".prefab", typeof(GameObject)) as GameObject;
  }
}
