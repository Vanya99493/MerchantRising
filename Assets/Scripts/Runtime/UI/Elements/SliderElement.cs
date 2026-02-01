using StudyProject.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StudyProject.UI
{
	public class SliderElement : MonoBehaviour
	{
		[SerializeField]
		private Slider _slider;

		[SerializeField]
		private TMP_Text _sliderValueText;

		public float Value => _slider.value;

		public void Initialize()
		{
			SetSliderValue(_slider.minValue);
		}

		private void OnEnable()
		{
			_slider.onValueChanged.AddListener(SetSliderValue);
		}

		private void OnDisable()
		{
			_slider.onValueChanged.RemoveListener(SetSliderValue);
		}

		public void SetSliderValue(float newValue)
		{
			if (_slider.wholeNumbers)
			{
				int value = (int)newValue;
				_slider.value = value;
				UpdateSliderValueText(value.ToString());
			}
			else
			{
				_slider.value = newValue;
				UpdateSliderValueText(newValue.Round(1).ToString());
			}
		}

		private void UpdateSliderValueText(string newValue)
		{
			_sliderValueText.text = newValue;
		}
	}
}