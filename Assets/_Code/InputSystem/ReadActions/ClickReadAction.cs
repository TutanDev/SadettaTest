using TutanDev.References;
using UnityEngine;

namespace TutanDev.Input
{
    [CreateAssetMenu(menuName = "TutanDev/ReadActions/Click")]
    public class ClickReadAction : ReadAction
    {
        [SerializeField] BoolReference readValue;
        [SerializeField] KeyCode[] activationKeys;

        public override void Read()
        {
            bool read = false;
            foreach (KeyCode key in activationKeys)
            {
                if (UnityEngine.Input.GetKeyDown(key)) read = true;
            }

            readValue.value = read;
        }
    }
}
