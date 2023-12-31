﻿using UnityEngine;
using UnityEngine.UI;

namespace Tobii.Gaming.Examples.GazePointData
{
	public class ToggleCodeExample : MonoBehaviour
	{
		public GameObject CodeSnippet1;
		public GameObject CodeSnippet2;

		void Update()
		{
			CodeSnippet1.SetActive(!GetComponent<Toggle>().isOn);
			CodeSnippet2.SetActive(GetComponent<Toggle>().isOn);
		}
	}
}