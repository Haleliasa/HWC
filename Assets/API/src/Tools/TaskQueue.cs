#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HWC.API {
    public class TaskQueue<TData> {
        private readonly Queue<(Func<TData, Task>, TData)> tasks;
        private TaskCompletionSource<bool>? runningTaskSource;
        private readonly object lockObj = new();

        private readonly Action<Exception>? onException;

        public TaskQueue(
            int capacity = 10,
            Action<Exception>? onException = null
        ) {
            this.tasks = new Queue<(Func<TData, Task>, TData)>(capacity);
            this.onException = onException;
        }

        public Task? Running => this.runningTaskSource?.Task;

        public async void Enqueue(Func<TData, Task> task, TData data) {
            lock (this.lockObj) {
                if (this.runningTaskSource != null) {
                    this.tasks.Enqueue((task, data));

                    return;
                }

                this.runningTaskSource = new TaskCompletionSource<bool>();
            }

            bool hasTask;

            do {
                try {
                    await task(data);
                } catch (Exception e) {
                    this.onException?.Invoke(e);
                }

                lock (this.lockObj) {
                    hasTask = this.tasks.TryDequeue(out (Func<TData, Task>, TData) tuple);
                    (task, data) = tuple;

                    if (!hasTask) {
                        this.runningTaskSource?.SetResult(true);
                        this.runningTaskSource = null;
                    }
                }
            } while (hasTask);
        }
    }
}
