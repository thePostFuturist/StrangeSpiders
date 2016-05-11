using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

namespace strangescenes
{

	public class HealthBarView: View, IHealthBarView {

		[SerializeField]
		int health_increment = 1;

		Slider _health_bar;
		Slider health_bar {
			get {
				if (_health_bar==null)
					_health_bar = transform.find<Slider>("HealthBar");
				return _health_bar;
			}
		}

		public void DeductHealth()
		{
			if (health_bar.value > 0)
			{
				health_bar.value -= health_increment;
			} else {
				// dead, respawn
				health_bar.value = 10;
				DispatchGameOver();
			}
		}

		void DispatchGameOver()
		{
			if (onGameOver != null)
				onGameOver ();
		}

		public event System.Action onGameOver;
	}

	public interface IHealthBarView {
		void DeductHealth();
		event System.Action onGameOver;
	}
	
}
