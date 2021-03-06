using TutanDev.References;
using UnityEngine;

namespace TutanDev.Input
{
    [CreateAssetMenu(menuName = "TutanDev/ReadActions/Hold")]
    public class HoldReadAction : ReadAction
    {
        [SerializeField] BoolReference readValue;
        [SerializeField] KeyCode[] activationKeys;

        public override void Read()
        {
            bool read = false;
            foreach (KeyCode key in activationKeys)
            {
                if (UnityEngine.Input.GetKey(key)) read = true;
            }

            readValue.value = read;
        }
    }
}