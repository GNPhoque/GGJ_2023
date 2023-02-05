using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFill : MonoBehaviour
{
	[SerializeField] Image fill;

	public void UpadteFillAmount(float fillAmount)
	{
		fill.fillAmount = fillAmount / 100f;
	}
}
