using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace strangescenes
{
	public class HeroMediator : Mediator {
		
		[Inject]
		public IHeroView view {get;set;}

//		[Inject]
//		public GameStartSignal game_start_signal {get;set;}
//
//		[Inject]
//		public LoadSceneSignal load_scene_signal {get;set;}

		public override void OnRegister ()
		{
//			view.onGameStart += ( (bool state) => {
//				game_start_signal.Dispatch(state);
//
//			});
//
//			view.onSceneLoad += (SceneNamesEnum scene_name) => load_scene_signal.Dispatch(scene_name);
		}

	}
}

