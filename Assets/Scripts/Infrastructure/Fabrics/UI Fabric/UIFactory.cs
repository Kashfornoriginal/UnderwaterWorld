using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class UIFactory : IUIFactory
{
    public GameObject LoadingGameScreen { get; private set; }
    public GameObject StartGameScreen { get; private set; }
    public GameObject GameplayScreen { get; private set; }

    private readonly DiContainer _container;

    public UIFactory(DiContainer container)
    {
        _container = container;
    }

    public async void CreateLoadingScreen()
    {
        var asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(GameConstants.LOADING_GAME_SCREEN);
        await asyncOperationHandle.Task;

        GameObject prefab = asyncOperationHandle.Result;

        LoadingGameScreen = _container.InstantiatePrefab(prefab);
    }

    public void DestroyLoadingScreen()
    {
        Object.Destroy(LoadingGameScreen);
    }

    public async Task<GameObject> CreateGameStartScreen()
    {
        var asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(GameConstants.START_GAME_SCREEN);
        
        await asyncOperationHandle.Task;
        
        GameObject prefab = asyncOperationHandle.Result;

        StartGameScreen = _container.InstantiatePrefab(prefab);

        return prefab;
    }
    

    public void DestroyGameStartScreen()
    {
        Object.Destroy(StartGameScreen);
    }

    public async Task<GameObject> CreateGameplayScreen()
    {
        var asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(GameConstants.GAMEPLAY_GAME_SCREEN);
        
        await asyncOperationHandle.Task;
        
        GameObject prefab = asyncOperationHandle.Result;

        GameplayScreen = _container.InstantiatePrefab(prefab);

        return prefab;
    }

    public void DestroyGameplayScreen()
    {
        Object.Destroy(GameplayScreen);
    }
}