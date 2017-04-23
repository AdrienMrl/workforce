using UnityEngine;
using System.Collections.Generic;

public class GameRender: MonoBehaviour {

  static public float TILE_SIZE;

  public void Start() {
    TILE_SIZE = Useful.findAsset("Grass1").GetComponent<Renderer>().bounds.size.x;
  }

  public GameObject createObject(GridObject obj) {
    GameObject asset = obj.getAsset();
    GameObject sprite = Instantiate(asset);
    sprite.transform.position = Grid.toWorldPosition(obj.root.position);
    return sprite;
  }

  public void renderWorld() {

    Grid grid = Engine.instance().grid;

    foreach (KeyValuePair<System.Type, List<GridObject>> entry in grid.objectsMap) {
      foreach (GridObject obj in entry.Value)
        obj.instantiate();
    }
  }
}
