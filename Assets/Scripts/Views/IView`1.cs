using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Views
{
    public interface IView<T> : IView
    {
        void Initialize(T data);
    }
}
