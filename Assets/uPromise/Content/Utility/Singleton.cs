using UnityEngine;

//Reference: http://wiki.unity3d.com/index.php/Singleton
/// <summary>
/// Be aware this will not prevent a non singleton constructor
///   such as `T myT = new T();`
/// To prevent that, add `protected T () {}` to your singleton class.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	/// <summary>
	/// A method that should be overridden to Initialize.
	///             The default implementation does nothing.
	/// 
	/// </summary>
	protected virtual void OnInit()
	{
;
	}

	private static T _instance;
 
	private static readonly object _lock = new object();
 
	public static T Instance
	{
		get
		{
			if (applicationIsQuitting) {
				return null;
			}
 
			lock(_lock)
			{
				if (_instance == null)
				{
					_instance = (T) FindObjectOfType(typeof(T));
 
					if ( FindObjectsOfType(typeof(T)).Length > 1 )
					{
						return _instance;
					}
 
					if (_instance == null)
					{
						GameObject singleton = new GameObject();
						_instance = singleton.AddComponent<T>();
						singleton.name = "(singleton) "+ typeof(T).ToString();
 
						DontDestroyOnLoad(singleton);
 
					} else {
					}
					_instance.OnInit();
				}
 
				return _instance;
			}
		}
	}
 
	private static bool applicationIsQuitting = false;
	/// <summary>
	/// When Unity quits, it destroys objects in a random order.
	/// In principle, a Singleton is only destroyed when application quits.
	/// If any script calls Instance after it have been destroyed, 
	///   it will create a buggy ghost object that will stay on the Editor scene
	///   even after stopping playing the Application. Really bad!
	/// So, this was made to be sure we're not creating that buggy ghost object.
	/// </summary>
	public void OnDestroy () {
		// NOTE: Moved this to OnApplicationQuit as it was causing an error when switching scenes.
		//applicationIsQuitting = true; 
	}

	void OnApplicationQuit()
	{
		applicationIsQuitting = true;
;
	}
}
