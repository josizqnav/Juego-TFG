using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour {
	//Objeto prefabricado
	public GameObject prefab;
	//Grupo de objetos inactivos, guardado en una colección LIFO
	private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

	public GameObject GetObject() 
	{
		GameObject spawnedGameObject;

		// Si tenemos un objeto inactivo  listo, la devolvemos
		if (inactiveInstances.Count > 0) 
		{
			// Borramos el objetvo inactivo
			spawnedGameObject = inactiveInstances.Pop();
		}
		// En otro caso crearemos un nuevo objeto
		else 
		{
			//Creamos el objeto con nuestro prefabricado
			spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);

			// Le agregamos PooledObject como componente para saber que pertenece al grupo
			PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
			pooledObject.pool = this;
		}

		// Colocamos el objeto en la raíz de la escena y lo activamos
		spawnedGameObject.transform.SetParent(null);
		spawnedGameObject.SetActive(true);

		// Devolvemos el objeto
		return spawnedGameObject;
	}
	
	public void ReturnObject(GameObject toReturn) 
	{
		PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

		// Si el objeto proviene del grupo, lo devolvemos
		if(pooledObject != null && pooledObject.pool == this)
		{
			// Hamos al objeto hijo y lo deshabilitamos
			toReturn.transform.SetParent(transform);
			toReturn.SetActive(false);

			// Añadimos el objeto a la colección de instancias inactivas
			inactiveInstances.Push(toReturn);
		}
		// En cualquier otro caso, destruímos el objeto
		else
		{
			Debug.LogWarning(toReturn.name + " fue devuelto a un grupo del que no se generó. Destruído.");
			Destroy(toReturn);
		}
	}
}
// Se usa para identificar el grupo(pool) del que proviene el GameObject
public class PooledObject : MonoBehaviour
{
	public SimpleObjectPool pool;
}
