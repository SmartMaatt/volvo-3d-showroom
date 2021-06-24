using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(ColorManager))]
public class Managers : MonoBehaviour
{
    public static ColorManager Color { get; private set; }
    public static InputManager Input { get; private set; }
    public static SaveManager Save { get; private set; }
    public static bool allLoaded { get; private set; }

    private List<IGameManager> _startSequence;

    private void Awake()
    {
        allLoaded = false;
        Color = GetComponent<ColorManager>();
        Input = GetComponent<InputManager>();
        Save = GetComponent<SaveManager>();

        _startSequence = new List<IGameManager>();
        _startSequence.Add(Color);
        _startSequence.Add(Input);
        _startSequence.Add(Save);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in _startSequence)
        {
            manager.Startup();
        }

        yield return null;

        int numModels = _startSequence.Count;
        int numReady = 0;

        while(numReady < numModels)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach(IGameManager manager in _startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                    numReady++;
            }

            if (numReady > lastReady)
                Debug.Log("Progress: " + numReady + " / " + numModels);

            yield return null;
        }
        Debug.Log("All managers has been started succesfully!");
        allLoaded = true;
    }
}
