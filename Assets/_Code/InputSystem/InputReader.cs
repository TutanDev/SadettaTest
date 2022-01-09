using UnityEngine;

namespace TutanDev.Input
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] ReadAction[] actions;

        private void Update()
        {
            foreach (ReadAction action in actions)
            {
                action.Read();
            }
        }
    }
}

