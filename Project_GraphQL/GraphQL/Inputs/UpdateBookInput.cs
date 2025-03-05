namespace Project_GraphQL.GraphQL.Inputs
{
    public class UpdateBookInput
    {
        public string? Title { get; set; }
        public int? Pages { get; set; }
        public int? AuthorId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CategoryId { get; set; }
    }
}
