using System;
using UnityEngine;

namespace StudyProject.RaceLogic
{
	public abstract class RacerBase : MonoBehaviour, IDestroyable<RacerBase>
	{
		public event Action<RacerBase> FinishEvent;
		public event Action<RacerBase> DestroyEvent;
		
		public RacerData RacerData { get; private set; }

		public virtual void Initialize(RacerData racerData)
		{
			RacerData = racerData;
		}

		public abstract void SetSpeed(float newSpeed);
		public abstract void StartOrProceedRun();

		public virtual void FinishRun()
		{
			FinishEvent?.Invoke(this);
		}

		public virtual void Destroy()
		{
			DestroyEvent?.Invoke(this);
		}
	}
}