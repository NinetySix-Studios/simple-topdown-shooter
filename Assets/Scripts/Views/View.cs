using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Views
{
    public abstract class View : MonoBehaviour, IView
    {
        public ViewContainer ViewContainer
        {
            get { return gameObject.GetComponentInParent<ViewContainer>(); }
        }

        public virtual void Initialize()
        {
            gameObject.SetActive(true);
        }

        public virtual void Release()
        {
            gameObject.SetActive(false);
        }
    }
}