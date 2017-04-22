using UnityEngine;

public class GameRender: MonoBehaviour {

  static public int TILE_SIZE = 1;

  public GameObject createObject(GridObject obj) {
    int x = obj.root.x;
    int y = obj.root.y;
    GameObject asset = obj.getAsset();
    GameObject sprite = Instantiate(asset);
    float size = sprite.GetComponent<Renderer>().bounds.size.x;
    sprite.transform.position = new Vector3(x * size, y * size, 0);
    return sprite;
  }

  public void renderWorld() {

    Grid grid = Engine.instance().grid;

    foreach (GridObject obj in grid.objects) {
      obj.gameObject = createObject(obj);
    }
  }
}
