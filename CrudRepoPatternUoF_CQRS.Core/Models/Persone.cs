using System.ComponentModel.DataAnnotations;

namespace CrudRepoPatternUoF_CQRS.Core.Models;

public class Persone
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public string Email { get; set; }



}