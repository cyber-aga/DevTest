using DeveloperTest.Properties;
using System.ComponentModel.DataAnnotations;
namespace DeveloperTest.Models
{
    public class BaseCustomerModel
    {
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessageResourceType = typeof(CustomerResources), ErrorMessageResourceName = "NameTooShort")]
        public string Name { get; set; }

        public string Type { get; set; }
    }
}
