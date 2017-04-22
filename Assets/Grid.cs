using UnityEngine;
using System.Collections.Generic;

public class GridObject {

  public enum Type {
    floor
  }
  public int width = 1, height = 1;
  public Tile root;
  public Type type;
  public GameObject gameObject;

  public GridObject(Tile root, Type type) {
    this.type = type;
    this.root = root;
  }
}

public class Tile {
  public int x, y;
  public Tile(int x, int y) {
    this.x = x;
    this.y = y;
  }
}

public class Grid {

  public int mWidth, mHeight;
  public List<GridObject> objects = new List<GridObject>();
  public Tile[,] tiles;

  public Grid(int width, int height) {
    mWidth = width;
    mHeight = height;

    tiles = new Tile[width, height];
    for (int i = 0; i < width; i++)
      for (int j = 0; j < height; j++)
        tiles[i,j] = new Tile(i, j);
    populateFloor();
  }

  private void populateFloor() {
    foreach (Tile t in tiles) {
      objects.Add(new FloorObject(t));
    }
  }
}
