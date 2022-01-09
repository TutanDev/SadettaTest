using TutanDev.References;
using UnityEngine;
using UnityEngine.UI;

namespace TutanDev.Input
{
    public class InputDebugger : MonoBehaviour
    {
        [SerializeField] Text display;
        [SerializeField] BoolReference[] values;

        private void Update()
        {
            if (display == null) return;

            string debug = "";
            foreach (BoolReference value in values)
            {
                debug += $"{value.name}: {value.value} \n";
            }

            display.text = debug;
        }

    }
}

