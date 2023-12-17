namespace Challenge.Ibge.Blazor.Domain.Entities
{
    public  class LocalityRemoved
    {
        public LocalityRemoved(long id, string city, string state, DateTime dateCreate)
        {
            Id = id;
            City = city;
            State = state;
            DateCreate = dateCreate;
            DateRemoved = DateTime.UtcNow;
        }

        public long Id { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public DateTime DateCreate { get; private set; }
        public DateTime DateRemoved { get; private set; }
    }
}
