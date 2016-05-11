using System;
using UnityEngine;
using strange.extensions.context.impl;

namespace strangescenes {
	public class MainRoot: ContextView
	{
		void Awake()
		{
			context = new MainContext (this);
		}
	}
}