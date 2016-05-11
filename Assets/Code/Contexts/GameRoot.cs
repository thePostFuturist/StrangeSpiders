using System;
using UnityEngine;
using strange.extensions.context.impl;

namespace strangescenes {
	public class GameRoot: ContextView
	{
		void Awake()
		{
			context = new GameContext (this);
		}
	}
}