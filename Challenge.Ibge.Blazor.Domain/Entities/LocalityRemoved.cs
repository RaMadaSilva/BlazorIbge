namespace Challenge.Ibge.Blazor.Domain.Entities
{
    public  class LocalityRemoved
    {
        public LocalityRemoved(int id, string city, string state, DateTime dateCreate)
        {
            Id = id;
            City = city;
            State = state;
            DateCreate = dateCreate;
            DateRemoved = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public DateTime DateCreate { get; private set; }
        public DateTime DateRemoved { get; private set; }
    }
}
