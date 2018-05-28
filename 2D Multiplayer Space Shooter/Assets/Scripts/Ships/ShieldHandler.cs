using UnityEngine;
using System.Collections;
using System;

public class ShieldHandler : MonoBehaviour
{
	[SerializeField]
	private GameObject _shieldPrefab;
	//private Ship _owner;
    
	//private void Start()
	//{
	//	_owner = gameObject.GetComponentInParent<Ship>();
	//}

	//private void Update()
	//{
	//	if (_owner.ShieldsStatus && !_shieldPrefab.activeSelf) ActivateShield();
	//	else DeactivateShield();
	//}
    
	public void ActivateShield()
	{
		_shieldPrefab.SetActive(true);
	}
   
	public void DeactivateShield()
    {
		_shieldPrefab.SetActive(false);
    }
}
