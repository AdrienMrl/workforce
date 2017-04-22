using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

	public static Engine instance() {
			return GameObject.Find("GameEngine").GetComponent(typeof(Engine)) as Engine;
	}

	public GameRender render;
	public Grid grid = new Grid(50, 50);

	void Start () {
		render.renderWorld();
	}

	void Update () {
	}
}
