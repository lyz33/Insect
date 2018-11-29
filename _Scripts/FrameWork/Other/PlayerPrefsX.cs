using UnityEngine;
using System;

public static class PlayerPrefsX
{

    #region Int Array

    /// <summary>
    /// Stores a Int Array or Multiple Parameters into a Key
    /// </summary>
    public static bool SetIntArray(string key, params int[] intArray)
    {
        if (intArray.Length == 0) return false;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < intArray.Length - 1; i++)
            sb.Append(intArray[i]).Append("|");
        sb.Append(intArray[intArray.Length - 1]);

        try { PlayerPrefs.SetString(key, sb.ToString()); }
        catch (Exception e) { return false; }
        return true;
    }

    /// <summary>
    /// Returns a Int Array from a Key
    /// </summary>
    public static int[] GetIntArray(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string[] stringArray = PlayerPrefs.GetString(key).Split("|"[0]);
            int[] intArray = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
                intArray[i] = Convert.ToInt32(stringArray[i]);
            return intArray;
        }
        return new int[0];
    }

    /// <summary>
    /// Returns a Int Array from a Key
    /// Note: Uses default values to initialize if no key was found
    /// </summary>
    public static int[] GetIntArray(string key, int defaultValue, int defaultSize)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return GetIntArray(key);
        }
        else
        {
            int[] intArray = new int[defaultSize];
            for (int i = 0; i < defaultSize; i++)
                intArray[i] = defaultValue;
            return intArray;
        }
    }

    #endregion
    #region Bool Array

    ///
    /// Stores a Bool Array or Multiple Parameters into a Key
    ///
    public static bool SetBoolArray(string key, params bool[] boolArray)
    {
        if (boolArray.Length == 0) return false;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < boolArray.Length - 1; i++)
            sb.Append(boolArray[i]).Append("|");
        sb.Append(boolArray[boolArray.Length - 1]);

        try { PlayerPrefs.SetString(key, sb.ToString()); }
        catch (Exception e) { return false; }
        return true;
    }

    ///
    /// Returns a Bool Array from a Key
    ///
    public static bool[] GetBoolArray(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string[] stringArray = PlayerPrefs.GetString(key).Split("|"[0]);
            bool[] boolArray = new bool[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
                boolArray[i] = Convert.ToBoolean(stringArray[i]);
            return boolArray;
        }
        return new bool[0];
    }

    ///
    /// Returns a Bool Array from a Key
    /// Note: Uses default values to initialize if no key was found
    ///
    public static bool[] GetBoolArray(string key, bool defaultValue, int defaultSize)
    {
        if (PlayerPrefs.HasKey(key))
            return GetBoolArray(key);
        bool[] boolArray = new bool[defaultSize];
        for (int i = 0; i < defaultSize; i++)
            boolArray[i] = defaultValue;
        return boolArray;
    }

    #endregion


}