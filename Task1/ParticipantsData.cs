namespace ConsoleApplication1
{
    // Data about participants in the list.
    public class ParticipantsData<T>
    {
        public ParticipantsData(T gender)
        {
            Gender = gender;
        }

        public T Gender;
        public ParticipantsData<T> Next;
    }
}