using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

namespace strangescenes
{

	public class SpiderView: View, ISpiderView {

		public Transform hero;
		NavMeshAgent nav_mesh_agent;

		[SerializeField] Vector3 explosion_growth = new Vector3(4,4,4);
		[SerializeField] float explosion_speed;

		Transform explosion_sphere;

		void OnEnable()
		{
			nav_mesh_agent = GetComponent<NavMeshAgent> ();
			explosion_sphere = transform.find<Renderer> ("ExplosionSphere").transform;
			StartCoroutine(DestinationAssigner());
		}

		IEnumerator DestinationAssigner()
		{
			while (true)
			{
				yield return new WaitForSeconds(1f);
				AssignDestination ();
			}
		}


		void AssignDestination()
		{
			nav_mesh_agent.destination = hero != null ? hero.position : transform.position;
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<IHeroView> () != null) { // Checks for interface of hero characters
				StartCoroutine(Explode());		
			}
		}

		IEnumerator Explode()
		{
			float i = 0;
			while (i < 1) {
				explosion_sphere.localScale = Vector3.Lerp (explosion_sphere.localScale, explosion_growth, i);
				i += Time.deltaTime * explosion_speed;
				yield return null;		
			}
			DispatchExplodeSignal();
			Destroy ();
		}

		void Destroy()
		{
			if (this != null)
			{
				StopAllCoroutines();
				Object.DestroyObject (this.gameObject);	
			}		
		}
			
		void DispatchExplodeSignal() 
		{
			if (onSpiderExplode!=null) {
				onSpiderExplode();
			}
		}

		public event System.Action onSpiderExplode;
	}

	public interface ISpiderView {
		event System.Action onSpiderExplode;
	}
}

  