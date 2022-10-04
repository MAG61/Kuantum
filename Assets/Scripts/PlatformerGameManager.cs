using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformerGameManager : MonoBehaviour
{
    private static PlatformerGameManager manager = null;

    public GameObject[] puzzles;
    public int[] puzzleStates;
    public GameObject[] interact;

    public GameObject currentPuzzle;
    public int currentPuzzleIndex;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);
        }
        else if (this != manager)
        {
            Destroy(gameObject);
        }
        if (currentPuzzle != null) { 
        }
    }

    public void openPuzzle(int index)
    {
        currentPuzzle = puzzles[index];
        currentPuzzleIndex = index;
        SceneManager.LoadScene(index + 1, LoadSceneMode.Additive);
    }

    public void openPuzzle(GameObject puzzle)
    {
        currentPuzzle = puzzle;
        currentPuzzleIndex = getIndex(puzzle);
        SceneManager.LoadScene(getIndex(puzzle) + 1, LoadSceneMode.Additive);
    }

    public void returnPlatformer(GameObject puzzle, int state)
    {
        currentPuzzle = null;
        puzzleStates[getIndex(puzzle)] = state;
        SceneManager.LoadScene(0);
    }
    public void returnPlatformer()
    {
        currentPuzzle = null;
        SceneManager.UnloadSceneAsync(currentPuzzleIndex + 1);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
    }

    public int getIndex(GameObject puzzle)
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            if (puzzles[i] == puzzle)
            {
                return i;
            }
        }
        return 0;
    }
    public int getState(GameObject puzzle)
    {
        return puzzleStates[getIndex(puzzle)];
    }

    public void setState(GameObject puzzle, int state)
    {
        puzzleStates[getIndex(puzzle)] = state;
    }

    public void setState(int index, int state)
    {
        puzzleStates[index] = state;
    }
}
