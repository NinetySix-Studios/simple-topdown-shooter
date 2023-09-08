using Project.Services;
using UnityEngine;

namespace Collections
{
    [CreateAssetMenu(fileName = "SampleCollection", menuName = "MENUNAME", order = 0)]
    public class SampleScriptableObject : ScriptableObject
    {
        public static SampleScriptableObject Services
        {
            get
            {
                if (_ == null) _ = Game.Services.Get<SampleScriptableObject>();
                return _;
            }
        }


        private static SampleScriptableObject _;
        
        
        public int intVariable = 0;
    }
}