﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recovery : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			// 0.1秒後に消える
			Destroy(gameObject, 0.1f);
		}
	}
}
