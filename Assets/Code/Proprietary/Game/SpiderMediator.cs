using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace strangescenes
{
	public class SpiderMediator : Mediator {
		
		[Inject]
		public ISpiderView view {get;set;}

		[Inject]
		public SpiderExplodeSignal spider_explode_signal {get;set;}

		public override void OnRegister ()
		{
			view.onSpiderExplode += () => spider_explode_signal.Dispatch();
		}

		public override void OnRemove()
		{
			view.onSpiderExplode -= () => spider_explode_signal.Dispatch();
		}

	}
}

