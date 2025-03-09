using System;
using System.Threading.Tasks;
using UnityEngine;

namespace HWC {
    public static class Utils {
        private static readonly ILogger logger = Debug.unityLogger;
        private const string logTag = nameof(Utils);

        public static async void FireAndForget(this Task task) {
            try {
                await task;
            } catch (Exception e) {
                logger.LogException(e);
            }
        }

        public static void Quit() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}
