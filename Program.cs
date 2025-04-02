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
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Services.Interfaces;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Services;
using Microsoft.Extensions.Logging;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole(); // tu peux aussi ajouter .AddDebug() si tu veux
    })
    .Build();

// j' ai utiliser la doc dans le site de simpleinjector pour faire cette partie

// Créer un conteneur SimpleInjector
var container = new Container();
container.RegisterConditional(typeof(ILogger<>),
    context => typeof(Logger<>).MakeGenericType(context.ServiceType.GetGenericArguments()[0]),
    Lifestyle.Singleton,
    context => true);
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

// Register les Services
container.Register<IVueService, VueService>(Lifestyle.Scoped);
container.Register<IProcService, ProcService>(Lifestyle.Scoped);


// Vérification que tout ca marche
container.Verify();

// Scope d'exécution
using (AsyncScopedLifestyle.BeginScope(container))
{
    var unitOfWork = container.GetInstance<IUnitOfWork>();
    //var logger = container.GetInstance<ILogger<Program>>();

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

    var vueService = container.GetInstance<IVueService>();
    var data = await vueService.GetTeachersWithSubjectsAsync();
    Console.WriteLine($"VueService.GetTeachersWithSubjectsAsync : {data.Count()}");

    var procService = container.GetInstance<IProcService>();
    var studentCamFromProc = await procService.GetStudentByNumberAsync("S2025");
    Console.WriteLine($"ProcService.GetStudentByNumberAsync : {studentCamFromProc?.LastName}");
}
