using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace strangescenes
{
	public class SceneLoadManagerMediator : Mediator {

		[Inject]
		public ISceneLoadManagerView view {get;set;}

		[Inject]
		public SceneManageSignal load_scene_signal {get;set;}


		public override void OnRegister ()
		{
			load_scene_signal.AddListener ( (SceneNamesEnum scene_name, bool state) => {
				view.ManageScene(scene_name, state);
			});

		}

		public override void OnRemove ()
		{
			load_scene_signal.RemoveListener ( (SceneNamesEnum scene_name, bool state) => {
				view.ManageScene(scene_name, state);
			});

		}

	}
}

