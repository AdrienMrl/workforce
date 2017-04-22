using UnityEngine;

public class GameRender: MonoBehaviour {

  public GameObject floorTile;
  static public int TILE_SIZE = 1;

  public GameObject createObject(int x, int y) {
    GameObject sprite = Instantiate(floorTile, new Vector3(x * TILE_SIZE, y * TILE_SIZE, 0), Quaternion.identity);
    return sprite;
  }

  public void renderWorld() {

    Grid grid = Engine.instance().grid;

    foreach (GridObject obj in grid.objects) {
      print(obj.root);
      obj.gameObject = createObject(obj.root.x, obj.root.y);
    }
  }
}
