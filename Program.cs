using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Data;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Repositories;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Repositories.Interfaces;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Repository;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models;

var host = Host.CreateDefaultBuilder(args).Build();

// j' ai utiliser la doc dans le site de simpleinjector pour faire cette partie

// Créer un conteneur SimpleInjector
var container = new Container();
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

// Charger config
var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

// Register EF DbContext
container.Register<SchoolContext>(() =>
{
    var options = new DbContextOptionsBuilder<SchoolContext>()
        .UseSqlServer(config.GetConnectionString("DefaultConnection"))
        .Options;

    return new SchoolContext(options);
}, Lifestyle.Scoped);

// Register les Repositories + UoW
container.Register(typeof(IReadOnlyRepository<>), typeof(Repository<>), Lifestyle.Scoped);
container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);
container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

// Vérification que tout ca marche
container.Verify();

// Scope d'exécution
using (AsyncScopedLifestyle.BeginScope(container))
{
    var unitOfWork = container.GetInstance<IUnitOfWork>();

    // Ajouter un nouvel étudiant
    var person = new Person
    {
        FirstName = "Khalil",
        LastName = "Assem"
    };
    unitOfWork.Persons.Add(person);
    await unitOfWork.CompleteAsync();  // pour la deuxieme operation qui suit... person.Id doit etre non null et enregistré dans la base de données

    var student = new Student
    {
        PersonId = person.Id,
        StudentNumber = "S2025"
    };
    unitOfWork.Students.Add(student);
    await unitOfWork.CompleteAsync();

    Console.WriteLine(" Étudiant ajouté avec succès !");

    // Afficher tous les étudiants
    var students = unitOfWork.Students.GetAll();
    foreach (var s in students)
        Console.WriteLine($" Étudiant : {s.StudentNumber}");
}
