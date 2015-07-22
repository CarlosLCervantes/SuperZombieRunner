using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectUtil {

	private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool> ();

	public static GameObject Instantiate(GameObject prefab, Vector3 pos) {
		GameObject instance = null;

		var recycledScript = prefab.GetComponent<RecycleGameObject> ();

		if (recycledScript != null) {
			var pool = getObjectPool(recycledScript);
			instance = pool.NextObject(pos).gameObject;
		} else {
			instance = GameObject.Instantiate (prefab);
			instance.transform.position = pos;
		}

		return instance;
	}

	public static void Destroy(GameObject gameObject) {

		var recycleGameObject = gameObject.GetComponent<RecycleGameObject> (); //won't throw error if doesn't exist

		if (recycleGameObject == null) {
			GameObject.Destroy (gameObject);
		} else {
			recycleGameObject.ShutDown();
		}
	}

	private static ObjectPool getObjectPool(RecycleGameObject reference) {
		ObjectPool pool = null;
		if (pools.ContainsKey (reference)) {
			pool = pools [reference];
		} else {
			var poolContainer = new GameObject(reference.gameObject.name + "ObjectPool");
			pool = poolContainer.AddComponent<ObjectPool>();
			pool.prefab = reference;
			pools.Add(reference, pool);
		}

		return pool;
	}
}
