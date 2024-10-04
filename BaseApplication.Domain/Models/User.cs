using System.ComponentModel.DataAnnotations.Schema;
using BaseApplication.Core.DomainObjects;

namespace BaseApplication.Domain.Models;

[Table("usuario")]
public class User : Entity, IAggregateRoot
{
    [Column("nome")] public string Name { get; private set; }
    [Column("sexo")] public string Gender { get; private set; }
    [Column("idade")] public int Age { get; private set; }
    [Column("cpf")] public string Cpf { get; private set; }
    [Column("telefone")] public string PhoneNumber { get; private set; }
    
    protected User()
    {
    }

    public User(string name, string gender, int age, string cpf, string phoneNumber)
    {
        Name = name;
        Gender = gender;
        Age = age;
        Cpf = cpf;
        PhoneNumber = phoneNumber;
    }
}