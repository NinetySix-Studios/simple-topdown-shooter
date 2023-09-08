using Gungrounds.Interfaces;
using UnityEngine;

namespace Gungrounds.LevelDesign
{
    public class CreateObjectAction : IEditorAction
    {
        public Vector3 Position { get; }

        private readonly GameObject _prefab;
        private GameObject _instance;

        public CreateObjectAction(GameObject prefab, Vector3 position)
        {
            _prefab = prefab;
            Position = position;
        }


        public void Do()
        {
            _instance = GameObject.Instantiate(_prefab, Position, Quaternion.identity);
        }

        public void Undo()
        {
            GameObject.Destroy(_instance);
        }
    }
}