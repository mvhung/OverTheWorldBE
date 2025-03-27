namespace LearningVocab.Utils
{
    public class SequentialGuidGenerator
    {
        public static Guid NewGuid()
        {
            byte[] guidBytes = Guid.NewGuid().ToByteArray();
            byte[] sequentialBytes = BitConverter.GetBytes(DateTime.UtcNow.Ticks);

            Array.Copy(sequentialBytes, 0, guidBytes, 0, 6);
            return new Guid(guidBytes);
        }
    }
}
