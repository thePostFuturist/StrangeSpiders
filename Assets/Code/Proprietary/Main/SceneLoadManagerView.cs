using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

namespace strangescenes
{

	public class SceneLoadManagerView: View, ISceneLoadManagerView {


		void LoadScene(SceneNamesEnum scene_name)
		{
			SceneManager.LoadScene (scene_name.ToString(), LoadSceneMode.Additive);
		}

		void UnloadScene(SceneNamesEnum scene_name)
		{
			SceneManager.UnloadScene (scene_name.ToString());
		}

		public void ManageScene(SceneNamesEnum scene_name, bool state)
		{
			if (state)
				LoadScene(scene_name);
			else
				UnloadScene(scene_name);
		}

	}

	public interface ISceneLoadManagerView {
		void ManageScene(SceneNamesEnum scene_name, bool state);
	}
}

  