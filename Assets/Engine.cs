using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine: MonoBehaviour {

	public static Engine instance() {
			return GameObject.Find("GameEngine").GetComponent(typeof(Engine)) as Engine;
	}

	public GameRender render;
	public Grid grid = new Grid(50, 50);
	public List<Character> livings = new List<Character>();

	void Start () {
		grid.born();
		for (int i = 0; i < 1; i++) {
			GameObject guy = Instantiate(Useful.findAsset("Character"));
			livings.Add(guy.GetComponent<Character>());
		}
		render.renderWorld();
	}

	void Update () {
	}
}
