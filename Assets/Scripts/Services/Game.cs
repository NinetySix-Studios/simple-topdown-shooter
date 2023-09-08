using Collections;
using Project.Managers;
using Project.Views;
using UnityEngine;

namespace Project.Services
{
    public static class Game
    {
        public static readonly ServiceLocator Services = new ServiceLocator();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            GameBindings bindings = Resources.Load<GameBindings>("GameBindings");
            
            Services.Clear();
            InitializeUnityServices(bindings);
            InitializeViewServices(bindings);
            
            // NOTE: In adding a component to the GameBindings, just add once
            
            // if not in the GameBindings then use this to find the component in the scene
            // Services.Add<SampleBind>(new UnityComponentServiceProvider<SampleBind>());
            
         
            // add the objects from GameBindings to the Services
            Services.Add(bindings.SampleScriptableObject);
        }
        
        /// <summary>
        /// Instantiate the "Services" GameObject in DontDestroyOnLoad
        /// </summary>
        private static void InitializeUnityServices(GameBindings bindings)
        {
            GameObject servicesObject = new GameObject("Services");
            Object.DontDestroyOnLoad(servicesObject);

            // InitializeSceneCollectionManager(servicesObject, bindings);
            InitializeAudioManager(servicesObject, bindings);
        }
        
        private static void InitializeAudioManager(GameObject servicesObject, GameBindings bindings)
        {
            AudioManager audioManager = Object.Instantiate(bindings.AudioManager, servicesObject.transform);
            Services.Add<AudioManager>(audioManager);
        }

        /// <summary>
        /// This method initialize/add the view collection and container to the services
        /// </summary>
        private static void InitializeViewServices(GameBindings bindings)
        {
            // Services.Add<ViewCollection>(bindings.ViewCollection);
            // Services.Add<ViewContainer>(new UnityComponentServiceProvider<ViewContainer>());
        }
    }
}