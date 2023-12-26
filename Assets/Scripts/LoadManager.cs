using UnityEngine;

public class LoadManager : MonoBehaviour
{
    private bool isFirstUpdate = true;

    void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            Loader.LoaderCallback();
        }
    }
}
