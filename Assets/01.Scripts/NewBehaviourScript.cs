using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	int move = 0; 

	private void Awake()
	{
		while(true)
		{
			A();

			B();

			if(/* k 눌리면 */true)
			{
				A();
			}

			C();
		}
	}


	public void A()
	{
		move = 100;
	}

	public void B()
	{
		move = 77;
	}

	public void C()
	{
		Debug.Log(move);
	}
}
