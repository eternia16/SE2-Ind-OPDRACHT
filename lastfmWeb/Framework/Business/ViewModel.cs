using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lastfmWeb.Framework.Business
{
    /// <summary>
    /// ViewModel class is a more object oriented variation of a dictionary. 
    /// This class is mainly used to pass data between the business- and presentation layer and vice versa.
    /// </summary>
    public class ViewModel
    {
        /// <summary>
        /// Name of the ViewModel.
        /// </summary>
        string _nameViewModel = "ViewModel";

        /// <summary>
        /// Get and set of the name of the ViewModel.
        /// </summary>
        public string Name
        {
            set
            {
                this._nameViewModel = value;
            }
            get
            {
                return this._nameViewModel;
            }
        }


        /// <summary>
        /// Dictionary of the ViewModel.
        /// </summary>
        Dictionary<string, Object> _viewModelDictionary
            = new Dictionary<string, Object>();


        /// <summary>
        /// Sets an object into the dictionary.
        /// </summary>
        /// <param name="key">Key of the object</param>
        /// <param name="obj">The actual object. Basically is the value.</param>
        public void SetAttribute(string key, Object obj)
        {
            if (HasAttribute(key))
                _viewModelDictionary[key] = obj;
            else
                _viewModelDictionary.Add(key, obj);
        }


        /// <summary>
        /// Trying to get an object out of the dictionary using the key.
        /// </summary>
        /// <param name="key">Key as search criteria</param>
        /// <returns>The object stored in the dictionary by the key.</returns>
        public Object GetAttribute(string key)
        {
            if (this._viewModelDictionary.ContainsKey(key))
                return this._viewModelDictionary[key];

            return null;
        }


        /// <summary>
        /// Returns a bool whether the key exists or not.
        /// </summary>
        /// <param name="key">Key as search criteria</param>
        /// <returns>True or False. Whether the key exists or not plus value.</returns>
        public bool HasAttribute(string key)
        {
            return this._viewModelDictionary.ContainsKey(key);
        }
    }
}