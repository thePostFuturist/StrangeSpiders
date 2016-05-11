using UnityEngine;
using System.Collections;

public class WaitTime {

	public static IEnumerator Wait (System.Action m_callback, float m_time)
	{
		yield return new WaitForSeconds (m_time);
		m_callback ();
	}

}
