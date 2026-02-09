using System.Collections.Generic;
using System.Linq;
using StudyProject.Utils;
using UnityEngine;

namespace StudyProject.BuildingLogic
{
	public class ArtisanBuildingsFactory : MonoBehaviour
	{
		[SerializeField]
		private List<Pair<BuildingType, ArtisanInteractableBuilding>> _artisanBuildings;

		public ArtisanInteractableBuilding CreateArtisanBuilding(BuildingType buildingType)
		{
			return _artisanBuildings.FirstOrDefault(x => x.FirstValue == buildingType)?.SecondValue;
		}
	}
}