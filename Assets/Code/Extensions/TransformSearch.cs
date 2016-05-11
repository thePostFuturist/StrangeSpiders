using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class TransformSearch
{

	public static T find <T> (this Transform m_transform, string m_name) where T: Component  {
	
		T found_component = null;
		T[] found_components = m_transform.GetComponentsInChildren<T> (true);

		foreach (T comp in found_components) {
			if (comp.name == m_name) {
				found_component = comp;
			}
		}

		return found_component;

	}


}