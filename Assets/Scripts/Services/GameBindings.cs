using Collections;
using Project.Managers;
using Project.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Services
{
    public sealed class GameBindings : ScriptableObject
    {
        [SerializeField] 
        private SamplePrefab samplePrefab;

        public SamplePrefab SamplePrefab => samplePrefab;

        [SerializeField] 
        private SampleScriptableObject sampleScriptableObject;

        public SampleScriptableObject SampleScriptableObject => sampleScriptableObject;
        
        
        [SerializeField] 
        private AudioManager _audioManager;
        
        public AudioManager AudioManager => _audioManager;
        
        // [SerializeField] 
        // private SamplePrefab samplePrefab;
        //
        // public SamplePrefab SamplePrefab => samplePrefab;
        //
        
        // [SerializeField] 
        // private SceneCollectionManager _sceneCollectionManager;
        //
        // public SceneCollectionManager SceneCollectionManager => _sceneCollectionManager;
        //
        // [SerializeField] 
        // private PlayerDataCollection _playerDataCollection;
        // public PlayerDataCollection PlayerDataCollection => _playerDataCollection;
        //
        // [SerializeField] 
        // private SpeedDataCollection _speedDataCollection;
        // public SpeedDataCollection SpeedDataCollection => _speedDataCollection;
        
        // [SerializeField] 
        // private ViewCollection _viewCollection;
        //
        // public ViewCollection ViewCollection => _viewCollection;
        
        // [SerializeField] 
        // private ScoreMultiplierCollection _scoreMultiplierCollection;
        //
        // public ScoreMultiplierCollection ScoreMultiplierCollection => _scoreMultiplierCollection;
        //
        // [SerializeField] 
        // private BlockDataCollection _blockDataCollection;
        // public BlockDataCollection BlockDataCollection => _blockDataCollection;
    }
}