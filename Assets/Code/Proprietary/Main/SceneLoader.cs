using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	void Start () {
		SceneManager.LoadScene ("Data", LoadSceneMode.Additive);
	}
}
