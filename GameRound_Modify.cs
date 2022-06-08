using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodySource
{
    public partial class Round
    {

        #region PROPERTIES

        /// <summary>
        /// Define custom properties
        /// </summary>
        public string _exampleProperty = "";

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Define custom methods
        /// </summary>
        public void _ExampleMethod() {}
        
        #endregion

    }

    /*
     * Be sure to define any methods that you want to be able to access from the inspector within the partial GameRound class as well.
     */
    public partial class GameRound
    {
        /// <summary>
        /// Define custom methods
        /// </summary>
        public void _ExampleMethod() => Debug.Log("This is an example method.");
    }
}