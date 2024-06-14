using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ClarkCodingChallenge.Models
{
    public class Contact
    {
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string emailAddress { get; set; }
    }
}
