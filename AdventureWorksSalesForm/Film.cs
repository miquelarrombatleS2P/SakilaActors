namespace AdventureWorksSalesForm
{
    public class Film
    {
        public int film_id { get; set; }
        public string title { get; set; }
        public int length { get; set; }

        public override string ToString()
        {
            return $"{title},{length+"'"}";
        }
    }
}