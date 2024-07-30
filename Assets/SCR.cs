using UnityEngine;
using Vuforia;


// ta skripta ob izpiše karto v console log ob prepoznavi.
public class ImageTargetDetection : MonoBehaviour
{
    private ObserverBehaviour mObserverBehaviour;

    void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        // èe je prepoznana karta ali ni prepoznana
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED) 
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    private void OnTrackingFound()
    {
        // print the target name in the console
        string targetName = mObserverBehaviour.TargetName;
        Debug.Log("The card recognized is : " + targetName);
    }

    private void OnTrackingLost()
    {
        Debug.Log("Image target lost.");
    }

    void OnDestroy()
    {
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}