using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace strangescenes
{
	public class MainUIControllerMediator : Mediator {
		
		[Inject]
		public IMainUIControllerView view {get;set;}

		[Inject]
		public GameStartSignal game_start_signal {get;set;}

		[Inject]
		public SceneManageSignal scene_manage_signal {get;set;}

		[Inject]
		public GameOverSignal game_over_signal { get; set; }

		public override void OnRegister ()
		{
			view.onGameStart += ( (bool state) => {
				game_start_signal.Dispatch(state);

			});

			view.onSceneLoad += (SceneNamesEnum scene_name, bool state) => scene_manage_signal.Dispatch(scene_name, state);
		
			game_over_signal.AddListener (() => {
				view.GameOver();
			});  
		}

		public override void OnRemove ()
		{
			view.onGameStart -= ( (bool state) => {
				game_start_signal.Dispatch(state);

			});

			view.onSceneLoad -= (SceneNamesEnum scene_name, bool state) => scene_manage_signal.Dispatch(scene_name, state);

			game_over_signal.RemoveListener (() => {
				view.GameOver();
			});  
		}

	}
}

