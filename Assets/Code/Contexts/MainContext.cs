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
	public class MainContext: MVCSContext 
	{
		public MainContext(MonoBehaviour view): base (view) {
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
			injectionBinder.Bind<GameStartSignal>().ToSingleton().CrossContext();
			injectionBinder.Bind<WeatherTextChangeSignal>().ToSingleton().CrossContext();
			injectionBinder.Bind<SceneManageSignal>().ToSingleton().CrossContext();
			injectionBinder.Bind<SpiderExplodeSignal>().ToSingleton().CrossContext();
			injectionBinder.Bind<GameOverSignal> ().ToSingleton ().CrossContext ();

			mediationBinder.Bind<SceneLoadManagerView>().ToAbstraction<ISceneLoadManagerView>().ToMediator<SceneLoadManagerMediator>();
			mediationBinder.Bind<MainUIControllerView>().ToAbstraction<IMainUIControllerView>().ToMediator<MainUIControllerMediator>();
		}
	}
}