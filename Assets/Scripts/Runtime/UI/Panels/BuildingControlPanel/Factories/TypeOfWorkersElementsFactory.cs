using System.Collections.Generic;
using UnityEngine;

namespace StudyProject.UI.BuildingControlPanelScripts
{
	public class TypeOfWorkersElementsFactory : MonoBehaviour
	{
		[SerializeField]
		private TypeOfWorkersElement _typeOfWorkersElementPrefab;

		[SerializeField]
		private Transform _parent;

		private List<TypeOfWorkersElement> _typeOfWorkersElements = new();

		public TypeOfWorkersElement InstantiateTypeOfWorkersElement()
		{
			var typeOfWorkersElement = Instantiate(_typeOfWorkersElementPrefab, _parent);
			typeOfWorkersElement.DestroyEvent += OnTypeOFWorkersElementDestroy;
			_typeOfWorkersElements.Add(typeOfWorkersElement);
			return typeOfWorkersElement;
		}

		public void DestroyAllTypeOfWorkersElements()
		{
			foreach (var typeOfWorkersElement in _typeOfWorkersElements)
			{
				typeOfWorkersElement.Destroy();
			}
			
			_typeOfWorkersElements.Clear();
		}

		private void OnTypeOFWorkersElementDestroy(TypeOfWorkersElement typeOfWorkersElement)
		{
			Destroy(typeOfWorkersElement.gameObject);
		}
	}
}