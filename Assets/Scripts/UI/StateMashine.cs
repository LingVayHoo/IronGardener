using UnityEngine;

public class StateMashine : MonoBehaviour
{
    [HideInInspector]
    public enum StateType
    {
        game,
    }

    [Header("Windows")]
    [SerializeField] private Window _gameScreen;


    private Window _currentScreen;

    private void Start()
    {
        _currentScreen = _gameScreen;
    }

    public void ChangeStates(StateType state)
    {
        if (_currentScreen == null)
        {
            return;
        }
        _currentScreen.Close_Instantly();

        switch (state)
            {
           
            case StateType.game:
                _gameScreen.Open_Instantly();
                _currentScreen = _gameScreen;
                break;

        }

    }
}
