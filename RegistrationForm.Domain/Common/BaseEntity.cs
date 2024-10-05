using System.ComponentModel.DataAnnotations;

namespace RegistrationForm.Domain.Common;
public class BaseEntity<TKey> where TKey : IComparable
{
    [Key]
    public virtual TKey Id { get; set; } = default!;
}
