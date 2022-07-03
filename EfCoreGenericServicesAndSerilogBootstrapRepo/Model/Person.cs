using System.ComponentModel.DataAnnotations;

namespace EfCoreGenericServicesAndSerilogBootstrapRepo.Model
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
