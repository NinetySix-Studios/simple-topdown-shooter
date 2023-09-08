using System.Collections.Generic;
using System.IO;
using Pathfinding.Serialization.JsonFx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gungrounds.LevelDesign
{
    public class LevelEditor : MonoBehaviour
    {
        [SerializeField]
        private GameObject _cubePrefab;


        private GameObject _currentCube;
        private GameObject _previewCube;
        private bool _isPlacingCube = false;

        private readonly EditorHistory _history = new();

        private void Start()
        {
            _previewCube = Instantiate(_cubePrefab);
            _previewCube.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 0.5f); // Semi-transparent
            _previewCube.SetActive(false); // initially set to inactive
        }

        // Update is called once per frame
        void Update()
        {
            // check if the mouse is over a UI element
            if (EventSystem.current.IsPointerOverGameObject())
            {
                _previewCube.SetActive(false); // hide the preview cube
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 newPosition = new Vector3();
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                newPosition = hit.point;
                newPosition.y = 0.5f; // snap to the floor at y = 0.5

                // update the position of the preview cube
                if (_isPlacingCube)
                {
                    _previewCube.transform.position = newPosition;
                    _previewCube.SetActive(true); // show the preview cube
                }
            }
            else
            {
                _previewCube.SetActive(false); // hide the preview cube if ray doesn't hit
            }

            if (Input.GetMouseButtonDown(0) && _isPlacingCube)
            {
                CreateObjectAction createAction = new CreateObjectAction(_cubePrefab, newPosition);
                _history.Do(createAction);
            }
        }

        public void OnCubeButtonClick()
        {
            _isPlacingCube = !_isPlacingCube; // flip the boolean value

            // hide the preview cube if we're not placing cubes
            if (!_isPlacingCube)
            {
                _previewCube.SetActive(false);
            }
        }

        public void OnUndoButtonClicked()
        {
            _history.Undo();
        }

        public void OnRedoButtonClicked()
        {
            _history.Redo();
        }
        
        public void OnSaveButtonClicked()
        {
            List<Vector3> cubePositions = new();
            foreach (CreateObjectAction action in _history.GetAllActions())
            {
                cubePositions.Add(action.Position);
            }


            string json = JsonWriter.Serialize(cubePositions);
            File.WriteAllText(Application.dataPath + "/cubePositions.txt", json);
            Debug.Log($"#{GetType().Name}#Saved!");
        }
        
        public void OnLoadButtonClicked()
        {
            string path = Application.dataPath + "/cubePositions.txt";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                List<Vector3> cubePositions = JsonReader.Deserialize<List<Vector3>>(json);

                // Clear existing cubes
                _history.Clear();
              
                // Instantiate cubes at saved positions
                foreach (Vector3 position in cubePositions)
                {
                    CreateObjectAction createAction = new CreateObjectAction(_cubePrefab, position);
                    _history.Do(createAction);
                }
            }
            Debug.Log($"#{GetType().Name}#Loaded!");
        }


    }
}