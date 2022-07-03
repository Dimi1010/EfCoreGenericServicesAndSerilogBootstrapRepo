using EfCoreGenericServicesAndSerilogBootstrapRepo.Model;
using GenericServices;
using System.ComponentModel;

namespace EfCoreGenericServicesAndSerilogBootstrapRepo.Dto
{
    public class PersonDto : ILinkToEntity<Person>
    {
        [ReadOnly(true)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
