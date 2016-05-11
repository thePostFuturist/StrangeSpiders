using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

namespace strangescenes
{

	public class SpiderManager: MonoBehaviour {

		[SerializeField] Transform hero;
		[SerializeField] GameObject spider;
		[SerializeField] Transform spawn_point;

		float time_to_wait = 3f;

		void OnTriggerEnter(Collider m_collider)
		{
			if (m_collider.GetComponent<IHeroView> () != null) 
			{
				StartCoroutine (BeginSpawn ());
			}
		}

		IEnumerator BeginSpawn()
		{
			while (true) 
			{
				SpawnSpider ();
				yield return new WaitForSeconds (time_to_wait);
			}
		}

		void OnTriggerExit(Collider m_collider)
		{
			if (m_collider.GetComponent<IHeroView> () != null) 
			{
				StopAllCoroutines ();
			}
		}

		void SpawnSpider()
		{
			GameObject spider_instance = (GameObject) Instantiate(spider, spawn_point.position, Quaternion.identity);
			spider_instance.gameObject.transform.SetParent(transform);
			spider_instance.GetComponent<SpiderView> ().hero = hero;
		}
	}
		
}

