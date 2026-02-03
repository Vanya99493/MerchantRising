using UnityEngine;

namespace StudyProject.CardLogic
{
	public class Card : CardBase
	{
		[SerializeField]
		private CardAnimationController _cardAnimationController;

		[SerializeField]
		private Renderer _runeRenderer;

		private bool _isSwapped;

		public override void Initialize(CardData cardData)
		{
			base.Initialize(cardData);
			
			_cardAnimationController.Initialize(transform.localPosition);
			SetRuneTexture(cardData.RuneTexture);
			
			_isSwapped = false;
		}

		public override void SwapCard(bool isForward = true)
		{
			if (_isSwapped)
			{
				if (isForward)
				{
					return;
				}
				
				_isSwapped = false;
			}
			else
			{
				base.Select();
				_isSwapped = true;
			}
			
			_cardAnimationController.PlayAnimation(isForward);
		}

		public override void Deactivate()
		{
			gameObject.SetActive(false);
		}

		private void SetRuneTexture(Texture runeTexture)
		{
			MaterialPropertyBlock mpb = new();
			_runeRenderer.GetPropertyBlock(mpb);
			mpb.SetTexture("_BaseMap", runeTexture);
			_runeRenderer.SetPropertyBlock(mpb);
		}
	}
}