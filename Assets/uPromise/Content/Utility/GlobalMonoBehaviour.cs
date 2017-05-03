using UnityEngine;
using System.Collections;

public class GlobalMonoBehaviour : Singleton<GlobalMonoBehaviour>
{
	//#region
	//private static GlobalMonoBehaviour _instance;
	//public static GlobalMonoBehaviour Instance
	//{
	//	get
	//	{
	//		if (_instance == null)
	//		{
//;
	//			_instance = new GameObject("__Global", typeof(GlobalMonoBehaviour)).GetComponent<GlobalMonoBehaviour>();
	//			_instance.gameObject.hideFlags = HideFlags.HideAndDontSave;
	//		}
	//		return _instance;
	//	}
	//}

	//void Awake()
	//{
	//	if (_instance != null)
	//	{
//;
	//		Destroy(gameObject);
	//		return;
	//	}
	//}


	//// Use this for initialization
	//void Start()
	//{

	//}

	//void OnApplicationQuit()
	//{
	//	if (this != _instance)
	//	{
	//		DestroyImmediate(this.gameObject);
	//		return;
	//	}
	//	DestroyImmediate(this.gameObject);
	//	_instance = null;
	//}
	//#endregion

	protected override void OnInit()
	{
	}

	public void Initialize()
	{
;
	}

	public void Shutdown()
	{
;
	}
	
}
