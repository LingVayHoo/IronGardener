using UnityEngine;
using CustomEventBus;
using System.Collections.Generic;

public class ServicesLocator_Main : MonoBehaviour
{
    [Header("Servises")]
    [SerializeField] private EventBus _eventBus;
   // [SerializeField] private UIManager _uiManager;

    private void Awake()
    {
        Initialization();
    }

    private List<IDisposable> _disposables = new List<IDisposable>();
    public void Initialization()
    { 
        _eventBus = new EventBus();

        RegisterServices();
        Init();
    }

    private void Init()
    {
       // _uiManager.Initialization();

    }

    private void RegisterServices()
    {
        ServiceLocator.Initialization();
        ServiceLocator.Current.Register(_eventBus);
      //  ServiceLocator.Current.Register(_gameManager);
    }

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
