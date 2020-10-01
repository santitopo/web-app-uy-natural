namespace Domain
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is State))
            {
                return false;
            }
            return Name == ((State)obj).Name;
        }
    }
}