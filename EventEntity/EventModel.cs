namespace EventEntity       // Class library having class (Event Model) inside it.
{
    public class EventModel         // Creating Table structure having colums (properties of a class)       // SQL table name sud be same as entity class name
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

    }
}
