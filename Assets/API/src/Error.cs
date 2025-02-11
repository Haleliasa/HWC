namespace HWC.API {
    public readonly struct Error {
        public readonly ErrorCode code;
        public readonly string message;

        public Error(ErrorCode code, string message) {
            this.code = code;
            this.message = message;
        }

        public override string ToString() {
            return $"{(byte)this.code} - {this.code}: {this.message}";
        }
    }
}
