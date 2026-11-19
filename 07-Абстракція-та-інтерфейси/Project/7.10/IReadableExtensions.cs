namespace Project;

public static class IReadableExtensions {
    extension(IReadable src) { 
        public void CopyTo(IWritable dst) {
            dst.Write(src.Read());
        }
    }
}