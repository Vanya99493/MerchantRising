using System;
using UnityEngine;

namespace StudyProject.BuildingLogic.Workers
{
	[Serializable]
	public class WorkerData
	{
		public string Name = "";
		public WorkerType WorkerType;
		public Sprite Icon;
		public int WorkerMaintence;
		public int WorkerProduction;
	}
}