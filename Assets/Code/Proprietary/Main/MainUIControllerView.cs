using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

namespace strangescenes
{

	public class MainUIControllerView: View, IMainUIControllerView {

		Button _button_play;
		Button button_play { 
			get {
				if (_button_play==null)
					_button_play = transform.find<Button>("ButtonPlay");
				return _button_play;
			}
		}

		protected override void Start()
		{
			button_play.onClick.AddListener ( ()=> {
				ToggleActive(false);
				DispatchSceneLoad(SceneNamesEnum.UI, true);
				DispatchSceneLoad(SceneNamesEnum.Game, true);
				DispatchBeginGame();
			});
		}

		void ToggleActive(bool state)
		{
			gameObject.SetActive(state);
		}

		void DispatchSceneLoad(SceneNamesEnum scene_name, bool state)
		{
			if (onSceneLoad!=null)
				onSceneLoad(scene_name, state);
		}


		void DispatchBeginGame()
		{
			if (onGameStart!=null)
				onGameStart(true);	
		}

		public void GameOver()
		{
			ToggleActive (true);
			DispatchSceneLoad (SceneNamesEnum.Game, false);
			DispatchSceneLoad (SceneNamesEnum.UI, false);
		}

		public event System.Action<bool> onGameStart;
		public event System.Action<SceneNamesEnum, bool> onSceneLoad;
	}

	public interface IMainUIControllerView {
		event System.Action<bool> onGameStart;
		event System.Action<SceneNamesEnum, bool> onSceneLoad;

		void GameOver();
	}
}

  