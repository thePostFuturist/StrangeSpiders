using UnityEngine;
using strange.extensions.signal.impl;

namespace strangescenes
{
	public enum SceneNamesEnum
	{
		Main,
		UI,
		Game
	}
		
	public class WeatherTextChangeSignal: Signal<string> {}
	public class GameStartSignal: Signal<bool> {}
	public class SceneManageSignal: Signal<SceneNamesEnum, bool>{}
	public class SpiderSpawnSignal: Signal {}
	public class SpiderExplodeSignal: Signal {}
	public class GameOverSignal: Signal{}

}