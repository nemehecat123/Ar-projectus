using UnityEngine;
using Vuforia;

public class ImageTargetDetection : MonoBehaviour
{
    private ObserverBehaviour mObserverBehaviour;
    private FightManager fightManager;

    void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        fightManager = FindObjectOfType<FightManager>();

        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
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
        string targetName = mObserverBehaviour.TargetName;
        fightManager.CardDetected(targetName);
    }

    private void OnTrackingLost()
    {
        string targetName = mObserverBehaviour.TargetName;
        fightManager.CardLost(targetName);
    }

    void OnDestroy()
    {
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}
