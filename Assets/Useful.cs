using UnityEngine;
using uPromise;

public class Useful {

  static public GameObject findAsset(string name) {
    return UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/prefabs/" + name + ".prefab", typeof(GameObject)) as GameObject;
  }

  static public Promise wait(float delay) {
    return PromiseFactory.StartNewDelayed(delay);
  }
}
