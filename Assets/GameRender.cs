using UnityEngine;

public class GameRender: MonoBehaviour {

  static public float TILE_SIZE;

  public GameObject createObject(GridObject obj) {
    int x = obj.root.x;
    int y = obj.root.y;
    GameObject asset = obj.getAsset();
    GameObject sprite = Instantiate(asset);
    TILE_SIZE = sprite.GetComponent<Renderer>().bounds.size.x;
    sprite.transform.position = Grid.toWorldPosition(x, y);
    return sprite;
  }

  public void renderWorld() {

    Grid grid = Engine.instance().grid;

    foreach (GridObject obj in grid.objects) {
      obj.gameObject = createObject(obj);
    }
  }
}
