using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace CodySource
{
    public partial class GameRound : MonoBehaviour
    {

        #region PROPERTIES

        /// <summary>
        /// Singleton
        /// </summary>
        public static GameRound instance { get; private set; } = null;

        [Header("CALLBACKS")]
        /// <summary>
        /// Triggered whenever the current round begins
        /// </summary>
        public UnityEvent<Round> onRoundBegin = new UnityEvent<Round>();

        /// <summary>
        /// Triggered whenever the current round ends
        /// </summary>
        public UnityEvent<Round> onRoundEnd = new UnityEvent<Round>();

        /// <summary>
        /// Triggered whenever the final round is completed
        /// </summary>
        public UnityEvent onFinalRoundEnd = new UnityEvent();

        [Space()]
        [Header("OPTIONAL LABEL")]
        [SerializeField] private string _prefaceText = "";
        [SerializeField] private TMP_Text text = null;

        [Space()]
        /// <summary>
        /// The list of all available rounds
        /// </summary>
        public List<Round> rounds = new List<Round>();

        /// <summary>
        /// Current round
        /// </summary>
        public Round currentRound => rounds[_currentIndex];

        /// <summary>
        /// The current round index
        /// </summary>
        public int currentRoundIndex => _currentIndex;

        /// <summary>
        /// The current round index
        /// </summary>
        private int _currentIndex = 0;

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Begins the current round
        /// </summary>
        public void BeginRound()
        {
            _UpdateLabel();
            onRoundBegin?.Invoke(currentRound);
        }

        /// <summary>
        /// Begins the round of the supplied index
        /// </summary>
        public void BeginRound(int pIndex)
        {
            _currentIndex = Mathf.Clamp(pIndex, 0, rounds.Count);
            BeginRound();
        }

        /// <summary>
        /// Begins the first round
        /// </summary>
        public void BeginFirstRound() => BeginRound(0);

        /// <summary>
        /// Begins the next round
        /// </summary>
        public void BeginNextRound() => BeginRound(_currentIndex + 1);

        /// <summary>
        /// Begins the previous round
        /// </summary>
        public void BeginPreviousRound() => BeginRound(_currentIndex - 1);

        /// <summary>
        /// Ends the current round
        /// </summary>
        public void EndRound()
        {
            if (_currentIndex == rounds.Count - 1) onFinalRoundEnd?.Invoke();
            else onRoundEnd?.Invoke(currentRound);
        }

        #endregion

        #region PRIVATE METHODS

        /// <summary>
        /// Configure singleton
        /// </summary>
        private void Awake() => instance = instance ?? this;

        /// <summary>
        /// Updates the optional round label
        /// </summary>
        private void _UpdateLabel()
        {
            if (text == null) return;
            text.text = $"{_prefaceText}{_currentIndex + 1}";
        }

        #endregion

    }

    #region PUBLIC CLASSES

    /// <summary>
    /// Create another partial round class to define necessary variables for each round
    /// </summary>
    [System.Serializable]
    public partial class Round { }

    #endregion

}