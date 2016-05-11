using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;

namespace strangescenes {
	public class UIContext: MVCSContext 
	{
		public UIContext(MonoBehaviour view): base (view) {
		}

		protected override void addCoreComponents ()
		{
			base.addCoreComponents();
			injectionBinder.Unbind<ICommandBinder>();
			injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
		}
		override public IContext Start()
		{
			base.Start();
			return this;
		}

		protected override void mapBindings ()
		{
			if (injectionBinder.GetBinding<SpiderExplodeSignal> () == null)
				injectionBinder.Bind<SpiderExplodeSignal> ().ToSingleton ();

			if (injectionBinder.GetBinding<GameOverSignal> () == null)
				injectionBinder.Bind<GameOverSignal> ().ToSingleton ();

			mediationBinder.Bind<HealthBarView>().ToAbstraction<IHealthBarView>().ToMediator<HealthBarMediator>();
		}

	}
}