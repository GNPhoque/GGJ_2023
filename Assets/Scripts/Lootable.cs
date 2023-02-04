using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lootable : MonoBehaviour, IPointerClickHandler
{
	public LootableType type;
	public float value;

	public void Loot()
	{
		print("LOOT!");
		switch (type)
		{
			case LootableType.None:
				break;
			case LootableType.Red:
				Player.instance.Purple += value;
				break;
			case LootableType.Blue:
				Player.instance.Orange += value;
				break;
			case LootableType.Yellow:
				Player.instance.Green += value;
				break;
			default:
				break;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Loot();
	}
}
