using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace strangescenes
{
	public class HealthBarMediator : Mediator {
		
		[Inject]
		public IHealthBarView view {get;set;}

		[Inject]
		public SpiderExplodeSignal spider_explode_signal {get;set;}

		[Inject]
		public GameOverSignal game_over_signal {get;set;}

		public override void OnRegister ()
		{
			spider_explode_signal.AddListener ( () => {
				view.DeductHealth();
			});

			view.onGameOver += () => game_over_signal.Dispatch();
		}

		public override void OnRemove ()
		{
			spider_explode_signal.RemoveListener ( () => {
				view.DeductHealth();
			});

			view.onGameOver -= () => game_over_signal.Dispatch();
		}


	}
}

