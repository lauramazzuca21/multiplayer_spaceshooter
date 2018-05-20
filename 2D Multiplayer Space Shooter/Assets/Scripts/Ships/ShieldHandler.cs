using UnityEngine;
using System.Collections;

public class ShieldHandler : MonoBehaviour
{
	[SerializeField]
    private GameObject _shieldPrefab;
	private GameObject _instantiatedShield;

	protected void GenerateShield()
	{
		_instantiatedShield = Instantiate(_shieldPrefab);
	}

	protected void EliminateShield()
    {
		Destroy(_instantiatedShield);
    }
}
