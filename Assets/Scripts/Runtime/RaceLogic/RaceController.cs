using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StudyProject.Extensions;
using StudyProject.ScriptableObjects.RaceData;
using StudyProject.ScriptableObjects.RacersData;
using StudyProject.UI.RacingPanelScripts;
using UnityEngine;

namespace StudyProject.RaceLogic
{
	public class RaceController : MonoBehaviour
	{
		[SerializeField]
		private RacersFactory _racersFactory;

		[SerializeField]
		private RaceCameraController _raceCameraController;

		[SerializeField]
		private Transform[] _startPositions;

		[Header("Data Assets")]
		[SerializeField]
		private RacersCollectionDataAsset _racersCollectionDataAsset;

		[SerializeField]
		private RaceDataAsset _raceDataAsset;

		private List<RacerData> _racersCollection = new();
		private List<RacerBase> _activeRacers = new();
		private List<RacerBase> _finishedRacers = new();

		private Coroutine _raceUpdatingCoroutine;
		private bool _isRaceRunning;

		public void Initialize(IRacingPanel racingPanel)
		{
			foreach (var racerDataAsset in _racersCollectionDataAsset.Racers)
			{
				_racersCollection.Add(racerDataAsset.RacerData);
			}

			_isRaceRunning = false;

			racingPanel.PrepareRaceEvent += PrepareRacers;
			racingPanel.StartRaceEvent += StartRace;
			racingPanel.StopRaceEvent += StopRace;
		}
		
		public void PrepareRacers(int racersCount)
		{
			ClearActiveRacers();
			
			// TODO: add checking on max positions count
			
			for (int i = 0; i < racersCount; i++)
			{
				CreateNewRacer(i);
			}
			
			_raceCameraController.SetRacers(_activeRacers.Select(x => x.transform).ToList());
		}

		public void StartRace()
		{
			_isRaceRunning = true;
			
			this.KillCoroutine(ref _raceUpdatingCoroutine);
			_raceUpdatingCoroutine = StartCoroutine(RaceUpdatingCoroutine());
		}

		public void StopRace()
		{
			_finishedRacers.Clear();
			_raceCameraController.ClearRacers();
			ClearActiveRacers();
		}

		private IEnumerator RaceUpdatingCoroutine()
		{
			while (_isRaceRunning)
			{
				foreach (var activeRacer in _activeRacers)
				{
					activeRacer.StartOrProceedRun();
				}

				yield return new WaitForSeconds(_raceDataAsset.UpdateSpeedDelay);
			}

			FinishRace();
		}

		private void CreateNewRacer(int racerPosition)
		{
			int randomIndex = Random.Range(0, _racersCollection.Count);
			RacerData racerData = _racersCollection.Pick(randomIndex);
			RacerBase racer = _racersFactory.InstantiateNewRacer(_startPositions[racerPosition].position, _startPositions[racerPosition].rotation, racerData);
			racer.SetSpeed(0f);
			racer.FinishEvent += OnRacerFinished;
			racer.DestroyEvent += OnRacerDestroy;
			_activeRacers.Add(racer);
		}

		private void OnRacerFinished(RacerBase racer)
		{
			_finishedRacers.Add(racer);
			if (_finishedRacers.Count >= _activeRacers.Count)
			{
				_isRaceRunning = false;
			}
		}

		private void FinishRace()
		{
			string raceResult = "";
			int currentPosition = 1;
			foreach (var finishedRacer in _finishedRacers)
			{
				raceResult += $"{currentPosition}. <color={finishedRacer.RacerData.ColorType.ToString().ToLower()}>{finishedRacer.RacerData.Name}</color>\n";
				currentPosition++;
			}
			Debug.Log(raceResult);
		}

		private void OnRacerDestroy(RacerBase racer)
		{
			_racersCollection.Add(racer.RacerData);
			var operationResult = _activeRacers.Remove(racer);
			
			if (!operationResult)
			{
				Debug.LogWarning("Cannot find active racer!");
			}
		}

		private void ClearActiveRacers()
		{
			while (_activeRacers.Count > 0)
			{
				_activeRacers[0].Destroy();
			}
			_activeRacers.Clear();
		}
	}
}