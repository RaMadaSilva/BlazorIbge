namespace Challenge.Ibge.Blazor.Domain.Entities
{
    public class Locality
    {
        public Locality(string city, string state)
        {
            City = city;
            State = state.ToUpper();
            DateCreate = DateTime.Now;
        }

        public int Id { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public DateTime DateCreate { get;  private set; }

        public void  UpdateLocality(string city, string state)
        {
            City = city;
            State = state.ToUpper(); 
        }
    }
}
