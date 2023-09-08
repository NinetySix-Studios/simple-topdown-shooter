using System.Collections.Generic;
using Gungrounds.Interfaces;

namespace Gungrounds.LevelDesign
{
    public class EditorHistory
    {
        private readonly Stack<IEditorAction> _undoStack = new();
        private readonly Stack<IEditorAction> _redoStack = new();

        public void Do(IEditorAction action)
        {
            action.Do();
            _undoStack.Push(action);
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                IEditorAction action = _undoStack.Pop();
                action.Undo();
                _redoStack.Push(action);
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                IEditorAction action = _redoStack.Pop();
                action.Do();
                _undoStack.Push(action);
            }
        }
        
        public void Clear()
        {
            _undoStack.Clear();
            _redoStack.Clear();
        }

        public IEnumerable<IEditorAction> GetAllActions()
        {
            return _undoStack;
        }
    }

}