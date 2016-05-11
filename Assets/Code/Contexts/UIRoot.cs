using System;
using UnityEngine;
using strange.extensions.context.impl;

namespace strangescenes {
	public class UIRoot: ContextView
	{
		void Awake()
		{
			context = new UIContext (this);
		}
	}
}