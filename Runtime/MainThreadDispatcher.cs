using System;
using System.Collections.Concurrent;
using UnityEngine;

namespace SBaier
{
    public class MainThreadDispatcher : MonoBehaviour
    {
        private readonly ConcurrentQueue<Entry> actions = new ConcurrentQueue<Entry>();

        private void Update()
        {
            while (actions.TryDequeue(out Entry entry))
            {
                entry.Action?.Invoke();
                entry.Callback?.Invoke();
            }
        }

        public void ExecuteOnMainThread(Action action, Action callback = null)
        {
            actions.Enqueue(new Entry(){Action = action, Callback = callback});
        }
        
        private struct Entry
        {
            public Action Action;
            public Action Callback;
        }
    }
}
