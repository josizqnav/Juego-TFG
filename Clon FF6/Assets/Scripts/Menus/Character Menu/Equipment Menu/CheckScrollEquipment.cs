using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScrollEquipment : MonoBehaviour {
	//Contenido del Scroll
	public Transform contentPanel;
	public List<EquipmentButtonController> buttons;
	public GameObject prefab;

	public void RefreshWeapons(){
		RemoveButtons ();
		AddButtonsWeapons ();
	}

	public void RefreshArmors(){
		RemoveButtons ();
		AddButtonsArmor ();
	}

	private void AddButtonsWeapons()
	{
		List<EquipmentStats> liste = PlayerState.Instance.savedEquipmentStats;
		for (int i = 0; i < liste.Count; i++) 
		{
			if (liste [i].typeEquipment == TypeEquipment.Weapon &&
			   !PlayerState.Instance.savedPlayerEquipment.weapon.Equals (PlayerState.Instance.savedEquipmentStats [i])) {
				EquipmentStats equipment = liste [i];

				GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
				newButton.transform.SetParent(contentPanel);
				newButton.SetActive(true);

				EquipmentButtonController equipmentButton = newButton.GetComponent<EquipmentButtonController> ();
				if (buttons.Count == 0) {
					equipmentButton.selected = true;
				}
				equipmentButton.SetupEquipment (equipment);
				buttons.Add (equipmentButton);
			}
		}
	}

	private void AddButtonsArmor()
	{
		for (int i = 0; i < PlayerState.Instance.savedEquipmentStats.Count; i++) 
		{
			if (PlayerState.Instance.savedEquipmentStats [i].typeEquipment.Equals (TypeEquipment.Armor) &&
				!PlayerState.Instance.savedPlayerEquipment.armor.Equals (PlayerState.Instance.savedEquipmentStats [i])) {
				EquipmentStats equipment = PlayerState.Instance.savedEquipmentStats [i];

				GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
				newButton.transform.SetParent(contentPanel);
				newButton.SetActive(true);

				EquipmentButtonController equipmentButton = newButton.GetComponent<EquipmentButtonController> ();
				if (buttons.Count == 0) {
					equipmentButton.selected = true;
				}
				equipmentButton.SetupEquipment (equipment);
				buttons.Add (equipmentButton);
			}
		}
	}

	private void RemoveButtons(){
		buttons.Clear ();
		for (int i = 0; i < contentPanel.transform.childCount; i++) {
			GameObject.Destroy (contentPanel.GetChild (i).gameObject);
		}
	}
}
