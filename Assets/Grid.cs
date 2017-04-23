using UnityEngine;
using System.Collections.Generic;

public class GridObject {

  public enum Type {
    floor
  }
  public int width = 1, height = 1;
  public float zOffset = 1f;
  public Tile root;
  public Type type;
  public GameObject gameObject;
  protected GameObject asset;
  public int locked = 0;

  public GridObject(Tile root, Type type) {
    this.type = type;
    this.root = root;
    root.objects.Add(this);
  }

  virtual public GameObject getAsset() {
    return asset;
  }

  public void instantiate() {

    gameObject = UnityEngine.GameObject.Instantiate(getAsset());
    Vector3 position = Grid.toWorldPosition(root.position);
    position.z -= zOffset;
    gameObject.transform.position = position;
  }
}

public class Tile {
  public Vector2 position;
  public List<GridObject> objects = new List<GridObject>();
  public Tile(Vector2 position) {
    this.position = position;
  }
}

public class Grid {

  public int mWidth, mHeight;
  public Dictionary<System.Type, List<GridObject>> objectsMap = new Dictionary<System.Type, List<GridObject>>();
  public Tile[,] tiles;
  public float treeDensity = 0.05f;

  public Grid(int width, int height) {
    mWidth = width;
    mHeight = height;

    tiles = new Tile[width, height];
    for (int i = 0; i < width; i++)
      for (int j = 0; j < height; j++)
        tiles[i,j] = new Tile(new Vector2(i, j));
  }

  public void born() {
    populateFloor();
    growTrees();
  }

  private void growTree() {

    Tile tile = tiles[Random.Range(0, mWidth), Random.Range(0, mHeight)];
    TreeObject tree = new TreeObject(tile);
    addObject(tree);
  }

  private void growTrees() {
    for (int i = 0; i < treeDensity * mWidth * mHeight; i++)
      growTree();
  }

  private void addObject(GridObject obj) {

    System.Type type = obj.GetType();
    if (!objectsMap.ContainsKey(type)) {
      objectsMap[type] = new List<GridObject>();
    }
    objectsMap[type].Add(obj);
  }

  private void populateFloor() {
    foreach (Tile t in tiles) {
      addObject(new FloorObject(t));
    }
  }

  public static Vector3 toWorldPosition(Vector2 position) {
    return new Vector3(position.x * GameRender.TILE_SIZE, position.y * GameRender.TILE_SIZE, position.y);
  }

  public static int AMOUNT_TO_CONSIDER = 100;
  public GridObject findCloseObject(Vector2 position, System.Type type) {
    List<GridObject> objects = objectsMap[type];
    if (objects == null) return null;

    float distance = -1;
    int bestMatchIdx = -1;
    int consider = AMOUNT_TO_CONSIDER;
    for (int i = 0; i < consider && i < objects.Count; i++) {
      if (objects[i].locked > 0) {
          consider++;
          continue;
      }
      Tile objectTile = objects[i].root;
      float testDistance = Vector2.Distance(objectTile.position, position);
      if (distance == -1 || distance > testDistance) {
        distance = testDistance;
        bestMatchIdx = i;
      }
    }
    return distance < 0 ? null : objects[bestMatchIdx];
  }
}
