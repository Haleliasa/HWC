#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace HWC.API {
    public readonly struct Result<T> {
        private readonly T? result;
        private readonly Error? error;

        public Result(T result) {
            this.result = result;
            this.error = null;
        }

        public Result(Error error) {
            this.result = default;
            this.error = error;
        }

        public bool IsOk(
            [NotNullWhen(true)] out T? result,
            [NotNullWhen(false)] out Error? error
        ) {
            result = this.result;
            error = this.error;

            return result != null;
        }
    }

    public readonly struct Result {
        private readonly Error? error;

        public Result(Error error) {
            this.error = error;
        }

        public bool IsOk([NotNullWhen(false)] out Error? error) {
            return (error = this.error) == null;
        }
    }
}
