using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static float defaultMasterVolume = 0.5f;
    public static float defaultDifficulty = 2f;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Tried to set volume out of range: " + volume.ToString());
        }
    }

    public static float GetMasterVolume()
    {
        if (PlayerPrefs.HasKey(MASTER_VOLUME_KEY))
            return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        return defaultMasterVolume;
    }


    public static void UnlockLevel(int level)
    {
        if (level >= 0 && level < Application.levelCount)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        }
        else
        {
            Debug.LogError("Tried to unlock level not in build order");
        }
    }

    public static void LockLevel(int level)
    {
        if (level >= 0 && level < SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 0);
        }
        else
        {
            Debug.LogError("Tried to lock level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        return PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1;
    }

    public static void SetDifficulty(float dificulty)
    {
        if (dificulty >= 1f && dificulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, dificulty);
        }
        else
        {
            Debug.LogError("Tried to set invalid value of dificulty: " + dificulty.ToString());
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}