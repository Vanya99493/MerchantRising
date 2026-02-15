using System.Collections.Generic;
using System.Linq;
using StudyProject.Utils;
using UnityEngine;

namespace StudyProject.BuildingLogic
{
	public class ArtisanBuildingsFactory : MonoBehaviour
	{
		[SerializeField]
		private List<Pair<ExtractiveBuildingType, ArtisanInteractableBuilding>> _artisanBuildings;

		public ArtisanInteractableBuilding CreateArtisanBuilding(ExtractiveBuildingType extractiveBuildingType)
		{
			return _artisanBuildings.FirstOrDefault(x => x.FirstValue == extractiveBuildingType)?.SecondValue;
		}
	}
}