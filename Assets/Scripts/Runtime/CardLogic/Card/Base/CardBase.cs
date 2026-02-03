using System;
using StudyProject.Interfaces;
using UnityEngine;

namespace StudyProject.CardLogic
{
	public abstract class CardBase : MonoBehaviour, IDestroyable<CardBase>
	{
		public event Action<CardBase> SelectEvent;
		public event Action<CardBase> DestroyEvent;
		
		public CardData CardData { get; private set; }
		
		public virtual void Initialize(CardData cardData)
		{
			CardData = cardData;
		}

		public abstract void SwapCard(bool isForward = true);
		public abstract void Deactivate();

		public virtual void Select()
		{
			SelectEvent?.Invoke(this);
		}

		public virtual void Destroy()
		{
			DestroyEvent?.Invoke(this);
		}
	}
}