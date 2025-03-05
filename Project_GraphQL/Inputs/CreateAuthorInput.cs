using System.Data;

namespace Project_GraphQL.Inputs
{
    public class CreateAuthorInput
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Cpf { get; set; }
    }
}
