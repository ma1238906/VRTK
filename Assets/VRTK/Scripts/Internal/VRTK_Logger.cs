namespace VRTK
{
    using UnityEngine;
    using System.Collections.Generic;

    public class VRTK_Logger : MonoBehaviour
    {
        public enum LogLevels
        {
            trace,
            debug,
            info,
            warn,
            error,
            fatal,
            none
        }

        public static VRTK_Logger instance = null;

        public static Dictionary<string, string> commonMessages = new Dictionary<string, string>()
        {
            {"NOT_DEFINED", "`{0}` not defined{2}."},
            {"REQUIRED_COMPONENT_MISSING_FROM_SCENE", "`{0}` requires the `{1}` component to be available in the scene{2}."},
            {"REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT", "`{0}` requires the `{1}` component to be attached to {2} GameObject{3}."},
            {"REQUIRED_COMPONENT_MISSING_FROM_PARAMETER", "`{0}` requires a `{1}` component to be specified as the `{2}` parameter{3}."},
            {"REQUIRED_COMPONENT_MISSING_NOT_INJECTED", "`{0}` requires the `{1}` component. Either the `{2}` parameter is not set or no `{1}` component is attached to {3} GameObject{4}."},
            {"COULD_NOT_FIND_OBJECT_FOR_ACTION", "The `{0}` could not automatically find {1} to {2}."},
            {"SDK_OBJECT_NOT_FOUND", "No {0} could be found. Have you selected a valid {1} in the SDK Manager? If you are unsure, then click the GameObject with the `VRTK_SDKManager` script attached to it in Edit Mode and select a {1} from the dropdown." },
            {"SDK_NOT_FOUND", "The SDK '{0}' doesn't exist anymore. The fallback SDK '{1}' will be used instead." },
            {"SDK_MANAGER_ERRORS", "The current SDK Manager setup is causing the following errors:\n\n{0}" }
        };

        public LogLevels minLevel = LogLevels.info;
        public bool throwExceptions = true;

        public static void CreateIfNotExists()
        {
            if (instance == null)
            {
                GameObject loggerObject = new GameObject("[VRTK_Logger]");
                instance = loggerObject.AddComponent<VRTK_Logger>();
                instance.minLevel = LogLevels.trace;
                instance.throwExceptions = true;
            }
        }

        public static string GetCommonMessage(string messageKey, string[] parameters = null)
        {
            parameters = (parameters == null ? new string[0] : parameters);
            return (commonMessages.ContainsKey(messageKey) ? string.Format(commonMessages[messageKey], parameters) : "");
        }

        public static void Trace(string message)
        {
            Log(LogLevels.trace, message);
        }

        public static void Debug(string message)
        {
            Log(LogLevels.debug, message);
        }

        public static void Info(string message)
        {
            Log(LogLevels.info, message);
        }

        public static void Warn(string message)
        {
            Log(LogLevels.warn, message);
        }

        public static void Error(string message)
        {
            Log(LogLevels.error, message);
        }

        public static void Fatal(string message)
        {
            Log(LogLevels.fatal, message);
        }

        public static void Log(LogLevels level, string message)
        {
#if VRTK_NO_LOGGING
            return;
#endif
            CreateIfNotExists();

            if (instance.minLevel > level)
            {
                return;
            }

            switch (level)
            {
                case LogLevels.trace:
                case LogLevels.debug:
                case LogLevels.info:
                    UnityEngine.Debug.Log(message);
                    break;
                case LogLevels.warn:
                    UnityEngine.Debug.LogWarning(message);
                    break;
                case LogLevels.error:
                case LogLevels.fatal:
                    if (instance.throwExceptions)
                    {
                        throw new System.Exception(message);
                    }
                    else
                    {
                        UnityEngine.Debug.LogError(message);
                    }
                    break;
            }
        }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}